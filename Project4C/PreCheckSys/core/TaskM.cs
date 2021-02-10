using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComClassLib;
using ComClassLib.core;
using ComClassLib.DB;
using ComClassLib.FileOp;
using PreCheckSys.Properties;
using PreCheckSys.UI;

namespace PreCheckSys.core {
    enum taskState : short {
        none,       //没有
        plan,       //计划
        running,   //正在运行
        finish      //完成
    }
    enum taskMsg : short {
        Msg,    //一般性的消息
        Mem,    //内存信息
        Del,    //删除图像数据
        Img,    //图像存储数据
        Loc,    //定位存储数据
        Flt,     //缺陷存储数据
        BackMsg,
        EndMsg
    }
    /// <summary>
    /// 任务管理
    /// </summary>
    class MonitorTask : StationInfo {

        private static List<MonitorTask> lsTasks;
        #region 静态参数定义
        private static readonly int m_sInfoDbIdx;                       //图像信息数据库Id:
        private static readonly int m_sImgDbId;                         //图像二进制存储数据库Id
        private static readonly int m_sAIFaultDbId;                     //智能识别缺陷数据库Id
        private static readonly int m_sGeoDbId;                         //几何参数数据库
        private static readonly int m_iMemLimit;                        //MemLimit:内存限制 （单位M)
        private static readonly int m_iSaveImgNumByOnce;                //一次事务处理的的图像数量
        private static readonly int m_iDelDataByOnce;                   //一次删除的图像数据
        private static readonly int m_iSaveGeoDataNumByOnce;            //一次事务处理的几何参数数据大小
        private static readonly int m_iSubDbSize;                       //分库大小 -1---只有一个分库 默认值；3000
        #endregion
        //定义一个回调函数，返回消息
        public static Action<string> CallInfo { get; set; }

        //静态构造函数
        static MonitorTask() {
            lsTasks = new List<MonitorTask>();
            m_sGeoDbId = 9;
            m_sImgDbId = 10;                                                //图像二进制存储数据库Id
            m_sInfoDbIdx = 11;                                              //图像信息数据库Id
            m_sAIFaultDbId = 12;                                            //智能识别缺陷数据库Id.
            m_iMemLimit = Settings.Default.DBMemLimit;                      //MemLimit:内存限制 （单位M)
            m_iSaveImgNumByOnce = Settings.Default.ISaveImgNumByOnce;       //一次事务处理的的图像数量 默认99张-实际为100张
            m_iDelDataByOnce = Settings.Default.IDelDataByOnce;             //一次删除的图像数据 默认200条记录
            m_iSaveGeoDataNumByOnce = Settings.Default.ISaveImgNumByOnce;   //一次事务处理的几何参数数据大小
                                                                            // m_iImgNumTwoPole = Settings.Default.IImgNumTwoPole;
            m_iSubDbSize = Settings.Default.SubDbSize;                      //分库存储的最大数据量 默认3000
        }
        /// <summary>
        /// 得到下一个任务
        /// </summary>
        /// <returns></returns>
        public static MonitorTask GetTask() {
            MonitorTask task = null;
            for (int i = 0; i < lsTasks.Count; ++i) {
                if (lsTasks[i].State != taskState.finish) {
                    task = lsTasks[i];
                    break;
                }
            }
            return task;
        }
        /// <summary>
        /// 获取下一个计划任务
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public static MonitorTask GetNextPlanTask(MonitorTask mt) {
            MonitorTask task = null;
            for (int i = 0; i < lsTasks.Count; ++i) {
                MonitorTask t = lsTasks[i];
                if (t.State != taskState.finish && t != mt) {
                    task = t;
                    break;
                }
            }
            return task;
        }
        /// <summary>
        /// 获取所有任务列表
        /// </summary>
        public static List<MonitorTask> GetAllTask() {
            return lsTasks;
        }
        /// <summary>
        /// 添加新任务
        /// </summary>
        /// <param name="stationInfo"></param>
        /// <param name="taskDir"></param>
        /// <param name="taskBackDir"></param>
        public static void AddTask(StationInfo stationInfo, string taskDir, string taskBackDir = "") {

            lsTasks.Add(new MonitorTask(stationInfo, taskDir, taskBackDir));
        }
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="task"></param>
        public static void RemoveTask(MonitorTask task) {
            if (task.State == taskState.running) {
                MsgBox.Show("该任务正在进行中无法删除!");
                return;
            }
            lsTasks.Remove(task);
        }
        public static void RemoveTask(string taskName) {
            for (int i = 0; i < lsTasks.Count; ++i) {
                if (lsTasks[i].TaskName.Equals(taskName)) {
                    if (lsTasks[i].State == taskState.running) {
                        MsgBox.Show("该任务正在进行中无法删除!");
                        return;
                    }
                    lsTasks.RemoveAt(i);
                    break;
                }
            }
        }

        //-----------------------------------------------
        // private StationInfo _stationInfo;
        #region 属性定义
        private CancellationTokenSource _tokenSource;
        private CancellationToken _token;
        private ManualResetEvent _resetEvent;

        private string _taskDir, _taskBackDir; //任务存储目录 -- 一个任务一个单独的目录
        public string CurDbFileFullName {
            get { return Path.Combine(_taskDir, $"{TaskName}.s{IcurrDbInd}"); }
        }
        public string CurDbBackFileFullName {
            get { return Path.Combine(_taskBackDir, $"{TaskName}.s{IcurrDbInd}"); }
        }
        public taskState State { get; set; }
        public bool HasBackDir { get { return !string.IsNullOrEmpty(_taskBackDir); } }


        //完整的任务文件名称（路径+文件名）
        public string TaskIndFileFullName { get; set; }
        //完整的备份任务文件名称（路径+文件名）
        public string TaskIndBackFileFullName { get; set; }
        //当前的分库完整路径+文件名
        public SqliteHelper CurrSubDb { get; set; }
        public SqliteHelper IndexDb { get; set; }

        private int IcurrDbInd {
            get { return Settings.Default.currDBIndex; }
            set {
                Settings.Default.currDBIndex = value;
                Settings.Default.Save();
            }
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationInfo"> 线路信息 </param>
        /// <param name="taskDir">任务目录</param>
        /// <param name="taskBackDir">任务备份目录，默认为空</param>
        private MonitorTask(StationInfo stationInfo, string taskDir, string taskBackDir = "") : base(stationInfo) {

           
            _taskDir = Path.Combine(taskDir, TaskName);
            //创建目录
            ComClassLib.FileOp.FileHelper.CreateDir(_taskDir);
            if (!string.IsNullOrEmpty(taskBackDir)) {
                _taskBackDir = Path.Combine(taskBackDir, TaskName);
                //创建目录
                ComClassLib.FileOp.FileHelper.CreateDir(_taskBackDir);
            }
           

            TaskIndFileFullName = Path.Combine(_taskDir, TaskName + ".ind");
           // _taskBackDir = taskBackDir;
            TaskIndBackFileFullName = string.IsNullOrEmpty(taskBackDir) ? "" : Path.Combine(_taskBackDir, TaskName + ".ind");
            State = taskState.plan;
            TaskIni();
        }
        /// <summary>
        /// 任务初始化
        /// </summary>
        private void TaskIni() {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _resetEvent = new ManualResetEvent(true);
        }

        /// <summary>
        /// 创建分库
        /// 流程 ：
        /// 1.判断当前是否存在分库==关闭分库
        ///     判断是否存在备份== 备份分库
        /// 2.创建新分库        
        /// </summary>
        public SqliteHelper CreateSubDB() {

            //若存在当前分库，则结束当前分库
            if (CurrSubDb != null) {
                //string sBackCurrFullName = Path.Combine(_taskBackDir, Path.GetFileName(CurrSubDb.DbFullName));
                CallInfo?.Invoke($"{taskMsg.Msg}:结束当前图像库!");
                CurrSubDb.CloseDb();
                if (HasBackDir) {

                    CurrSubDb.Dispose();
                    //存在备份，将其拷贝到备份盘  注意：分表数据库文件名。[ 线路信息_行别.s1 ]
                    CallInfo?.Invoke($"{taskMsg.Msg}:后台备份当前图像库......");
                    string s1 = CurDbFileFullName, s2 = CurDbBackFileFullName;
                    var copyTask = new Task(() => FileHelper.FileCopy(s1, s2, true));
                    copyTask.Start();
                }
                ++IcurrDbInd;
            }


            // string newCurSubDbFullName = Path.Combine(_taskDir, $"{TaskName}.s{IcurrDbInd}");
            CurrSubDb = DBM.CreateCurrentDB(CurDbFileFullName);

            CallInfo?.Invoke($"{ taskMsg.Msg}:图像库-{IcurrDbInd}-开启成功！");
            return CurrSubDb;
        }

        //任务开启
        //创建索引数据库，写入用户信息，线路信息
        public void TaskStart() {
            //创建索引库
            IndexDb = DBM.CreateIndDB(TaskIndFileFullName);

            //写入站点信息
            DBM.WriteStationInfo(this);
            //创建图像分库
            CreateSubDB();

            //设置任务状态
            State = taskState.running;
            _ExecToSqlite = true;
            imgDB = new RedisHelper(m_sImgDbId);                     //图像数据库ID
            imgInfoDB = new RedisHelper(m_sInfoDbIdx);               //图像信息数据库ID
            locDB = new RedisHelper(m_sAIFaultDbId);                 //定位数据库ID  
            if (Settings.Default.isDelAllDB) {
                RedisHelper.ClearAllDB();//清除所有数据
            }
            Task toSqlite = new Task(ToSqliteAsync, _token);
            toSqlite.Start();
        }

        //任务结束
        //拷贝索引 关闭索引数据库，拷贝索引数据库到备份磁盘，关闭最后一个分库，拷贝到备份磁盘
        public bool TaskEnd() {
            if (State == taskState.finish)
                return false;
            _tokenSource.Cancel();


            ////关闭索引库，分库
            //IndexDb.CloseDb();
            //CurrSubDb.CloseDb();
            ////存在备份-- 开启拷贝任务 1.拷贝索引库；2.拷贝分库
            //if (!string.IsNullOrEmpty(TaskIndBackFileFullName)) {
            //    CallInfo?.Invoke($"{taskMsg.BackMsg}:#正在备份相关数据......");
            //}
            //State = taskState.finish;
            return true;
        }
        /// <summary>
        /// 任务结束后的备份处理
        /// </summary>
        public void TaskBackProc() {

            GC.Collect();
            GC.WaitForPendingFinalizers();

            //CallInfo?.Invoke($"{taskMsg.BackMsg}:#正在备份索引库......");
            DialogTaskTip.GetInstance().SetTipTxt("#正在备份索引库......");
            //1.拷贝索引库
            FileHelper.FileCopy(TaskIndFileFullName, TaskIndBackFileFullName, true);

            //CallInfo?.Invoke($"{taskMsg.BackMsg}:#正在备份图像库......");
            DialogTaskTip.GetInstance().SetTipTxt("#正在备份图像库......");
            //2.拷贝分库
            // string sCurrFullName = Path.Combine(_taskDir, $"{TaskName}.s{IcurrDbInd}");
            // string sBackCurrFullName = Path.Combine(_taskBackDir, $"{TaskName}.s{IcurrDbInd}");
            FileHelper.FileCopy(CurDbFileFullName, CurDbBackFileFullName, true);
            //CallInfo?.Invoke($"{taskMsg.EndMsg}:数据备份成功!");
            DialogTaskTip.GetInstance().SetTipTxt("#数据备份成功......");
            Thread.Sleep(2000);
            DialogTaskTip.GetInstance().EndProc();
        }

        #region  ToSqlite
        bool _ExecToSqlite;
        private RedisHelper imgDB;
        private RedisHelper imgInfoDB;
        private RedisHelper locDB;
        private long _iImgInd, _iLocInd, _iFaultInd, _iDelImgIdx;//当前图像id，当前定位id,当前缺陷id，当前删除图像id

        //开始数据持久化任务
        public async void ToSqliteAsync() {
            _iImgInd = _iLocInd = _iFaultInd = _iDelImgIdx = 0;
            try {
                while (_ExecToSqlite) {
                    if (_tokenSource.IsCancellationRequested) {

                        //关闭索引库，分库
                        IndexDb.CloseDb();
                        IndexDb.Dispose();
                        IndexDb = null;
                        CurrSubDb.CloseDb();
                        CurrSubDb.Dispose();
                        CurrSubDb = null;

                        //存在备份-- 开启拷贝任务 1.拷贝索引库；2.拷贝分库
                        if (!string.IsNullOrEmpty(TaskIndBackFileFullName)) {
                            CallInfo?.Invoke($"{taskMsg.BackMsg}:#正在备份相关数据......");
                        }
                        State = taskState.finish;
                        _ExecToSqlite = false;
                        //还原分库信息=======
                        Settings.Default.currDBIndex = 1;
                        Settings.Default.Save();
                        return;
                    }
                    // await Task.Delay(1000); //测试用 每1秒操作一次
                    //写入图片信息
                    if (!WriteImgAndInfo()) {
                        await Task.Delay(2000); //取不到数据休眠2秒继续取数据 并且判定是否没有提交的事务直接提交	
                    }

                    //写入定位与缺陷信息 -- 后面可以根据情况进行优化 例如每2次 持久化200条记录
                    WriteFaultDb();

                    #region  内存监控
                    double usedMEM = RedisHelper.GetUsedMem();// Console.WriteLine($"#================ 已经使用内存:{usedMEM}M ================#");
                    if (usedMEM > m_iMemLimit) {
                        RemoveMEM();
                    }                    //Console.WriteLine($"#================ 已经使用内存(删除数据后）:{RedisHelper.GetUsedMem()}M ================#");
                    #endregion
                    //消息回调 -- 图像已经存储数量
                    string sMem = usedMEM.ToString("N");
                    CallInfo?.Invoke($"{taskMsg.Mem}:{sMem}M");
                    //创建分库信息
                    if (m_iSubDbSize != -1 && _iImgInd > m_iSubDbSize * IcurrDbInd) {
                        CreateSubDB();
                    }
                }
            }
            catch (Exception e) {
                MsgBox.Show(e.ToString());

            }
        }
        /// <summary>
        /// 清除内存
        /// </summary>
        public void RemoveMEM() {
            Console.WriteLine($"#--- 超过内存限制({m_iMemLimit} M)，开始清除内存 .....");
            //====== 清除内存，注意没有持久化的数据不能删除 ======/
            long iEndDelIdx = _iDelImgIdx + m_iDelDataByOnce;
            if (iEndDelIdx > _iImgInd) {//删除的图像结束为止> 持久化的图像
                iEndDelIdx = _iImgInd;
            }
            if (iEndDelIdx > _iDelImgIdx) {
                try {
                    string[] keys = imgInfoDB.ListRange("list", _iDelImgIdx, iEndDelIdx);
                    if (keys == null || keys.Length == 0) {
                        Console.WriteLine($"#--- 无数据删除，等待数据持久化...");
                        return;
                    }
                    _iDelImgIdx = iEndDelIdx;
                    //算法修改，每次删除完数据后 将list[0]的值修改为未删除数据的list编号
                    // imgInfoDB.ListLeftPush("list", _iDelImgIdx);
                    imgInfoDB.ListSetValueInHead("list", _iDelImgIdx);
                    for (int i = 0; i < keys.Length; i++) {
                        imgDB.KeyDelete(keys[i]);
                        //Console.WriteLine($"#--- {imgKey} 删除成功！\t");
                    }
                  
                    //消息回调 -- 图像已经存储数量
                    CallInfo?.Invoke($"{taskMsg.Msg}:{_iDelImgIdx}");

                }
                catch (Exception e) {
                    Console.WriteLine($"#内存清除失败\t原因:{e.ToString()}");

                }
            }
        }

        public bool WriteImgAndInfo() {
            //开启存储过程 存储数据            
            try {
                PicInfo picInfo = null;
                string[] keys = imgInfoDB.ListRange("list", _iImgInd, _iImgInd + m_iSaveImgNumByOnce);
                // Console.WriteLine($"读取图像数据：[{keys.Length}]");
                if (keys == null || keys.Length == 0) {
                    Console.WriteLine($"#=== 已持久化图像数据信息共：{_iImgInd}条! \t 等待新数据写入......\n");
                    CallInfo?.Invoke($"{taskMsg.Msg}:#=== 等待新图像数据写入 _iImgInd:{_iImgInd}");
                    return false;
                }
                //下一次取图像全局ID的起始值
                _iImgInd += keys.Length;
                //====== 遍历所有的 imgKey ======
                IndexDb.BeginTransaction();
                CurrSubDb.BeginTransaction();               
                foreach (var imgKey in keys) {
                    //获取所有的图像信息
                    string sJson = imgInfoDB.StringGet(imgKey);
                    if (string.IsNullOrEmpty(sJson)) {
                        CallInfo?.Invoke($"{taskMsg.Msg}:#==={imgKey}: sJson is Null");
                        continue;
                    }
                    //获取所有的图像
                    byte[] img = imgDB.GetByte(imgKey);
                    picInfo = JsonHelper.GetModel<PicInfo>(sJson);
                    //写入索引数据库  "CREATE TABLE picInfoInd(imgGUID INT64 PRIMARY KEY ,cId INTEGER,shootTime INT64,poleNum TEXT,KMValue TEXT,STN TEXT,SubDBId int);";
                    IndexDb.InsertByTran($"insert into picInfoInd values({imgKey},{picInfo.CID},{picInfo.TIM},'{picInfo.POL}','{picInfo.KMV}','{picInfo.STNUTF}',{IcurrDbInd})");
                    //写入图像数据库 CREATE TABLE imgInfo(imgGUID INT64 PRIMARY KEY ,imgContent BLOB,sJson TEXT );
                    string strSQL = $"INSERT INTO imgInfo(imgGUID,imgContent,sJson) values({imgKey},@img,@sJson)";
                    SQLiteParameter[] parameters = { new SQLiteParameter("@img", DbType.Binary), new SQLiteParameter("@sJson", DbType.String) };
                    parameters[0].Value = img;
                    parameters[1].Value = sJson;
                    CurrSubDb.InsertByTran(strSQL, parameters);
                }
                CurrSubDb.Commit();
                IndexDb.Commit();
                //消息回调 -- 图像已经存储数量
                CallInfo?.Invoke($"{taskMsg.Img}:{_iImgInd}");
            }
            catch (Exception e) {
                Console.WriteLine("图像&信息写入失败！\n" + e.ToString());
                CurrSubDb.Rollback();
                IndexDb.Rollback();
                MsgBox.Show(e.ToString());
                return false;
            }
            return true;
        }

        public void WriteFaultDb() {
            //获取定位数据 下标
            string[] keys = locDB.ListRange("list", _iLocInd, _iLocInd + m_iSaveImgNumByOnce);
            if (keys == null || keys.Length == 0) {
                Console.WriteLine($"#=== 已持久化定位信息共：{_iLocInd}条(缺陷信息：{_iFaultInd}条)! \t 等待新数据写入......\n\n");
                //CallInfo?.Invoke($"{taskMsg.Msg}:等待新定位数据写入");
                return;
            }
            //Console.WriteLine($"#=== 读取定位缺陷信息{keys.Length}");
            List<LocFaultInfo> lsFault = new List<LocFaultInfo>();
            // //下一次取定位全局ID的起始值/修改定位起步ID编号
            _iLocInd += keys.Length;
            //saveFaultNum += keys.Length;
            try {
                IndexDb.BeginTransaction();
                foreach (var locKey in keys) {
                    string sJson = locDB.StringGet(locKey);
                    List<LocFaultInfo> lsUnit = LocFaultInfo.getLstUnitPos(sJson);
                    //遍历事务写入缺陷信息
                    foreach (var locInfo in lsUnit) {
                        if (locInfo.IsFault) {
                            locInfo.setImgGUID(Int64.Parse(locKey));
                            lsFault.Add(locInfo);
                        }
                    }
                    int iFault = lsFault.Count > 0 ? 1 : 0;
                    string strSQL = $"INSERT INTO locFaultInfo(imgGUID,ExistFault,sJson) VALUES({locKey},{iFault},'{sJson}')";
                    IndexDb.InsertByTran(strSQL);
                    //测试 -- 

                }
                IndexDb.Commit();
                //消息回调 -- 定位信息存储
                CallInfo?.Invoke($"{taskMsg.Loc}:{_iLocInd}");
            }
            catch (Exception e) {
                Console.WriteLine("#---定位信息写入失败！\n" + e.ToString());
                IndexDb.Rollback();
            }

            //写入 缺陷信息
            if (lsFault.Count > 0) {
                IndexDb.BeginTransaction();
                try {

                    foreach (var fault in lsFault) {
                        string strSQL = $"INSERT INTO FaultInfo(pId,imgGUID,unitId,fault,mark) " +
                            $"VALUES({fault.ID},{fault.UnitId},{fault.getImgGUID()},{fault.Fault},{fault.Mark})";
                        IndexDb.InsertByTran(strSQL, null);
                    }
                    _iFaultInd += lsFault.Count();
                    IndexDb.Commit();
                    //消息回调 -- 定位信息存储
                    CallInfo?.Invoke($"{taskMsg.Flt}:{_iFaultInd}");
                }
                catch (Exception e) {
                    Console.WriteLine("#---缺陷信息写入失败！\n" + e.ToString());
                    IndexDb.Rollback();

                }
            }

        }
        #endregion
    }
}
