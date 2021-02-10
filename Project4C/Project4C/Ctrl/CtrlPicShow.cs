using Project4C.Core;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project4C.Ctrl {
    public partial class CtrlPicShow : UserControl {
        public CtrlPicShow() {
            InitializeComponent();
            AddPicEvent += new AddPictCallback(AddPic);
            //picBox1.Click += new System.EventHandler(FrmMain.GetInstance().pic_Click);
            //picBox2.Click += new System.EventHandler(FrmMain.GetInstance().pic_Click);
            //picBox3.Click += new System.EventHandler(FrmMain.GetInstance().pic_Click);
            //picBox4.Click += new System.EventHandler(FrmMain.GetInstance().pic_Click);
        }
        delegate void AddPictCallback(int ind, Image p, DataRow dr, string sCameraNo);
        event AddPictCallback AddPicEvent;
        private void AddPic(int ind, Image img, DataRow dr, string sCameraNo) {
            switch (ind) {
                case 0:
                    if (picBox1.InvokeRequired) {
                        AddPictCallback d = new AddPictCallback(AddPic);
                        this.Invoke(d, new object[] { ind, img, dr, sCameraNo });
                    }
                    else {
                        picBox1.Image = img;
                        picBox1.Tag = dr;
                        lblPic1.Text = sCameraNo;
                    }
                    break;
                case 1:
                    if (picBox2.InvokeRequired) {
                        AddPictCallback d = new AddPictCallback(AddPic);
                        this.Invoke(d, new object[] { ind, img, dr, sCameraNo });
                    }
                    else {
                        picBox2.Image = img;
                        picBox2.Tag = dr;
                        lblPic2.Text = sCameraNo;
                    }
                    break;

                case 2:
                    if (picBox3.InvokeRequired) {
                        AddPictCallback d = new AddPictCallback(AddPic);
                        this.Invoke(d, new object[] { ind, img, dr, sCameraNo });
                    }
                    else {
                        picBox3.Image = img;
                        picBox3.Tag = dr;
                        lblPic3.Text = sCameraNo;
                    }
                    break;
                case 3:
                    if (picBox4.InvokeRequired) {
                        AddPictCallback d = new AddPictCallback(AddPic);
                        this.Invoke(d, new object[] { ind, img, dr, sCameraNo });
                    }
                    else {
                        picBox4.Image = img;
                        picBox4.Tag = dr;
                        lblPic4.Text = sCameraNo;
                    }
                    break;
            }
        }
        public void loadPic(object i, object d) {
            DataRow dr = (DataRow)d;
            int ind = (int)i;
            
           // MemoryStream mStreamSeal = new MemoryStream((byte[])dr["imgContent"]);
        //    Image x = Image.FromStream(mStreamSeal, true).GetThumbnailImage(70, 50, null, IntPtr.Zero);

            string sCameraNo = dr["shootTime"].ToString().Substring(17);
            AddPic(ind, (Image)JpgCompress.Decompress((byte[])dr["imgContent"]), dr, sCameraNo);
        }
        public void SetViewed(int ind) {
            switch (ind) {
                case 0:
                    lblPic1.BackColor = System.Drawing.SystemColors.Highlight;
                    break;
                case 1:
                    lblPic2.BackColor = System.Drawing.SystemColors.Highlight;
                    break;
                case 2:
                    lblPic3.BackColor = System.Drawing.SystemColors.Highlight;
                    break;
                case 3:
                    lblPic4.BackColor = System.Drawing.SystemColors.Highlight;
                    break;

            }
        }

        private void picBox_Click(object sender, EventArgs e) {
            PictureBox picBox = (PictureBox)sender;
            if (picBox.Tag == null) return;

            if (picBox.Name.Equals("picBox1"))
                lblPic1.BackColor = System.Drawing.SystemColors.Highlight;
            else if (picBox.Name.Equals("picBox2"))
                lblPic2.BackColor = System.Drawing.SystemColors.Highlight;
            else if (picBox.Name.Equals("picBox3"))
                lblPic3.BackColor = System.Drawing.SystemColors.Highlight;
            else
                lblPic4.BackColor = System.Drawing.SystemColors.Highlight;

        

        }
    }
}
