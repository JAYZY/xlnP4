using DevComponents.DotNetBar.Controls;
using Project4C.Core;
using Project4C.Ctrl;
using Project4C.DB;
using Project4C.FileOp;
using Project4C.Properties;
using Project4C.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace Project4C {
    public partial class FrmMain : Form {

        #region 创建单实例对象
        private static FrmMain _frmParent;
        private static object _obj = new object();
        public static FrmMain GetInstance() {
            if (_frmParent == null) {
                lock (_obj) {
                    if (_frmParent == null) {
                        _frmParent = new FrmMain();
                    }
                }
            }
            return _frmParent;
        }
        private FrmMain() {
            InitializeComponent();

            sNavMenuSel.SelectedItem = sNavItemDBM;
            sTabCtrlDataSel.SelectedTab = superTabItem1;
            ipAddressInput.Value = Settings.Default.ServIP;


        }
        private SqliteHelper1 GetDB => SqliteHelper1.GetSqlite(Settings.Default.MDB);
        #endregion
        /// <summary>
        /// 窗体显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Shown(object sender, EventArgs e) {
            ChgCtrlEnable();
        }
        /// <summary>
        /// 改变化面板enable
        /// </summary>
        private void ChgCtrlEnable() {
            sNavItemAnalyse.Enabled = !sNavItemAnalyse.Enabled;
            sNavItemSet.Enabled = !sNavItemSet.Enabled;
            sNavItemReport.Enabled = !sNavItemReport.Enabled;

        }

        private bool isDataSetSuccess = false;


        private void sideNavItem3_Click(object sender, EventArgs e) {

        }

        public Bitmap ReadImg2Db(String imgPath) {
            // System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
            // sp.Reset();
            // sp.Start();
            Bitmap map = null;
            string imgName = Path.GetFileNameWithoutExtension(imgPath);
            try {
                FileStream fs = new FileStream(imgPath, FileMode.Open);
                byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imageBytes = br.ReadBytes(Convert.ToInt32(fs.Length));//图片转换成二进制流
                                                                      //DbOpe.insert(imgName, imageBytes);
                                                                      // m_dProcessTime = sp.ElapsedMilliseconds;
                                                                      //  sp.Stop();
                MemoryStream mStreamSeal = new MemoryStream(imageBytes);
                map = new Bitmap(Image.FromStream(mStreamSeal, true));
            } catch (Exception ex) {
                Console.WriteLine("Insert {0} is error;\n{1}", imgName, ex.Message);//显示异常信息
            }
            return map;
        }

        private void buttonX1_Click(object sender, EventArgs e) {
            (new FrmDBManage()).ShowDialog();
        }

        #region 任务选择(数据选择)

        #region 离线数据选择
        int iOffTaskInfoModifyType = 0;//0 -- 无操作 1--insert  2 -- update

        private void btnOpenDir_Click(object sender, EventArgs e) {
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
                    } else {
                        iOffTaskInfoModifyType = 1;
                    }

                    Properties.Settings.Default.lastDbDir = Path.GetDirectoryName(of.FileName);//获取目录路径
                    //数据选择成功
                    isDataSetSuccess = true;
                    Settings.Default.ViewMode = 0;//离线线模式
                }
            } catch (Exception ex) {
                isDataSetSuccess = false;
                MessageBox.Show("数据库打开失败！" + ex.ToString());
            }
        }

        private void btnTaskOk_Click(object sender, EventArgs e) {
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
            try {
                if (iOffTaskInfoModifyType == 1)//insert 
                {
                    StationInfoP4.GetInstance().TaskDate = dateTimeInput.Value;
                    StationInfoP4.GetInstance().SaveToDb();
                } else if (iOffTaskInfoModifyType == 2) {
                    StationInfoP4.GetInstance().TaskDate = dateTimeInput.Value;
                    StationInfoP4.GetInstance().UpdateDb();
                }
                sNavMenuSel.IsMenuExpanded = false;
                sNavMenuSel.SelectedItem = sNavItemAnalyse;
                ChgCtrlEnable();
                lblTaskInfo.Text = @"线路任务：" + StationInfoP4.GetInstance().GetDateStr() + "_" + StationInfoP4.GetInstance().LineName + "_" + StationInfoP4.GetInstance().StartStation + "-" + StationInfoP4.GetInstance().EndStation;
                lblTaskInfo.Visible = true;
            } catch (Exception ex) {
                MessageBox.Show("任务加载错误\n" + ex.ToString());
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
        /// 在线数据测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX3_Click(object sender, EventArgs e) {
            try {
                if (RedisHelper.GetInstance().SetRedisServer(ipAddressInput.Value)) {
                    Settings.Default.ServIP = ipAddressInput.Value;
                    Settings.Default.Save();
                    //MessageBox.Show("数据库连接成功！");                    
                    //FrmOnline ctrlDataAnalyse = new FrmOnline();
                    // ctrlDataAnalyse.Dock = DockStyle.Fill;
                    // sNavPanelDataAnalyse.Controls.Add(ctrlDataAnalyse);
                    sNavMenuSel.IsMenuExpanded = false;
                    sNavMenuSel.SelectedItem = sNavItemAnalyse;
                    ChgCtrlEnable();
                    Settings.Default.ViewMode = 1;//在线模式
                }
            } catch (Exception ex) {
                MessageBox.Show("数据库连接失败，请重试！" + ex.ToString());

            }
        }
        #endregion 
        #endregion

        private void sNavMenuSel_TabIndexChanged(object sender, EventArgs e) {

        }
        private void sNavItemDBM_Click(object sender, EventArgs e) {
            sNavItemAnalyse.Enabled = false;
            sNavItemSet.Enabled = false;
            sNavItemReport.Enabled = false;
        }
        private void sNavMenuSel_SelectedItemChanged(object sender, EventArgs e) {

            if (sNavMenuSel.SelectedItem == sNavItemAnalyse) {
                sNavPanelDataAnalyse.Controls.Add(FrmOnline.GetInstance());
            } else if (sNavMenuSel.SelectedItem == sNavItemReport) {
                CtrlReport report = new CtrlReport(null);
                sNavPanelReport.Controls.Add(report);
                report.Dock = DockStyle.Fill;
            }

        }

        private void sideNavPanel3_Paint(object sender, PaintEventArgs e) {

        }

        private void cbTaskInfo_TextChanged(object sender, EventArgs e) {
            ComboBoxEx cbBox = (ComboBoxEx)sender;
            string sTxt = cbBox.Text.Trim();
            StationInfoP4 stationInfo = StationInfoP4.GetInstance();
            switch (cbBox.Name) {
                case "cbBoxLineInfo":
                    stationInfo.LineName = sTxt;
                    break;
                case "cbBoxStartStation":
                    stationInfo.StartStation = sTxt;
                    break;
                case "cbBoxEndStation":
                    stationInfo.EndStation = sTxt;
                    break;
                case "this.cbBoxUpDown":
                    stationInfo.SType = sTxt;
                    break;
            }
            if (iOffTaskInfoModifyType == 1) {
                return;
            }
            iOffTaskInfoModifyType = 2;
        }

        private void btnImport_Click(object sender, EventArgs e) {
            lstDT = new List<DataTable>();
            progressBarX1.Visible = true;
            lblValue.Visible = true;
            new Thread(ImportImg).Start();
            new Thread(ThWriteImg).Start();
        }

        bool isBreak = false;
        List<DataTable> lstDT;
        int iImgCount = int.MaxValue;
        string sMainPath = "", strInfo = "";
        private void ChgProcess(int value, string sMsgTip) {
            if (progressBarX1.InvokeRequired) {
                Action<int, string> a = ChgProcess;
                progressBarX1.Invoke(a, value, sMsgTip);
            } else {
                progressBarX1.Value = value;
                lblValue.Text = value.ToString() + "%";
                lblTip.Text = sMsgTip;
            }
        }
        private void ImportImg() {
            this.Enabled = false;
            StationInfoP4 stationInfo = StationInfoP4.GetInstance();

            strInfo = stationInfo.GetDateStr() + "_" + stationInfo.LineName + "_" + stationInfo.SType + "_" + stationInfo.StartStation + "-" + stationInfo.EndStation;
            sMainPath = Path.Combine(lnkImportDir.Text, strInfo);
            //创建 主文件夹
            FileHelper1.CreateDir(sMainPath);
            //读取总的图像数目           
            iImgCount = Convert.ToInt32(GetDB.ExecuteScalar("select count(*) from picInfo"));

            //遍历，每次读取 1000，线程开启写图像
            int iOffLineDataIdx = 0;
            while (true) {
                string sSql = "select * from picInfo  Limit " + 1000 + " offset " + iOffLineDataIdx;
                DataTable dt = GetDB.ExecuteDataTable(sSql, null);
                iOffLineDataIdx += 1000;
                lstDT.Add(dt);
                if (dt.Rows.Count < 1000) {
                    isBreak = true;
                    break;
                }
            }
        }
        private void ThWriteImg() {
            int iInd = 0;
            string sZoneInfo = "", sPoleNum = "";
            //区间信息
            string sZonePath = sMainPath;
            //杆号信息
            string sPolePath = sMainPath;
            int iImgNum = 0;
            while (true) {
                if (iInd < lstDT.Count) {
                    foreach (DataRow row in lstDT[iInd].Rows) {
                        //区间识别
                        if (!row["STN"].ToString().Equals(sZoneInfo)) {
                            sZoneInfo = row["STN"].ToString();
                            sZonePath = Path.Combine(sMainPath, sZoneInfo);
                            FileHelper1.CreateDir(sZonePath);
                        }
                        //杆号识别
                        string sPNum = row["poleNum"].ToString().Replace(':', '-');
                        if (!sPNum.Equals(sPoleNum)) {
                            sPoleNum = sPNum;
                            sPolePath = Path.Combine(sZonePath, sPoleNum);
                            FileHelper1.CreateDir(sPolePath);
                        }
                        string sImgName = row["shootTime"].ToString() + "-" + row["cId"].ToString() + ".jpg";
                        FileHelper1.ImgToFile(Path.Combine(sPolePath, sImgName), (byte[])row["imgContent"]);
                        //修改进度条
                        ChgProcess((int)(++iImgNum / (1.0 * iImgCount) * 100), string.Format("导出 [{0}]-[{1}] 图像 {2}", sZoneInfo, sPoleNum, sImgName));
                    }
                    lstDT[iInd].Clear();
                    ++iInd;
                } else if (isBreak) {
                    if (iImgNum >= iImgCount) {
                        ChgProcess(100, "一杆一档图像导出成功！");
                        MessageBox.Show("一杆一档图像导出成功！");
                        break;
                    }
                } else {
                    ChgProcess((int)(iImgNum / (1.0 * iImgCount) * 100), "等待导出图像数据...");
                }
            }
            this.Enabled = true;
        }

        private void lnkDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e) {
            FolderBrowserDialog of = new FolderBrowserDialog();
            try {
                of.Description = "请选择导出图像文件夹";
                if (of.ShowDialog() == DialogResult.OK) {
                    lnkImportDir.Text = of.SelectedPath;
                }
            } catch (Exception) {

            }
        }
    }
}
