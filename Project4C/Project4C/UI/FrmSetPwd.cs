using Project4C.Core;
using Project4C.DB;
using System;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmSetPwd : Form {
        private string DBName = "login";
        private SqliteHelper1 loginDB => SqliteHelper1.GetSqlite(DBName);
        public FrmSetPwd() {
            InitializeComponent();
            lblLoginID.Text = StationInfoP4.GetInstance().UId.ToString();
            lblName.Text = StationInfoP4.GetInstance().User;
        }
        private bool CheckAug() {
            string sSQL = string.Format("select UId from login where UId={0} and  uPwd='{1}'", lblLoginID.Text, ComClassLib.core.Crypto.DesEncrypt(txtbOldPwd.Text));

            return loginDB.ExecuteScalar(sSQL) != null;
        }
        private void btn_Save_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(lblLoginID.Text)) {
                return;
            }

            if (string.IsNullOrEmpty(txtbNewPwdA.Text)) {
                lblINfo.Text = @"新密码不能为空！";
                txtbNewPwdA.Focus();
                return;
            }
            if (txtbNewPwdA.Text != txtbNewPwdB.Text) {
                lblINfo.Text = @"两次新密码输入不相同！";
                txtbNewPwdB.Focus();
                txtbNewPwdB.SelectAll();
                return;
            }
            if (string.IsNullOrEmpty(txtbOldPwd.Text)) {
                lblINfo.Text = @"请输入旧密码！";
                txtbOldPwd.Focus();
                return;
            }
            try {

                if (!CheckAug()) {
                    lblINfo.Text = @"旧密码输入错误！";
                    txtbOldPwd.Focus();
                    txtbOldPwd.SelectAll();
                    return;
                }
                string strQuery = string.Format("update login set uPwd='{0}' where UId={1}",
                      ComClassLib.core.Crypto.DesEncrypt(txtbNewPwdB.Text), lblLoginID.Text);
                if (loginDB.ExecuteNonQuery(strQuery) == 0) {
                    //系统报错 
                    lblINfo.Text = @"未知的更新错误!";
                    return;
                }
                //否则 更新成功
                lblINfo.Text = @"密码修改成功!";

            } catch (Exception ex) {

                MessageBox.Show("数据库连接超时！\n错误详情："+ex.ToString());
            }
        }
    }
}
