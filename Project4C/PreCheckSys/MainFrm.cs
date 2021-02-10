using ComClassLib.DB;
using PreCheckSys.DB;
using PreCheckSys.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PreCheckSys {
    public partial class MainFrm : Form {

        bool isRunRedis2Sqlite = false;

       private string args  ="";

        //private string ServIp = "127.0.0.1";
        //private int iMemLimit = 2;
        public MainFrm() {

            InitializeComponent();
            Ini();
            //每隔1秒检查内存数据库是否在线,若不在线则启动数据库
            Thread thRedisDBServ = new Thread(CheckRedisServ);
            thRedisDBServ.Start();

            //每隔1秒，检查AI服务是否启动
            Thread thAIServ = new Thread(RunAIServ);
            thAIServ.Start();


        }

        public void Ini() {
            
            ipAddrInput.Value = Settings.Default.DbServIP;
            iMaxMem.Value = Settings.Default.MaxMem;
            linkLblDbPath.Text = Settings.Default.DBPath;
            linkLblDbBackPath.Text = Settings.Default.DBBackPath;
            cbBoxStartStation.Text = Settings.Default.sStartStation;
            cbBoxEndStation.Text = Settings.Default.sEndStation;
            notifyIcon1.Visible = true;
            lblTaskDate.Text = DateTime.Now.ToShortDateString();
            cbBoxUpDown.SelectedIndex = 0;
            timerDate.Start();
            
        }

        private void richTextBoxEx1_TextChanged(object sender, EventArgs e) {

        }
      

        private void RunTask() {
            if (string.IsNullOrEmpty(cbBoxStartStation.Text.Trim()) || string.IsNullOrEmpty(cbBoxEndStation.Text.Trim())) {
                MessageBox.Show(@"任务不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(cbBoxTarskLineName.Text.Trim())  ) {
                MessageBox.Show(@"线路名称不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(linkLblDbPath.Text.Trim())) {
                MessageBox.Show(@"持久化数据目录不能为空！");
                return;
            }
            //检查磁盘空间是否足够           
            if (!CheckDiskSpace(Path.GetPathRoot(linkLblDbPath.Text))) {
                return;
            }
            if (!string.IsNullOrEmpty(linkLblDbBackPath.Text) && !CheckDiskSpace(Path.GetPathRoot(linkLblDbBackPath.Text))) {
                return;
            }
            Settings.Default.sStartStation = cbBoxStartStation.Text.Trim();
            Settings.Default.sEndStation = cbBoxEndStation.Text.Trim();
            Settings.Default.Save();

            string sDate = DateTime.Now.ToString("yyMMdd-HHmm_");
            string sDbName = sDate + "_" + cbBoxStartStation.Text + "-" + cbBoxEndStation.Text;
            string sDbFullName = Path.Combine(linkLblDbPath.Text, sDbName + ".db");
            string sBackDBPath = Path.Combine(linkLblDbBackPath.Text, sDbName + "-bak.db");
            args = ipAddrInput.Value + " " + sDbFullName + " " + sBackDBPath + " " + iMaxMem.Value.ToString();
            SqliteHelper1.GenerateSqlite("MainDB", sDbFullName);
            SqliteHelper1.GenerateSqlite("BackDB", sBackDBPath);
            //创建表
            if (!CreateTable("MainDB")) {
                return;
            }

            if (!CreateTable("BackDB")) {
                return;
            }

            //写入线路信息
            if (!WriteStationInfo("MainDB")) {
                return;
            }
            if (!WriteStationInfo("BackDB")) {
                return;
            }

            //数据库持久化
            Thread th = new Thread(RunRedis2Sqlit);
            th.Start();
        }
        private bool CheckDiskSpace(string sDiskName) {
            double dCurDiskSpace = utils.IOUtils.GetHardDiskSpace(sDiskName);
            if (dCurDiskSpace < Settings.Default.miniDiskSpace) {
                MessageBox.Show(sDiskName + " 剩余磁盘空间 " + dCurDiskSpace.ToString("F2") + "G, 存储空间不足！\n 需要至少" + Settings.Default.miniDiskSpace
                    + "G,请更换磁盘或清除磁盘内容！");
                return false;
            }
            return true;
        }

        private void btnStartCheck_Click(object sender, EventArgs e) {
            //运行任务
            RunTask();
        }

        public void CheckRedisServ() {
            while (true) {
                bool res = RedisHelper.CheckConnect(Settings.Default.DbServIP,Settings.Default.Port);
                DbServChgState(res);
                if (res) {
                    // timer1.Start();
                    AddGobalInfo("# --- " + DateTime.Now.ToString() + "   " + Settings.Default.DbServIP + " 数据库服务已开启！\n");

                    Thread.Sleep(300000);//连接正常 就5分钟检查一次


                } else {
                    RunRedisServer();
                }
                Thread.Sleep(5000);//连接正常 就5秒钟检查一次
            }

        }
        public void RunRedisServer() {
            //AddGobalInfo("1.在线数据库服务启动 ---");
            if (RedisHelper.GetInstance().SetRedisServer(Settings.Default.DbServIP)) {
                return;
            }
            string str = Path.Combine(System.Environment.CurrentDirectory, "redis.cmd");
            RedisHelper.GetInstance().ServerPath = str;
            int returnValue = -1;
            try {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(RedisHelper.GetInstance().ServerPath);
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.StartInfo.UseShellExecute = false;

                myProcess.OutputDataReceived += new DataReceivedEventHandler(processOutputDataReceived);
                myProcess.StartInfo.RedirectStandardInput = true;// 重定向输入    
                myProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
                myProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出       

                myProcess.Start();
                myProcess.BeginOutputReadLine();
                //while (!myProcess.HasExited) {
                //    myProcess.WaitForExit();
                //}
                returnValue = myProcess.ExitCode;
                myProcess.Dispose();
                myProcess.Close();

            } catch (Exception) {
                DbServChgState(false);
                //return false;
            }


            // return returnValue > -1;
        }

        public void RunAIServ() {
            //AddGobalInfo("\n3.智能分析服务器启动 ---");

            string sCmd = System.Environment.CurrentDirectory + "\\RunAIServe\\test.exe";


            int rtnValue = -1;
            try {
                /*
                 * 打开ubuntu服务器上的算法模块
                **返回值：数值1：打开成功；
                **返回值：数值3：算法模块已打开，请求open的指令无效；
                **返回值：数值0：打开失败；
                */
                Process myProcess = new Process();
                while (true) {
                    ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(sCmd);
                    myProcessStartInfo.CreateNoWindow = true;
                    myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    myProcess.StartInfo = myProcessStartInfo;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.RedirectStandardInput = false;// 重定向输入    
                    myProcess.StartInfo.RedirectStandardOutput = false; // 重定向标准输出    
                    myProcess.StartInfo.RedirectStandardError = false;  // 重定向错误输出     
                    myProcess.Start();

                    while (!myProcess.HasExited) {
                        myProcess.WaitForExit();
                    }
                    rtnValue = myProcess.ExitCode;
                    AddGobalInfo("# --- " + DateTime.Now.ToString() + " 智能分析服务已开启！\n");
                    AIServChgState(true);
                    if (rtnValue != 0) {
                        break;
                    }
                    Thread.Sleep(1000000);//每隔10分钟 启动一次AI服务

                }
                myProcess.Dispose();
                myProcess.Close();

            } catch (Exception ex) {
               // MessageBox.Show(ex.ToString());
                AIServChgState(false);
                //return false;
            }


        }

        private void processOutputDataReceived(object sendingProcess, DataReceivedEventArgs outLine) {

            // Collect the sort command output.      outLine.Data即为输出的信息（string类型）
            if (!String.IsNullOrEmpty(outLine.Data)) {
                AddDbRunInfo(outLine.Data + "\n");
            }
        }
        private void AIOutputDataReceived(object sendingProcess, DataReceivedEventArgs outLine) {

            // Collect the sort command output.      outLine.Data即为输出的信息（string类型）
            if (!String.IsNullOrEmpty(outLine.Data)) {
                AddAIInfo(outLine.Data + "\n");
            }
        }

        private void AddGobalInfo(string str) {
            if (rTextBoxInfo.InvokeRequired) {
                Action<string> a = new Action<string>(AddGobalInfo);
                rTextBoxInfo.Invoke(a, str);
            } else {

                rTextBoxInfo.AppendText(str);
            }
        }

        #region 状态改变--委托
        private void DbServChgState(bool isRun) {
            if (lblDbServState.InvokeRequired) {
                Action<bool> a = new Action<bool>(DbServChgState);
                lblDbServState.Invoke(a, isRun);
            } else {
                lblDbServState.ImageIndex = isRun ? 15 : 16;
            }
        }
        private void DbSqliteChgState(bool isRun) {
            if (lblDbSaveState.InvokeRequired) {
                Action<bool> a = new Action<bool>(DbSqliteChgState);
                lblDbSaveState.Invoke(a, isRun);
            } else {
                lblDbSaveState.ImageIndex = isRun ? 15 : 16;
            }
        }
        private void AIServChgState(bool isRun) {
            if (lblAIServState.InvokeRequired) {
                Action<bool> a = new Action<bool>(AIServChgState);
                lblAIServState.Invoke(a, isRun);
            } else {
                lblAIServState.ImageIndex = isRun ? 15 : 16;
            }
        }
        private void CameraChgState(bool isRun) {
            if (lblCameraState.InvokeRequired) {
                Action<bool> a = new Action<bool>(CameraChgState);
                lblCameraState.Invoke(a, isRun);
            } else {
                lblCameraState.ImageIndex = isRun ? 15 : 16;
            }
        }
        #endregion


        private void AddDbRunInfo(string str) {
            if (rTextBoxDbServerInfo.InvokeRequired) {
                Action<string> a = new Action<string>(AddDbRunInfo);
                rTextBoxDbServerInfo.Invoke(a, str);
            } else {
                rTextBoxDbServerInfo.AppendText(str);
                rTextBoxDbServerInfo.ScrollToCaret();
            }
        }

        private void AddAIInfo(string str) {
            if (rTBAIServInfo.InvokeRequired) {
                Action<string> a = new Action<string>(AddAIInfo);
                rTBAIServInfo.Invoke(a, str);
            } else {
                rTBAIServInfo.AppendText(str);
                rTBAIServInfo.ScrollToCaret();
            }

        }
        private void AddPersistInfo(string str) {
            if (rTxtBoxPersistInfo.InvokeRequired) {
                Action<string> a = new Action<string>(AddPersistInfo);
                rTxtBoxPersistInfo.Invoke(a, str);
            } else {
                if (rTxtBoxPersistInfo.Lines.Length > 100) {
                    rTxtBoxPersistInfo.Clear();
                }

                rTxtBoxPersistInfo.AppendText(str);
                rTxtBoxPersistInfo.ScrollToCaret();

            }
        }

        private void KillRuningExe(string str) {
            Process[] psProcesses = Process.GetProcessesByName(str);
            for (int i = 0; i < psProcesses.Length; i++) {
                try {
                    psProcesses[i].Kill();
                } catch (Exception) {
                    //MessageBox.Show(ex.ToString());
                }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
            notifyIcon1.ShowBalloonTip(5000, "提示", "双击还原总控平台", ToolTipIcon.Info);

            //KillRuningExe("redis-server");
            //KillRuningExe("Redis2Sqlite");
        }
        //写入站点信息
        private bool WriteStationInfo(string sDbName) {

            string sSql = string.Format("insert into stationInfo (sLineName,sStartStation,sEndStation ,sType,taskDate)values ( '{0}','{1}','{2}',{3},'{4}' )"
                , cbBoxTarskLineName.Text, this.cbBoxStartStation.Text, this.cbBoxEndStation.Text, this.cbBoxUpDown.SelectedIndex, DateTime.Now.ToString("s"));
            try {
                SqliteHelper1.GetSqlite(sDbName).ExecuteNonQuery(sSql, null);
            } catch (Exception) {
                MessageBox.Show("写入任务信息失败！");
                return false;
            }

            return true;
        }

        private bool CreateTable(string dbName) {
            //创建 picInfo
            const string strCreateImgTb = "CREATE TABLE picInfo(imgGUID INT64 PRIMARY KEY ,cId INTEGER,shootTime INT64,poleNum TEXT,KMValue TEXT,STN TEXT,imgContent BLOB,sJson TEXT );";
            // 创建 线路信息表 stationInfo
            const string strCreateStationTB = "CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY AUTOINCREMENT,sLineName varchar(50),sStartStation varchar(50),sEndStation varchar(50),sType tinyint,taskDate DATE );";
            //创建定位缺陷表 
            const string sCreateLocFaultTB = "CREATE TABLE locFaultInfo(imgGUID INT64 PRIMARY KEY ,ExistFault INTEGER,sJson TEXT);";
            //创建 缺陷表
            const string strCreateFaultTB = "create table FaultInfo( pId INT64 primary key,imgGUID INT64,unitId int,fault varchar(255),mark varchar(100),faultLevel varchar(5),"
                + "isAI int DEFAULT 1, analyzeDate datetime NOT NULL DEFAULT(datetime('now', 'localtime')), " +
                "confirmDate datetime, confirmUser varchar(50), confirmResult int DEFAULT -1, memo varchar(100) )";
            try {
                SqliteHelper1 sqlite = SqliteHelper1.GetSqlite(dbName);
                sqlite.ExecuteNonQuery(strCreateImgTb, null);
                sqlite.ExecuteNonQuery(strCreateStationTB, null);
                sqlite.ExecuteNonQuery(sCreateLocFaultTB, null);
                sqlite.ExecuteNonQuery(strCreateFaultTB, null);
            } catch (Exception) {

                Console.WriteLine(dbName + "表创建失败！");
            }
            return true;
        }
       
        /// <summary>
        /// 运行数据持久化操作
        /// </summary>
        private void RunRedis2Sqlit() {
            if (isRunRedis2Sqlite) {
                DbSqliteChgState(true);
                return;
            }
            if (!RedisHelper.GetInstance().SetRedisServer(Settings.Default.DbServIP)) {
                return;
            }
            // RedisHelper.GetInstance().ClearAllDB();
            int returnValue = -1;
            try {

                Process myProcess = new Process();
                string str = Path.Combine(System.Environment.CurrentDirectory, "Redis2Sqlite.exe");


                AddGobalInfo("#--- 数据持久化开启 -->");

                //输入参数 ipAddr：Ip地址  sDBFullName：数据库所在位置; MemLimit：内存限制  bulkSaveImgNum：一次性持久化数据大小 iLst
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(str, args);
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.StartInfo.UseShellExecute = false;

                myProcess.OutputDataReceived += new DataReceivedEventHandler(PersistDataReceived);
                myProcess.StartInfo.RedirectStandardInput = true;// 重定向输入    
                myProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
                myProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出       

                myProcess.Start();
                isRunRedis2Sqlite = true;
                myProcess.BeginOutputReadLine();
                AddGobalInfo("  启动成功！\n");
                DbSqliteChgState(true);
                while (!myProcess.HasExited) {
                    myProcess.WaitForExit();
                }
                returnValue = myProcess.ExitCode;
                myProcess.Dispose();
                myProcess.Close();
            } catch (Exception ex) {
                AddGobalInfo(ex.Message.ToString() + "  启动失败！\n");
                DbSqliteChgState(false);
                //return false;
            }
        }
        private void PersistDataReceived(object sendingProcess, DataReceivedEventArgs outLine) {

            // Collect the sort command output.      outLine.Data即为输出的信息（string类型）
            if (!String.IsNullOrEmpty(outLine.Data)) {
                AddPersistInfo(outLine.Data + "\n");
            }
        }

        private void btnGenLocFaultData_Click(object sender, EventArgs e) {

            try {
                AddGobalInfo("测试信息：生成模拟定位 & 缺陷信息数据 --- !");
                Process myProcess = new Process();
                string str = Path.Combine(System.Environment.CurrentDirectory, "GenLocData.exe");
                //输入参数 ipAddr：Ip地址  sDBFullName：数据库所在位置; MemLimit：内存限制  bulkSaveImgNum：一次性持久化数据大小 iLst
                string args = ipAddrInput.Value;
                // MessageBox.Show(args);
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(str, args);
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.StartInfo.UseShellExecute = false;

                myProcess.StartInfo.RedirectStandardInput = false;// 重定向输入    
                myProcess.StartInfo.RedirectStandardOutput = false; // 重定向标准输出    
                myProcess.StartInfo.RedirectStandardError = false;  // 重定向错误输出     
                myProcess.Start();
                myProcess.BeginOutputReadLine();
                AddGobalInfo("  生成成功！\n");
                while (!myProcess.HasExited) {
                    myProcess.WaitForExit();
                }
                //returnValue = myProcess.ExitCode;
                myProcess.Dispose();
                myProcess.Close();
                MessageBox.Show(@"成功生成模拟定位 & 缺陷信息数据");
            } catch (Exception ex) {
                AddGobalInfo(ex.Message.ToString() + "  生成失败！\n");

            }
        }

        private void groupPanel2_Click(object sender, EventArgs e) {

        }

        private void btnClose_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show("确认关闭系统!\n退出系统，不会关闭数据库服务！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) {
                //  KillRuningExe("redis-server");
                KillRuningExe("Redis2Sqlite");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void panelEx1_Click(object sender, EventArgs e) {

        }

        #region 参数设置
        private void btnDBPath_Click(object sender, EventArgs e) {
            string sPath = OpenDir(Settings.Default.DBPath);
            if (sPath != string.Empty) {
                if (!this.CheckDiskSpace(Path.GetPathRoot(sPath))) {
                    return;
                }

                linkLblDbPath.Text = sPath;
                linkLblDbBackPath.Text = sPath;

                Settings.Default.DBPath = sPath;
                Settings.Default.Save();
            }
        }
        private void btnDBBackPath_Click(object sender, EventArgs e) {
            string sPath = OpenDir(Settings.Default.DBBackPath);
            if (sPath != string.Empty) {
                if (!this.CheckDiskSpace(Path.GetPathRoot(sPath))) {
                    return;
                }

                linkLblDbBackPath.Text = sPath;
                Settings.Default.DBBackPath = sPath;
                Settings.Default.Save();
            } else {
                linkLblDbBackPath.Text = "";
            }
        }
        private void linkLbl_Click(object sender, EventArgs e) {
            LinkLabel lnkLbl = (LinkLabel)sender;
            if (!string.IsNullOrEmpty(lnkLbl.Text)) {
                try {
                    Process.Start(lnkLbl.Text.Trim());
                } catch { MessageBox.Show(@"目录打开失败!"); }
            }
        }
        #endregion


        #region 文件操作
        private string OpenDir(string defaultDir = "") {
            string sRtn = string.Empty;
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.SelectedPath = defaultDir;
            dialog.Description = "请选择离线数据库所在文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (string.IsNullOrEmpty(dialog.SelectedPath)) {
                    MessageBox.Show(this, @"文件夹路径不能为空", @"提示");
                    sRtn = string.Empty;
                } else {
                    sRtn = dialog.SelectedPath;
                }
            }
            return sRtn;
        }


        #endregion

        private void Input_TextChanged(object sender, EventArgs e) {
            Control ctrl = ((Control)sender);
            if (ctrl.Name == "ipAddrInput") {
                Settings.Default.DbServIP = ipAddrInput.Value;
                Settings.Default.Save();
            } else if (ctrl.Name == "iMaxMem") {
                Settings.Default.MaxMem = iMaxMem.Value;
                Settings.Default.Save();
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Visible = true;
        }

        private void TsMenuItemExit_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show("确认退出系统!\n注意：退出系统，会关闭离线数据保存服务！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) {
                //KillRuningExe("redis-server");
                KillRuningExe("Redis2Sqlite");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Visible = !this.Visible;
        }

        private void btnClearDB_Click(object sender, EventArgs e) {

        }
        //监控任务
        private void timer1_Tick(object sender, EventArgs e) {
            MessageBox.Show("任务开始");
            string str = RedisHelper.GetInstance().GetString("TaskInfo", 11);

            if (string.IsNullOrEmpty(str)) {
                return;
            }

            string[] s = str.Split('_');
            cbBoxStartStation.Text = s[3];
            cbBoxEndStation.Text = s[4];
            MessageBox.Show("任务开始" + str);
        }

        private void timerDate_Tick(object sender, EventArgs e) {
            lblDate.Text = DateTime.Now.ToString("yy-MM-dd HH:mm:ss");
        }
    }
}
