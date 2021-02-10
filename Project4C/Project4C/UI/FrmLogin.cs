using ComClassLib.core;
using ComClassLib.DB;
using DevComponents.DotNetBar;
using Project4C.Core;
using Project4C.DB;
using Project4C.FileOp;
using Project4C.Properties;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmLogin : OfficeForm {
        private bool isLogin;
        private string DBName = "login";
        private SqliteHelper loginDB => SqliteHelper.GetSqlite(DBName);

        public FrmLogin() {
            InitializeComponent();

            CheckDB();
            Ini();
            isLogin = false;
        }
        private void Ini() {
            DataTable dt = loginDB.ExecuteDataTable("select * from login", null);
            foreach (DataRow row in dt.Rows) {
                cbLoginName.Items.Add(row["uName"].ToString());
            }
            cbLoginName.SelectedIndex = 0;
        }
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e) {
            if (isLogin) {
                return;
            }
            if (MessageBox.Show(@"确定退出4C智能分析系统！", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) {
                e.Cancel = true;
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e) {
            if (!isLogin) {
                Application.Exit();
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            isLogin = CheckAug();
            if (isLogin) {
                this.Close();
            }
            else {
                MessageBox.Show("用户名或密码错误！");
                txtB_PWD.Focus();
                txtB_PWD.SelectAll();
            }

        }
        private bool CheckAug() {
            string pwd = ComClassLib.core.Crypto.DesEncrypt(txtB_PWD.Text);
            string sSQL = $"select UId from login where uName='{cbLoginName.Text}' and  uPwd='{pwd}'";
            object dt = loginDB.ExecuteScalar(sSQL);
            bool res = false;
            if (dt != null) {
                StationInfo.UId = Convert.ToInt32(dt);
                StationInfo.User = cbLoginName.Text;
                res = true;
            }
            return res;
        }

        #region 登录数据库 加密
        private void CheckDB() {
            string dbPath = Path.Combine(System.Environment.CurrentDirectory, "data");
            string dbFilePath = Path.Combine(dbPath, "login.db");
            if (!System.IO.File.Exists(dbFilePath)) {
                ComClassLib.FileOp.FileHelper.CreateDir(dbPath);
                //不存在文件
                SqliteHelper.CreateDbWithPwd(dbFilePath, Settings.Default.dbPwd);
                SqliteHelper.GenerateSqlite(DBName, dbFilePath, Settings.Default.dbPwd);

                string sTable = "create table login(uId INTEGER primary key AUTOINCREMENT, uName varchar(50) not null," +
                    "uPwd  varchar(100) not null,loginDatetime  datetime NOT NULL DEFAULT(datetime('now', 'localtime')))";

                loginDB.ExecuteNonQuery(sTable, null);
                string sPWd = ComClassLib.core.Crypto.DesEncrypt("123");
                string sql = $"insert into login (uName,uPwd) values( 'admin','{sPWd}')";
                loginDB.ExecuteNonQuery(sql, null);


            }
            else {//存在文件 -- open
                SqliteHelper.GenerateSqlite(DBName, dbFilePath, Settings.Default.dbPwd);
            }
        }
        #endregion
    }
}
