namespace PreCheckSys.UI {
    partial class VideoControl {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoControl));
            this.picVideo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCameraPos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.线路名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.预置位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSetParamOk = new DevComponents.DotNetBar.ButtonX();
            this.dInputExposure = new DevComponents.Editors.DoubleInput();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.iInputGain = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnFocusPlus = new DevComponents.DotNetBar.ButtonX();
            this.btnFocusMinus = new DevComponents.DotNetBar.ButtonX();
            this.label11 = new System.Windows.Forms.Label();
            this.iInputCurrValue = new DevComponents.Editors.IntegerInput();
            this.iInputChgValue = new DevComponents.Editors.IntegerInput();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPos = new System.Windows.Forms.Panel();
            this.btnCameraPosView = new DevComponents.DotNetBar.ButtonX();
            this.btnMoveTo = new DevComponents.DotNetBar.ButtonX();
            this.iInputCameraPos = new DevComponents.Editors.IntegerInput();
            this.btnSetPos = new DevComponents.DotNetBar.ButtonX();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iInputMoveValue = new DevComponents.Editors.IntegerInput();
            this.btnRight = new DevComponents.DotNetBar.ButtonX();
            this.btnDown = new DevComponents.DotNetBar.ButtonX();
            this.btnLeft = new DevComponents.DotNetBar.ButtonX();
            this.label12 = new System.Windows.Forms.Label();
            this.btnUP = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSetFPSOk = new DevComponents.DotNetBar.ButtonX();
            this.dInputFPS = new DevComponents.Editors.DoubleInput();
            this.sBtnDisplay = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.sBtnTriggerMode = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCameraInfo = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraPos)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dInputExposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iInputGain)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iInputCurrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iInputChgValue)).BeginInit();
            this.panelPos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iInputCameraPos)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iInputMoveValue)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dInputFPS)).BeginInit();
            this.SuspendLayout();
            // 
            // picVideo
            // 
            this.picVideo.Location = new System.Drawing.Point(594, 662);
            this.picVideo.Name = "picVideo";
            this.picVideo.Size = new System.Drawing.Size(205, 229);
            this.picVideo.TabIndex = 0;
            this.picVideo.TabStop = false;
            this.picVideo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCameraPos);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panelPos);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(899, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 891);
            this.panel1.TabIndex = 5;
            // 
            // dgvCameraPos
            // 
            this.dgvCameraPos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCameraPos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCameraPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCameraPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.线路名称,
            this.预置位});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCameraPos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCameraPos.EnableHeadersVisualStyles = false;
            this.dgvCameraPos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCameraPos.Location = new System.Drawing.Point(51, 836);
            this.dgvCameraPos.Name = "dgvCameraPos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCameraPos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCameraPos.RowHeadersVisible = false;
            this.dgvCameraPos.RowTemplate.Height = 23;
            this.dgvCameraPos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCameraPos.Size = new System.Drawing.Size(258, 150);
            this.dgvCameraPos.TabIndex = 10;
            this.dgvCameraPos.Visible = false;
            // 
            // 线路名称
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            this.线路名称.DefaultCellStyle = dataGridViewCellStyle2;
            this.线路名称.HeaderText = "线路名称";
            this.线路名称.Name = "线路名称";
            // 
            // 预置位
            // 
            this.预置位.HeaderText = "预置位";
            this.预置位.Name = "预置位";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnSetParamOk);
            this.panel7.Controls.Add(this.dInputExposure);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.iInputGain);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(38, 695);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(265, 119);
            this.panel7.TabIndex = 13;
            // 
            // btnSetParamOk
            // 
            this.btnSetParamOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetParamOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetParamOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetParamOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetParamOk.Location = new System.Drawing.Point(232, 90);
            this.btnSetParamOk.Name = "btnSetParamOk";
            this.btnSetParamOk.Size = new System.Drawing.Size(23, 29);
            this.btnSetParamOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSetParamOk.Symbol = "";
            this.btnSetParamOk.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSetParamOk.TabIndex = 12;
            this.btnSetParamOk.Visible = false;
            this.btnSetParamOk.Click += new System.EventHandler(this.btnSetParamOk_Click);
            // 
            // dInputExposure
            // 
            // 
            // 
            // 
            this.dInputExposure.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dInputExposure.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dInputExposure.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dInputExposure.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.dInputExposure.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dInputExposure.Increment = 1D;
            this.dInputExposure.Location = new System.Drawing.Point(124, 16);
            this.dInputExposure.Name = "dInputExposure";
            this.dInputExposure.ShowUpDown = true;
            this.dInputExposure.Size = new System.Drawing.Size(102, 29);
            this.dInputExposure.TabIndex = 11;
            this.dInputExposure.Value = 60D;
            this.dInputExposure.ValueChanged += new System.EventHandler(this.dInputExposure_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(19, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 30);
            this.label10.TabIndex = 9;
            this.label10.Text = "增益";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label8.Location = new System.Drawing.Point(19, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 30);
            this.label8.TabIndex = 9;
            this.label8.Text = "曝光时间";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iInputGain
            // 
            // 
            // 
            // 
            this.iInputGain.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.iInputGain.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iInputGain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputGain.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputGain.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.iInputGain.ForeColor = System.Drawing.Color.Black;
            this.iInputGain.Location = new System.Drawing.Point(124, 51);
            this.iInputGain.MaxValue = 50;
            this.iInputGain.MinValue = 1;
            this.iInputGain.Name = "iInputGain";
            this.iInputGain.ShowUpDown = true;
            this.iInputGain.Size = new System.Drawing.Size(102, 29);
            this.iInputGain.TabIndex = 6;
            this.iInputGain.Value = 15;
            this.iInputGain.ValueChanged += new System.EventHandler(this.iInputGain_ValueChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(38, 662);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 33);
            this.label7.TabIndex = 12;
            this.label7.Text = "图像调节";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnFocusPlus);
            this.panel6.Controls.Add(this.btnFocusMinus);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.iInputCurrValue);
            this.panel6.Controls.Add(this.iInputChgValue);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(38, 598);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(265, 64);
            this.panel6.TabIndex = 11;
            // 
            // btnFocusPlus
            // 
            this.btnFocusPlus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFocusPlus.BackColor = System.Drawing.SystemColors.Control;
            this.btnFocusPlus.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFocusPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFocusPlus.Location = new System.Drawing.Point(229, 16);
            this.btnFocusPlus.Name = "btnFocusPlus";
            this.btnFocusPlus.Size = new System.Drawing.Size(32, 32);
            this.btnFocusPlus.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnFocusPlus.Symbol = "";
            this.btnFocusPlus.TabIndex = 11;
            this.btnFocusPlus.Click += new System.EventHandler(this.btnFocusPlus_Click);
            // 
            // btnFocusMinus
            // 
            this.btnFocusMinus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFocusMinus.BackColor = System.Drawing.SystemColors.Control;
            this.btnFocusMinus.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFocusMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFocusMinus.Location = new System.Drawing.Point(60, 16);
            this.btnFocusMinus.Name = "btnFocusMinus";
            this.btnFocusMinus.Size = new System.Drawing.Size(32, 32);
            this.btnFocusMinus.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnFocusMinus.Symbol = "";
            this.btnFocusMinus.TabIndex = 11;
            this.btnFocusMinus.Click += new System.EventHandler(this.btnFocusMinus_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label11.Location = new System.Drawing.Point(5, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 30);
            this.label11.TabIndex = 10;
            this.label11.Text = "聚焦";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iInputCurrValue
            // 
            // 
            // 
            // 
            this.iInputCurrValue.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.iInputCurrValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iInputCurrValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputCurrValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputCurrValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iInputCurrValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.iInputCurrValue.ForeColor = System.Drawing.Color.Black;
            this.iInputCurrValue.Location = new System.Drawing.Point(94, 18);
            this.iInputCurrValue.MaxValue = 79000;
            this.iInputCurrValue.MinValue = 1000;
            this.iInputCurrValue.Name = "iInputCurrValue";
            this.iInputCurrValue.ShowUpDown = true;
            this.iInputCurrValue.Size = new System.Drawing.Size(75, 29);
            this.iInputCurrValue.TabIndex = 6;
            this.iInputCurrValue.Value = 1000;
            this.iInputCurrValue.WatermarkText = "当前对焦环数值";
            // 
            // iInputChgValue
            // 
            // 
            // 
            // 
            this.iInputChgValue.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.iInputChgValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iInputChgValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputChgValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputChgValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iInputChgValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.iInputChgValue.ForeColor = System.Drawing.Color.Black;
            this.iInputChgValue.Location = new System.Drawing.Point(172, 18);
            this.iInputChgValue.MaxValue = 1000;
            this.iInputChgValue.MinValue = 10;
            this.iInputChgValue.Name = "iInputChgValue";
            this.iInputChgValue.ShowUpDown = true;
            this.iInputChgValue.Size = new System.Drawing.Size(51, 29);
            this.iInputChgValue.TabIndex = 6;
            this.iInputChgValue.Value = 10;
            this.iInputChgValue.WatermarkText = "调节级数";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(38, 565);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 33);
            this.label6.TabIndex = 10;
            this.label6.Text = "镜头调节";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPos
            // 
            this.panelPos.Controls.Add(this.btnCameraPosView);
            this.panelPos.Controls.Add(this.btnMoveTo);
            this.panelPos.Controls.Add(this.iInputCameraPos);
            this.panelPos.Controls.Add(this.btnSetPos);
            this.panelPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPos.Location = new System.Drawing.Point(38, 468);
            this.panelPos.Name = "panelPos";
            this.panelPos.Size = new System.Drawing.Size(265, 97);
            this.panelPos.TabIndex = 9;
            // 
            // btnCameraPosView
            // 
            this.btnCameraPosView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCameraPosView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(226)))));
            this.btnCameraPosView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCameraPosView.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnCameraPosView.Image = ((System.Drawing.Image)(resources.GetObject("btnCameraPosView.Image")));
            this.btnCameraPosView.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnCameraPosView.Location = new System.Drawing.Point(97, 20);
            this.btnCameraPosView.Name = "btnCameraPosView";
            this.btnCameraPosView.Size = new System.Drawing.Size(34, 33);
            this.btnCameraPosView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCameraPosView.TabIndex = 9;
            this.btnCameraPosView.TextColor = System.Drawing.Color.White;
            this.btnCameraPosView.Tooltip = "预置位查找";
            this.btnCameraPosView.Click += new System.EventHandler(this.btnCameraPosView_Click);
            // 
            // btnMoveTo
            // 
            this.btnMoveTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoveTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(226)))));
            this.btnMoveTo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMoveTo.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnMoveTo.Location = new System.Drawing.Point(137, 20);
            this.btnMoveTo.Name = "btnMoveTo";
            this.btnMoveTo.Size = new System.Drawing.Size(57, 33);
            this.btnMoveTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMoveTo.TabIndex = 8;
            this.btnMoveTo.Text = "移动";
            this.btnMoveTo.TextColor = System.Drawing.Color.White;
            this.btnMoveTo.Click += new System.EventHandler(this.btnMoveTo_Click);
            // 
            // iInputCameraPos
            // 
            // 
            // 
            // 
            this.iInputCameraPos.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.iInputCameraPos.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iInputCameraPos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputCameraPos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputCameraPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iInputCameraPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.iInputCameraPos.ForeColor = System.Drawing.Color.Black;
            this.iInputCameraPos.Location = new System.Drawing.Point(13, 22);
            this.iInputCameraPos.MaxValue = 16;
            this.iInputCameraPos.MinValue = 1;
            this.iInputCameraPos.Name = "iInputCameraPos";
            this.iInputCameraPos.ShowUpDown = true;
            this.iInputCameraPos.Size = new System.Drawing.Size(79, 29);
            this.iInputCameraPos.TabIndex = 6;
            this.iInputCameraPos.Value = 1;
            // 
            // btnSetPos
            // 
            this.btnSetPos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(226)))));
            this.btnSetPos.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSetPos.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnSetPos.Location = new System.Drawing.Point(200, 20);
            this.btnSetPos.Name = "btnSetPos";
            this.btnSetPos.Size = new System.Drawing.Size(57, 33);
            this.btnSetPos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetPos.TabIndex = 8;
            this.btnSetPos.Text = "设置";
            this.btnSetPos.TextColor = System.Drawing.Color.White;
            this.btnSetPos.Click += new System.EventHandler(this.btnSetPos_Click);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label9.Location = new System.Drawing.Point(38, 435);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(265, 33);
            this.label9.TabIndex = 5;
            this.label9.Text = "云台预置位";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.iInputMoveValue);
            this.panel4.Controls.Add(this.btnRight);
            this.panel4.Controls.Add(this.btnDown);
            this.panel4.Controls.Add(this.btnLeft);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.btnUP);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(38, 199);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(265, 236);
            this.panel4.TabIndex = 4;
            // 
            // iInputMoveValue
            // 
            // 
            // 
            // 
            this.iInputMoveValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iInputMoveValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputMoveValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputMoveValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iInputMoveValue.Location = new System.Drawing.Point(100, 110);
            this.iInputMoveValue.MaxValue = 64;
            this.iInputMoveValue.MinValue = 5;
            this.iInputMoveValue.Name = "iInputMoveValue";
            this.iInputMoveValue.ShowUpDown = true;
            this.iInputMoveValue.Size = new System.Drawing.Size(61, 29);
            this.iInputMoveValue.TabIndex = 10;
            this.iInputMoveValue.Value = 32;
            this.iInputMoveValue.WatermarkText = "移动值";
            // 
            // btnRight
            // 
            this.btnRight.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRight.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnRight.Location = new System.Drawing.Point(170, 80);
            this.btnRight.Name = "btnRight";
            this.btnRight.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRight.PressedImage")));
            this.btnRight.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnRight.Size = new System.Drawing.Size(64, 64);
            this.btnRight.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRight.TabIndex = 9;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnDown.Location = new System.Drawing.Point(96, 155);
            this.btnDown.Name = "btnDown";
            this.btnDown.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnDown.PressedImage")));
            this.btnDown.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnDown.Size = new System.Drawing.Size(64, 64);
            this.btnDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDown.TabIndex = 9;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeft.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnLeft.Location = new System.Drawing.Point(24, 80);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnLeft.PressedImage")));
            this.btnLeft.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnLeft.Size = new System.Drawing.Size(64, 64);
            this.btnLeft.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLeft.TabIndex = 9;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label12.Location = new System.Drawing.Point(101, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 21);
            this.label12.TabIndex = 5;
            this.label12.Text = "移动值";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUP
            // 
            this.btnUP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUP.Image = ((System.Drawing.Image)(resources.GetObject("btnUP.Image")));
            this.btnUP.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnUP.Location = new System.Drawing.Point(96, 8);
            this.btnUP.Name = "btnUP";
            this.btnUP.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnUP.PressedImage")));
            this.btnUP.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnUP.Size = new System.Drawing.Size(64, 64);
            this.btnUP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUP.TabIndex = 9;
            this.btnUP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btnUP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(38, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 33);
            this.label5.TabIndex = 3;
            this.label5.Text = "云台调节";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSetFPSOk);
            this.panel3.Controls.Add(this.dInputFPS);
            this.panel3.Controls.Add(this.sBtnDisplay);
            this.panel3.Controls.Add(this.sBtnTriggerMode);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(38, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 133);
            this.panel3.TabIndex = 2;
            // 
            // btnSetFPSOk
            // 
            this.btnSetFPSOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetFPSOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetFPSOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetFPSOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetFPSOk.Location = new System.Drawing.Point(235, 90);
            this.btnSetFPSOk.Name = "btnSetFPSOk";
            this.btnSetFPSOk.Size = new System.Drawing.Size(23, 29);
            this.btnSetFPSOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSetFPSOk.Symbol = "";
            this.btnSetFPSOk.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSetFPSOk.TabIndex = 13;
            this.btnSetFPSOk.Visible = false;
            this.btnSetFPSOk.Click += new System.EventHandler(this.btnSetFPSOk_Click);
            // 
            // dInputFPS
            // 
            // 
            // 
            // 
            this.dInputFPS.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dInputFPS.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dInputFPS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dInputFPS.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.dInputFPS.DisplayFormat = "0.0";
            this.dInputFPS.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dInputFPS.Increment = 1D;
            this.dInputFPS.Location = new System.Drawing.Point(158, 90);
            this.dInputFPS.MaxValue = 12D;
            this.dInputFPS.MinValue = 0.5D;
            this.dInputFPS.Name = "dInputFPS";
            this.dInputFPS.ShowUpDown = true;
            this.dInputFPS.Size = new System.Drawing.Size(76, 29);
            this.dInputFPS.TabIndex = 12;
            this.dInputFPS.Value = 9D;
            this.dInputFPS.ValueChanged += new System.EventHandler(this.dInputFPS_ValueChanged);
            // 
            // sBtnDisplay
            // 
            this.sBtnDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // 
            // 
            this.sBtnDisplay.BackgroundStyle.CornerDiameter = 20;
            this.sBtnDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.sBtnDisplay.BackgroundStyle.CornerTypeBottomLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnDisplay.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnDisplay.BackgroundStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnDisplay.BackgroundStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sBtnDisplay.Location = new System.Drawing.Point(158, 11);
            this.sBtnDisplay.Name = "sBtnDisplay";
            this.sBtnDisplay.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.sBtnDisplay.OffTextColor = System.Drawing.Color.White;
            this.sBtnDisplay.OnBackColor = System.Drawing.Color.Lime;
            this.sBtnDisplay.ReadOnlyMarkerColor = System.Drawing.Color.Red;
            this.sBtnDisplay.Size = new System.Drawing.Size(77, 30);
            this.sBtnDisplay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sBtnDisplay.SwitchBackColor = System.Drawing.Color.White;
            this.sBtnDisplay.SwitchBorderColor = System.Drawing.Color.Black;
            this.sBtnDisplay.SwitchFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBtnDisplay.SwitchWidth = 15;
            this.sBtnDisplay.TabIndex = 8;
            this.sBtnDisplay.ValueChanged += new System.EventHandler(this.sBtnDisplay_ValueChanged);
            // 
            // sBtnTriggerMode
            // 
            this.sBtnTriggerMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // 
            // 
            this.sBtnTriggerMode.BackgroundStyle.CornerDiameter = 20;
            this.sBtnTriggerMode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.sBtnTriggerMode.BackgroundStyle.CornerTypeBottomLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnTriggerMode.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnTriggerMode.BackgroundStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnTriggerMode.BackgroundStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.sBtnTriggerMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sBtnTriggerMode.Location = new System.Drawing.Point(158, 54);
            this.sBtnTriggerMode.Name = "sBtnTriggerMode";
            this.sBtnTriggerMode.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.sBtnTriggerMode.OffTextColor = System.Drawing.Color.White;
            this.sBtnTriggerMode.OnBackColor = System.Drawing.Color.Lime;
            this.sBtnTriggerMode.ReadOnlyMarkerColor = System.Drawing.Color.Red;
            this.sBtnTriggerMode.Size = new System.Drawing.Size(77, 30);
            this.sBtnTriggerMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sBtnTriggerMode.SwitchBackColor = System.Drawing.Color.White;
            this.sBtnTriggerMode.SwitchBorderColor = System.Drawing.Color.Black;
            this.sBtnTriggerMode.SwitchFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBtnTriggerMode.SwitchWidth = 15;
            this.sBtnTriggerMode.TabIndex = 7;
            this.sBtnTriggerMode.ValueChanged += new System.EventHandler(this.sBtnTriggerMode_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "FPS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "使能触发";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "实时采集显示";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(38, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "相机控制";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(38, 891);
            this.panel2.TabIndex = 0;
            // 
            // lblCameraInfo
            // 
            this.lblCameraInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCameraInfo.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.lblCameraInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCameraInfo.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCameraInfo.ForeColor = System.Drawing.Color.Red;
            this.lblCameraInfo.Location = new System.Drawing.Point(12, 12);
            this.lblCameraInfo.Name = "lblCameraInfo";
            this.lblCameraInfo.Size = new System.Drawing.Size(881, 46);
            this.lblCameraInfo.TabIndex = 7;
            this.lblCameraInfo.Text = "labelX1";
            this.lblCameraInfo.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.lblCameraInfo.WordWrap = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // VideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 891);
            this.Controls.Add(this.lblCameraInfo);
            this.Controls.Add(this.picVideo);
            this.Controls.Add(this.panel1);
            this.Name = "VideoControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoControl";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoControl_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraPos)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dInputExposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iInputGain)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iInputCurrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iInputChgValue)).EndInit();
            this.panelPos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iInputCameraPos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iInputMoveValue)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dInputFPS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picVideo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelPos;
        private DevComponents.DotNetBar.ButtonX btnMoveTo;
        private DevComponents.Editors.IntegerInput iInputCameraPos;
        private DevComponents.DotNetBar.ButtonX btnSetPos;
        private DevComponents.DotNetBar.ButtonX btnRight;
        private DevComponents.DotNetBar.ButtonX btnDown;
        private DevComponents.DotNetBar.ButtonX btnLeft;
        private DevComponents.DotNetBar.ButtonX btnUP;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private DevComponents.Editors.IntegerInput iInputChgValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnFocusPlus;
        private DevComponents.DotNetBar.ButtonX btnFocusMinus;
        private System.Windows.Forms.Label label11;
        private DevComponents.Editors.IntegerInput iInputCurrValue;
        private DevComponents.Editors.IntegerInput iInputGain;
        private DevComponents.DotNetBar.ButtonX btnSetParamOk;
        private DevComponents.Editors.DoubleInput dInputExposure;
        private DevComponents.DotNetBar.Controls.SwitchButton sBtnDisplay;
        private DevComponents.DotNetBar.Controls.SwitchButton sBtnTriggerMode;
        private DevComponents.DotNetBar.ButtonX btnCameraPosView;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCameraPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn 线路名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 预置位;
        private DevComponents.Editors.DoubleInput dInputFPS;
        private DevComponents.DotNetBar.ButtonX btnSetFPSOk;
        private DevComponents.DotNetBar.LabelX lblCameraInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private DevComponents.Editors.IntegerInput iInputMoveValue;
        private System.Windows.Forms.Label label12;
    }
}