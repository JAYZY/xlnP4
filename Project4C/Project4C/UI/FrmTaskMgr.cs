using ComClassLib;
using ComClassLib.FileOp;
using DevComponents.DotNetBar;
using Project4C.Core;
using Project4C.DB;
using Project4C.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmTaskMgr : OfficeForm {
        OffLineOp _offLineOp;


        public FrmTaskMgr() {
            InitializeComponent();
            this.SetPanelInfoVisible = false;
            btnSelOffline.Parent = pictureBox1;
            btnSelOnline.Parent = pictureBox1;
            _offLineOp = null;
            lblDBPath.Text = "";

        }
        //属性--设置面板的可见性
        public bool SetPanelInfoVisible {
            set {
                panelInfo.Visible = value; superTabItem1.Visible = true;
                superTabItem2.Visible = true;
            }
        }

        public bool isDataSetSuccess { get; private set; }


        #region 任务选择(数据选择)

        #region 离线数据选择
        int iOffTaskInfoModifyType = 0;//0 -- 无操作 1--insert  2 -- update

        private void btnOpenDir_Click(object sender, EventArgs e) {
            OffLineDBSel();
        }
        /// <summary>
        /// 离线数据库文件选择
        /// </summary>
        private void OffLineDBFileSel() {
            OpenFileDialog of = new OpenFileDialog();
            try {
                of.InitialDirectory = Properties.Settings.Default.lastDbDir;
                if (of.ShowDialog() == DialogResult.OK) {
                    lblDBPath.Text = of.FileName;
                    //更新主要数据库
                    SqliteHelper1.GenerateSqlite(Settings.Default.MDB, lblDBPath.Text.Trim());
                    //创建点击信息表
                    CheckClickInfo();
                    StationInfoP4 stationInfo = StationInfoP4.GetInstance();
                    bool res = stationInfo.QueryFromDb();
                    if (res) {
                        cbBoxStartStation.Text = stationInfo.StartStation;
                        cbBoxEndStation.Text = stationInfo.EndStation;
                        cbBoxLineInfo.Text = stationInfo.LineName;
                        cbBoxUpDown.Text = stationInfo.SType;
                        dateTimeInput.Value = stationInfo.TaskDate;
                        iOffTaskInfoModifyType = 0;
                        FrmParent.GetInstance().LblTaskInfoTxt = @"线路任务：" + StationInfoP4.GetInstance().GetDateStr() + "_" + StationInfoP4.GetInstance().LineName + "_" + StationInfoP4.GetInstance().StartStation + "-" + StationInfoP4.GetInstance().EndStation;
                    }
                    else {
                        cbBoxStartStation.Text = "";
                        cbBoxEndStation.Text = "";
                        cbBoxLineInfo.Text = "";
                        cbBoxUpDown.Text = "";
                        dateTimeInput.Value = DateTime.Now;
                        iOffTaskInfoModifyType = 1;
                        FrmParent.GetInstance().LblTaskInfoTxt = @"线路任务：[无]";
                    }

                    Properties.Settings.Default.lastDbDir = Path.GetDirectoryName(of.FileName);//获取目录路径
                    //数据选择成功
                    isDataSetSuccess = true;
                    Settings.Default.ViewMode = 0;//离线线模式
                }
            }
            catch (Exception ex) {
                isDataSetSuccess = false;
                MessageBox.Show("数据库打开失败！" + ex.ToString());
            }
        }

        /// <summary>
        /// 离线数据文件选择
        /// </summary>
        private void OffLineDBSel() {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = Settings.Default.lastDbDir;
            folder.Description = "选择离线数据目录";
            if (folder.ShowDialog() == DialogResult.OK) {
                Settings.Default.ViewMode = 0;//离线模式
                string sPath = folder.SelectedPath;
                _offLineOp = new OffLineOp(sPath);
                lblDBPath.Text = sPath;
                ComClassLib.core.StationInfo stationInfo = _offLineOp.Station;
                cbBoxStartStation.Text = stationInfo.StartStation;
                cbBoxEndStation.Text = stationInfo.EndStation;
                cbBoxLineInfo.Text = stationInfo.LineName;
                cbBoxUpDown.Text = stationInfo.SType;
                dateTimeInput.Value = stationInfo.TaskDate;
                iOffTaskInfoModifyType = 0;
                FrmParent.GetInstance().LblTaskInfoTxt = @"线路任务：" + stationInfo.GetDateStr() + "_" + stationInfo.LineName + "_" + stationInfo.StartStation + "-" + stationInfo.EndStation;
                Settings.Default.lastDbDir = sPath;
                Settings.Default.Save();
            }

        }


        private void btnTaskOk_Click(object sender, EventArgs e) {
            if (_offLineOp == null) {
                MsgBox.Error("请选择离线数据！");
                return;
            }

            try {
               // FrmParent.GetInstance().LblTaskInfoTxt = @"线路任务：" + StationInfoP4.GetInstance().GetDateStr() + "_" + StationInfoP4.GetInstance().LineName + "_" + StationInfoP4.GetInstance().StartStation + "-" + StationInfoP4.GetInstance().EndStation;
                FrmParent.GetInstance().ShowDataAnalyze(_offLineOp);
            }
            catch (Exception ex) {
                MessageBox.Show("任务加载错误\n" + ex.ToString());
            }

        }
        //旧方法中的检测-【停用】
        private void checkSel() {
            
            if (string.IsNullOrEmpty(lblDBPath.Text.Trim())) {
                MessageBox.Show("数据库路径设置不正确！");
            }
            if (!isDataSetSuccess) {
                MessageBox.Show(this, "请检查数据任务！", "任务选择错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cbBoxLineInfo.Text.Trim())) {
                MessageBox.Show(this, "线路信息不能为空！", "请完善信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbBoxLineInfo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbBoxStartStation.Text.Trim())) {
                MessageBox.Show(this, "起始站点不能为空！", "请完善信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbBoxStartStation.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbBoxEndStation.Text.Trim())) {
                MessageBox.Show(this, "终止站点不能为空！", "请完善信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbBoxEndStation.Focus();
                return;
            }
        }
        //创建点击信息表
        private void CheckClickInfo() {
            if (!SqliteHelper1.GetSqlite(Settings.Default.MDB).IsTableExist("processedInfo")) {
                string sSql = "create table  processedInfo(pInfoId INTEGER primary key AUTOINCREMENT,imgGUID int64 not null,clickUser varchar(50))";
                SqliteHelper1.GetSqlite(Settings.Default.MDB).ExecuteNonQuery(sSql);
            }

        }

        #endregion
        #region 在线数据选择
        /// <summary>
        /// 在线数据 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnline_Click(object sender, EventArgs e) {
            LoginOnline();
        }
        private void LoginOnline() {
            try {
                sTabCtrlDataSel.SelectedTabIndex = 0;
                if (RedisHelper.GetInstance().SetRedisServer(ipAddressInput.Value)) {
                    Settings.Default.ServIP = ipAddressInput.Value;
                    Settings.Default.Save();
                    //MessageBox.Show("数据库连接成功！");                    
                    //FrmOnline ctrlDataAnalyse = new FrmOnline();
                    // ctrlDataAnalyse.Dock = DockStyle.Fill;
                    // sNavPanelDataAnalyse.Controls.Add(ctrlDataAnalyse);
                    Settings.Default.ViewMode = 1;//在线模式
                    FrmParent.GetInstance().ShowDataAnalyze(_offLineOp);
                }
            }
            catch (Exception) {
                MessageBox.Show("数据库服务器连接失败，请重试！");
                btnOnline.Text = "连接";
            }
        }
        #endregion

        #endregion

        private void FrmTaskMgr_Shown(object sender, EventArgs e) {
            this.SetPanelInfoVisible = false;
            btnSelOffline.Visible = btnSelOnline.Visible = true;
            ipAddressInput.Value = Settings.Default.ServIP;
            btnOnline.Text = "连接";

        }

        private void FrmTaskMgr_Resize(object sender, EventArgs e) {
            int x = (int)(0.5 * (this.Width - btnSelOnline.Width));
            int y = (int)(0.5 * (this.Height - btnSelOnline.Height));
            btnSelOnline.Location = new Point(x - 150, y);
            btnSelOffline.Location = new Point(x + 150, y);
        }

        private void FrmTaskMgr_ResizeEnd(object sender, EventArgs e) {

        }

        private void btnSelOnline_Click(object sender, EventArgs e) {
            btnSelOffline.Visible = btnSelOnline.Visible = false;
            this.SetPanelInfoVisible = true;
            btnOnline.Text = "连接中...";
            sTabCtlPanelOnline.Visible = true;
            superTabItem1.Visible = true;
            superTabItem2.Visible = false;
            LoginOnline();


        }

        private void btnSelOffline_Click(object sender, EventArgs e) {
            btnSelOffline.Visible = btnSelOnline.Visible = false;
            (new FrmLogin()).ShowDialog();
            this.SetPanelInfoVisible = true;
            Settings.Default.Save();
            superTabItem1.Visible = false;
            superTabItem2.Visible = true;
        }

        private void cbEnableModify_CheckedChanged(object sender, EventArgs e) {
            if (cbEnableModify.Checked) {
                cbEnableModify.Checked = false;
                ToastNotification.Show(panelInfo, "暂无修改任务信息的权限！");
            }
        }
    }
}
