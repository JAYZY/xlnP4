using DevComponents.DotNetBar;
using PreCheckSys.core;
using PreCheckSys.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreCheckSys.UI {
    public partial class VideoControl : Form {

        private ComClassLib.CtrlView imageView;

        enum CameraParam {
            Gain, //增益 0.0-30.0
            Exposure, //曝光时间  60u
            FocusMinus, //聚焦  默认200 <1000
            FocusPlus,
            LEDWidth,
            EnableLED,
            FrameRate, //帧率 0.5~12.0  
            TriggerMode, //0 不   1-触发（使能）
            MoveUp,   //跟值 >1 <100
            MoveDown,
            MoveLeft,
            MoveRight,
            MoveStop,
            MoveTo,    //预置位 1~16
            SetPos,   // 将当前 位置设置为预置位
            RemovePos,  //1 。
            ShutDown,
            Restart
        }
        string[] arrParam = { "Gain", "Exposure", "FocusMinus", "FocusPlus", "LEDWidth", "EnableLED", "FrameRate", "TriggerMode", "MoveUp", "MoveDown", "MoveLeft", "MoveRight", "MoveStop", "MoveTo", "SetPos", "RemovePos", "ShutDown", "Restart" };
        CameraParam param;
        string sParamValue;
        private IntPtr _hDec;
        private string _ipAddress;
        private int _iPort;
        private System.Windows.Forms.Timer timerDisplay;
        public VideoControl(string ipAddress) {

            InitializeComponent();
            this.Text = "相机调试" + ipAddress;
            _hDec = IntPtr.Zero;
            _ipAddress = ipAddress;
            _iPort = Settings.Default.videoPort;
            imageView = new ComClassLib.CtrlView();
            this.Controls.Add(imageView);
            imageView.Dock = DockStyle.Fill;
            sBtnDisplay.Value = true;
        }
        public void Display() {
            if (_hDec == IntPtr.Zero) {
                _hDec = VideoM.Connection(_ipAddress, _iPort);
                if (_hDec != IntPtr.Zero) {
                    timerDisplay = new Timer();
                    this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
                    timerDisplay.Interval = 200;
                    StartDisplay();
                }
                else {
                    MessageBox.Show("相机打开出现异常，请检查！");
                }
            }
        }

        #region 显示控制
        private void StartDisplay() {
            timerDisplay.Start();
        }
        private void StopDisplay() {
            if (timerDisplay != null)
                timerDisplay.Stop();
        }
        #endregion


        private void timerDisplay_Tick(object sender, EventArgs e) {
            long lTime = 0; int ih = 0, iw = 0;

            VideoM.LoadImg(imageView, _hDec, ref iw, ref ih, ref lTime);
            // picVideo.Image = VideoM.GetImg(_hDec, ref iw, ref ih, ref lTime);
            lblCameraInfo.Text = VideoM.GetCameraParam(_hDec);



        }
        #region 参数设置
        /// <summary>
        /// FPS值(帧率)参数设置
        /// </summary>
        private void dInputFPS_ValueChanged(object sender, EventArgs e) {
            // SetBtnPos(dInputFPS.Location, dInputFPS.Width);
            btnSetFPSOk.Location = new Point(dInputFPS.Location.X + dInputFPS.Width + 3, dInputFPS.Location.Y);
            btnSetFPSOk.Visible = true;
            param = CameraParam.FrameRate;
            sParamValue = dInputFPS.Value.ToString();
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        private void dInputExposure_ValueChanged(object sender, EventArgs e) {
            SetBtnPos(dInputExposure.Location, dInputExposure.Width);
            param = CameraParam.Exposure;
            sParamValue = dInputExposure.Value.ToString();
        }




        /// <summary>
        /// 修改增益
        /// </summary>
        private void iInputGain_ValueChanged(object sender, EventArgs e) {
            SetBtnPos(iInputGain.Location, iInputGain.Width);
            param = CameraParam.Gain;
            sParamValue = iInputGain.Value.ToString();
        }

        /// <summary>
        /// 查找预置位
        /// </summary>
        private void btnCameraPosView_Click(object sender, EventArgs e) {
            Point p = new Point(panelPos.Location.X + iInputCameraPos.Location.X, panelPos.Top + iInputCameraPos.Top + iInputCameraPos.Height);
            dgvCameraPos.Location = p;
            dgvCameraPos.Visible = !dgvCameraPos.Visible;
            btnCameraPosView.Image = dgvCameraPos.Visible ? Image.FromFile("img\\hideTB.png") : Image.FromFile("img\\showTB.png");
        }
        /// <summary>
        /// 设置是否触发-使能
        /// </summary>
        private void sBtnTriggerMode_ValueChanged(object sender, EventArgs e) {
            //SetBtnPos(iInputGain.Location, iInputGain.Width);
            param = CameraParam.TriggerMode;
            sParamValue = sBtnTriggerMode.Value ? "true" : "false";
            SetCameraParam();
        }


        #region 聚焦控制

        int _maxFocus = 79000;
        int _minFocus = 1000;
        /// <summary>
        /// 聚焦增加
        /// </summary> 
        private void btnFocusPlus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrValue.Value + iInputChgValue.Value;
            if (currValue > _maxFocus) {
                MessageBox.Show("聚焦调整超过最大值：" + _maxFocus);
                return;
            }
            param = CameraParam.FocusMinus;
            sParamValue = iInputChgValue.Value.ToString();
            iInputCurrValue.Value = currValue;
            SetCameraParam();
        }
        /// <summary>
        /// 聚焦减少
        /// </summary> 
        private void btnFocusMinus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrValue.Value - iInputChgValue.Value;
            if (currValue < _maxFocus) {
                MessageBox.Show("聚焦调整小于最小值：" + _minFocus);
                return;
            }
            param = CameraParam.FocusMinus;
            sParamValue = iInputChgValue.Value.ToString();
            iInputCurrValue.Value = currValue;
            SetCameraParam();
        }
        #endregion

        #region 云台控制 

        bool isLongAction = false; bool isfinish = false;
        private void btn_MouseDown(object sender, MouseEventArgs e) {
            ButtonX btn = (ButtonX)sender;
            switch (btn.Name) {
                case "btnUP":
                    param = CameraParam.MoveUp;
                    break;
                case "btnDown":
                    param = CameraParam.MoveDown;
                    break;
                case "btnLeft":
                    param = CameraParam.MoveLeft;
                    break;
                case "btnRight":
                    param = CameraParam.MoveRight;
                    break;
            }

            sParamValue = iInputMoveValue.Value.ToString();
            SetCameraParam();
            isfinish = false;
            isLongAction = true;
            timer1.Interval = 100;  //按下鼠标 发送动的指令。 100毫秒后如果鼠标放开 则 发送停止，否则
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            if (!isLongAction) {
                param = CameraParam.MoveStop;
                sParamValue = "";
                SetCameraParam();
            }
            isfinish = true;
            timer1.Stop();

        }
        private void timer2_Tick(object sender, EventArgs e) {

        }

        private void btn_MouseUp(object sender, MouseEventArgs e) {
            if (isfinish) {
                param = CameraParam.MoveStop;
                sParamValue = "";
                SetCameraParam();
                isLongAction = false;
            }
        }
        /// <summary>
        /// 云台向上移动--- 一直动直到stop
        /// </summary>
        private void btnUP_Click(object sender, EventArgs e) {
            param = CameraParam.MoveUp;
            sParamValue = "5";
            SetCameraParam();
        }




        /// <summary>
        /// 云台向左移动--- 一直动直到stop
        /// </summary>

        private void btnLeft_Click(object sender, EventArgs e) {
            param = CameraParam.MoveLeft;
            sParamValue = "5";
            SetCameraParam();
        }
        /// <summary>
        /// 云台向右移动--- 一直动直到stop
        /// </summary>
        private void btnRight_Click(object sender, EventArgs e) {
            param = CameraParam.MoveRight;
            sParamValue = "5";
            SetCameraParam();
        }
        /// <summary>
        /// 云台向左移动--- 一直动直到stop
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e) {
            param = CameraParam.MoveDown;
            sParamValue = "5";
            SetCameraParam();
        }
        private void btnStop_Click(object sender, EventArgs e) {
            param = CameraParam.MoveStop;
            sParamValue = "";
            SetCameraParam();
        }

        #endregion

        #region 确定相机参数
        /// <summary>
        /// 设置确定按钮位置
        /// </summary>
        private void SetBtnPos(Point location, int Width) {
            btnSetParamOk.Location = new Point(location.X + Width + 3, location.Y);
            btnSetParamOk.Visible = true;

        }
        /// <summary>
        /// 确定按钮点击 设置相机参数
        /// </summary>
        private void btnSetParamOk_Click(object sender, EventArgs e) {
            SetCameraParam();
            btnSetParamOk.Visible = false;

        }
        private void btnSetFPSOk_Click(object sender, EventArgs e) {
            SetCameraParam();
            btnSetFPSOk.Visible = false;
        }
        /// <summary>
        /// 设置相机参数
        /// </summary>
        private void SetCameraParam() {
            string str = "{\"" + param.ToString() + "\":" + sParamValue + "}";
            bool re = VideoM.SetRPCParam(_hDec, 0, str);
            ToastNotification.Show(this, param.ToString() + "参数设置成功！");

        }

        #endregion

        #endregion

        private void sBtnDisplay_ValueChanged(object sender, EventArgs e) {
            if (sBtnDisplay.Value) {
                Display();
            }
            else { StopDisplay(); }
        }

        #region 预置位设置
        /// <summary>
        /// 移动到预置位
        /// </summary>
        private void btnMoveTo_Click(object sender, EventArgs e) {
            param = CameraParam.MoveTo;
            sParamValue = iInputCameraPos.Value.ToString();
            SetCameraParam();
        }
        /// <summary>
        /// 设置预置位
        /// </summary>

        private void btnSetPos_Click(object sender, EventArgs e) {
            param = CameraParam.SetPos;
            sParamValue = iInputCameraPos.Value.ToString();
            SetCameraParam();
        }





        #endregion

        private void VideoControl_FormClosed(object sender, FormClosedEventArgs e) {
            VideoM.CloseRPC(_hDec); _hDec = IntPtr.Zero;
        }
    }

}
