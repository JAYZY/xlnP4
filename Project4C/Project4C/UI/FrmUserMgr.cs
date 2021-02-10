using DevComponents.DotNetBar;
using Project4C.Core;
using Project4C.DB;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmUserMgr : OfficeForm {

        private DataTable dtLoginT;

        private string DBName = "login";
        private SqliteHelper1 LoginDB => SqliteHelper1.GetSqlite(DBName);
        public FrmUserMgr() {
            InitializeComponent();
            new Thread(Th_ReadLoginT).Start();
        }
        #region 读取登陆用户数据
        private void Th_ReadLoginT() {
            try {
                dtLoginT = LoginDB.ExecuteDataTable(@"select * from login", null);

                SynBindingDgv();
            } catch (Exception) {
                throw;
            }
        }

        private void SynBindingDgv() {
            if (dgvLoginT.InvokeRequired) {
                Action a = new Action(SynBindingDgv);
                dgvLoginT.BeginInvoke(a);
            } else {
                //IsFinishBinding = false;
                dgvLoginT.AutoGenerateColumns = false;
                dgvLoginT.DataSource = dtLoginT;

            }
        }

        #endregion

        //[按钮事件]--添加用户
        private void btn_addUser_Click(object sender, EventArgs e) {
           //  string sLoginId = lbl_loginId.Text.Trim();
            if (string.IsNullOrEmpty(txtB_Ry.Text.Trim())) {
                MessageBox.Show(@"请输入正确的用户名"); return;
            }
            string sPWd = ComClassLib.core.Crypto.DesEncrypt("123456");
            string strSql = string.Format("insert into login(uName,uPwd) values ('{0}','{1}')", txtB_Ry.Text, sPWd);
            LoginDB.ExecuteNonQuery(strSql);
            (new Thread(Th_ReadLoginT)).Start();
            ToastNotification.Show(this, @"用户添加成功");

            //lbl_loginId.Text = "";
            txtB_Ry.Text = "";
        }



        #region 菜单事件

        private void TSMenuItem_DeleteUser_Click(object sender, EventArgs e) {
            if (dtLoginT == null || dgvLoginT.CurrentRow == null) {
                return;
            }
            int iCurrentRowId = dgvLoginT.CurrentRow.Index;
            if (iCurrentRowId == -1) {
                return;
            }
            if (MessageBox.Show(@"确定删除用户：" + dtLoginT.Rows[iCurrentRowId]["uName"], @"删除警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                return;
            }
            string sID = dtLoginT.Rows[iCurrentRowId]["uId"].ToString();
            LoginDB.ExecuteNonQuery("delete  login where uId=" + sID);
            (new Thread(Th_ReadLoginT)).Start();
            ToastNotification.Show(this, @"用户删除成功");
        }

        private void TSMenuItem_ResetPWD_Click(object sender, EventArgs e) {
            if (dtLoginT == null || dgvLoginT.CurrentRow == null) {
                return;
            }

            int iCurrentRowId = dgvLoginT.CurrentRow.Index;
            if (iCurrentRowId == -1) {
                return;
            }
            string sUserName = dtLoginT.Rows[iCurrentRowId]["uPwd"].ToString();
            string sLoginId = dtLoginT.Rows[iCurrentRowId]["uId"].ToString();
            //默认密码是123456
            string sPWd = ComClassLib.core.Crypto.DesEncrypt("123456");
            string strSql = string.Format("update login set uPwd='{0}' where uId='{1}'", sPWd, sLoginId);
            LoginDB.ExecuteNonQuery(strSql, null);
            ToastNotification.Show(this, @"用户密码设置成功！");
        }
    }
    #endregion

}
