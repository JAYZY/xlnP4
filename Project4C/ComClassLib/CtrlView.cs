using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComClassLib.core;
using FVIL.Forms;

namespace ComClassLib {
    public partial class CtrlView : UserControl {
        public CtrlView() {
            InitializeComponent();
        }
        private void IniView() {
            FigHandlingOverlay m_FigHandOverlay = new FigHandlingOverlay();
            imgView.Display.Overlays.Add(m_FigHandOverlay);
            m_FigHandOverlay.AddMouseEventHandler(imgView);
            imgView.MouseWheel += new System.Windows.Forms.MouseEventHandler(ImageView_MouseWheel);
            //imgView.MouseMove += new System.Windows.Forms.MouseEventHandler(ImgView_MouseMove);
            // imgView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(ImgView_MouseDoubleClick);
            // imgView.MouseDown += new System.Windows.Forms.MouseEventHandler(ImgView_MouseDown);
            // imgView.MouseUp += new System.Windows.Forms.MouseEventHandler(ImgView_MouseUp);
        }
        public void LoadImg(byte[] imgByte, uint uJpgSize, int iOffset) {
            imgView.Image = JpegCompress.Decompress(imgByte, uJpgSize, iOffset);
            double mag = imgView.Height * 1.0 / imgView.Display.ImageSize.Height;
            if (mag < 0.01) {
                return;
            }
            imgView.Display.Magnification = mag;
        }


        #region 鼠标事件

        /// <summary>
        /// 滚轮事件--图像放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ImageView_MouseWheel(object sender, MouseEventArgs e) {

            CFviImageView ImgV = (CFviImageView)sender;
            if (e.Delta > 0) {
                ImgV.Display.Magnification = ImgV.Display.Magnification * 1.2;
            }
            else if (e.Delta < 0) {
                ImgV.Display.Magnification = ImgV.Display.Magnification * 0.8;
            }

            ImgV.Refresh();

        }


        #endregion


    }
}
