using PreCheckSys.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreCheckSys.UI {
    public partial class ImportBaseData : Form {


         private string _destFilePath;
        public ImportBaseData() {
            InitializeComponent();
        }


        /// <summary>
        /// 检查CSV文件合法性
        /// </summary>
        /// <param name="selFileName"></param>
        /// <returns></returns>
        private bool CheckCSV(string selFileName) {
            bool res = false;
            try {
                CsvHelper csv = new CsvHelper(selFileName);
                DataTable dt = csv.csvDT;
                if (dt == null) {
                    res = false;
                }
                else {
                    tbLineName.Text = dt.Rows[0][0].ToString();
                    cbBoxUpDown.Text = dt.Rows[0][1].ToString();
                    //DataTable dataTableDistinct = dt.DefaultView.ToTable(true, "站区");
                    res = true;
                }
            }
            catch {
                res = false;
            }
            return res;
        }
        /// <summary>
        /// 选择导入的基础数据文件
        /// </summary> 
        private void btnSelBaseDataPath_Click(object sender, EventArgs e) {
            string fileFilter = "csv files (*.csv)|*.csv";//过滤选项设置，文本文件，所有文件。
            string title = "选择导入的基础数据文件";
            string sPath = FileHelper.OpenFile(title, fileFilter);
            if (!string.IsNullOrEmpty(sPath)) {

                try {
                    if (CheckCSV(sPath)) {
                        linkLblPath.Text = sPath;
                        string fileName = Path.GetFileNameWithoutExtension(sPath);
                        //int iUpDown = -1;
                        //int pos = fileName.IndexOf("上行");
                        //if (pos < 0) {
                        //    pos = fileName.IndexOf("下行");
                        //    iUpDown = 1;
                        //}
                        //else {
                        //    iUpDown = 0;
                        //}
                        //if (iUpDown != -1) {
                        //    tbLineName.Text = fileName;
                        //}
                        //else {
                        //    tbLineName.Text = fileName.Substring(0, pos);
                        //    cbBoxUpDown.SelectedIndex = iUpDown;
                        //}
                    }
                    else {
                        MessageBox.Show("导入的基础数据格式不正确");

                    }
                }
                catch {
                    MessageBox.Show("基础数据导入有误！");
                }

                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tbLineName.Text.Trim())) {
                MessageBox.Show("线路信息不能为空！");
                tbLineName.Select();
                return;
            }
            if (string.IsNullOrEmpty(cbBoxUpDown.Text.Trim())) {
                MessageBox.Show("请选择线路行别！");
                cbBoxUpDown.DroppedDown = true;

            }

            string destFileName = $"{System.Environment.CurrentDirectory}/DB/BaseData/{tbLineName.Text}_{cbBoxUpDown.Text}.csv)";
            try {
                FileInfo newFile = FileHelper.FileCopy(linkLblPath.Text.Trim(), destFileName, false);
                MessageBox.Show("导入的基础数据成功!");
            }
            catch (IOException) {
                MessageBox.Show("导入的基础数据文件已经存在！\n请核对后重新导入!");

            }
            catch (Exception ex) {
                MessageBox.Show("导入基础数据发生未知错误！\n" + ex.ToString());
            }
            
        }
    }
}
