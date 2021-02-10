namespace Project4C.UI {
    partial class FrmUserMgr {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserMgr));
            this.dgvLoginT = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMenuItem_DeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuItem_ResetPWD = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtB_Ry = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_addUser = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginT)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoginT
            // 
            this.dgvLoginT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colDateTime});
            this.dgvLoginT.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoginT.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoginT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLoginT.Location = new System.Drawing.Point(7, 61);
            this.dgvLoginT.Name = "dgvLoginT";
            this.dgvLoginT.RowTemplate.Height = 23;
            this.dgvLoginT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoginT.Size = new System.Drawing.Size(582, 298);
            this.dgvLoginT.TabIndex = 2;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "uId";
            this.colId.HeaderText = "序号";
            this.colId.Name = "colId";
            // 
            // colName
            // 
            this.colName.DataPropertyName = "uName";
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "loginDatetime";
            this.colDateTime.HeaderText = "最后一次登录时间";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMenuItem_DeleteUser,
            this.TSMenuItem_ResetPWD});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 48);
            // 
            // TSMenuItem_DeleteUser
            // 
            this.TSMenuItem_DeleteUser.Name = "TSMenuItem_DeleteUser";
            this.TSMenuItem_DeleteUser.Size = new System.Drawing.Size(139, 22);
            this.TSMenuItem_DeleteUser.Text = "删除(&D)";
            this.TSMenuItem_DeleteUser.Click += new System.EventHandler(this.TSMenuItem_DeleteUser_Click);
            // 
            // TSMenuItem_ResetPWD
            // 
            this.TSMenuItem_ResetPWD.Name = "TSMenuItem_ResetPWD";
            this.TSMenuItem_ResetPWD.Size = new System.Drawing.Size(139, 22);
            this.TSMenuItem_ResetPWD.Text = "密码重置(&P)";
            this.TSMenuItem_ResetPWD.Click += new System.EventHandler(this.TSMenuItem_ResetPWD_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(16, 32);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 18);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "用户姓名：";
            // 
            // txtB_Ry
            // 
            this.txtB_Ry.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtB_Ry.Border.Class = "TextBoxBorder";
            this.txtB_Ry.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtB_Ry.DisabledBackColor = System.Drawing.Color.White;
            this.txtB_Ry.ForeColor = System.Drawing.Color.Black;
            this.txtB_Ry.Location = new System.Drawing.Point(90, 31);
            this.txtB_Ry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtB_Ry.Name = "txtB_Ry";
            this.txtB_Ry.PreventEnterBeep = true;
            this.txtB_Ry.Size = new System.Drawing.Size(326, 21);
            this.txtB_Ry.TabIndex = 5;
            // 
            // btn_addUser
            // 
            this.btn_addUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_addUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_addUser.Location = new System.Drawing.Point(457, 29);
            this.btn_addUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_addUser.Name = "btn_addUser";
            this.btn_addUser.Size = new System.Drawing.Size(87, 25);
            this.btn_addUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_addUser.TabIndex = 6;
            this.btn_addUser.Text = "添加用户";
            this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // FrmUserMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 371);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtB_Ry);
            this.Controls.Add(this.btn_addUser);
            this.Controls.Add(this.dgvLoginT);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginT)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvLoginT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMenuItem_DeleteUser;
        private System.Windows.Forms.ToolStripMenuItem TSMenuItem_ResetPWD;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtB_Ry;
        private DevComponents.DotNetBar.ButtonX btn_addUser;
    }
}