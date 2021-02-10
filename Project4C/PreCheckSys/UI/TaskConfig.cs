using ComClassLib;
using ComClassLib.core;
using ComClassLib.DB;
using PreCheckSys.core;
using PreCheckSys.DB;
using PreCheckSys.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace PreCheckSys.UI {
    public partial class TaskConfig : Form {

        private List<string> _StationLst;
        private HashSet<string> _LineName; //线路名称
        private bool _isFinish;
        private bool _isSpaceError;

        public string BackDbPath {
            get {
                return Settings.Default.DBBackPath;
            }
            set {
                Settings.Default.DBBackPath = value;
                Settings.Default.Save();
            }
        }
        public string DBSavePath;
        public string DBPath {
            get {
                return Settings.Default.DBPath;
            }
            set {
                Settings.Default.DBPath = value; Settings.Default.Save();
            }
        }
        public const string sDBDir = "天窗数据";
        /// <summary>
        /// 初始化
        /// </summary>
        public TaskConfig() {
            InitializeComponent();
            _isFinish = _isSpaceError = false;
            ReadBaseDataFile(); //读取基础数据
            ReadMovableDisk();  //读取可移动硬盘
            LoadMonitorTask();         //载入任务

            lblTaskDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            SetMainDbPath();
        }
        #region 刷新任务
        private void LoadMonitorTask() {
            dgvTask.Rows.Clear();
            List<MonitorTask> lstTasks = MonitorTask.GetAllTask();
            for (int i = 0; i < lstTasks.Count; i++) {
                MonitorTask t = lstTasks[i];
                string taskSt = "";
                switch (t.State) {
                    case taskState.plan:
                        taskSt = "计划任务";
                        break;
                    case taskState.running:
                        taskSt = "执行中";
                        break;
                    case taskState.finish:
                        taskSt = "任务完成";
                        break;
                    default:
                        taskSt = "未知";
                        break;
                }
                dgvTask.Rows.Add(t.TaskName, taskSt, string.IsNullOrEmpty(t.TaskIndBackFileFullName) ? "否" : "是");
            }
        }
        #endregion

        #region 数据持久化磁盘选择
        /// <summary>
        /// 设置并判断主存储盘
        /// </summary>
        private void SetMainDbPath() {
             
            string sDriveName = string.IsNullOrEmpty(DBPath) ?  "C:\\":DBPath.Substring(0, 3) ;
            string sPath = Path.Combine(sDriveName + sDBDir, lblTaskDate.Text);
            //判断磁盘空间是否充足
            _isSpaceError = lblMainDBTip.Visible = !CheckDiskSpace(sDriveName);
            linkLblDbPath.Text = DBSavePath = sPath;
        }

        #region 备份磁盘选择
        /// <summary>
        /// 读取可移动硬盘
        /// </summary>
        private void ReadMovableDisk() {
            DriveInfo[] allDirves = DriveInfo.GetDrives();
            ManagementClass mgtCls = new ManagementClass("Win32_DiskDrive");
            var disks = mgtCls.GetInstances();
            //检索计算机上的所有逻辑驱动器名称
            foreach (ManagementObject mo in disks) {
                if (mo.Properties["MediaType"].Value == null ||
                   mo.Properties["MediaType"].Value.ToString() != "External hard disk media") {
                    continue;
                }
                foreach (ManagementObject diskPartition in mo.GetRelated("Win32_DiskPartition")) {
                    foreach (ManagementBaseObject disk in diskPartition.GetRelated("Win32_LogicalDisk")) {
                        cbBackDisk.Items.Add(disk.Properties["Name"].Value.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 激活备份选择
        /// </summary>
        private void ckIsBack_CheckedChanged(object sender, EventArgs e) {
            cbBackDisk.Enabled = ckIsBack.Checked;
            BackDbPath = "";
            if (cbBackDisk.Enabled) {
                cbBackDisk.DroppedDown = true;
            }
            else {
                cbBackDisk.Text = "";
                cbBackDisk.DroppedDown = false;
            }
        }
        /// <summary>
        /// 选择备份移动磁盘
        /// </summary>
        private void cbBackDisk_SelectedIndexChanged(object sender, EventArgs e) {
            //检查移动磁盘的空间容量
            cbBackDisk.Text += "\\";
            if (utils.IOUtils.CheckDiskSpace(cbBackDisk.Text)) {
                BackDbPath = Path.Combine(cbBackDisk.Text + sDBDir, DateTime.Now.ToString("yyyy-MM-dd"));
                _isSpaceError = false;
            }
            else {
                BackDbPath = "";
                _isSpaceError = true;
            }

        }

        #endregion

        #endregion




        #region 创建任务

        /// <summary>
        /// 读取基础数据
        /// </summary>
        private void ReadBaseDataFile() {
            cbBoxTarskLineName.Items.Clear();
            cbBoxStartStation.Text = "";
            cbBoxStartStation.Items.Clear();
            cbBoxEndStation.Text = "";
            cbBoxEndStation.Items.Clear();

            _StationLst = new List<string>();
            _LineName = new HashSet<string>();
            DirectoryInfo root = new DirectoryInfo("DB/BaseData");
            foreach (FileInfo f in root.GetFiles()) {
                if (".csv" == f.Extension) {
                    _LineName.Add(Path.GetFileNameWithoutExtension(f.Name).Split('-')[0]);
                }
            }

            foreach (var item in _LineName) {
                cbBoxTarskLineName.Items.Add(item);
            }

        }

        /// <summary>
        /// 下拉选择线路信息    
        /// </summary>
        private void cbBoxTarskLineName_SelectedIndexChanged(object sender, EventArgs e) {
            cbBoxUpDown.Select();
            cbBoxUpDown.DroppedDown = true;
            cbBoxStartStation.Items.Clear();
            cbBoxEndStation.Items.Clear();
            cbBoxStartStation.Text = "";
            cbBoxEndStation.Text = "";
        }

        /// <summary>
        /// 选择配置文件CSV
        /// </summary>
        private void ShowSel(string selFileName) {

            if (!string.IsNullOrEmpty(selFileName)) {
                _isFinish = false;
                cbBoxStartStation.Items.Clear();
                cbBoxEndStation.Items.Clear();
                cbBoxStartStation.Text = "";
                cbBoxEndStation.Text = "";
                _StationLst.Clear();
                CsvHelper csv = new CsvHelper(selFileName);
                DataTable dt = csv.csvDT;
                if (dt != null) {
                    DataTable dataTableDistinct = dt.DefaultView.ToTable(true, "站区");
                    foreach (DataRow item in dataTableDistinct.Rows) {
                        if (!item[0].ToString().Contains("-")) {
                            cbBoxStartStation.Items.Add(item[0]);
                            _StationLst.Add(item[0].ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 选择行别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxUpDown_SelectedIndexChanged(object sender, EventArgs e) {
            string selFileName = $"DB/BaseData/{ cbBoxTarskLineName.SelectedItem.ToString()}-{cbBoxUpDown.SelectedItem.ToString()}.csv";
            ShowSel(selFileName);
            cbBoxStartStation.Select();
            cbBoxStartStation.DroppedDown = true;
        }

        /// <summary>
        /// 选择起始站区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxStartStation_SelectedIndexChanged(object sender, EventArgs e) {
            cbBoxEndStation.Items.Clear();
            cbBoxEndStation.Text = "";
            int selInd = cbBoxStartStation.SelectedIndex;
            for (int i = selInd + 1; i < _StationLst.Count; ++i) {
                cbBoxEndStation.Items.Add(_StationLst[i]);
            }
            cbBoxEndStation.Select();
            cbBoxEndStation.DroppedDown = true;
        }

        /// <summary>
        /// 选择结束站区，完成选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxEndStation_SelectedIndexChanged(object sender, EventArgs e) {
            try {

                _isFinish = true;

            }
            catch (Exception) {
                MessageBox.Show("线路信息选择有误，请检查!");
            }
        }
        #endregion


        #region 文件操作
        private bool CheckDiskSpace(string sDiskName) {
            double dCurDiskSpace = utils.IOUtils.GetHardDiskSpace(sDiskName);
            if (dCurDiskSpace < Settings.Default.miniDiskSpace) {
                MessageBox.Show(sDiskName + " 剩余磁盘空间 " + dCurDiskSpace.ToString("F2") + "G, 存储空间不足！\n 需要至少" + Settings.Default.miniDiskSpace
                    + "G,请更换磁盘或清除磁盘内容！");
                return false;
            }
            return true;
        }
        private string OpenDir(string defaultDir = "") {
            string sRtn = string.Empty;
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.SelectedPath = defaultDir;
            dialog.Description = "请选择离线数据库所在文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (string.IsNullOrEmpty(dialog.SelectedPath)) {
                    MessageBox.Show(this, @"文件夹路径不能为空", @"提示");
                    sRtn = string.Empty;
                }
                else {
                    sRtn = dialog.SelectedPath;
                }
            }
            return sRtn;
        }
        #endregion

        #region 导入基础数据库
        /// <summary>
        /// 检查CSV文件合法性
        /// </summary>
        /// <param name="selFileName"></param>
        /// <returns></returns>
        private bool CopyCSV(string selFileName) {
            bool res = false;
            string sDestFileName = "";
            string sFileName = "";
            try {
                CsvHelper csv = new CsvHelper(selFileName);
                DataTable dt = csv.csvDT;
                if (dt != null) {
                    sFileName = $"{dt.Rows[0][0].ToString()}-{ dt.Rows[0][1].ToString()}";
                    sDestFileName = $"{System.Environment.CurrentDirectory}/DB/BaseData/{sFileName}.csv";
                    res = true;
                    FileInfo newFile = FileHelper.FileCopy(selFileName, sDestFileName, false);
                    ComClassLib.MsgBox.Show($"导入的基础数据-{sFileName}成功!");
                }
            }
            catch (IOException) {
                ComClassLib.MsgBox.Warning($"导入的基础数据文件-{sFileName}已经存在！\n请核对后重新导入!", "导入错误");

            }
            catch (Exception ex) {
                ComClassLib.MsgBox.Error($"导入的基础数据-{selFileName}-格式不正确！");
                res = false;
            }
            return res;
        }
        /// <summary>
        /// 导入基础数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportBaseData_Click(object sender, EventArgs e) {
            string fileFilter = "csv files (*.csv)|*.csv";//过滤选项设置，文本文件，所有文件。
            string title = "选择导入的基础数据文件";
            string sPath = FileHelper.OpenFile(title, fileFilter);
            if (!string.IsNullOrEmpty(sPath)) {
                if (CopyCSV(sPath)) {
                    ReadBaseDataFile();
                }
            }
        }
        #endregion




        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
        /// <summary>
        /// 添加任务 -- 注意一个任务一个目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e) {

            if (_isSpaceError) {
                ComClassLib.MsgBox.Error("磁盘存储空间不足，请确认！)");
                return;
            }
            if (string.IsNullOrEmpty(Settings.Default.DBPath)) {
                ComClassLib.MsgBox.Show("主存储路径不能为空");
                return;
            }
            if (!_isFinish) {
                ComClassLib.MsgBox.Show("请完成线路选择！");
                return;
            }
            if (ckIsBack.Checked) {
                if (String.IsNullOrEmpty(BackDbPath)) {
                    ComClassLib.MsgBox.Warning("请确定是否需要备份数据！","备份数据警告");
                    return;
                }
            }
            //（1）新建任务 == 创建索引数据库，写入用户信息，线路信息
            else{
                BackDbPath = "";
            }
            if (Settings.Default.currDBIndex != 1) {
               // if (DialogResult.No == MsgBox.WarningYesNo("上次未正常退出，是否继续任务\n选择'yes'保留数据，继续上次任务\n选择'NO'将清除已有数据！", "警告")) {
                    Settings.Default.currDBIndex = 1;
                    Settings.Default.Save();
                //}
            }
            /* 新建任务目录与登录数据库，主索引数据库 */
            StationInfo stationInfo = new StationInfo(cbBoxTarskLineName.Text, cbBoxStartStation.Text, cbBoxEndStation.Text, (short)cbBoxUpDown.SelectedIndex, DateTime.Now);



            MonitorTask.AddTask(stationInfo, DBSavePath, BackDbPath);
            //刷新显示任务
            LoadMonitorTask();
            // this.DialogResult = DialogResult.OK;
            cbBoxStartStation.Items.Clear();
            cbBoxEndStation.Items.Clear();
            cbBoxStartStation.Text = "";
            cbBoxEndStation.Text = "";
            _isFinish = false;
        }






        /// <summary>
        /// 超链接打开 目录
        /// </summary>
        private void linkLblDbPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            OpenLocalDir(((LinkLabel)sender).Text);
        }

        private void OpenLocalDir(string sDir) {
            try {
                System.Diagnostics.Process.Start(sDir);
            }
            catch (Exception) {

            }

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TMItemDel_Click(object sender, EventArgs e) {

            if (dgvTask.CurrentRow == null) {
                return;
            }
            string taskName = dgvTask.CurrentRow.Cells["colTaskName"].Value.ToString();
            MonitorTask.RemoveTask(taskName);
            LoadMonitorTask();
        }
    }
}

