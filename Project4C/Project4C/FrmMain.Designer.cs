namespace Project4C {
    partial class FrmMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.sNavMenuSel = new DevComponents.DotNetBar.Controls.SideNav();
            this.sideNavPanel2 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.sideNavPanel1 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lnkImportDir = new System.Windows.Forms.LinkLabel();
            this.lblValue = new DevComponents.DotNetBar.LabelX();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.lblTip = new DevComponents.DotNetBar.LabelX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.sideNavPanel3 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.sTabCtrlDataSel = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.btnOnline = new DevComponents.DotNetBar.ButtonX();
            this.ipAddressInput = new DevComponents.Editors.IpAddressInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.sTabCtlPanelOffline = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lblDBPath = new System.Windows.Forms.LinkLabel();
            this.btnOffLine = new DevComponents.DotNetBar.ButtonX();
            this.btnOpenDir = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dateTimeInput = new System.Windows.Forms.DateTimePicker();
            this.cbBoxEndStation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBoxStartStation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBoxLineInfo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBoxUpDown = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sNavPanelDataAnalyse = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.sNavPanelReport = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.sideNavItem1 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.separator1 = new DevComponents.DotNetBar.Separator();
            this.sNavItemDBM = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sNavItemAnalyse = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sNavItemReport = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.separator2 = new DevComponents.DotNetBar.Separator();
            this.sNavItemSet = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.styleManagerAmbient1 = new DevComponents.DotNetBar.StyleManagerAmbient(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.lblTaskInfo = new System.Windows.Forms.Label();
            this.sNavMenuSel.SuspendLayout();
            this.sideNavPanel2.SuspendLayout();
            this.sideNavPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.sideNavPanel3.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sTabCtrlDataSel)).BeginInit();
            this.sTabCtrlDataSel.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput)).BeginInit();
            this.sTabCtlPanelOffline.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sNavMenuSel
            // 
            this.sNavMenuSel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sNavMenuSel.BackgroundImage")));
            this.sNavMenuSel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sNavMenuSel.Controls.Add(this.sideNavPanel3);
            this.sNavMenuSel.Controls.Add(this.sideNavPanel2);
            this.sNavMenuSel.Controls.Add(this.sNavPanelDataAnalyse);
            this.sNavMenuSel.Controls.Add(this.sNavPanelReport);
            this.sNavMenuSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sNavMenuSel.EnableClose = false;
            this.sNavMenuSel.EnableMaximize = false;
            this.sNavMenuSel.EnableSplitter = false;
            this.sNavMenuSel.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sideNavItem1,
            this.separator1,
            this.sNavItemDBM,
            this.sNavItemAnalyse,
            this.sNavItemReport,
            this.separator2,
            this.sNavItemSet});
            this.sNavMenuSel.Location = new System.Drawing.Point(0, 0);
            this.sNavMenuSel.Name = "sNavMenuSel";
            this.sNavMenuSel.Padding = new System.Windows.Forms.Padding(1);
            this.sNavMenuSel.Size = new System.Drawing.Size(1393, 656);
            this.sNavMenuSel.TabIndex = 0;
            this.sNavMenuSel.TabStop = false;
            this.sNavMenuSel.SelectedItemChanged += new System.EventHandler(this.sNavMenuSel_SelectedItemChanged);
            this.sNavMenuSel.TabIndexChanged += new System.EventHandler(this.sNavMenuSel_TabIndexChanged);
            // 
            // sideNavPanel2
            // 
            this.sideNavPanel2.Controls.Add(this.sideNavPanel1);
            this.sideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel2.Location = new System.Drawing.Point(111, 32);
            this.sideNavPanel2.Name = "sideNavPanel2";
            this.sideNavPanel2.Size = new System.Drawing.Size(1281, 623);
            this.sideNavPanel2.TabIndex = 6;
            this.sideNavPanel2.Visible = false;
            // 
            // sideNavPanel1
            // 
            this.sideNavPanel1.Controls.Add(this.groupPanel2);
            this.sideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel1.Location = new System.Drawing.Point(0, 0);
            this.sideNavPanel1.Name = "sideNavPanel1";
            this.sideNavPanel1.Size = new System.Drawing.Size(1281, 623);
            this.sideNavPanel1.TabIndex = 10;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel2.Controls.Add(this.lnkImportDir);
            this.groupPanel2.Controls.Add(this.lblValue);
            this.groupPanel2.Controls.Add(this.btnImport);
            this.groupPanel2.Controls.Add(this.lblTip);
            this.groupPanel2.Controls.Add(this.progressBarX1);
            this.groupPanel2.Controls.Add(this.buttonX2);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel2.Location = new System.Drawing.Point(147, 37);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(595, 126);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.AliceBlue;
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 37;
            this.groupPanel2.Text = "导出一杆一档图像数据";
            // 
            // lnkImportDir
            // 
            this.lnkImportDir.LinkColor = System.Drawing.Color.Black;
            this.lnkImportDir.Location = new System.Drawing.Point(133, 29);
            this.lnkImportDir.Name = "lnkImportDir";
            this.lnkImportDir.Size = new System.Drawing.Size(322, 20);
            this.lnkImportDir.TabIndex = 33;
            this.lnkImportDir.TabStop = true;
            this.lnkImportDir.Text = "选择导出图像目录";
            this.lnkImportDir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDir_LinkClicked);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblValue.ForeColor = System.Drawing.Color.Blue;
            this.lblValue.Location = new System.Drawing.Point(526, 64);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(28, 23);
            this.lblValue.TabIndex = 36;
            this.lblValue.Text = "0%";
            this.lblValue.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImport.Location = new System.Drawing.Point(472, 28);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.TabIndex = 33;
            this.btnImport.Text = "导出数据";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.Color.Yellow;
            this.lblTip.Location = new System.Drawing.Point(43, 93);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 0);
            this.lblTip.TabIndex = 36;
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(40, 64);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(480, 23);
            this.progressBarX1.TabIndex = 35;
            this.progressBarX1.Text = "progressBarX1";
            this.progressBarX1.Visible = false;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX2.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.buttonX2.Location = new System.Drawing.Point(40, 21);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(87, 37);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 32;
            this.buttonX2.Text = "导出目录";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // sideNavPanel3
            // 
            this.sideNavPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sideNavPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sideNavPanel3.Controls.Add(this.panelEx1);
            this.sideNavPanel3.Controls.Add(this.pictureBox1);
            this.sideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel3.Location = new System.Drawing.Point(111, 32);
            this.sideNavPanel3.Name = "sideNavPanel3";
            this.sideNavPanel3.Size = new System.Drawing.Size(1281, 623);
            this.sideNavPanel3.TabIndex = 10;
            this.sideNavPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.sideNavPanel3_Paint);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.sTabCtrlDataSel);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(441, 310);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(679, 213);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 6;
            // 
            // sTabCtrlDataSel
            // 
            this.sTabCtrlDataSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
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
            this.sTabCtrlDataSel.Controls.Add(this.superTabControlPanel1);
            this.sTabCtrlDataSel.Controls.Add(this.sTabCtlPanelOffline);
            this.sTabCtrlDataSel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.sTabCtrlDataSel.ForeColor = System.Drawing.Color.White;
            this.sTabCtrlDataSel.Location = new System.Drawing.Point(62, 17);
            this.sTabCtrlDataSel.Name = "sTabCtrlDataSel";
            this.sTabCtrlDataSel.ReorderTabsEnabled = true;
            this.sTabCtrlDataSel.SelectedTabFont = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.sTabCtrlDataSel.SelectedTabIndex = 1;
            this.sTabCtrlDataSel.Size = new System.Drawing.Size(565, 82);
            this.sTabCtrlDataSel.TabFont = new System.Drawing.Font("微软雅黑", 10F);
            this.sTabCtrlDataSel.TabIndex = 1;
            this.sTabCtrlDataSel.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2});
            this.sTabCtrlDataSel.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.integerInput1);
            this.superTabControlPanel1.Controls.Add(this.btnOnline);
            this.superTabControlPanel1.Controls.Add(this.ipAddressInput);
            this.superTabControlPanel1.Controls.Add(this.labelX7);
            this.superTabControlPanel1.Controls.Add(this.labelX1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 32);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(565, 50);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            this.superTabControlPanel1.Visible = false;
            // 
            // integerInput1
            // 
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput1.Location = new System.Drawing.Point(393, 13);
            this.integerInput1.Margin = new System.Windows.Forms.Padding(2);
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.ShowUpDown = true;
            this.integerInput1.Size = new System.Drawing.Size(60, 27);
            this.integerInput1.TabIndex = 20;
            this.integerInput1.Value = 6379;
            // 
            // btnOnline
            // 
            this.btnOnline.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOnline.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOnline.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOnline.Location = new System.Drawing.Point(472, 8);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(69, 39);
            this.btnOnline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOnline.TabIndex = 5;
            this.btnOnline.Text = "确定";
            this.btnOnline.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // ipAddressInput
            // 
            this.ipAddressInput.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInput.ButtonFreeText.Visible = true;
            this.ipAddressInput.Location = new System.Drawing.Point(159, 13);
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
            this.labelX7.Location = new System.Drawing.Point(353, 15);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(50, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "端口：";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelX1.Location = new System.Drawing.Point(41, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(132, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "数据库IP地址：";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "在线数据分析";
            // 
            // sTabCtlPanelOffline
            // 
            this.sTabCtlPanelOffline.Controls.Add(this.lblDBPath);
            this.sTabCtlPanelOffline.Controls.Add(this.btnOffLine);
            this.sTabCtlPanelOffline.Controls.Add(this.btnOpenDir);
            this.sTabCtlPanelOffline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sTabCtlPanelOffline.Location = new System.Drawing.Point(0, 32);
            this.sTabCtlPanelOffline.Name = "sTabCtlPanelOffline";
            this.sTabCtlPanelOffline.Size = new System.Drawing.Size(565, 50);
            this.sTabCtlPanelOffline.TabIndex = 0;
            this.sTabCtlPanelOffline.TabItem = this.superTabItem2;
            // 
            // lblDBPath
            // 
            this.lblDBPath.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblDBPath.Location = new System.Drawing.Point(122, 15);
            this.lblDBPath.Name = "lblDBPath";
            this.lblDBPath.Size = new System.Drawing.Size(322, 20);
            this.lblDBPath.TabIndex = 5;
            this.lblDBPath.TabStop = true;
            this.lblDBPath.Text = "选择离线数据库";
            this.lblDBPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDir_LinkClicked);
            // 
            // btnOffLine
            // 
            this.btnOffLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOffLine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOffLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOffLine.Location = new System.Drawing.Point(474, 9);
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
            this.btnOpenDir.Location = new System.Drawing.Point(25, 7);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(87, 37);
            this.btnOpenDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOpenDir.TabIndex = 4;
            this.btnOpenDir.Text = "数据库选择";
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.sTabCtlPanelOffline;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "离线数据分析";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dateTimeInput);
            this.groupPanel1.Controls.Add(this.cbBoxEndStation);
            this.groupPanel1.Controls.Add(this.cbBoxStartStation);
            this.groupPanel1.Controls.Add(this.cbBoxLineInfo);
            this.groupPanel1.Controls.Add(this.cbBoxUpDown);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(62, 105);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(565, 92);
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
            this.cbBoxEndStation.FormattingEnabled = true;
            this.cbBoxEndStation.ItemHeight = 17;
            this.cbBoxEndStation.Location = new System.Drawing.Point(281, -1);
            this.cbBoxEndStation.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxEndStation.Name = "cbBoxEndStation";
            this.cbBoxEndStation.Size = new System.Drawing.Size(149, 23);
            this.cbBoxEndStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.cbBoxEndStation.TabIndex = 19;
            this.cbBoxEndStation.TextChanged += new System.EventHandler(this.cbTaskInfo_TextChanged);
            // 
            // cbBoxStartStation
            // 
            this.cbBoxStartStation.DisplayMember = "Text";
            this.cbBoxStartStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxStartStation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbBoxStartStation.FormattingEnabled = true;
            this.cbBoxStartStation.ItemHeight = 17;
            this.cbBoxStartStation.Location = new System.Drawing.Point(82, -1);
            this.cbBoxStartStation.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxStartStation.Name = "cbBoxStartStation";
            this.cbBoxStartStation.Size = new System.Drawing.Size(153, 23);
            this.cbBoxStartStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.cbBoxStartStation.TabIndex = 19;
            this.cbBoxStartStation.TextChanged += new System.EventHandler(this.cbTaskInfo_TextChanged);
            // 
            // cbBoxLineInfo
            // 
            this.cbBoxLineInfo.DisplayMember = "Text";
            this.cbBoxLineInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxLineInfo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbBoxLineInfo.FormattingEnabled = true;
            this.cbBoxLineInfo.ItemHeight = 17;
            this.cbBoxLineInfo.Location = new System.Drawing.Point(82, 31);
            this.cbBoxLineInfo.Name = "cbBoxLineInfo";
            this.cbBoxLineInfo.Size = new System.Drawing.Size(197, 23);
            this.cbBoxLineInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxLineInfo.TabIndex = 18;
            this.cbBoxLineInfo.TextChanged += new System.EventHandler(this.cbTaskInfo_TextChanged);
            // 
            // cbBoxUpDown
            // 
            this.cbBoxUpDown.DisplayMember = "Text";
            this.cbBoxUpDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxUpDown.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbBoxUpDown.FormattingEnabled = true;
            this.cbBoxUpDown.ItemHeight = 17;
            this.cbBoxUpDown.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbBoxUpDown.Location = new System.Drawing.Point(496, 2);
            this.cbBoxUpDown.Name = "cbBoxUpDown";
            this.cbBoxUpDown.Size = new System.Drawing.Size(58, 23);
            this.cbBoxUpDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxUpDown.TabIndex = 18;
            this.cbBoxUpDown.Text = "上行";
            this.cbBoxUpDown.TextChanged += new System.EventHandler(this.cbTaskInfo_TextChanged);
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
            this.labelX3.ForeColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(6, 29);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "线路信息：";
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
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(11, 1);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 23);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "站区(间)：";
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
            this.labelX5.ForeColor = System.Drawing.Color.White;
            this.labelX5.Location = new System.Drawing.Point(451, 2);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(50, 23);
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
            this.labelX4.ForeColor = System.Drawing.Color.White;
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
            this.labelX6.ForeColor = System.Drawing.Color.White;
            this.labelX6.Location = new System.Drawing.Point(297, 33);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(79, 23);
            this.labelX6.TabIndex = 9;
            this.labelX6.Text = "检测时间：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1279, 621);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // sNavPanelDataAnalyse
            // 
            this.sNavPanelDataAnalyse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sNavPanelDataAnalyse.Location = new System.Drawing.Point(111, 32);
            this.sNavPanelDataAnalyse.Name = "sNavPanelDataAnalyse";
            this.sNavPanelDataAnalyse.Size = new System.Drawing.Size(1281, 623);
            this.sNavPanelDataAnalyse.TabIndex = 2;
            this.sNavPanelDataAnalyse.Visible = false;
            // 
            // sNavPanelReport
            // 
            this.sNavPanelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sNavPanelReport.Location = new System.Drawing.Point(111, 32);
            this.sNavPanelReport.Name = "sNavPanelReport";
            this.sNavPanelReport.Size = new System.Drawing.Size(1281, 623);
            this.sNavPanelReport.TabIndex = 24;
            this.sNavPanelReport.Visible = false;
            // 
            // sideNavItem1
            // 
            this.sideNavItem1.IsSystemMenu = true;
            this.sideNavItem1.Name = "sideNavItem1";
            this.sideNavItem1.Symbol = "";
            // 
            // separator1
            // 
            this.separator1.FixedSize = new System.Drawing.Size(3, 1);
            this.separator1.Name = "separator1";
            this.separator1.Padding.Bottom = 2;
            this.separator1.Padding.Left = 6;
            this.separator1.Padding.Right = 6;
            this.separator1.Padding.Top = 2;
            this.separator1.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical;
            // 
            // sNavItemDBM
            // 
            this.sNavItemDBM.Checked = true;
            this.sNavItemDBM.Name = "sNavItemDBM";
            this.sNavItemDBM.Panel = this.sideNavPanel3;
            this.sNavItemDBM.Symbol = "";
            this.sNavItemDBM.Text = "任务管理";
            this.sNavItemDBM.Click += new System.EventHandler(this.sNavItemDBM_Click);
            // 
            // sNavItemAnalyse
            // 
            this.sNavItemAnalyse.Name = "sNavItemAnalyse";
            this.sNavItemAnalyse.Panel = this.sNavPanelDataAnalyse;
            this.sNavItemAnalyse.PopupSide = DevComponents.DotNetBar.ePopupSide.Top;
            this.sNavItemAnalyse.Symbol = "";
            this.sNavItemAnalyse.Text = "人工分析";
            // 
            // sNavItemReport
            // 
            this.sNavItemReport.Name = "sNavItemReport";
            this.sNavItemReport.Panel = this.sNavPanelReport;
            this.sNavItemReport.Symbol = "";
            this.sNavItemReport.Text = "缺陷报告";
            // 
            // separator2
            // 
            this.separator2.FixedSize = new System.Drawing.Size(3, 1);
            this.separator2.Name = "separator2";
            this.separator2.Padding.Bottom = 2;
            this.separator2.Padding.Left = 6;
            this.separator2.Padding.Right = 6;
            this.separator2.Padding.Top = 2;
            this.separator2.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical;
            // 
            // sNavItemSet
            // 
            this.sNavItemSet.Name = "sNavItemSet";
            this.sNavItemSet.Panel = this.sideNavPanel2;
            this.sNavItemSet.Symbol = "";
            this.sNavItemSet.Text = "系统设置";
            this.sNavItemSet.Click += new System.EventHandler(this.sideNavItem3_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // lblTaskInfo
            // 
            this.lblTaskInfo.AutoSize = true;
            this.lblTaskInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTaskInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTaskInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblTaskInfo.Location = new System.Drawing.Point(171, 6);
            this.lblTaskInfo.Name = "lblTaskInfo";
            this.lblTaskInfo.Size = new System.Drawing.Size(51, 19);
            this.lblTaskInfo.TabIndex = 31;
            this.lblTaskInfo.Text = "label1";
            this.lblTaskInfo.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 656);
            this.Controls.Add(this.lblTaskInfo);
            this.Controls.Add(this.sNavMenuSel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "人工分析软件";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.sNavMenuSel.ResumeLayout(false);
            this.sNavMenuSel.PerformLayout();
            this.sideNavPanel2.ResumeLayout(false);
            this.sideNavPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.sideNavPanel3.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sTabCtrlDataSel)).EndInit();
            this.sTabCtrlDataSel.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput)).EndInit();
            this.sTabCtlPanelOffline.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.SideNav sNavMenuSel;
        private DevComponents.DotNetBar.Controls.SideNavPanel sNavPanelDataAnalyse;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem1;
        private DevComponents.DotNetBar.Separator separator1;
        private DevComponents.DotNetBar.Controls.SideNavItem sNavItemAnalyse;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel2;
        private DevComponents.DotNetBar.Controls.SideNavItem sNavItemSet;
        private DevComponents.DotNetBar.StyleManagerAmbient styleManagerAmbient1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel3;
        private DevComponents.DotNetBar.Controls.SideNavItem sNavItemDBM;
        private DevComponents.DotNetBar.SuperTabControl sTabCtrlDataSel;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.Editors.IpAddressInput ipAddressInput;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel sTabCtlPanelOffline;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.ButtonX btnOffLine;
        private DevComponents.DotNetBar.ButtonX btnOpenDir;
        private DevComponents.DotNetBar.ButtonX btnOnline;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Separator separator2;
        private DevComponents.DotNetBar.Controls.SideNavPanel sNavPanelReport;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel1;
        private DevComponents.DotNetBar.Controls.SideNavItem sNavItemReport;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxEndStation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxStartStation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxUpDown;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.IntegerInput integerInput1;
        private System.Windows.Forms.Label lblTaskInfo;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.LinkLabel lblDBPath;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxLineInfo;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.DateTimePicker dateTimeInput;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private System.Windows.Forms.LinkLabel lnkImportDir;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.LabelX lblTip;
        private DevComponents.DotNetBar.LabelX lblValue;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
    }
}

