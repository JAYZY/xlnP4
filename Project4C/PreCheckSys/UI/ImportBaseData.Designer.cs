namespace PreCheckSys.UI {
    partial class ImportBaseData {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBaseData));
            this.btnSelBaseDataPath = new DevComponents.DotNetBar.ButtonX();
            this.linkLblPath = new System.Windows.Forms.LinkLabel();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cbBoxUpDown = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.tbLineName = new System.Windows.Forms.TextBox();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnSelBaseDataPath
            // 
            this.btnSelBaseDataPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelBaseDataPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelBaseDataPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelBaseDataPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelBaseDataPath.Location = new System.Drawing.Point(38, 25);
            this.btnSelBaseDataPath.Name = "btnSelBaseDataPath";
            this.btnSelBaseDataPath.Size = new System.Drawing.Size(106, 28);
            this.btnSelBaseDataPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelBaseDataPath.TabIndex = 44;
            this.btnSelBaseDataPath.Text = "导入基础数据";
            this.btnSelBaseDataPath.Click += new System.EventHandler(this.btnSelBaseDataPath_Click);
            // 
            // linkLblPath
            // 
            this.linkLblPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblPath.LinkColor = System.Drawing.Color.Yellow;
            this.linkLblPath.Location = new System.Drawing.Point(150, 28);
            this.linkLblPath.Name = "linkLblPath";
            this.linkLblPath.Size = new System.Drawing.Size(381, 22);
            this.linkLblPath.TabIndex = 43;
            this.linkLblPath.TabStop = true;
            this.linkLblPath.Text = "linkLabel1";
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
            this.labelX7.Location = new System.Drawing.Point(37, 79);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(90, 26);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 46;
            this.labelX7.Text = "线路名称：";
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
            this.labelX8.Location = new System.Drawing.Point(362, 78);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(57, 26);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 45;
            this.labelX8.Text = "行别：";
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
            this.cbBoxUpDown.Location = new System.Drawing.Point(420, 77);
            this.cbBoxUpDown.Name = "cbBoxUpDown";
            this.cbBoxUpDown.Size = new System.Drawing.Size(111, 29);
            this.cbBoxUpDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxUpDown.TabIndex = 47;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "上行";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "下行";
            // 
            // tbLineName
            // 
            this.tbLineName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbLineName.Location = new System.Drawing.Point(115, 78);
            this.tbLineName.Name = "tbLineName";
            this.tbLineName.Size = new System.Drawing.Size(236, 29);
            this.tbLineName.TabIndex = 49;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnOK.Image = global::PreCheckSys.Properties.Resources.base_checkboxes;
            this.btnOK.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnOK.Location = new System.Drawing.Point(430, 129);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 41);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 50;
            this.btnOK.Text = "导入";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ImportBaseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(581, 184);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbLineName);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.cbBoxUpDown);
            this.Controls.Add(this.btnSelBaseDataPath);
            this.Controls.Add(this.linkLblPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportBaseData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入基础数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSelBaseDataPath;
        private System.Windows.Forms.LinkLabel linkLblPath;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxUpDown;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private System.Windows.Forms.TextBox tbLineName;
        private DevComponents.DotNetBar.ButtonX btnOK;
    }
}