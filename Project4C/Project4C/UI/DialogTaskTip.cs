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
    public partial class DialogTaskTip : Form {
        private static int iValue = 0;

        #region 创建单实例对象

        private static DialogTaskTip _dialogTaskTip;
        private static object _obj = new object();

        public static DialogTaskTip GetInstance() {
            if (_dialogTaskTip == null) {
                lock (_obj) {
                    if (_dialogTaskTip == null)
                        _dialogTaskTip = new DialogTaskTip();
                }
            }
            return _dialogTaskTip;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DialogTaskTip() {
            InitializeComponent();
            iValue = 0;
        }
        #endregion

        public void SetTipTxt(string tipTxt) {
            lblTip.Text = tipTxt.Trim();
        }


        private void DialogTaskTip_Shown(object sender, EventArgs e) {

            timer1.Start();
        }

        public bool IsRunning { get; set; }

        public void SetValue() {
            if (circularProgress1.InvokeRequired) {
                circularProgress1.IsRunning = false;
                Action a = SetValue;
                circularProgress1.Invoke(a);
            }
            else {
                if (iValue > 100)
                    iValue = 0;
                else if (iValue < 0) {
                    iValue = 0;
                    Hide();

                }
                circularProgress1.Value = iValue;

            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            ++iValue;
            SetValue();
        }
        public void EndProc() {
            iValue = -100;
        }

    }}
