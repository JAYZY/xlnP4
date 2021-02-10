using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmGoPoleNum : Form {
        public string rtnStr;
           
        public FrmGoPoleNum(string startV,string endV) {
            InitializeComponent();
            lblTip.Text = $"转到支柱号({startV}-{endV}):";
            tbPoleNum.Text = rtnStr= startV;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            rtnStr = tbPoleNum.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            rtnStr = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
