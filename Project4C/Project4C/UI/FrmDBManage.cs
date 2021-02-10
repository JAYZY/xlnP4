using Project4C.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmDBManage : Form {
        public FrmDBManage() {
            InitializeComponent();
        }

        private void btnOpenDir_Click(object sender, EventArgs e) {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            try {
                if (fdb.ShowDialog() == DialogResult.OK) {
                    lblImgPath.Text = fdb.SelectedPath.ToString();
                }
            }
            catch (Exception) {

                throw;
            }

        }
        private void btnSelDBDir_Click(object sender, EventArgs e) {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            if (fdb.ShowDialog() == DialogResult.OK) {
                string path = fdb.SelectedPath;
                tbDBFullName.Text = path;

            }
        }
        //btnEvent--插入图片
        private void btnInsertImg_Click(object sender, EventArgs e) {
            SqliteHelper1.date = tbDate.Text.Trim();
            SqliteHelper1.lineName = tbLineName.Text.Trim();

            //遍历文件夹
            List<string> files = new List<string>();

            Director(lblImgPath.Text, ref files);
           // SqliteHelper.Insert(files);

        }
        //遍历文件夹（包括子文件夹）图片并插入数据库
        private void Director(string dir, ref List<string> files) {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos) {
                // SqliteHelper.BeginTransaction();
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹
                {
                    Director(fsinfo.FullName, ref files);//递归调用
                }
                else {
                    if (fsinfo.Extension == ".jpg")
                        files.Add(fsinfo.FullName);
                    //Console.WriteLine(fsinfo.FullName);//输出文件的全部路径
                }
            }


        }

        //btnEvent--创建数据库
        private void btnCreateDB_Click(object sender, EventArgs e) {
           // SqliteHelper.CreateDB(tbDBFullName.Text);
            MessageBox.Show("数据库：" + tbDBFullName.Text + " 创建成功！");
        }

        private void lblImgPath_Click(object sender, EventArgs e) {

        }
    }
}
