using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRPC {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e) {
            var hDec = DllLib.OpenRPC(ipAddressInput1.Value);
            // DllLib.CloseRPC(IntPtr.Zero);
             richTextBox1.Text = hDec.ToString();
            char[] jpg_buffer = new char[100000000];
            IntPtr pImageData=IntPtr.Zero;
            unsafe {
                fixed (void* p = &jpg_buffer[0]) {
                    pImageData = (IntPtr)p;// +8*sizeof(byte);               
                }
            }
             int s = DllLib.GetRpcImage(hDec, 0, pImageData);
           
            for (int i = 0; i < 100; i++) {
                richTextBox1.AppendText("s "+ s.ToString()+"\n" +jpg_buffer[i].ToString()+" s ");
            }

            string str = DllLib.GetRpcInfo(hDec, 0);
            richTextBox1.AppendText("\n" + str.ToString() + " \n");
        }
    }
}
