using ComClassLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisMemoryManager {
    class SaveToSqlite {
        private static string m_sIpAddr;                                //数据库IP
        private static string _sMainDBDir;                            //db路径+名称
        private static string _sDBBackPath;                            //备份DB路径+名称
        private int getFaultInd;

        public bool isLogSubDb { get; private set; }

        private int getImgInd;
        private SqliteHelper mainDB = null;
        private SqliteHelper currDB = null;
        private int curDBIndex;

        //定义一个回调函数，返回消息
        public Action<string> CallInfo { get; set; }

        //是否存在备份数据库
        private bool IsBackDB { get { return !string.IsNullOrEmpty(_sDBBackPath); } }
        /// <summary>
        /// 是否存在分库
        /// </summary>
        private bool HasSubDB { get { return false; } }

        /// <summary>
        /// 创建主索引表
        /// </summary>
        private void CreateIndexDB() {
            try {
                mainDB = SqliteHelper.GenerateSqlite("IndexDb", _sMainDBDir + "_m.db");
                if (mainDB.IsTableExist("indexTB")) {
                    return;
                }
                //string strTB = "create table indexTB (id int primary key ,begImgGUID INT64," +
                //    "endImgGUID INT64, begPoleNum varchar(50),endPoleNum varchar(50),begKMV varchar(50),endKMV varchar(50)," +
                //    "imgCount  int, locFaultInfo int)";
                string strImgInofTb = "CREATE TABLE picInfo(imgGUID INT64 PRIMARY KEY ,cId INTEGER,shootTime INT64,poleNum TEXT,KMValue TEXT,STN TEXT," +
                    "SubDBId int);";
                mainDB.ExecuteNonQuery(strImgInofTb);
                //创建定位缺陷表 
                const string sCreateLocFaultTB = "CREATE TABLE locFaultInfo(imgGUID INT64 PRIMARY KEY ,ExistFault INTEGER,sJson TEXT);";
                mainDB.ExecuteNonQuery(sCreateLocFaultTB);
                // 创建 线路信息表 stationInfo
                const string strCreateStationTB = "CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY AUTOINCREMENT,sLineName varchar(50),sStartStation varchar(50),sEndStation varchar(50),iType tinyint,taskDate DATE );";
                mainDB.ExecuteNonQuery(strCreateStationTB);
                //创建 缺陷表
                const string strCreateFaultTB = "create table FaultInfo( pId INT64 primary key,imgGUID INT64,unitId int,fault varchar(255),mark varchar(100),faultLevel varchar(5),"
                    + "isAI int DEFAULT 1, analyzeDate datetime NOT NULL DEFAULT(datetime('now', 'localtime')), " +
                    "confirmDate datetime, confirmUser varchar(50), confirmResult int DEFAULT -1, memo varchar(100) )";


            } catch (Exception ex) {
                ComClassLib.MsgBox.Error("索引库创建失败！\n详细信息\n" + ex.ToString());
            }
        }
        /// <summary>
        /// 创建分表 -- 只包含图像数据
        /// </summary>
        //private void CreateCurrentDB() {
        //    try {
        //        //var oldDB = SqliteHelper.GetSqlite("currDB");
        //        //if (oldDB != null) {

        //        //}

        //        currDB = SqliteHelper.GenerateSqlite("currDB", _sMainDBDir + $"_{++curDBIndex}.db");
        //        if (currDB.IsTableExist("indexTB")) {
        //            return;
        //        }
        //        //创建 图像表
        //        string strCreateImgTb = "CREATE TABLE picInfo(imgGUID INT64 PRIMARY KEY ,imgContent BLOB,sJson TEXT );";
        //        currDB.ExecuteNonQuery(strCreateImgTb);

        //        //创建定位缺陷表 
        //        string sCreateLocFaultTB = "CREATE TABLE locFaultInfo(imgGUID INT64 PRIMARY KEY ,ExistFault INTEGER,sJson TEXT);";
        //        currDB.ExecuteNonQuery(sCreateLocFaultTB);

        //        //创建 缺陷表
        //        string strCreateFaultTB = "create table FaultInfo( pId INT64 primary key,imgGUID INT64,unitId int,fault varchar(255),mark varchar(100),faultLevel varchar(5),";
        //        strCreateFaultTB += "isAI int DEFAULT 1, analyzeDate datetime NOT NULL DEFAULT(datetime('now', 'localtime')),";
        //        strCreateFaultTB += " confirmDate datetime, confirmUser varchar(50), confirmResult int DEFAULT -1, memo varchar(100) )";

        //        currDB.ExecuteNonQuery(strCreateFaultTB);

        //        //Settings.Default.currDBIndex = curDBIndex;
        //       // Settings.Default.Save();
        //        isLogSubDb = false;
        //        getImgInd = getFaultInd = 0;
        //    } catch (Exception e) {
        //        currDB.CloseDb();
        //        MessageBox.Show("分表创建失败\n" + e.ToString());
        //    }
        //}
        /// <summary>
        /// 写入图像信息 1.主索引表中记录图像信息，
        /// </summary>
        /// <param name="keys"></param>
        //public void WriteImgAndInfo(string[] keys) {
        //    currDB.OpenDb();
        //    currDB.BeginTransaction();
        //    try {
        //        PicInfo picInfo = null;
        //        int i = 0;
        //        //====== 遍历所有的 imgKey ======
        //        foreach (var imgKey in keys) {
        //            //获取所有的图像信息
        //            string sJson = imgInfoDB.StringGet(imgKey);
        //            //获取所有的图像
        //            byte[] img = imgDB.GetByte(imgKey);
        //            picInfo = JsonHelper1.GetModel<PicInfo>(sJson);
        //            //SQLiteParameter sqlparm = new SQLiteParameter();
        //            if (!isLogSubDb) {

        //                mainDB.ExecuteNonQuery($"insert into indexTB values({curDBIndex},{imgKey},0,'{picInfo.POL}',null,'{picInfo.KMV}',null,0,0)");
        //                isLogSubDb = true;
        //            }
        //            //写入数据库
        //            string strSQL = $"INSERT INTO picInfo(imgGUID,cId,shootTime,poleNum,KMValue,STN,imgContent,sJson) " +
        //                $"VALUES({imgKey},{picInfo.CID},{picInfo.TIM},'{picInfo.POL}','{picInfo.KMV}','{picInfo.STNUTF}',@img,@sJson)";
        //            SQLiteParameter[] parameters = { new SQLiteParameter("@img", DbType.Binary), new SQLiteParameter("@sJson", DbType.String) };
        //            parameters[0].Value = img;
        //            parameters[1].Value = sJson;
        //            try {
        //                currDB.ExecuteNonQueryByTran(strSQL, parameters);
        //            } catch {
        //            }
        //            Console.WriteLine(++i);
        //        }
        //        currDB.Commit();
        //        if (picInfo != null) {
        //            //修改索引表
        //            string str = $"update indexTB set endImgGUID={keys[keys.Length - 1]},endPoleNum='{picInfo.POL}',endKMV='{picInfo.KMV}',imgCount={saveImgNum} where id={curDBIndex}";
        //            mainDB.ExecuteNonQuery(str);
        //        }
        //    } catch (Exception e) {
        //        Console.WriteLine("图像&信息写入失败！\n" + e.ToString());
        //        currDB.Rollback();
        //    } finally {
        //        currDB.CloseDb();
        //    }
        //}

        //public void WriteFaultDb() {
        //    string[] keys = locDB.ListRange("list", getFaultInd, getFaultInd + ISaveImgNumByOnce);
        //    if (keys == null || keys.Length == 0) {
        //        Console.WriteLine($"#=== 已持久化定位信息共：{getFaultInd}条(缺陷信息：{IFaultNum}条)! \t 等待新数据写入......\n\n");
        //        return;
        //    }
        //    Console.WriteLine($"#=== 读取定位缺陷信息{keys.Length}");
        //    List<LocFaultInfo> lsFault = new List<LocFaultInfo>();
        //    //修改起步ID编号
        //    getFaultInd += keys.Length;
        //    saveFaultNum += keys.Length;

        //    SqliteHelper.GetSqlite("mainDB").OpenDb();
        //    currDB.OpenDb();
        //    currDB.BeginTransaction();
        //    try {
        //        foreach (var locKey in keys) {

        //            string sJson = locDB.StringGet(locKey);
        //            List<LocFaultInfo> lsUnit = LocFaultInfo.getLstUnitPos(sJson);
        //            //遍历事务写入缺陷信息
        //            foreach (var locInfo in lsUnit) {
        //                if (locInfo.IsFault) {
        //                    locInfo.setImgGUID(Int64.Parse(locKey));
        //                    lsFault.Add(locInfo);
        //                }
        //            }
        //            string strSQL = $"INSERT INTO locFaultInfo(imgGUID,sJson,ExistFault) VALUES({locKey},{sJson},{lsFault.Count > 0})";
        //            currDB.ExecuteNonQueryByTran(strSQL, null);
        //        }
        //        currDB.Commit();
        //        mainDB.ExecuteNonQuery($"update picInfo set locFaultInfo={saveFaultNum} where id={curDBIndex}");

        //    } catch (Exception e) {
        //        Console.WriteLine("#---定位信息写入失败！\n" + e.ToString());
        //        currDB.Rollback();
        //    } finally {
        //        currDB.CloseDb();
        //    }
        //    //写入 缺陷信息
        //    if (lsFault.Count > 0) {
        //        currDB.OpenDb();
        //        currDB.BeginTransaction();
        //        try {
        //            foreach (var fault in lsFault) {
        //                string strSQL = $"INSERT INTO FaultInfo(pId,imgGUID,unitId,fault,mark) " +
        //                    $"VALUES({fault.ID},{fault.UnitId},{fault.getImgGUID()},{fault.Fault},{fault.Mark})";
        //                currDB.ExecuteNonQueryByTran(strSQL, null);
        //            }
        //        } catch (Exception e) {
        //            Console.WriteLine("#---缺陷信息写入失败！\n" + e.ToString());
        //            currDB.Rollback();
        //            throw;
        //        } finally {
        //            currDB.CloseDb();
        //        }
        //    }

        //}
    }
}
