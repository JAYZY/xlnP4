using PreCheckSys.Ctrl;
using System.Windows.Forms;

namespace PreCheckSys {
    //开启双缓冲

    partial class FrmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            DevComponents.Instrumentation.GaugeCircularScale gaugeCircularScale1 = new DevComponents.Instrumentation.GaugeCircularScale();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor1 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugePointer gaugePointer1 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection1 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor2 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor3 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugeText gaugeText1 = new DevComponents.Instrumentation.GaugeText();
            DevComponents.Instrumentation.GaugeText gaugeText2 = new DevComponents.Instrumentation.GaugeText();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemMin = new DevComponents.DotNetBar.ButtonItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerGlobal = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmItemDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBase = new DevComponents.DotNetBar.PanelEx();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.picCameraD = new System.Windows.Forms.PictureBox();
            this.picCameraC = new System.Windows.Forms.PictureBox();
            this.picCameraB = new System.Windows.Forms.PictureBox();
            this.picCameraA = new System.Windows.Forms.PictureBox();
            this.lblCameraInfo3D = new DevComponents.DotNetBar.LabelX();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.picAIServ = new System.Windows.Forms.PictureBox();
            this.labelX35 = new DevComponents.DotNetBar.LabelX();
            this.labelX34 = new DevComponents.DotNetBar.LabelX();
            this.lblSwitchInfo = new DevComponents.DotNetBar.LabelX();
            this.lblCameraInfoD = new DevComponents.DotNetBar.LabelX();
            this.lblCameraInfoC = new DevComponents.DotNetBar.LabelX();
            this.lblCameraInfoB = new DevComponents.DotNetBar.LabelX();
            this.lblCameraInfoA = new DevComponents.DotNetBar.LabelX();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.picSwitch = new System.Windows.Forms.PictureBox();
            this.picMainServ = new System.Windows.Forms.PictureBox();
            this.picCamera3D = new System.Windows.Forms.PictureBox();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.lblMainServ = new DevComponents.DotNetBar.LabelX();
            this.lblAIServ = new DevComponents.DotNetBar.LabelX();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblKMV = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenP4 = new DevComponents.DotNetBar.ButtonX();
            this.btnStopTask = new DevComponents.DotNetBar.ButtonX();
            this.btnTaskConfig = new DevComponents.DotNetBar.ButtonX();
            this.btnStartTask = new DevComponents.DotNetBar.ButtonX();
            this.lblTaskInfo = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelDiskInfo = new System.Windows.Forms.Panel();
            this.labelX28 = new DevComponents.DotNetBar.LabelX();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panelDiskIOInfo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX27 = new DevComponents.DotNetBar.LabelX();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.lblMemUsed = new System.Windows.Forms.Label();
            this.gaugeCtrlMemory = new DevComponents.Instrumentation.GaugeControl();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rTbTaskMsg = new System.Windows.Forms.RichTextBox();
            this.lblDelNum = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX38 = new DevComponents.DotNetBar.LabelX();
            this.lblServMem = new DevComponents.DotNetBar.LabelX();
            this.labelX37 = new DevComponents.DotNetBar.LabelX();
            this.lblSaveFaultNum = new DevComponents.DotNetBar.LabelX();
            this.lblSaveLocNum = new DevComponents.DotNetBar.LabelX();
            this.lblSaveImgNum = new DevComponents.DotNetBar.LabelX();
            this.labelX36 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.picSaveDataState = new System.Windows.Forms.PictureBox();
            this.picAIServState = new System.Windows.Forms.PictureBox();
            this.picTimeServState = new System.Windows.Forms.PictureBox();
            this.picRedisState = new System.Windows.Forms.PictureBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.lblDate = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelBase.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAIServ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainServ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera3D)).BeginInit();
            this.panel7.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelDiskInfo.SuspendLayout();
            this.panelDiskIOInfo.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeCtrlMemory)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panel10.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSaveDataState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAIServState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeServState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedisState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // labelItem1
            // 
            this.labelItem1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.labelItem1.ForeColor = System.Drawing.Color.White;
            this.labelItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.PaddingLeft = 30;
            this.labelItem1.Text = "接触悬挂检测系统总控平台";
            this.labelItem1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.labelItem1,
            this.btnItemMin});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1839, 41);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ImageFixedSize = new System.Drawing.Size(136, 32);
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // btnItemMin
            // 
            this.btnItemMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemMin.ForeColor = System.Drawing.Color.White;
            this.btnItemMin.Image = ((System.Drawing.Image)(resources.GetObject("btnItemMin.Image")));
            this.btnItemMin.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnItemMin.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnItemMin.Name = "btnItemMin";
            this.btnItemMin.Text = "最小化";
            this.btnItemMin.Tooltip = "最小化总控平台";
            this.btnItemMin.Click += new System.EventHandler(this.btnItemMin_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "redis(红).png");
            this.imageList1.Images.SetKeyName(1, "redis.png");
            this.imageList1.Images.SetKeyName(2, "存储.png");
            this.imageList1.Images.SetKeyName(3, "分析.png");
            this.imageList1.Images.SetKeyName(4, "关  闭.png");
            this.imageList1.Images.SetKeyName(5, "关机.png");
            this.imageList1.Images.SetKeyName(6, "开启.png");
            this.imageList1.Images.SetKeyName(7, "时钟_clock74.png");
            this.imageList1.Images.SetKeyName(8, "停止.png");
            this.imageList1.Images.SetKeyName(9, "新建.png");
            this.imageList1.Images.SetKeyName(10, "展示.png");
            this.imageList1.Images.SetKeyName(11, "最大化.png");
            this.imageList1.Images.SetKeyName(12, "最小化.png");
            // 
            // timerGlobal
            // 
            this.timerGlobal.Interval = 1000;
            this.timerGlobal.Tick += new System.EventHandler(this.timerGlobal_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "吊弦系统总控平台";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmItemDisplay,
            this.toolStripMenuItem1,
            this.tsmItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 54);
            // 
            // tsmItemDisplay
            // 
            this.tsmItemDisplay.Name = "tsmItemDisplay";
            this.tsmItemDisplay.Size = new System.Drawing.Size(150, 22);
            this.tsmItemDisplay.Text = "显示(&Display)";
            this.tsmItemDisplay.Click += new System.EventHandler(this.tsmItemDisplay_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // tsmItemExit
            // 
            this.tsmItemExit.Name = "tsmItemExit";
            this.tsmItemExit.Size = new System.Drawing.Size(150, 22);
            this.tsmItemExit.Text = "退出(&Exit)";
            this.tsmItemExit.Click += new System.EventHandler(this.tsmItemExit_Click);
            // 
            // panelBase
            // 
            this.panelBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBase.Controls.Add(this.panelCenter);
            this.panelBase.Controls.Add(this.panelLeft);
            this.panelBase.Controls.Add(this.panelRight);
            this.panelBase.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase.Location = new System.Drawing.Point(0, 41);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(1839, 1043);
            this.panelBase.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBase.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(161)))), ((int)(((byte)(150)))));
            this.panelBase.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(89)))), ((int)(((byte)(83)))));
            this.panelBase.Style.GradientAngle = 90;
            this.panelBase.TabIndex = 21;
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Black;
            this.panelCenter.Controls.Add(this.panel9);
            this.panelCenter.Controls.Add(this.panel8);
            this.panelCenter.Controls.Add(this.panel7);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(431, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(5);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Padding = new System.Windows.Forms.Padding(10);
            this.panelCenter.Size = new System.Drawing.Size(1048, 1043);
            this.panelCenter.TabIndex = 18;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.labelX7);
            this.panel9.Controls.Add(this.labelX5);
            this.panel9.Controls.Add(this.flowLayoutPanel14);
            this.panel9.Controls.Add(this.flowLayoutPanel13);
            this.panel9.Controls.Add(this.flowLayoutPanel12);
            this.panel9.Controls.Add(this.flowLayoutPanel11);
            this.panel9.Controls.Add(this.flowLayoutPanel10);
            this.panel9.Controls.Add(this.flowLayoutPanel9);
            this.panel9.Controls.Add(this.flowLayoutPanel2);
            this.panel9.Controls.Add(this.picCameraD);
            this.panel9.Controls.Add(this.picCameraC);
            this.panel9.Controls.Add(this.picCameraB);
            this.panel9.Controls.Add(this.picCameraA);
            this.panel9.Controls.Add(this.lblCameraInfo3D);
            this.panel9.Controls.Add(this.flowLayoutPanel1);
            this.panel9.Controls.Add(this.picAIServ);
            this.panel9.Controls.Add(this.labelX35);
            this.panel9.Controls.Add(this.labelX34);
            this.panel9.Controls.Add(this.lblSwitchInfo);
            this.panel9.Controls.Add(this.lblCameraInfoD);
            this.panel9.Controls.Add(this.lblCameraInfoC);
            this.panel9.Controls.Add(this.lblCameraInfoB);
            this.panel9.Controls.Add(this.lblCameraInfoA);
            this.panel9.Controls.Add(this.flowLayoutPanel3);
            this.panel9.Controls.Add(this.picSwitch);
            this.panel9.Controls.Add(this.picMainServ);
            this.panel9.Controls.Add(this.picCamera3D);
            this.panel9.Controls.Add(this.labelX20);
            this.panel9.Controls.Add(this.lblMainServ);
            this.panel9.Controls.Add(this.lblAIServ);
            this.panel9.Controls.Add(this.flowLayoutPanel7);
            this.panel9.Controls.Add(this.flowLayoutPanel15);
            this.panel9.Controls.Add(this.flowLayoutPanel5);
            this.panel9.Controls.Add(this.flowLayoutPanel8);
            this.panel9.Controls.Add(this.flowLayoutPanel4);
            this.panel9.Controls.Add(this.flowLayoutPanel6);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(10, 499);
            this.panel9.Margin = new System.Windows.Forms.Padding(10);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel9.Size = new System.Drawing.Size(1028, 534);
            this.panel9.TabIndex = 42;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this.labelX7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.labelX7.Location = new System.Drawing.Point(111, 110);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(66, 21);
            this.labelX7.TabIndex = 65;
            this.labelX7.Text = "————";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this.labelX5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.labelX5.Location = new System.Drawing.Point(41, 110);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(66, 21);
            this.labelX5.TabIndex = 64;
            this.labelX5.Text = "————";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX5.Click += new System.EventHandler(this.labelX5_Click);
            // 
            // flowLayoutPanel14
            // 
            this.flowLayoutPanel14.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel14.BackgroundImage")));
            this.flowLayoutPanel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel14.Location = new System.Drawing.Point(378, 325);
            this.flowLayoutPanel14.Name = "flowLayoutPanel14";
            this.flowLayoutPanel14.Size = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel14.TabIndex = 45;
            // 
            // flowLayoutPanel13
            // 
            this.flowLayoutPanel13.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel13.BackgroundImage")));
            this.flowLayoutPanel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel13.Location = new System.Drawing.Point(881, 325);
            this.flowLayoutPanel13.Name = "flowLayoutPanel13";
            this.flowLayoutPanel13.Size = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel13.TabIndex = 45;
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel12.BackgroundImage")));
            this.flowLayoutPanel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel12.Location = new System.Drawing.Point(809, 325);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel12.TabIndex = 45;
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel11.BackgroundImage")));
            this.flowLayoutPanel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel11.Location = new System.Drawing.Point(730, 325);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel11.TabIndex = 45;
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel10.BackgroundImage")));
            this.flowLayoutPanel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(593, 325);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel10.TabIndex = 45;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel9.BackgroundImage")));
            this.flowLayoutPanel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(449, 325);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel9.TabIndex = 45;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel2.BackgroundImage")));
            this.flowLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(305, 325);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel2.TabIndex = 45;
            // 
            // picCameraD
            // 
            this.picCameraD.BackColor = System.Drawing.Color.Transparent;
            this.picCameraD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCameraD.Image = ((System.Drawing.Image)(resources.GetObject("picCameraD.Image")));
            this.picCameraD.Location = new System.Drawing.Point(681, 175);
            this.picCameraD.Name = "picCameraD";
            this.picCameraD.Size = new System.Drawing.Size(93, 72);
            this.picCameraD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCameraD.TabIndex = 38;
            this.picCameraD.TabStop = false;
            this.picCameraD.Tag = "D";
            this.picCameraD.DoubleClick += new System.EventHandler(this.picVideo_DoubleClick);
            // 
            // picCameraC
            // 
            this.picCameraC.BackColor = System.Drawing.Color.Transparent;
            this.picCameraC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCameraC.Image = ((System.Drawing.Image)(resources.GetObject("picCameraC.Image")));
            this.picCameraC.Location = new System.Drawing.Point(543, 175);
            this.picCameraC.Name = "picCameraC";
            this.picCameraC.Size = new System.Drawing.Size(93, 72);
            this.picCameraC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCameraC.TabIndex = 39;
            this.picCameraC.TabStop = false;
            this.picCameraC.Tag = "C";
            this.picCameraC.DoubleClick += new System.EventHandler(this.picVideo_DoubleClick);
            // 
            // picCameraB
            // 
            this.picCameraB.BackColor = System.Drawing.Color.Transparent;
            this.picCameraB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCameraB.Image = ((System.Drawing.Image)(resources.GetObject("picCameraB.Image")));
            this.picCameraB.Location = new System.Drawing.Point(405, 175);
            this.picCameraB.Name = "picCameraB";
            this.picCameraB.Size = new System.Drawing.Size(93, 72);
            this.picCameraB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCameraB.TabIndex = 37;
            this.picCameraB.TabStop = false;
            this.picCameraB.Tag = "B";
            this.picCameraB.DoubleClick += new System.EventHandler(this.picVideo_DoubleClick);
            // 
            // picCameraA
            // 
            this.picCameraA.BackColor = System.Drawing.Color.Transparent;
            this.picCameraA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCameraA.Image = ((System.Drawing.Image)(resources.GetObject("picCameraA.Image")));
            this.picCameraA.Location = new System.Drawing.Point(267, 175);
            this.picCameraA.Name = "picCameraA";
            this.picCameraA.Size = new System.Drawing.Size(93, 72);
            this.picCameraA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCameraA.TabIndex = 37;
            this.picCameraA.TabStop = false;
            this.picCameraA.Tag = "A";
            this.picCameraA.DoubleClick += new System.EventHandler(this.picVideo_DoubleClick);
            // 
            // lblCameraInfo3D
            // 
            this.lblCameraInfo3D.AutoSize = true;
            this.lblCameraInfo3D.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCameraInfo3D.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCameraInfo3D.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this.lblCameraInfo3D.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblCameraInfo3D.Location = new System.Drawing.Point(841, 246);
            this.lblCameraInfo3D.Name = "lblCameraInfo3D";
            this.lblCameraInfo3D.Size = new System.Drawing.Size(111, 55);
            this.lblCameraInfo3D.TabIndex = 62;
            this.lblCameraInfo3D.Text = "———————\r\n192.168.100.52\r\n吊弦相机1";
            this.lblCameraInfo3D.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(277, 332);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(615, 6);
            this.flowLayoutPanel1.TabIndex = 44;
            // 
            // picAIServ
            // 
            this.picAIServ.BackColor = System.Drawing.Color.Transparent;
            this.picAIServ.Image = ((System.Drawing.Image)(resources.GetObject("picAIServ.Image")));
            this.picAIServ.Location = new System.Drawing.Point(696, 389);
            this.picAIServ.Name = "picAIServ";
            this.picAIServ.Size = new System.Drawing.Size(209, 33);
            this.picAIServ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAIServ.TabIndex = 41;
            this.picAIServ.TabStop = false;
            // 
            // labelX35
            // 
            this.labelX35.AutoSize = true;
            this.labelX35.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX35.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX35.FontBold = true;
            this.labelX35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.labelX35.Location = new System.Drawing.Point(120, 81);
            this.labelX35.Name = "labelX35";
            this.labelX35.Size = new System.Drawing.Size(53, 34);
            this.labelX35.TabIndex = 61;
            this.labelX35.Text = "异常";
            // 
            // labelX34
            // 
            this.labelX34.AutoSize = true;
            this.labelX34.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX34.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX34.FontBold = true;
            this.labelX34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.labelX34.Location = new System.Drawing.Point(50, 81);
            this.labelX34.Name = "labelX34";
            this.labelX34.Size = new System.Drawing.Size(53, 34);
            this.labelX34.TabIndex = 61;
            this.labelX34.Text = "正常\r\n";
            // 
            // lblSwitchInfo
            // 
            this.lblSwitchInfo.AutoSize = true;
            this.lblSwitchInfo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSwitchInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSwitchInfo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.lblSwitchInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblSwitchInfo.Location = new System.Drawing.Point(165, 354);
            this.lblSwitchInfo.Name = "lblSwitchInfo";
            this.lblSwitchInfo.Size = new System.Drawing.Size(90, 25);
            this.lblSwitchInfo.TabIndex = 61;
            this.lblSwitchInfo.Text = "网络交换机";
            // 
            // lblCameraInfoD
            // 
            this.lblCameraInfoD.AutoSize = true;
            this.lblCameraInfoD.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCameraInfoD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCameraInfoD.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraInfoD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblCameraInfoD.Location = new System.Drawing.Point(677, 246);
            this.lblCameraInfoD.Name = "lblCameraInfoD";
            this.lblCameraInfoD.Size = new System.Drawing.Size(108, 54);
            this.lblCameraInfoD.TabIndex = 51;
            this.lblCameraInfoD.Text = "———————\r\n192.168.100.54\r\n吊弦相机4";
            this.lblCameraInfoD.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblCameraInfoC
            // 
            this.lblCameraInfoC.AutoSize = true;
            this.lblCameraInfoC.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCameraInfoC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCameraInfoC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraInfoC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblCameraInfoC.Location = new System.Drawing.Point(543, 246);
            this.lblCameraInfoC.Name = "lblCameraInfoC";
            this.lblCameraInfoC.Size = new System.Drawing.Size(108, 54);
            this.lblCameraInfoC.TabIndex = 51;
            this.lblCameraInfoC.Text = "———————\r\n192.168.100.53\r\n吊弦相机3";
            this.lblCameraInfoC.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblCameraInfoB
            // 
            this.lblCameraInfoB.AutoSize = true;
            this.lblCameraInfoB.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCameraInfoB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCameraInfoB.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraInfoB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblCameraInfoB.Location = new System.Drawing.Point(405, 246);
            this.lblCameraInfoB.Name = "lblCameraInfoB";
            this.lblCameraInfoB.Size = new System.Drawing.Size(108, 54);
            this.lblCameraInfoB.TabIndex = 51;
            this.lblCameraInfoB.Text = "———————\r\n192.168.100.52\r\n吊弦相机2";
            this.lblCameraInfoB.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblCameraInfoA
            // 
            this.lblCameraInfoA.AutoSize = true;
            this.lblCameraInfoA.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCameraInfoA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCameraInfoA.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraInfoA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblCameraInfoA.Location = new System.Drawing.Point(267, 246);
            this.lblCameraInfoA.Name = "lblCameraInfoA";
            this.lblCameraInfoA.Size = new System.Drawing.Size(108, 54);
            this.lblCameraInfoA.TabIndex = 51;
            this.lblCameraInfoA.Text = "———————\r\n192.168.100.55\r\n吊弦相机1";
            this.lblCameraInfoA.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(312, 279);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(6, 43);
            this.flowLayoutPanel3.TabIndex = 45;
            // 
            // picSwitch
            // 
            this.picSwitch.BackColor = System.Drawing.Color.Transparent;
            this.picSwitch.Image = ((System.Drawing.Image)(resources.GetObject("picSwitch.Image")));
            this.picSwitch.Location = new System.Drawing.Point(143, 317);
            this.picSwitch.Name = "picSwitch";
            this.picSwitch.Size = new System.Drawing.Size(130, 35);
            this.picSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSwitch.TabIndex = 43;
            this.picSwitch.TabStop = false;
            // 
            // picMainServ
            // 
            this.picMainServ.BackColor = System.Drawing.Color.Transparent;
            this.picMainServ.Image = ((System.Drawing.Image)(resources.GetObject("picMainServ.Image")));
            this.picMainServ.Location = new System.Drawing.Point(333, 387);
            this.picMainServ.Name = "picMainServ";
            this.picMainServ.Size = new System.Drawing.Size(178, 28);
            this.picMainServ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMainServ.TabIndex = 42;
            this.picMainServ.TabStop = false;
            // 
            // picCamera3D
            // 
            this.picCamera3D.BackColor = System.Drawing.Color.Transparent;
            this.picCamera3D.Image = ((System.Drawing.Image)(resources.GetObject("picCamera3D.Image")));
            this.picCamera3D.Location = new System.Drawing.Point(827, 183);
            this.picCamera3D.Name = "picCamera3D";
            this.picCamera3D.Size = new System.Drawing.Size(140, 66);
            this.picCamera3D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamera3D.TabIndex = 40;
            this.picCamera3D.TabStop = false;
            // 
            // labelX20
            // 
            this.labelX20.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX20.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX20.ForeColor = System.Drawing.Color.White;
            this.labelX20.Location = new System.Drawing.Point(0, 5);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(1021, 49);
            this.labelX20.TabIndex = 29;
            this.labelX20.Text = "硬件状态";
            this.labelX20.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblMainServ
            // 
            this.lblMainServ.AutoSize = true;
            this.lblMainServ.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblMainServ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMainServ.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.lblMainServ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblMainServ.Location = new System.Drawing.Point(363, 417);
            this.lblMainServ.Name = "lblMainServ";
            this.lblMainServ.Size = new System.Drawing.Size(123, 25);
            this.lblMainServ.TabIndex = 57;
            this.lblMainServ.Text = "检测处理服务器";
            // 
            // lblAIServ
            // 
            this.lblAIServ.AutoSize = true;
            this.lblAIServ.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblAIServ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAIServ.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.lblAIServ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lblAIServ.Location = new System.Drawing.Point(737, 423);
            this.lblAIServ.Name = "lblAIServ";
            this.lblAIServ.Size = new System.Drawing.Size(123, 25);
            this.lblAIServ.TabIndex = 59;
            this.lblAIServ.Text = "智能分析服务器";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(456, 285);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(6, 37);
            this.flowLayoutPanel7.TabIndex = 46;
            // 
            // flowLayoutPanel15
            // 
            this.flowLayoutPanel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel15.Location = new System.Drawing.Point(600, 285);
            this.flowLayoutPanel15.Name = "flowLayoutPanel15";
            this.flowLayoutPanel15.Size = new System.Drawing.Size(6, 37);
            this.flowLayoutPanel15.TabIndex = 47;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(385, 347);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(6, 37);
            this.flowLayoutPanel5.TabIndex = 63;
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(816, 350);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(6, 33);
            this.flowLayoutPanel8.TabIndex = 63;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(737, 285);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(6, 37);
            this.flowLayoutPanel4.TabIndex = 48;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(888, 285);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(6, 37);
            this.flowLayoutPanel6.TabIndex = 48;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(10, 483);
            this.panel8.Margin = new System.Windows.Forms.Padding(10);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel8.Size = new System.Drawing.Size(1028, 16);
            this.panel8.TabIndex = 41;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panel7.Controls.Add(this.lblKMV);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.lblSpeed);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.btnClose);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.btnOpenP4);
            this.panel7.Controls.Add(this.btnStopTask);
            this.panel7.Controls.Add(this.btnTaskConfig);
            this.panel7.Controls.Add(this.btnStartTask);
            this.panel7.Controls.Add(this.lblTaskInfo);
            this.panel7.Controls.Add(this.labelX10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(10, 10);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel7.Size = new System.Drawing.Size(1028, 473);
            this.panel7.TabIndex = 32;
            // 
            // lblKMV
            // 
            this.lblKMV.AutoSize = true;
            this.lblKMV.BackColor = System.Drawing.Color.Transparent;
            this.lblKMV.Font = new System.Drawing.Font("Microsoft JhengHei UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKMV.ForeColor = System.Drawing.Color.White;
            this.lblKMV.Location = new System.Drawing.Point(590, 247);
            this.lblKMV.Name = "lblKMV";
            this.lblKMV.Size = new System.Drawing.Size(148, 42);
            this.lblKMV.TabIndex = 50;
            this.lblKMV.Text = "_ _ _ _ _ _";
            this.lblKMV.Click += new System.EventHandler(this.lblKMV_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(482, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 42);
            this.label8.TabIndex = 50;
            this.label8.Text = "站区：";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft JhengHei UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.White;
            this.lblSpeed.Location = new System.Drawing.Point(195, 245);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(141, 42);
            this.lblSpeed.TabIndex = 50;
            this.lblSpeed.Text = "_ _km/h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(97, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 42);
            this.label6.TabIndex = 50;
            this.label6.Text = "车速：";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.AutoExpandOnClick = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Location = new System.Drawing.Point(815, 332);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 77);
            this.btnClose.TabIndex = 49;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(827, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 28);
            this.label5.TabIndex = 48;
            this.label5.Text = "关闭系统";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(644, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 28);
            this.label4.TabIndex = 48;
            this.label4.Text = "停止检测";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(461, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 28);
            this.label3.TabIndex = 48;
            this.label3.Text = "在线展示";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(278, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 28);
            this.label2.TabIndex = 48;
            this.label2.Text = "开启检测";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 48;
            this.label1.Text = "任务配置";
            // 
            // btnOpenP4
            // 
            this.btnOpenP4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpenP4.AutoExpandOnClick = true;
            this.btnOpenP4.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenP4.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnOpenP4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenP4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnOpenP4.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenP4.Image")));
            this.btnOpenP4.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnOpenP4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnOpenP4.Location = new System.Drawing.Point(449, 332);
            this.btnOpenP4.Name = "btnOpenP4";
            this.btnOpenP4.Size = new System.Drawing.Size(124, 77);
            this.btnOpenP4.TabIndex = 47;
            this.btnOpenP4.Click += new System.EventHandler(this.btnOpenP4_Click);
            // 
            // btnStopTask
            // 
            this.btnStopTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopTask.AutoExpandOnClick = true;
            this.btnStopTask.BackColor = System.Drawing.Color.Transparent;
            this.btnStopTask.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnStopTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopTask.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnStopTask.Image = ((System.Drawing.Image)(resources.GetObject("btnStopTask.Image")));
            this.btnStopTask.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnStopTask.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnStopTask.Location = new System.Drawing.Point(632, 332);
            this.btnStopTask.Name = "btnStopTask";
            this.btnStopTask.Size = new System.Drawing.Size(124, 77);
            this.btnStopTask.TabIndex = 46;
            this.btnStopTask.Click += new System.EventHandler(this.btnStopTask_Click);
            // 
            // btnTaskConfig
            // 
            this.btnTaskConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTaskConfig.AutoExpandOnClick = true;
            this.btnTaskConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnTaskConfig.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnTaskConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskConfig.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnTaskConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskConfig.Image")));
            this.btnTaskConfig.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnTaskConfig.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnTaskConfig.Location = new System.Drawing.Point(83, 332);
            this.btnTaskConfig.Name = "btnTaskConfig";
            this.btnTaskConfig.Size = new System.Drawing.Size(124, 77);
            this.btnTaskConfig.TabIndex = 45;
            this.btnTaskConfig.Tooltip = "任务配置-04";
            this.btnTaskConfig.Click += new System.EventHandler(this.btnTaskConfig_Click);
            // 
            // btnStartTask
            // 
            this.btnStartTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartTask.AutoExpandOnClick = true;
            this.btnStartTask.BackColor = System.Drawing.Color.Transparent;
            this.btnStartTask.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnStartTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTask.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnStartTask.Image = ((System.Drawing.Image)(resources.GetObject("btnStartTask.Image")));
            this.btnStartTask.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnStartTask.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnStartTask.Location = new System.Drawing.Point(266, 332);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(124, 77);
            this.btnStartTask.TabIndex = 40;
            this.btnStartTask.Click += new System.EventHandler(this.btnStartTask_Click);
            // 
            // lblTaskInfo
            // 
            this.lblTaskInfo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTaskInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTaskInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTaskInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskInfo.ForeColor = System.Drawing.Color.White;
            this.lblTaskInfo.Location = new System.Drawing.Point(0, 50);
            this.lblTaskInfo.Name = "lblTaskInfo";
            this.lblTaskInfo.PaddingTop = 50;
            this.lblTaskInfo.Size = new System.Drawing.Size(1023, 124);
            this.lblTaskInfo.TabIndex = 31;
            this.lblTaskInfo.Text = "_ _ _  _ _  _ _ _-_ _ _";
            this.lblTaskInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX10.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.ForeColor = System.Drawing.Color.White;
            this.labelX10.Location = new System.Drawing.Point(0, 5);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(1023, 45);
            this.labelX10.TabIndex = 29;
            this.labelX10.Text = "检测任务";
            this.labelX10.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Black;
            this.panelLeft.Controls.Add(this.panelDiskInfo);
            this.panelLeft.Controls.Add(this.panel13);
            this.panelLeft.Controls.Add(this.panelDiskIOInfo);
            this.panelLeft.Controls.Add(this.panel12);
            this.panelLeft.Controls.Add(this.panel14);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(0, 10, 30, 10);
            this.panelLeft.Size = new System.Drawing.Size(431, 1043);
            this.panelLeft.TabIndex = 17;
            // 
            // panelDiskInfo
            // 
            this.panelDiskInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelDiskInfo.Controls.Add(this.labelX28);
            this.panelDiskInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDiskInfo.Location = new System.Drawing.Point(0, 676);
            this.panelDiskInfo.Margin = new System.Windows.Forms.Padding(10);
            this.panelDiskInfo.Name = "panelDiskInfo";
            this.panelDiskInfo.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panelDiskInfo.Size = new System.Drawing.Size(401, 357);
            this.panelDiskInfo.TabIndex = 47;
            // 
            // labelX28
            // 
            this.labelX28.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX28.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX28.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX28.ForeColor = System.Drawing.Color.White;
            this.labelX28.Location = new System.Drawing.Point(0, 5);
            this.labelX28.Name = "labelX28";
            this.labelX28.Size = new System.Drawing.Size(396, 45);
            this.labelX28.TabIndex = 29;
            this.labelX28.Text = "磁盘容量";
            this.labelX28.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 660);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel13.Size = new System.Drawing.Size(401, 16);
            this.panel13.TabIndex = 43;
            // 
            // panelDiskIOInfo
            // 
            this.panelDiskIOInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panelDiskIOInfo.Controls.Add(this.tableLayoutPanel1);
            this.panelDiskIOInfo.Controls.Add(this.labelX27);
            this.panelDiskIOInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDiskIOInfo.Location = new System.Drawing.Point(0, 383);
            this.panelDiskIOInfo.Margin = new System.Windows.Forms.Padding(10);
            this.panelDiskIOInfo.Name = "panelDiskIOInfo";
            this.panelDiskIOInfo.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panelDiskIOInfo.Size = new System.Drawing.Size(401, 277);
            this.panelDiskIOInfo.TabIndex = 46;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 222);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // labelX27
            // 
            this.labelX27.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX27.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX27.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX27.ForeColor = System.Drawing.Color.White;
            this.labelX27.Location = new System.Drawing.Point(0, 5);
            this.labelX27.Name = "labelX27";
            this.labelX27.Size = new System.Drawing.Size(396, 45);
            this.labelX27.TabIndex = 29;
            this.labelX27.Text = "磁盘写入速度";
            this.labelX27.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 367);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel12.Size = new System.Drawing.Size(401, 16);
            this.panel12.TabIndex = 44;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel14.Controls.Add(this.lblMemUsed);
            this.panel14.Controls.Add(this.gaugeCtrlMemory);
            this.panel14.Controls.Add(this.labelX22);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 10);
            this.panel14.Margin = new System.Windows.Forms.Padding(10);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel14.Size = new System.Drawing.Size(401, 357);
            this.panel14.TabIndex = 45;
            // 
            // lblMemUsed
            // 
            this.lblMemUsed.AutoSize = true;
            this.lblMemUsed.BackColor = System.Drawing.Color.Transparent;
            this.lblMemUsed.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemUsed.ForeColor = System.Drawing.Color.White;
            this.lblMemUsed.Location = new System.Drawing.Point(39, 269);
            this.lblMemUsed.Name = "lblMemUsed";
            this.lblMemUsed.Size = new System.Drawing.Size(57, 20);
            this.lblMemUsed.TabIndex = 50;
            this.lblMemUsed.Text = "车速：";
            // 
            // gaugeCtrlMemory
            // 
            this.gaugeCtrlMemory.BackColor = System.Drawing.Color.Transparent;
            gaugeCircularScale1.BorderColor = System.Drawing.Color.White;
            gaugeCircularScale1.Labels.Layout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gaugeCircularScale1.Labels.Layout.ForeColor = System.Drawing.Color.White;
            gradientFillColor1.BorderColor = System.Drawing.Color.DimGray;
            gradientFillColor1.BorderWidth = 1;
            gradientFillColor1.Color1 = System.Drawing.Color.Yellow;
            gradientFillColor1.Color2 = System.Drawing.Color.White;
            gaugeCircularScale1.MajorTickMarks.Layout.FillColor = gradientFillColor1;
            gaugeCircularScale1.MaxPin.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugeCircularScale1.MaxPin.FillColor.BorderWidth = 1;
            gaugeCircularScale1.MaxPin.FillColor.Color1 = System.Drawing.Color.Aqua;
            gaugeCircularScale1.MaxPin.FillColor.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            gaugeCircularScale1.MaxPin.FillColor.GradientAngle = 0;
            gaugeCircularScale1.MaxPin.Name = "MaxPin";
            gaugeCircularScale1.MaxPin.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Star7;
            gaugeCircularScale1.MinorTickMarks.Visible = false;
            gaugeCircularScale1.MinPin.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugeCircularScale1.MinPin.FillColor.BorderWidth = 1;
            gaugeCircularScale1.MinPin.FillColor.Color1 = System.Drawing.Color.Lime;
            gaugeCircularScale1.MinPin.FillColor.Color2 = System.Drawing.Color.Red;
            gaugeCircularScale1.MinPin.Name = "MinPin";
            gaugeCircularScale1.Name = "Scale2";
            gaugePointer1.BarStyle = DevComponents.Instrumentation.BarPointerStyle.Pointed;
            gaugePointer1.CapFillColor.BorderColor = System.Drawing.Color.White;
            gaugePointer1.CapFillColor.BorderWidth = 1;
            gaugePointer1.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer1.CapFillColor.Color2 = System.Drawing.Color.White;
            gaugePointer1.CapStyle = DevComponents.Instrumentation.NeedlePointerCapStyle.Style1;
            gaugePointer1.CapWidth = 0.1F;
            gaugePointer1.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer1.FillColor.BorderWidth = 1;
            gaugePointer1.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer1.FillColor.Color2 = System.Drawing.Color.Blue;
            gaugePointer1.MarkerStyle = DevComponents.Instrumentation.GaugeMarkerStyle.Wedge;
            gaugePointer1.Name = "Pointer1";
            gaugePointer1.Style = DevComponents.Instrumentation.PointerStyle.Needle;
            gaugePointer1.ThermoBackColor.BorderColor = System.Drawing.Color.Black;
            gaugePointer1.ThermoBackColor.BorderWidth = 1;
            gaugePointer1.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer1.Value = 0D;
            gaugeCircularScale1.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer1});
            gaugeSection1.FillColor.Color1 = System.Drawing.Color.DeepSkyBlue;
            gaugeSection1.FillColor.Color2 = System.Drawing.Color.Orange;
            gaugeSection1.Name = "Section1";
            gaugeCircularScale1.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection1});
            gaugeCircularScale1.StartAngle = 135F;
            gaugeCircularScale1.SweepAngle = 270F;
            gaugeCircularScale1.Width = 0.098F;
            this.gaugeCtrlMemory.CircularScales.AddRange(new DevComponents.Instrumentation.GaugeCircularScale[] {
            gaugeCircularScale1});
            this.gaugeCtrlMemory.Cursor = System.Windows.Forms.Cursors.Default;
            this.gaugeCtrlMemory.ForeColor = System.Drawing.Color.Transparent;
            gradientFillColor2.Color1 = System.Drawing.Color.Gainsboro;
            gradientFillColor2.Color2 = System.Drawing.Color.DarkGray;
            this.gaugeCtrlMemory.Frame.BackColor = gradientFillColor2;
            gradientFillColor3.BorderColor = System.Drawing.Color.Gainsboro;
            gradientFillColor3.BorderWidth = 1;
            gradientFillColor3.Color1 = System.Drawing.Color.White;
            gradientFillColor3.Color2 = System.Drawing.Color.DimGray;
            this.gaugeCtrlMemory.Frame.FrameColor = gradientFillColor3;
            this.gaugeCtrlMemory.Frame.RoundRectangleArc = 0.442F;
            gaugeText1.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            gaugeText1.ForeColor = System.Drawing.Color.White;
            gaugeText1.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText1.Location")));
            gaugeText1.Name = "Text1";
            gaugeText1.Text = "20%";
            gaugeText2.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            gaugeText2.ForeColor = System.Drawing.Color.White;
            gaugeText2.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText2.Location")));
            gaugeText2.Name = "Text2";
            gaugeText2.Text = "使用率";
            this.gaugeCtrlMemory.GaugeItems.AddRange(new DevComponents.Instrumentation.GaugeItem[] {
            gaugeText1,
            gaugeText2});
            this.gaugeCtrlMemory.Location = new System.Drawing.Point(55, 54);
            this.gaugeCtrlMemory.Name = "gaugeCtrlMemory";
            this.gaugeCtrlMemory.Size = new System.Drawing.Size(273, 249);
            this.gaugeCtrlMemory.TabIndex = 30;
            this.gaugeCtrlMemory.Text = "gaugeControl1";
            // 
            // labelX22
            // 
            this.labelX22.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX22.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX22.ForeColor = System.Drawing.Color.White;
            this.labelX22.Location = new System.Drawing.Point(0, 5);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(396, 45);
            this.labelX22.TabIndex = 29;
            this.labelX22.Text = "內存使用率";
            this.labelX22.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Black;
            this.panelRight.Controls.Add(this.panel10);
            this.panelRight.Controls.Add(this.panel11);
            this.panelRight.Controls.Add(this.panel6);
            this.panelRight.Controls.Add(this.panel5);
            this.panelRight.Controls.Add(this.panel4);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1479, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.panelRight.Size = new System.Drawing.Size(360, 1043);
            this.panelRight.TabIndex = 19;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panel10.Controls.Add(this.groupPanel1);
            this.panel10.Controls.Add(this.lblDelNum);
            this.panel10.Controls.Add(this.labelX6);
            this.panel10.Controls.Add(this.labelX38);
            this.panel10.Controls.Add(this.lblServMem);
            this.panel10.Controls.Add(this.labelX37);
            this.panel10.Controls.Add(this.lblSaveFaultNum);
            this.panel10.Controls.Add(this.lblSaveLocNum);
            this.panel10.Controls.Add(this.lblSaveImgNum);
            this.panel10.Controls.Add(this.labelX36);
            this.panel10.Controls.Add(this.labelX15);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(30, 606);
            this.panel10.Margin = new System.Windows.Forms.Padding(10);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel10.Size = new System.Drawing.Size(300, 427);
            this.panel10.TabIndex = 42;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rTbTaskMsg);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(0, 263);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(295, 159);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 36;
            this.groupPanel1.Text = "实时信息";
            // 
            // rTbTaskMsg
            // 
            this.rTbTaskMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTbTaskMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTbTaskMsg.Location = new System.Drawing.Point(0, 0);
            this.rTbTaskMsg.Name = "rTbTaskMsg";
            this.rTbTaskMsg.Size = new System.Drawing.Size(289, 134);
            this.rTbTaskMsg.TabIndex = 0;
            this.rTbTaskMsg.Text = "";
            // 
            // lblDelNum
            // 
            this.lblDelNum.AutoSize = true;
            this.lblDelNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblDelNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDelNum.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelNum.ForeColor = System.Drawing.Color.Yellow;
            this.lblDelNum.Location = new System.Drawing.Point(42, 288);
            this.lblDelNum.Name = "lblDelNum";
            this.lblDelNum.Size = new System.Drawing.Size(0, 0);
            this.lblDelNum.TabIndex = 35;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.labelX6.ForeColor = System.Drawing.Color.White;
            this.labelX6.Location = new System.Drawing.Point(43, 236);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(143, 31);
            this.labelX6.TabIndex = 35;
            this.labelX6.Text = "数据服务器内存";
            // 
            // labelX38
            // 
            this.labelX38.AutoSize = true;
            this.labelX38.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX38.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.labelX38.ForeColor = System.Drawing.Color.White;
            this.labelX38.Location = new System.Drawing.Point(4, 184);
            this.labelX38.Name = "labelX38";
            this.labelX38.Size = new System.Drawing.Size(182, 31);
            this.labelX38.TabIndex = 35;
            this.labelX38.Text = "持久化缺陷信息数量";
            // 
            // lblServMem
            // 
            this.lblServMem.AutoSize = true;
            this.lblServMem.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblServMem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblServMem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.lblServMem.FontBold = true;
            this.lblServMem.ForeColor = System.Drawing.Color.Yellow;
            this.lblServMem.Location = new System.Drawing.Point(187, 236);
            this.lblServMem.Name = "lblServMem";
            this.lblServMem.Size = new System.Drawing.Size(39, 31);
            this.lblServMem.TabIndex = 35;
            this.lblServMem.Text = "0条";
            // 
            // labelX37
            // 
            this.labelX37.AutoSize = true;
            this.labelX37.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX37.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.labelX37.ForeColor = System.Drawing.Color.White;
            this.labelX37.Location = new System.Drawing.Point(4, 132);
            this.labelX37.Name = "labelX37";
            this.labelX37.Size = new System.Drawing.Size(182, 31);
            this.labelX37.TabIndex = 35;
            this.labelX37.Text = "持久化定位信息数量";
            // 
            // lblSaveFaultNum
            // 
            this.lblSaveFaultNum.AutoSize = true;
            this.lblSaveFaultNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSaveFaultNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSaveFaultNum.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.lblSaveFaultNum.FontBold = true;
            this.lblSaveFaultNum.ForeColor = System.Drawing.Color.Yellow;
            this.lblSaveFaultNum.Location = new System.Drawing.Point(187, 184);
            this.lblSaveFaultNum.Name = "lblSaveFaultNum";
            this.lblSaveFaultNum.Size = new System.Drawing.Size(39, 31);
            this.lblSaveFaultNum.TabIndex = 35;
            this.lblSaveFaultNum.Text = "0条";
            // 
            // lblSaveLocNum
            // 
            this.lblSaveLocNum.AutoSize = true;
            this.lblSaveLocNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSaveLocNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSaveLocNum.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.lblSaveLocNum.FontBold = true;
            this.lblSaveLocNum.ForeColor = System.Drawing.Color.Yellow;
            this.lblSaveLocNum.Location = new System.Drawing.Point(187, 132);
            this.lblSaveLocNum.Name = "lblSaveLocNum";
            this.lblSaveLocNum.Size = new System.Drawing.Size(39, 31);
            this.lblSaveLocNum.TabIndex = 35;
            this.lblSaveLocNum.Text = "0条";
            // 
            // lblSaveImgNum
            // 
            this.lblSaveImgNum.AutoSize = true;
            this.lblSaveImgNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSaveImgNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSaveImgNum.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.lblSaveImgNum.FontBold = true;
            this.lblSaveImgNum.ForeColor = System.Drawing.Color.Yellow;
            this.lblSaveImgNum.Location = new System.Drawing.Point(187, 80);
            this.lblSaveImgNum.Name = "lblSaveImgNum";
            this.lblSaveImgNum.Size = new System.Drawing.Size(39, 31);
            this.lblSaveImgNum.TabIndex = 35;
            this.lblSaveImgNum.Text = "0张";
            // 
            // labelX36
            // 
            this.labelX36.AutoSize = true;
            this.labelX36.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX36.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.labelX36.ForeColor = System.Drawing.Color.White;
            this.labelX36.Location = new System.Drawing.Point(43, 80);
            this.labelX36.Name = "labelX36";
            this.labelX36.Size = new System.Drawing.Size(143, 31);
            this.labelX36.TabIndex = 35;
            this.labelX36.Text = "持久化图片数量";
            // 
            // labelX15
            // 
            this.labelX15.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX15.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX15.ForeColor = System.Drawing.Color.White;
            this.labelX15.Location = new System.Drawing.Point(0, 5);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(295, 45);
            this.labelX15.TabIndex = 29;
            this.labelX15.Text = "数据持久化信息";
            this.labelX15.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(30, 590);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel11.Size = new System.Drawing.Size(300, 16);
            this.panel11.TabIndex = 41;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panel6.Controls.Add(this.picSaveDataState);
            this.panel6.Controls.Add(this.picAIServState);
            this.panel6.Controls.Add(this.picTimeServState);
            this.panel6.Controls.Add(this.picRedisState);
            this.panel6.Controls.Add(this.labelX4);
            this.panel6.Controls.Add(this.labelX3);
            this.panel6.Controls.Add(this.labelX2);
            this.panel6.Controls.Add(this.labelX1);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.pictureBox2);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.labelX14);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(30, 200);
            this.panel6.Margin = new System.Windows.Forms.Padding(10);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel6.Size = new System.Drawing.Size(300, 390);
            this.panel6.TabIndex = 40;
            // 
            // picSaveDataState
            // 
            this.picSaveDataState.BackColor = System.Drawing.Color.Transparent;
            this.picSaveDataState.Image = ((System.Drawing.Image)(resources.GetObject("picSaveDataState.Image")));
            this.picSaveDataState.Location = new System.Drawing.Point(245, 299);
            this.picSaveDataState.Name = "picSaveDataState";
            this.picSaveDataState.Size = new System.Drawing.Size(32, 32);
            this.picSaveDataState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSaveDataState.TabIndex = 35;
            this.picSaveDataState.TabStop = false;
            // 
            // picAIServState
            // 
            this.picAIServState.BackColor = System.Drawing.Color.Transparent;
            this.picAIServState.Image = ((System.Drawing.Image)(resources.GetObject("picAIServState.Image")));
            this.picAIServState.Location = new System.Drawing.Point(245, 233);
            this.picAIServState.Name = "picAIServState";
            this.picAIServState.Size = new System.Drawing.Size(32, 32);
            this.picAIServState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAIServState.TabIndex = 35;
            this.picAIServState.TabStop = false;
            this.picAIServState.Click += new System.EventHandler(this.picAIServState_Click);
            // 
            // picTimeServState
            // 
            this.picTimeServState.BackColor = System.Drawing.Color.Transparent;
            this.picTimeServState.Image = ((System.Drawing.Image)(resources.GetObject("picTimeServState.Image")));
            this.picTimeServState.Location = new System.Drawing.Point(245, 167);
            this.picTimeServState.Name = "picTimeServState";
            this.picTimeServState.Size = new System.Drawing.Size(32, 32);
            this.picTimeServState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTimeServState.TabIndex = 35;
            this.picTimeServState.TabStop = false;
            // 
            // picRedisState
            // 
            this.picRedisState.BackColor = System.Drawing.Color.Transparent;
            this.picRedisState.Image = ((System.Drawing.Image)(resources.GetObject("picRedisState.Image")));
            this.picRedisState.Location = new System.Drawing.Point(245, 98);
            this.picRedisState.Name = "picRedisState";
            this.picRedisState.Size = new System.Drawing.Size(32, 32);
            this.picRedisState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRedisState.TabIndex = 35;
            this.picRedisState.TabStop = false;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.labelX4.ForeColor = System.Drawing.Color.White;
            this.labelX4.Location = new System.Drawing.Point(100, 299);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(143, 31);
            this.labelX4.TabIndex = 34;
            this.labelX4.Text = "数据持久化服务";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(100, 233);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(139, 34);
            this.labelX3.TabIndex = 34;
            this.labelX3.Text = "智能分析服务";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(100, 167);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(139, 34);
            this.labelX2.TabIndex = 34;
            this.labelX2.Text = "时钟同步服务";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(100, 96);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(115, 34);
            this.labelX1.TabIndex = 34;
            this.labelX1.Text = "Redis 服务";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(42, 289);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 48);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(42, 227);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(42, 157);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // labelX14
            // 
            this.labelX14.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX14.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX14.ForeColor = System.Drawing.Color.White;
            this.labelX14.Location = new System.Drawing.Point(0, 5);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(295, 45);
            this.labelX14.TabIndex = 29;
            this.labelX14.Text = "服务启动信息";
            this.labelX14.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(30, 184);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel5.Size = new System.Drawing.Size(300, 16);
            this.panel5.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panel4.Controls.Add(this.lblTime);
            this.panel4.Controls.Add(this.lblDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(30, 10);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel4.Size = new System.Drawing.Size(300, 174);
            this.panel4.TabIndex = 30;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTime.Font = new System.Drawing.Font("Arial", 45.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.FontBold = true;
            this.lblTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblTime.Location = new System.Drawing.Point(0, 101);
            this.lblTime.Name = "lblTime";
            this.lblTime.PaddingBottom = 15;
            this.lblTime.Size = new System.Drawing.Size(295, 68);
            this.lblTime.TabIndex = 30;
            this.lblTime.Text = "23:48:16";
            this.lblTime.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.Font = new System.Drawing.Font("微软雅黑", 28F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblDate.Location = new System.Drawing.Point(0, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.PaddingTop = 10;
            this.lblDate.Size = new System.Drawing.Size(311, 68);
            this.lblDate.TabIndex = 29;
            this.lblDate.Text = "2020年03月30日";
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1839, 1084);
            this.ControlBox = false;
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelBase.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAIServ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainServ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera3D)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelDiskInfo.ResumeLayout(false);
            this.panelDiskIOInfo.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeCtrlMemory)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSaveDataState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAIServState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeServState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedisState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.Bar bar1;
        private  Panel panelLeft;
        private  Panel panelRight;
        private  Panel panel4;
        private  Panel panel5;
        private  Panel panel6;
        private  Panel panelCenter;
        private  Panel panel7;
        private  Panel panel13;
        private  Panel panel12;

        private  Panel panel10;
        private  Panel panel11;
        private  Panel panel9;
        private  Panel panel8;
        private  Panel panelDiskInfo;
        private  Panel panelDiskIOInfo;
        private  Panel panel14;


        private DevComponents.DotNetBar.LabelX lblDate;
        
        private DevComponents.DotNetBar.LabelX lblTime;
       
        private DevComponents.DotNetBar.LabelX labelX14;
       
        private DevComponents.DotNetBar.LabelX lblTaskInfo;
        private DevComponents.DotNetBar.LabelX labelX10;

        private DevComponents.DotNetBar.LabelX labelX15;

        private DevComponents.DotNetBar.LabelX labelX20;

        private DevComponents.DotNetBar.LabelX labelX28;

        private DevComponents.DotNetBar.LabelX labelX27;

        private DevComponents.Instrumentation.GaugeControl gaugeCtrlMemory;
        private DevComponents.DotNetBar.LabelX labelX22;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX btnStartTask;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerGlobal;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.PictureBox picSaveDataState;
        private System.Windows.Forms.PictureBox picAIServState;
        private System.Windows.Forms.PictureBox picTimeServState;
        private System.Windows.Forms.PictureBox picRedisState;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.PictureBox picCameraA;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox picSwitch;
        private System.Windows.Forms.PictureBox picMainServ;
        private System.Windows.Forms.PictureBox picAIServ;
        private System.Windows.Forms.PictureBox picCamera3D;
        private System.Windows.Forms.PictureBox picCameraD;
        private System.Windows.Forms.PictureBox picCameraC;
        private DevComponents.DotNetBar.LabelX lblCameraInfoA;
        private DevComponents.DotNetBar.LabelX lblSwitchInfo;
        private DevComponents.DotNetBar.LabelX lblAIServ;
        private DevComponents.DotNetBar.LabelX lblMainServ;
        private System.Windows.Forms.PictureBox picCameraB;
        private DevComponents.DotNetBar.LabelX labelX35;
        private DevComponents.DotNetBar.LabelX labelX34;
        private DevComponents.DotNetBar.LabelX labelX38;
        private DevComponents.DotNetBar.LabelX labelX37;
        private DevComponents.DotNetBar.LabelX labelX36;
        private DevComponents.DotNetBar.LabelX lblSaveFaultNum;
        private DevComponents.DotNetBar.LabelX lblSaveLocNum;
        private DevComponents.DotNetBar.LabelX lblSaveImgNum;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnOpenP4;
        private DevComponents.DotNetBar.ButtonX btnStopTask;
        private DevComponents.DotNetBar.ButtonX btnTaskConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Label lblKMV;
        private Label label8;
        private Label lblSpeed;
        private Label label6;
        private Label lblMemUsed;
        private DevComponents.DotNetBar.LabelX lblCameraInfo3D;
        private DevComponents.DotNetBar.LabelX lblCameraInfoD;
        private DevComponents.DotNetBar.LabelX lblCameraInfoC;
        private DevComponents.DotNetBar.LabelX lblCameraInfoB;
        private DevComponents.DotNetBar.PanelEx panelBase;
        private NotifyIcon notifyIcon1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private RichTextBox rTbTaskMsg;
        private DevComponents.DotNetBar.LabelX lblDelNum;
        private DevComponents.DotNetBar.LabelX lblServMem;
        private DevComponents.DotNetBar.LabelX labelX6;
        private FlowLayoutPanel flowLayoutPanel14;
        private FlowLayoutPanel flowLayoutPanel13;
        private FlowLayoutPanel flowLayoutPanel12;
        private FlowLayoutPanel flowLayoutPanel11;
        private FlowLayoutPanel flowLayoutPanel10;
        private FlowLayoutPanel flowLayoutPanel9;
        private FlowLayoutPanel flowLayoutPanel7;
        private FlowLayoutPanel flowLayoutPanel15;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel8;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.ButtonItem btnItemMin;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmItemDisplay;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem tsmItemExit;
    }
}