namespace Project4C.UI {
    partial class FrmTaskMgr {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskMgr));
            this.panelInfo = new DevComponents.DotNetBar.PanelEx();
            this.sTabCtrlDataSel = new DevComponents.DotNetBar.SuperTabControl();
            this.sTabCtlPanelOnline = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.btnOnline = new DevComponents.DotNetBar.ButtonX();
            this.ipAddressInput = new DevComponents.Editors.IpAddressInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.sTabCtlPanelOffline = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lblDBPath = new System.Windows.Forms.LinkLabel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dateTimeInput = new System.Windows.Forms.DateTimePicker();
            this.cbBoxEndStation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbBoxStartStation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBoxLineInfo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBoxUpDown = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnOffLine = new DevComponents.DotNetBar.ButtonX();
            this.btnOpenDir = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSelOnline = new DevComponents.DotNetBar.ButtonX();
            this.btnSelOffline = new DevComponents.DotNetBar.ButtonX();
            this.cbEnableModify = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sTabCtrlDataSel)).BeginInit();
            this.sTabCtrlDataSel.SuspendLayout();
            this.sTabCtlPanelOnline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput)).BeginInit();
            this.sTabCtlPanelOffline.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelInfo.CanvasColor = System.Drawing.Color.Transparent;
            this.panelInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelInfo.Controls.Add(this.sTabCtrlDataSel);
            this.panelInfo.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelInfo.Location = new System.Drawing.Point(234, 210);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(752, 244);
            this.panelInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelInfo.Style.GradientAngle = 90;
            this.panelInfo.TabIndex = 10;
            // 
            // sTabCtrlDataSel
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.sTabCtrlDataSel.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.sTabCtrlDataSel.ControlBox.MenuBox.Name = "";
            this.sTabCtrlDataSel.ControlBox.Name = "";
            this.sTabCtrlDataSel.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sTabCtrlDataSel.ControlBox.MenuBox,
            this.sTabCtrlDataSel.ControlBox.CloseBox});
            this.sTabCtrlDataSel.Controls.Add(this.sTabCtlPanelOffline);
            this.sTabCtrlDataSel.Controls.Add(this.sTabCtlPanelOnline);
            this.sTabCtrlDataSel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.sTabCtrlDataSel.ForeColor = System.Drawing.Color.White;
            this.sTabCtrlDataSel.Location = new System.Drawing.Point(62, 17);
            this.sTabCtrlDataSel.Name = "sTabCtrlDataSel";
            this.sTabCtrlDataSel.ReorderTabsEnabled = true;
            this.sTabCtrlDataSel.SelectedTabFont = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.sTabCtrlDataSel.SelectedTabIndex = 1;
            this.sTabCtrlDataSel.Size = new System.Drawing.Size(627, 212);
            this.sTabCtrlDataSel.TabFont = new System.Drawing.Font("微软雅黑", 10F);
            this.sTabCtrlDataSel.TabIndex = 1;
            this.sTabCtrlDataSel.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2});
            this.sTabCtrlDataSel.Text = "superTabControl1";
            // 
            // sTabCtlPanelOnline
            // 
            this.sTabCtlPanelOnline.CanvasColor = System.Drawing.Color.Transparent;
            this.sTabCtlPanelOnline.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sTabCtlPanelOnline.Controls.Add(this.integerInput1);
            this.sTabCtlPanelOnline.Controls.Add(this.btnOnline);
            this.sTabCtlPanelOnline.Controls.Add(this.ipAddressInput);
            this.sTabCtlPanelOnline.Controls.Add(this.labelX7);
            this.sTabCtlPanelOnline.Controls.Add(this.labelX1);
            this.sTabCtlPanelOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sTabCtlPanelOnline.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sTabCtlPanelOnline.Location = new System.Drawing.Point(0, 32);
            this.sTabCtlPanelOnline.Name = "sTabCtlPanelOnline";
            this.sTabCtlPanelOnline.Size = new System.Drawing.Size(621, 162);
            this.sTabCtlPanelOnline.TabIndex = 1;
            this.sTabCtlPanelOnline.TabItem = this.superTabItem1;
            // 
            // integerInput1
            // 
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.BackColor = System.Drawing.Color.DimGray;
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput1.Location = new System.Drawing.Point(399, 60);
            this.integerInput1.Margin = new System.Windows.Forms.Padding(2);
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.ShowUpDown = true;
            this.integerInput1.Size = new System.Drawing.Size(74, 27);
            this.integerInput1.TabIndex = 20;
            this.integerInput1.Value = 6379;
            // 
            // btnOnline
            // 
            this.btnOnline.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOnline.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOnline.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOnline.Location = new System.Drawing.Point(498, 54);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(69, 39);
            this.btnOnline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOnline.TabIndex = 5;
            this.btnOnline.Text = "确定";
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // ipAddressInput
            // 
            this.ipAddressInput.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInput.BackgroundStyle.BackColor = System.Drawing.Color.DimGray;
            this.ipAddressInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInput.ButtonFreeText.Visible = true;
            this.ipAddressInput.Colors.HighlightText = System.Drawing.Color.Black;
            this.ipAddressInput.DisabledBackColor = System.Drawing.Color.White;
            this.ipAddressInput.DisabledForeColor = System.Drawing.Color.Gray;
            this.ipAddressInput.FocusHighlightColor = System.Drawing.Color.Blue;
            this.ipAddressInput.Location = new System.Drawing.Point(165, 60);
            this.ipAddressInput.Name = "ipAddressInput";
            this.ipAddressInput.Size = new System.Drawing.Size(185, 27);
            this.ipAddressInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInput.TabIndex = 1;
            this.ipAddressInput.Value = "127.0.0.1";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(359, 62);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(50, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "端口：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(47, 62);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(107, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "数据库IP地址：";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.sTabCtlPanelOnline;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "在线数据分析";
            // 
            // sTabCtlPanelOffline
            // 
            this.sTabCtlPanelOffline.CanvasColor = System.Drawing.Color.Transparent;
            this.sTabCtlPanelOffline.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sTabCtlPanelOffline.Controls.Add(this.cbEnableModify);
            this.sTabCtlPanelOffline.Controls.Add(this.lblDBPath);
            this.sTabCtlPanelOffline.Controls.Add(this.groupPanel1);
            this.sTabCtlPanelOffline.Controls.Add(this.btnOffLine);
            this.sTabCtlPanelOffline.Controls.Add(this.btnOpenDir);
            this.sTabCtlPanelOffline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sTabCtlPanelOffline.Location = new System.Drawing.Point(0, 32);
            this.sTabCtlPanelOffline.Name = "sTabCtlPanelOffline";
            this.sTabCtlPanelOffline.Size = new System.Drawing.Size(627, 180);
            this.sTabCtlPanelOffline.TabIndex = 0;
            this.sTabCtlPanelOffline.TabItem = this.superTabItem2;
            // 
            // lblDBPath
            // 
            this.lblDBPath.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDBPath.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblDBPath.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblDBPath.Location = new System.Drawing.Point(122, 23);
            this.lblDBPath.Name = "lblDBPath";
            this.lblDBPath.Size = new System.Drawing.Size(364, 20);
            this.lblDBPath.TabIndex = 5;
            this.lblDBPath.TabStop = true;
            this.lblDBPath.Text = "选择离线数据库";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dateTimeInput);
            this.groupPanel1.Controls.Add(this.cbBoxEndStation);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.cbBoxStartStation);
            this.groupPanel1.Controls.Add(this.cbBoxLineInfo);
            this.groupPanel1.Controls.Add(this.cbBoxUpDown);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Enabled = false;
            this.groupPanel1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(11, 81);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(575, 92);
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
            this.groupPanel1.TabIndex = 19;
            this.groupPanel1.Text = "任务信息";
            // 
            // dateTimeInput
            // 
            this.dateTimeInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimeInput.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dateTimeInput.Location = new System.Drawing.Point(373, 31);
            this.dateTimeInput.Name = "dateTimeInput";
            this.dateTimeInput.Size = new System.Drawing.Size(181, 23);
            this.dateTimeInput.TabIndex = 20;
            // 
            // cbBoxEndStation
            // 
            this.cbBoxEndStation.DisplayMember = "Text";
            this.cbBoxEndStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxEndStation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbBoxEndStation.ForeColor = System.Drawing.Color.Black;
            this.cbBoxEndStation.FormattingEnabled = true;
            this.cbBoxEndStation.ItemHeight = 17;
            this.cbBoxEndStation.Location = new System.Drawing.Point(281, -1);
            this.cbBoxEndStation.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxEndStation.Name = "cbBoxEndStation";
            this.cbBoxEndStation.Size = new System.Drawing.Size(149, 23);
            this.cbBoxEndStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.cbBoxEndStation.TabIndex = 19;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(9, -1);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 23);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "站区(间)：";
            // 
            // cbBoxStartStation
            // 
            this.cbBoxStartStation.DisabledForeColor = System.Drawing.Color.Black;
            this.cbBoxStartStation.DisplayMember = "Text";
            this.cbBoxStartStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxStartStation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbBoxStartStation.ForeColor = System.Drawing.Color.Black;
            this.cbBoxStartStation.FormattingEnabled = true;
            this.cbBoxStartStation.ItemHeight = 17;
            this.cbBoxStartStation.Location = new System.Drawing.Point(82, -1);
            this.cbBoxStartStation.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxStartStation.Name = "cbBoxStartStation";
            this.cbBoxStartStation.Size = new System.Drawing.Size(153, 23);
            this.cbBoxStartStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.cbBoxStartStation.TabIndex = 19;
            // 
            // cbBoxLineInfo
            // 
            this.cbBoxLineInfo.DisplayMember = "Text";
            this.cbBoxLineInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxLineInfo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbBoxLineInfo.ForeColor = System.Drawing.Color.Black;
            this.cbBoxLineInfo.FormattingEnabled = true;
            this.cbBoxLineInfo.ItemHeight = 17;
            this.cbBoxLineInfo.Location = new System.Drawing.Point(82, 31);
            this.cbBoxLineInfo.Name = "cbBoxLineInfo";
            this.cbBoxLineInfo.Size = new System.Drawing.Size(197, 23);
            this.cbBoxLineInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.cbBoxLineInfo.TabIndex = 18;
            // 
            // cbBoxUpDown
            // 
            this.cbBoxUpDown.DisplayMember = "Text";
            this.cbBoxUpDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxUpDown.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbBoxUpDown.ForeColor = System.Drawing.Color.Black;
            this.cbBoxUpDown.FormattingEnabled = true;
            this.cbBoxUpDown.ItemHeight = 17;
            this.cbBoxUpDown.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbBoxUpDown.Location = new System.Drawing.Point(496, 2);
            this.cbBoxUpDown.Name = "cbBoxUpDown";
            this.cbBoxUpDown.Size = new System.Drawing.Size(58, 23);
            this.cbBoxUpDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.cbBoxUpDown.TabIndex = 18;
            this.cbBoxUpDown.Text = "上行";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "上行";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "下行";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(6, 29);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 23);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "线路信息：";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(451, 2);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(50, 23);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "行别：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(240, -1);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(44, 23);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "<—>";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(297, 33);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(79, 23);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 9;
            this.labelX6.Text = "检测时间：";
            // 
            // btnOffLine
            // 
            this.btnOffLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOffLine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOffLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOffLine.Location = new System.Drawing.Point(511, 13);
            this.btnOffLine.Name = "btnOffLine";
            this.btnOffLine.Size = new System.Drawing.Size(66, 40);
            this.btnOffLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOffLine.TabIndex = 4;
            this.btnOffLine.Text = "选择确定";
            this.btnOffLine.Click += new System.EventHandler(this.btnTaskOk_Click);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpenDir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpenDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDir.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btnOpenDir.Location = new System.Drawing.Point(11, 15);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(101, 37);
            this.btnOpenDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOpenDir.TabIndex = 4;
            this.btnOpenDir.Text = "离线数据目录";
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.sTabCtlPanelOffline;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "离线数据分析";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1120, 585);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnSelOnline
            // 
            this.btnSelOnline.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelOnline.BackColor = System.Drawing.Color.Transparent;
            this.btnSelOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelOnline.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelOnline.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelOnline.Image = ((System.Drawing.Image)(resources.GetObject("btnSelOnline.Image")));
            this.btnSelOnline.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnSelOnline.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSelOnline.Location = new System.Drawing.Point(422, 445);
            this.btnSelOnline.Name = "btnSelOnline";
            this.btnSelOnline.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(16);
            this.btnSelOnline.Size = new System.Drawing.Size(128, 128);
            this.btnSelOnline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelOnline.TabIndex = 15;
            this.btnSelOnline.Text = "在线监测";
            this.btnSelOnline.Click += new System.EventHandler(this.btnSelOnline_Click);
            // 
            // btnSelOffline
            // 
            this.btnSelOffline.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelOffline.BackColor = System.Drawing.Color.Transparent;
            this.btnSelOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelOffline.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelOffline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelOffline.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelOffline.Image = ((System.Drawing.Image)(resources.GetObject("btnSelOffline.Image")));
            this.btnSelOffline.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnSelOffline.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSelOffline.Location = new System.Drawing.Point(683, 445);
            this.btnSelOffline.Name = "btnSelOffline";
            this.btnSelOffline.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(16);
            this.btnSelOffline.Size = new System.Drawing.Size(128, 128);
            this.btnSelOffline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelOffline.TabIndex = 15;
            this.btnSelOffline.Text = "离线分析";
            this.btnSelOffline.Click += new System.EventHandler(this.btnSelOffline_Click);
            // 
            // cbEnableModify
            // 
            this.cbEnableModify.AutoSize = true;
            // 
            // 
            // 
            this.cbEnableModify.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbEnableModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbEnableModify.Location = new System.Drawing.Point(15, 64);
            this.cbEnableModify.Name = "cbEnableModify";
            this.cbEnableModify.Size = new System.Drawing.Size(109, 22);
            this.cbEnableModify.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEnableModify.TabIndex = 21;
            this.cbEnableModify.Text = "修改任务信息";
            this.cbEnableModify.CheckedChanged += new System.EventHandler(this.cbEnableModify_CheckedChanged);
            // 
            // FrmTaskMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 585);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelOffline);
            this.Controls.Add(this.btnSelOnline);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaskMgr";
            this.ShowIcon = false;
            this.TitleText = "任务选择";
            this.Shown += new System.EventHandler(this.FrmTaskMgr_Shown);
            this.ResizeEnd += new System.EventHandler(this.FrmTaskMgr_ResizeEnd);
            this.Resize += new System.EventHandler(this.FrmTaskMgr_Resize);
            this.panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sTabCtrlDataSel)).EndInit();
            this.sTabCtrlDataSel.ResumeLayout(false);
            this.sTabCtlPanelOnline.ResumeLayout(false);
            this.sTabCtlPanelOnline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput)).EndInit();
            this.sTabCtlPanelOffline.ResumeLayout(false);
            this.sTabCtlPanelOffline.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.PanelEx panelInfo;
        private DevComponents.DotNetBar.SuperTabControl sTabCtrlDataSel;
        private DevComponents.DotNetBar.SuperTabControlPanel sTabCtlPanelOnline;
        private DevComponents.Editors.IntegerInput integerInput1;
        private DevComponents.DotNetBar.ButtonX btnOnline;
        private DevComponents.Editors.IpAddressInput ipAddressInput;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel sTabCtlPanelOffline;
        private System.Windows.Forms.LinkLabel lblDBPath;
        private DevComponents.DotNetBar.ButtonX btnOffLine;
        private DevComponents.DotNetBar.ButtonX btnOpenDir;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DateTimePicker dateTimeInput;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxEndStation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxStartStation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxLineInfo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxUpDown;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnSelOnline;
        private DevComponents.DotNetBar.ButtonX btnSelOffline;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbEnableModify;
    }
}