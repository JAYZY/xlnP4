using ComClassLib.core;
using ComClassLib.FileOp;
using Project4C.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmImportImg : Form {
        struct ExImgInfo {

        }
        // private SqliteHelper1 GetDB => SqliteHelper1.GetSqlite(Settings.Default.MDB);
        OffLineOp _offLineOp;
        public FrmImportImg(OffLineOp offLineOp) {
            InitializeComponent();
            _offLineOp = offLineOp;
        }

        private void btnOpenDir_Click(object sender, EventArgs e) {
            FolderBrowserDialog of = new FolderBrowserDialog();
            try {
                of.Description = @"请选择导出图像文件夹";
                if (of.ShowDialog() == DialogResult.OK) {
                    lnkImportDir.Text = of.SelectedPath;
                }
            } catch (Exception) {

            }
        }

        private void lnkDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
        bool isBreak = false;
        List<DataRow> lstDT;
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
        private void SetRunState(bool isrun) {
            if (this.InvokeRequired) {
                Action<bool> a = SetRunState;
                this.Invoke(a, isrun);
            } else {
                this.Enabled = !isrun;
            }
        }


        private void btnImport_Click(object sender, EventArgs e) {
            lstDT = new List<DataRow>();
            progressBarX1.Visible = true;
            lblValue.Visible = true;
            this.Enabled = false;
            new Thread(ImportImg).Start();
            new Thread(ThWriteImg).Start();
        }
        private void ImportImg() {

            StationInfo stationInfo = _offLineOp.Station;

            strInfo = stationInfo.GetDateStr() + "_" + stationInfo.LineName + "_" + stationInfo.SType + "_" + stationInfo.StartStation + "-" + stationInfo.EndStation;
            sMainPath = Path.Combine(lnkImportDir.Text, strInfo);
            //创建 主文件夹
            FileHelper.CreateDir(sMainPath);
            //读取总的图像数目           
            iImgCount = _offLineOp.GetTotalImgNum();
            string sSql = "select * from picInfoInd";
            DataTable dt = _offLineOp.IndDb.ExecuteDataTable(sSql, null);

            for (int i = 0; i < dt.Rows.Count; ++i) {
                var row = dt.Rows[i];
                //查询分库获取图像
                ComClassLib.DB.SqliteHelper currDB = _offLineOp.GetSubDB(row["SubDBId"].ToString());
                DataTable imgDt = currDB.ExecuteDataTable($"select * from imgInfo where imgGUID={row["imgGUID"].ToString()}");
                if (imgDt == null || imgDt.Rows.Count == 0) {
                    --iImgCount;
                    continue;
                }
                lstDT.Add(imgDt.Rows[0]);

            }
            isBreak = true;

        }
        private void ThWriteImg() {
            int iInd = 0;
            string sZoneInfo = "", sPoleNum = "";
            //区间信息
            string sZonePath = sMainPath;
            //杆号信息
            string sPolePath = sMainPath;
            //STN  poleNum  shootTime  cId imgContent

            string sJson = null; PicInfo picInfo = null;
            int iImgNum = 0;

            while (true) {
                if (iImgNum < lstDT.Count) {
                    DataRow row = lstDT[iImgNum];
                    sJson = row["sJson"].ToString();
                    picInfo = JsonHelper.GetModel<PicInfo>(sJson);
                    //区间识别
                    if (!picInfo.STNUTF.Equals(sZoneInfo)) {
                        sZoneInfo = picInfo.STNUTF;
                        sZonePath = Path.Combine(sMainPath, sZoneInfo);
                        FileHelper.CreateDir(sZonePath);
                    }
                    //杆号识别
                    string sPNum = picInfo.POL.Replace(':', '-');
                    if (!sPNum.Equals(sPoleNum)) {
                        sPoleNum = sPNum;
                        sPolePath = Path.Combine(sZonePath, sPoleNum);
                        FileHelper.CreateDir(sPolePath);
                    }
                    string sImgName = picInfo.TIM.ToString() + "-" + picInfo.CID.ToString() + ".jpg";
                    FileHelper.ImgToFile(Path.Combine(sPolePath, sImgName), (byte[])row["imgContent"]);
                    lstDT[iImgNum].Delete();
                    //修改进度条
                    ChgProcess((int)(++iImgNum / (1.0 * iImgCount) * 100), string.Format("导出 [{0}]-[{1}] 图像 {2}", sZoneInfo, sPoleNum, sImgName));

                     
                } else if (isBreak) {
                    if (iImgNum >= iImgCount) {
                        ChgProcess(100, "一杆一档图像导出成功！");
                        ComClassLib.MsgBox.Show("一杆一档图像导出成功！");
                        break;
                    }
                } else {
                    ChgProcess((int)(iImgNum / (1.0 * iImgCount) * 100), "等待导出图像数据...");
                }
            }
            SetRunState(true);
        }

    }
}
