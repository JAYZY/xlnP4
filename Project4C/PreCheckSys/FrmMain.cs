using ComClassLib;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using PreCheckSys.core;
using PreCheckSys.Ctrl;
using PreCheckSys.Properties;
using PreCheckSys.UI;
using PreCheckSys.utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreCheckSys {
    public partial class FrmMain : Form {
        private bool isWhile = true;
        UCtrlDiskIOInfo _ctrlMainDiskIO, _ctrlSecDiskIO;
        bool _isRunTimeServ = false, _isRunReidsServ = false, _isRunAIServ = false;
        CancellationTokenSource _tokenSource;
        CancellationToken _token;
        ManualResetEvent _resetEvent;



        //enum TaskState {
        //    none,
        //    createTask,
        //    startTask,
        //    StopTask
        //}

        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x0014) // 禁掉清除背景消息
{
                return;
            }

            base.WndProc(ref m);
        }
        public FrmMain() {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);// 双缓冲
                                                            // this.SetStyle(ControlStyles.UserPaint, true);
            Init();
            TaskIni();
            InitCameraState(); //初始化相机状态
            string diskName = Settings.Default.DBPath.Substring(0, 2);
            _ctrlMainDiskIO = new UCtrlDiskIOInfo(diskName, $"数据主磁盘-" + diskName);
            _ctrlMainDiskIO.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(_ctrlMainDiskIO);
            _ctrlMainDiskIO.StartDisplay();

            _ctrlSecDiskIO = new UCtrlDiskIOInfo("", "");
            _ctrlSecDiskIO.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(_ctrlSecDiskIO);
        }

        private void Init() {
            //初始化日期時間
            timerGlobal.Enabled = true;
            //初始化按钮状态 
            ChBtnState(taskState.none);
            totalPys = IOUtils.GetTotalPhys(); //获取总内存信息
            GenerateDiskInfo();
            (new Thread(GetMem)).Start();
            ChgPicState(picAIServState, true);
        }

        /// <summary>
        /// 任务初始化
        /// </summary>
        private void TaskIni() {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _resetEvent = new ManualResetEvent(true);
        }
        private void FrmMain_Shown(object sender, EventArgs e) {
            OpenMonitor();
            DevMonitor();
            Recev();//接收广播
        }

        #region 广播信息监听

        private void ShowNetMsg(string m) {
            if (lblSpeed.InvokeRequired) {
                Action<string> a = new Action<string>(ShowNetMsg);
                lblSpeed.Invoke(a, m);
            } else {
                string[] str = m.Split(',');
                if (str.Length > 1) {
                    lblSpeed.Text = str[0] + "KM/h";
                    lblKMV.Text = str[1];
                }
            }
        }
        NetMsg _netMsg;
        private void Recev() {
            _netMsg = new NetMsg(int.Parse(Settings.Default.gwPort));
            _netMsg.SetCallBack(ShowNetMsg);
            _netMsg.start();
        }

        #endregion

        #region 软件模块运行情况监控
        //开启所有监控
        private void OpenMonitor() {

            //监控 -- 时间同步服务
            if (!_isRunTimeServ) {
                _isRunTimeServ = true;
                ServTask(picTimeServState, "TimeServ");
            }

            //监控 -- Redis服务
            if (!_isRunReidsServ) {
                _isRunReidsServ = true;
                ServTask(picRedisState, "Redis");
            }

            //监控 -- AIServ服务
            if (!_isRunAIServ) {
                _isRunAIServ = true;
                AIServMonitor();
            }
        }

        private void AIServMonitor() {
            var AIServTask = new Task(async () =>
            {//   //"192.168.100.58", 6379, 10, 11, 12, "list"
                while (_isRunAIServ) {
                    if (_tokenSource.IsCancellationRequested) {
                        return;
                    }
                    if (CallAIServ.GetInstance().OpenAIServ(Settings.Default.DbServIP, 10, 11, 12, "list")) {
                        ChgPicState(picAIServState, true);
                    } else {
                        ChgPicState(picAIServState, false);
                    }
                    //Thread.Sleep(3000);
                    await Task.Delay(3000);
                }
            }, _token);
            // AIServTask.Start();
        }


        #region 服务监控



        /// <summary>
        /// 用Task优化 监控服务
        /// </summary>
        private void ServTask(PictureBox pic, string servName) {

            var timeServTask = new Task(async () =>
            {
                while (_isRunTimeServ) {
                    if (_tokenSource.IsCancellationRequested) {
                        return;
                    }

                    var serviceControllers = ServiceController.GetServices();
                    var server = serviceControllers.FirstOrDefault(service => service.ServiceName == servName);// "TimeServ");
                    string sTip = (server == null) ? "stop" : server.Status.ToString();
                    Console.WriteLine(servName + "->" + sTip);
                    if (server != null && server.Status != ServiceControllerStatus.Running) {
                        ChgPicState(pic, false);
                    } else {
                        ChgPicState(pic, true);
                    }
                    await Task.Delay(1000);
                }
            }, _token);
            timeServTask.Start();
        }
        #endregion

        #endregion

        #region 硬件模块运行状态监控

        PictureBox[] picCameraBoxs;
        LabelX[] lblCameras;
        string[] sCameraIPs;
        string[] sCameraInfos;
        IntPtr[] cameraHDevs;
        private void InitCameraState() {
            picCameraBoxs = new PictureBox[] { picCameraA, picCameraB, picCameraC, picCameraD };
            lblCameras = new LabelX[] { lblCameraInfoA, lblCameraInfoB, lblCameraInfoC, lblCameraInfoD };
            sCameraInfos = new string[] { Settings.Default.cameralInfoA, Settings.Default.cameralInfoB, Settings.Default.cameralInfoC, Settings.Default.cameralInfoD };
            sCameraIPs = new string[] { Settings.Default.cameraIPA, Settings.Default.cameraIPB, Settings.Default.cameraIPC, Settings.Default.cameraIPD };
            ///相机相关控件初始化
            for (int i = 0; i < picCameraBoxs.Length; ++i) {
                picCameraBoxs[i].Image = Image.FromFile("img/cameraG.png");
                lblCameras[i].Text = $"———————\r\n{sCameraIPs[i]}\r\n{sCameraInfos[i]}";
                lblCameras[i].ForeColor = Settings.Default.RedColor;
            }

            //其他控件初始化
            picMainServ.Image = Image.FromFile("img/MonitorServR.png");
            picAIServ.Image = Image.FromFile("img/AIServG2.png");
            picCamera3D.Image = Image.FromFile("img/3DGreen.png");

            lblCameraInfo3D.ForeColor = Settings.Default.GreenColor;
            lblAIServ.ForeColor = Settings.Default.GreenColor;
            lblMainServ.ForeColor = Settings.Default.RedColor;

            lblCameraInfo3D.Text = $"———————\r\n{Settings.Default.camera3DIP}\r\n{Settings.Default.camera3DInfo}";
            lblMainServ.Text = $"———————\r\n{Settings.Default.MainServIP}\r\n{Settings.Default.MainServInfo}";
            lblAIServ.Text = $"———————\r\n{Settings.Default.AIServIP}\r\n{Settings.Default.AIServInfo}";
        }

        private void CameraTask(int i) {
            new Task(async () =>
            {
                while (_isRunTimeServ) {
                    if (_tokenSource.IsCancellationRequested) {
                        return;
                    }

                    bool res = ConnectCamera(i, Settings.Default.videoPort);
                    ChgPicState(picCameraBoxs[i], res ? "cameraG.png" : "cameraR.png");
                    lblCameras[i].ForeColor = res ? Settings.Default.GreenColor : Settings.Default.RedColor;
                    await Task.Delay(5000);
                }
            }, _token).Start();
        }

        private void DevMonitor() {
            Thread.Sleep(5000);
            cameraHDevs = new IntPtr[4];
            CameraTask(0);
            CameraTask(1);
            CameraTask(2);
            CameraTask(3);



            //new Task(() => {
            //    bool res = ConnectCamera(Settings.Default.camera3DIP, Settings.Default.videoPort);
            //    ChgPicState(picCamera3D, res ? "3DGreen.png" : "3DRed.png");
            //}, _token).Start();

            new Task(async () =>
            {
                while (_isRunTimeServ) {
                    if (_tokenSource.IsCancellationRequested) {
                        return;
                    }

                    bool res = PingConn(Settings.Default.MainServIP);
                    ChgPicState(picMainServ, res ? "MonitorServG.png" : "MonitorServR.png");
                    lblMainServ.ForeColor = res ? Settings.Default.GreenColor : Settings.Default.RedColor;
                    await Task.Delay(1000);
                }
            }, _token).Start();
            //new Task(() => {
            //    bool res = PingConn(Settings.Default.AIServInfo);
            //    ChgPicState(picAIServ, res ? "AIServG2.png" : "AIServR2.png");
            //    lblAIServ.ForeColor = res ? Settings.Default.GreenColor : Settings.Default.RedColor;
            //}, _token).Start();

        }
        private bool ConnectCamera(int i, int iport) {
            bool isConn = false;
            try {
                if (cameraHDevs[i] == IntPtr.Zero) {
                    string ipAddr = sCameraIPs[i];
                    IntPtr hDec = VideoM.Connection(ipAddr, iport);
                    if (hDec != IntPtr.Zero) {
                        isConn = !string.IsNullOrEmpty(VideoM.GetCameraParam(hDec));
                        cameraHDevs[i] = hDec;
                    }
                } else {
                    string sInfo = VideoM.GetCameraParam(cameraHDevs[i]);
                    isConn = !string.IsNullOrEmpty(sInfo);
                }
                //VideoM.CloseRPC(hDec);
                //hDec = IntPtr.Zero;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            } catch {
               
            } finally {
                if (!isConn&&cameraHDevs[i] != IntPtr.Zero) {
                    VideoM.CloseRPC(cameraHDevs[i]);
                    cameraHDevs[i] = IntPtr.Zero;
                }
            }
            return isConn;
        }
        private void CloseRPC() {
            try {
                for (int i = 0; i < cameraHDevs.Length; i++) {
                    IntPtr hDev = cameraHDevs[i];
                    if (hDev == IntPtr.Zero) {
                        continue;
                    }
                    VideoM.CloseRPC(hDev);
                    hDev = IntPtr.Zero;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            } catch {
                
            }
        }
        private bool PingConn(string ipAddr) {
            bool res = false;
            try {
                Ping ping = new Ping();
                int iTimeOut = 3000;
                PingReply pingReply = ping.Send(ipAddr, iTimeOut);
                res = (pingReply.Status == IPStatus.Success);
            } catch {
                res = false;
            }
            return res;
        }
        #endregion

        #region 状态改变--委托
        /// <summary>
        /// 软件运行状态改变
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="isRun"></param>
        private void ChgPicState(PictureBox pic, bool isRun) {
            if (pic.InvokeRequired) {
                Action<PictureBox, bool> a = new Action<PictureBox, bool>(ChgPicState);
                pic.Invoke(a, pic, isRun);
            } else {
                string picPath = isRun ? "img/ok-small.png" : "img/error-small.png";
                pic.LoadAsync(picPath);
            }
        }
        /// <summary>
        /// 硬件运行状态改变
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="sPicPath"></param>
        private void ChgPicState(PictureBox pic, string sPicPath) {
            if (pic.InvokeRequired) {
                Action<PictureBox, string> a = new Action<PictureBox, string>(ChgPicState);
                pic.Invoke(a, pic, sPicPath);
            } else {
                string picPath = "img/" + sPicPath;
                pic.LoadAsync(picPath);
            }
        }
        #endregion

        #region 打开视频控制
        /// <summary>
        /// 双击打开，视频控制窗口
        /// </summary>
        private void picVideo_DoubleClick(object sender, EventArgs e) {
            PictureBox pic = (PictureBox)sender;
            string sIP = "";
            switch (pic.Tag.ToString()) {
                case "A":
                    sIP = Settings.Default.cameraIPA;
                    break;
                case "B":
                    sIP = Settings.Default.cameraIPB;
                    break;
                case "C":
                    sIP = Settings.Default.cameraIPC;
                    break;
                case "D":
                    sIP = Settings.Default.cameraIPD;
                    break;
                default:
                    return;
            }
            UI.VideoControl video = new UI.VideoControl(sIP);
            video.ShowDialog();
        }
        #endregion

        #region 显示日期时间        

        private void timerGlobal_Tick(object sender, EventArgs e) {
            lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        #endregion

        #region 获取系统信息

        private double totalPys = 0;
        #region 磁盘信息

        /// <summary>
        /// 获取磁盘信息
        /// </summary>
        private void GenerateDiskInfo() {
            DriveInfo[] allDirves = DriveInfo.GetDrives();
            int iLeft = 60, iTop = 120, iSpace = 36;
            //检索计算机上的所有逻辑驱动器名称
            foreach (DriveInfo item in allDirves) {
                //Fixed 硬盘
                //Removable 可移动存储设备，如软盘驱动器或USB闪存驱动器。
                Label lblDiskName = new Label();

                lblDiskName.BackColor = System.Drawing.Color.Transparent;
                lblDiskName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
                lblDiskName.ForeColor = Color.White;
                lblDiskName.Text = item.Name;
                lblDiskName.AutoSize = true;
                lblDiskName.Location = new Point(iLeft, iTop);
                lblDiskName.Cursor = Cursors.Hand;
                lblDiskName.Click += new EventHandler(this.ClickOpen);
                panelDiskInfo.Controls.Add(lblDiskName);

                ProgressBarX progressBar = new ProgressBarX();
                progressBar.Tag = item.Name;
                progressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                progressBar.BackgroundStyle.TextAlignment = eStyleTextAlignment.Center;
                progressBar.BackgroundStyle.TextColor = Color.White;
                progressBar.Location = new Point(iLeft + 36, iTop);
                progressBar.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);

                progressBar.Name = $"prog{item.Name}";
                progressBar.Size = new System.Drawing.Size(236, 26);

                progressBar.Click += new EventHandler(this.ClickOpen);


                if (item.IsReady) {
                    double freeSpace = item.TotalFreeSpace;
                    double totalSpace = item.TotalSize;
                    progressBar.Value = (int)((1.0 - freeSpace / totalSpace) * 100);
                    progressBar.Text = $"{IOUtils.FormatSize(freeSpace)}可用，共{IOUtils.FormatSize(totalSpace)}";

                } else {
                    progressBar.Text = $"没有就绪";
                    progressBar.Value = 0;
                    continue;
                }
                progressBar.TextVisible = true;
                panelDiskInfo.Controls.Add(progressBar);
                iTop += iSpace + lblDiskName.Height;


            }
            panelDiskInfo.Refresh();
        }

        private void ClickOpen(Object obj, EventArgs e) {
            string sUrl = "";
            try {
                if (obj is ProgressBarX) {
                    sUrl = ((ProgressBarX)obj).Tag.ToString();
                } else if (obj is Label) {
                    sUrl = ((Label)obj).Text;
                }
                if (!string.IsNullOrEmpty(sUrl)) {

                    Process.Start(sUrl);
                }
            } catch {
                MessageBox.Show(@"打开失败!");
            }
        }
        #endregion

        #region 内存信息仪表盘
        private void GetMem() {
            while (isWhile) {
                double usedPys = IOUtils.GetUsedPhys();
                ChgCtrl(totalPys, usedPys);
                Thread.Sleep(1000);
            }
        }
        private void ChgCtrl(double totalPys, double usedPys) {
            if (gaugeCtrlMemory.InvokeRequired) {
                Action<double, double> a = ChgCtrl;
                gaugeCtrlMemory.Invoke(a, totalPys, usedPys);
            } else {
                double prec = usedPys / totalPys;
                gaugeCtrlMemory.CircularScales[0].Pointers[0].Value = prec * 100;
                ((DevComponents.Instrumentation.GaugeText)gaugeCtrlMemory.GaugeItems[0]).Text = prec.ToString("P0");
                lblMemUsed.Text = $"总内存：{IOUtils.FormatSize(totalPys)}    已使用:{IOUtils.FormatSize(usedPys)}";
            }
        }
        #endregion

        #endregion

        #region 任务操作-配置，开启持久化，停止任务
        MonitorTask _currTask = null;
        /// <summary>
        /// 新建任务--配置任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaskConfig_Click(object sender, EventArgs e) {
            UI.TaskConfig taskConfig = new UI.TaskConfig();
            taskConfig.ShowDialog();
            _currTask = MonitorTask.GetTask();

            if (_currTask != null && _currTask.State != taskState.running) {
                lblTaskInfo.Text = $"{_currTask.LineName} {_currTask.SType} " +
                    $"{_currTask.StartStation}-{_currTask.EndStation}";
                //开始磁盘监控
                if (!string.IsNullOrEmpty(_currTask.TaskIndBackFileFullName)) {
                    string sDiskName = Path.GetPathRoot(_currTask.TaskIndBackFileFullName);
                    sDiskName = sDiskName.Remove(sDiskName.Length - 1);
                    _ctrlSecDiskIO.SetDiskName(sDiskName, $"数据备份盘-{sDiskName} ");
                    _ctrlSecDiskIO.StartDisplay();

                    string sMainDiskName = Path.GetPathRoot(_currTask.TaskIndFileFullName);
                    sMainDiskName = sMainDiskName.Remove(sMainDiskName.Length - 1);
                    _ctrlSecDiskIO.SetDiskName(sMainDiskName, $"数据主磁盘-{sMainDiskName}");
                    _ctrlMainDiskIO.StartDisplay();

                }
                //新建任务修改按钮状态
                ChBtnState(taskState.plan);
            }
        }
        /// <summary>
        /// 开始持久化数据任务
        /// </summary>
        private void btnStartTask_Click(object sender, EventArgs e) {
            if (_currTask == null) {
                MsgBox.Warning("当没有任务计划，请先配置任务!", "开启任务失败");
                return;
            }
            MonitorTask.CallInfo = ShowTaskMsg;
            ChgPicState(picSaveDataState, true);
            //新建任务修改按钮状态Task
            ChBtnState(taskState.running);
            _currTask.TaskStart();
        }
        private void ShowTaskMsg(string sMsg) {
            if (lblSaveImgNum.InvokeRequired) {
                Action<string> a = ShowTaskMsg;
                lblSaveFaultNum.Invoke(a, sMsg);
            } else {
                try {
                    string[] s = sMsg.Split(':');
                    // taskMsg iMsg = (taskMsg)int.Parse(s[0]);
                    switch (s[0]) {
                        case "Msg":
                            string prex = DateTime.Now.ToString("#HH:mm:ss");
                            if (rTbTaskMsg.Lines.Count() > 60) {
                                rTbTaskMsg.Lines = rTbTaskMsg.Lines.Skip(5).ToArray();
                            }

                            rTbTaskMsg.AppendText($"{prex}->{s[1]}\n");
                            rTbTaskMsg.ScrollToCaret();
                            break;
                        case "Mem":
                            lblServMem.Text = s[1];
                            break;
                        case "Del":
                            lblDelNum.Text = $"Tip:#释放图像数量-[{s[2]}]-张";
                            break;
                        case "Img":
                            lblSaveImgNum.Text = s[1] + "张";
                            break;
                        case "Loc":
                            lblSaveLocNum.Text = s[1] + "条";
                            break;
                        case "Flt":
                            lblSaveFaultNum.Text = s[1] + "条";
                            break;
                        case "BackMsg": //最后消息处理
                            DialogTaskTip.GetInstance().SetTipTxt(s[1]);
                            new Thread(_currTask.TaskBackProc).Start();
                            DialogTaskTip.GetInstance().ShowDialog();
                            break;
                        case "EndMsg":
                            DialogTaskTip.GetInstance().EndProc();
                            break;
                    }
                } catch { }
            }
        }

        /// <summary>
        /// 停止持久化数据任务
        /// </summary>
        private void btnStopTask_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MsgBox.YesNo($"结束当前任务-{_currTask.TaskName}-！\n请确认！")) {
                _currTask.TaskEnd();
                ChBtnState(taskState.finish);

            }
            Thread.Sleep(2000);
            MonitorTask nextTask = MonitorTask.GetNextPlanTask(_currTask);
            if (nextTask != null && DialogResult.Yes == MsgBox.YesNo($"存在计划任务-{nextTask.TaskName}-！\n是否自动开启？")) {
                _currTask = nextTask;
                lblTaskInfo.Text = $"{_currTask.LineName} {_currTask.SType} " +
                    $"{_currTask.StartStation}-{_currTask.EndStation}";
                //新建任务修改按钮状态Task
                ChBtnState(taskState.running);
                _currTask.TaskStart();
                ChgPicState(picSaveDataState, true);
            }

        }


        /// <summary>
        /// 打开在线监控软件
        /// </summary>
        private void btnOpenP4_Click(object sender, EventArgs e) {
            Process.Start("P4\\Project4C.exe");
        }
        /// <summary>
        /// 改变任务按钮状态
        /// </summary>
        /// <param name="taskState"></param>
        private void ChBtnState(taskState taskS) {
            switch (taskS) {
                case taskState.none:
                    btnTaskConfig.Enabled = true;
                    btnStartTask.Enabled = false;
                    btnStopTask.Enabled = false;
                    break;
                case taskState.plan://创建任务成功
                    btnStartTask.Enabled = true;
                    btnStopTask.Enabled = false;
                    break;
                case taskState.running:
                    btnStartTask.Enabled = false;
                    btnStopTask.Enabled = true;
                    break;
                case taskState.finish:
                    btnStopTask.Enabled = false;
                    btnStartTask.Enabled = false;

                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 关闭系统

        /// <summary>
        /// 系统关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show("退出总控平台将停止数据采集！\n请确认！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) {
                try {
                   
                    AbortThread();
                    CloseRPC();
                    this.Close();
                } catch {
                } finally {
                    System.Environment.Exit(0);
                }
            }
        }

        private void labelX5_Click(object sender, EventArgs e) {

        }

        private void lblKMV_Click(object sender, EventArgs e) {

        }

        private void picCameraA_Click(object sender, EventArgs e) {

        }

        private void picAIServState_Click(object sender, EventArgs e) {

        }

        private void btnItemMin_Click(object sender, EventArgs e) {
            this.Visible = false;
            notifyIcon1.ShowBalloonTip(5000, "提示", "双击还原总控平台", ToolTipIcon.Info);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {

        }

        private void tsmItemDisplay_Click(object sender, EventArgs e) {
            this.Visible = !this.Visible;
        }

        private void tsmItemExit_Click(object sender, EventArgs e) {
            if (!btnStartTask.Enabled) {
                if (DialogResult.Yes == MessageBox.Show("退出总控平台将停止数据采集！\n请确认！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) {
                    AbortThread();
                    this.Close();
                    System.Environment.Exit(0);
                }
            } else {
                MessageBox.Show("请先结束任务才能退出总控平台！\n请确认！", "警告");
                this.Visible = !this.Visible;
            }
        }

        private void AbortThread() {
            _isRunAIServ = _isRunReidsServ = _isRunTimeServ = false;
            _netMsg.Stop();
            _tokenSource.Cancel();
            isWhile = false;
            _ctrlMainDiskIO.StopDisplay();
            _ctrlSecDiskIO.StopDisplay();
        }
        private void FrmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
            notifyIcon1.ShowBalloonTip(5000, "提示", "双击还原总控平台", ToolTipIcon.Info);
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            this.Visible = !this.Visible;
        }
        #endregion



    }
}
