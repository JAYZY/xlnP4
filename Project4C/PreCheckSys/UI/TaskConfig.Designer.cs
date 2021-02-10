namespace PreCheckSys.UI {
    partial class TaskConfig {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskConfig));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbBoxEndStation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBoxTarskLineName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbBoxStartStation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblTaskDate = new DevComponents.DotNetBar.LabelX();
            this.linkLblDbPath = new System.Windows.Forms.LinkLabel();
            this.cbBoxUpDown = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.btnImportBaseData = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.cbBackDisk = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ckIsBack = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblMainDBTip = new DevComponents.DotNetBar.LabelX();
            this.dgvTask = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsBack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TMItemDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX7.ForeColor = System.Drawing.Color.White;
            this.labelX7.Location = new System.Drawing.Point(27, 71);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(90, 26);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 14;
            this.labelX7.Text = "线路信息：";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.ForeColor = System.Drawing.Color.White;
            this.labelX5.Location = new System.Drawing.Point(27, 28);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(90, 26);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 40;
            this.labelX5.Text = "检测日期：";
            // 
            // cbBoxEndStation
            // 
            this.cbBoxEndStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBoxEndStation.DisplayMember = "Text";
            this.cbBoxEndStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxEndStation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxEndStation.ForeColor = System.Drawing.Color.Black;
            this.cbBoxEndStation.FormattingEnabled = true;
            this.cbBoxEndStation.ItemHeight = 20;
            this.cbBoxEndStation.Location = new System.Drawing.Point(339, 114);
            this.cbBoxEndStation.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxEndStation.Name = "cbBoxEndStation";
            this.cbBoxEndStation.Size = new System.Drawing.Size(196, 26);
            this.cbBoxEndStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxEndStation.TabIndex = 19;
            this.cbBoxEndStation.SelectedIndexChanged += new System.EventHandler(this.cbBoxEndStation_SelectedIndexChanged);
            // 
            // cbBoxTarskLineName
            // 
            this.cbBoxTarskLineName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBoxTarskLineName.DisplayMember = "Text";
            this.cbBoxTarskLineName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxTarskLineName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxTarskLineName.ForeColor = System.Drawing.Color.Black;
            this.cbBoxTarskLineName.FormattingEnabled = true;
            this.cbBoxTarskLineName.ItemHeight = 20;
            this.cbBoxTarskLineName.Items.AddRange(new object[] {
            this.comboItem3});
            this.cbBoxTarskLineName.Location = new System.Drawing.Point(121, 71);
            this.cbBoxTarskLineName.Name = "cbBoxTarskLineName";
            this.cbBoxTarskLineName.Size = new System.Drawing.Size(238, 26);
            this.cbBoxTarskLineName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxTarskLineName.TabIndex = 39;
            this.cbBoxTarskLineName.SelectedIndexChanged += new System.EventHandler(this.cbBoxTarskLineName_SelectedIndexChanged);
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "comboItem3";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.ForeColor = System.Drawing.Color.White;
            this.labelX4.Location = new System.Drawing.Point(27, 114);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(85, 26);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 14;
            this.labelX4.Text = "站区(间)：";
            // 
            // cbBoxStartStation
            // 
            this.cbBoxStartStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBoxStartStation.DisplayMember = "Text";
            this.cbBoxStartStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxStartStation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxStartStation.ForeColor = System.Drawing.Color.Black;
            this.cbBoxStartStation.FormattingEnabled = true;
            this.cbBoxStartStation.ItemHeight = 20;
            this.cbBoxStartStation.Location = new System.Drawing.Point(121, 114);
            this.cbBoxStartStation.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxStartStation.Name = "cbBoxStartStation";
            this.cbBoxStartStation.Size = new System.Drawing.Size(179, 26);
            this.cbBoxStartStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxStartStation.TabIndex = 19;
            this.cbBoxStartStation.SelectedIndexChanged += new System.EventHandler(this.cbBoxStartStation_SelectedIndexChanged);
            // 
            // lblTaskDate
            // 
            this.lblTaskDate.AutoSize = true;
            this.lblTaskDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTaskDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTaskDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTaskDate.FontBold = true;
            this.lblTaskDate.ForeColor = System.Drawing.Color.Yellow;
            this.lblTaskDate.Location = new System.Drawing.Point(121, 28);
            this.lblTaskDate.Name = "lblTaskDate";
            this.lblTaskDate.Size = new System.Drawing.Size(33, 26);
            this.lblTaskDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblTaskDate.TabIndex = 40;
            this.lblTaskDate.Text = "2.3";
            // 
            // linkLblDbPath
            // 
            this.linkLblDbPath.Font = new System.Drawing.Font("Arial", 12F);
            this.linkLblDbPath.LinkColor = System.Drawing.Color.Yellow;
            this.linkLblDbPath.Location = new System.Drawing.Point(118, 159);
            this.linkLblDbPath.Name = "linkLblDbPath";
            this.linkLblDbPath.Size = new System.Drawing.Size(241, 22);
            this.linkLblDbPath.TabIndex = 41;
            this.linkLblDbPath.TabStop = true;
            this.linkLblDbPath.Text = "linkLabel1";
            this.linkLblDbPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblDbPath_LinkClicked);
            // 
            // cbBoxUpDown
            // 
            this.cbBoxUpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBoxUpDown.DisplayMember = "Text";
            this.cbBoxUpDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxUpDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxUpDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxUpDown.ForeColor = System.Drawing.Color.Black;
            this.cbBoxUpDown.FormattingEnabled = true;
            this.cbBoxUpDown.ItemHeight = 23;
            this.cbBoxUpDown.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbBoxUpDown.Location = new System.Drawing.Point(438, 70);
            this.cbBoxUpDown.Name = "cbBoxUpDown";
            this.cbBoxUpDown.Size = new System.Drawing.Size(96, 29);
            this.cbBoxUpDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxUpDown.TabIndex = 18;
            this.cbBoxUpDown.SelectedIndexChanged += new System.EventHandler(this.cbBoxUpDown_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "上行";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "下行";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX9.ForeColor = System.Drawing.Color.White;
            this.labelX9.Location = new System.Drawing.Point(301, 117);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(33, 20);
            this.labelX9.TabIndex = 9;
            this.labelX9.Text = "<->";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX8.ForeColor = System.Drawing.Color.White;
            this.labelX8.Location = new System.Drawing.Point(375, 71);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(57, 26);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 9;
            this.labelX8.Text = "行别：";
            // 
            // btnImportBaseData
            // 
            this.btnImportBaseData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImportBaseData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImportBaseData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportBaseData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImportBaseData.Location = new System.Drawing.Point(417, 2);
            this.btnImportBaseData.Name = "btnImportBaseData";
            this.btnImportBaseData.Size = new System.Drawing.Size(155, 32);
            this.btnImportBaseData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImportBaseData.Symbol = "";
            this.btnImportBaseData.TabIndex = 43;
            this.btnImportBaseData.Text = "导入基础数据库";
            this.btnImportBaseData.Tooltip = "暂不可用";
            this.btnImportBaseData.Click += new System.EventHandler(this.btnImportBaseData_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(301, 236);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(123, 44);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 44;
            this.btnOK.Text = "创建任务";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(438, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 44);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.Symbol = "";
            this.btnCancel.SymbolColor = System.Drawing.Color.Red;
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbBackDisk
            // 
            this.cbBackDisk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBackDisk.DisplayMember = "Text";
            this.cbBackDisk.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBackDisk.Enabled = false;
            this.cbBackDisk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBackDisk.ForeColor = System.Drawing.Color.Black;
            this.cbBackDisk.FormattingEnabled = true;
            this.cbBackDisk.ItemHeight = 20;
            this.cbBackDisk.Location = new System.Drawing.Point(121, 200);
            this.cbBackDisk.Margin = new System.Windows.Forms.Padding(2);
            this.cbBackDisk.Name = "cbBackDisk";
            this.cbBackDisk.Size = new System.Drawing.Size(106, 26);
            this.cbBackDisk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBackDisk.TabIndex = 46;
            this.cbBackDisk.SelectedIndexChanged += new System.EventHandler(this.cbBackDisk_SelectedIndexChanged);
            // 
            // ckIsBack
            // 
            this.ckIsBack.AutoSize = true;
            this.ckIsBack.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ckIsBack.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckIsBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckIsBack.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckIsBack.Location = new System.Drawing.Point(27, 200);
            this.ckIsBack.Name = "ckIsBack";
            this.ckIsBack.Size = new System.Drawing.Size(94, 26);
            this.ckIsBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckIsBack.TabIndex = 47;
            this.ckIsBack.Text = "备份数据";
            this.ckIsBack.TextColor = System.Drawing.Color.Yellow;
            this.ckIsBack.CheckedChanged += new System.EventHandler(this.ckIsBack_CheckedChanged);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(27, 157);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(74, 26);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 14;
            this.labelX1.Text = "主存储盘";
            // 
            // lblMainDBTip
            // 
            this.lblMainDBTip.AutoSize = true;
            this.lblMainDBTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.lblMainDBTip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMainDBTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainDBTip.FontBold = true;
            this.lblMainDBTip.ForeColor = System.Drawing.Color.Red;
            this.lblMainDBTip.Location = new System.Drawing.Point(355, 157);
            this.lblMainDBTip.Name = "lblMainDBTip";
            this.lblMainDBTip.Size = new System.Drawing.Size(206, 26);
            this.lblMainDBTip.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblMainDBTip.TabIndex = 14;
            this.lblMainDBTip.Text = "磁盘空间不足，请释放空间";
            this.lblMainDBTip.Visible = false;
            // 
            // dgvTask
            // 
            this.dgvTask.AllowUserToAddRows = false;
            this.dgvTask.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTask.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTaskName,
            this.colTaskState,
            this.colIsBack});
            this.dgvTask.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTask.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTask.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvTask.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvTask.Location = new System.Drawing.Point(576, 0);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.ReadOnly = true;
            this.dgvTask.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvTask.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTask.RowTemplate.Height = 23;
            this.dgvTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTask.Size = new System.Drawing.Size(328, 297);
            this.dgvTask.TabIndex = 48;
            // 
            // colTaskName
            // 
            this.colTaskName.HeaderText = "任务名称";
            this.colTaskName.Name = "colTaskName";
            this.colTaskName.ReadOnly = true;
            this.colTaskName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTaskName.Width = 160;
            // 
            // colTaskState
            // 
            this.colTaskState.HeaderText = "任务状态";
            this.colTaskState.Name = "colTaskState";
            this.colTaskState.ReadOnly = true;
            this.colTaskState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTaskState.Width = 80;
            // 
            // colIsBack
            // 
            this.colIsBack.HeaderText = "有备份";
            this.colIsBack.Name = "colIsBack";
            this.colIsBack.ReadOnly = true;
            this.colIsBack.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TMItemDel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // TMItemDel
            // 
            this.TMItemDel.Name = "TMItemDel";
            this.TMItemDel.Size = new System.Drawing.Size(180, 22);
            this.TMItemDel.Text = "删除(&Del)";
            this.TMItemDel.Click += new System.EventHandler(this.TMItemDel_Click);
            // 
            // TaskConfig
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(904, 297);
            this.ControlBox = false;
            this.Controls.Add(this.dgvTask);
            this.Controls.Add(this.ckIsBack);
            this.Controls.Add(this.cbBackDisk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.btnImportBaseData);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.cbBoxEndStation);
            this.Controls.Add(this.cbBoxUpDown);
            this.Controls.Add(this.cbBoxTarskLineName);
            this.Controls.Add(this.lblMainDBTip);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.linkLblDbPath);
            this.Controls.Add(this.lblTaskDate);
            this.Controls.Add(this.cbBoxStartStation);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TaskConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建任务";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxEndStation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxTarskLineName;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxStartStation;
        private DevComponents.DotNetBar.LabelX lblTaskDate;
        private System.Windows.Forms.LinkLabel linkLblDbPath;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxUpDown;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ButtonX btnImportBaseData;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBackDisk;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckIsBack;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblMainDBTip;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsBack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TMItemDel;
    }
}