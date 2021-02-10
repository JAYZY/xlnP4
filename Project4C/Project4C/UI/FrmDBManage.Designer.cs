namespace Project4C.UI {
    partial class FrmDBManage {
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbLineName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbDBFullName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSelDBDir = new DevComponents.DotNetBar.ButtonX();
            this.btnOpenDir = new DevComponents.DotNetBar.ButtonX();
            this.lblImgPath = new DevComponents.DotNetBar.LabelX();
            this.btnCreateDB = new DevComponents.DotNetBar.ButtonX();
            this.btnInsertImg = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.tbLineName);
            this.panelEx1.Controls.Add(this.tbDate);
            this.panelEx1.Controls.Add(this.tbDBFullName);
            this.panelEx1.Controls.Add(this.btnSelDBDir);
            this.panelEx1.Controls.Add(this.btnOpenDir);
            this.panelEx1.Controls.Add(this.lblImgPath);
            this.panelEx1.Controls.Add(this.btnCreateDB);
            this.panelEx1.Controls.Add(this.btnInsertImg);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(767, 247);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.labelX2.Location = new System.Drawing.Point(81, 137);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "线路名称：";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.labelX1.Location = new System.Drawing.Point(81, 110);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "日期：";
            // 
            // tbLineName
            // 
            this.tbLineName.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.tbLineName.Border.Class = "TextBoxBorder";
            this.tbLineName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbLineName.DisabledBackColor = System.Drawing.Color.Black;
            this.tbLineName.ForeColor = System.Drawing.Color.White;
            this.tbLineName.Location = new System.Drawing.Point(162, 137);
            this.tbLineName.Name = "tbLineName";
            this.tbLineName.PreventEnterBeep = true;
            this.tbLineName.Size = new System.Drawing.Size(247, 21);
            this.tbLineName.TabIndex = 4;
            this.tbLineName.Text = "新乡东-郑州东";
            // 
            // tbDate
            // 
            this.tbDate.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.tbDate.Border.Class = "TextBoxBorder";
            this.tbDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDate.DisabledBackColor = System.Drawing.Color.Black;
            this.tbDate.ForeColor = System.Drawing.Color.White;
            this.tbDate.Location = new System.Drawing.Point(162, 113);
            this.tbDate.Name = "tbDate";
            this.tbDate.PreventEnterBeep = true;
            this.tbDate.Size = new System.Drawing.Size(247, 21);
            this.tbDate.TabIndex = 4;
            this.tbDate.Text = "20190201";
            // 
            // tbDBFullName
            // 
            this.tbDBFullName.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.tbDBFullName.Border.Class = "TextBoxBorder";
            this.tbDBFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDBFullName.DisabledBackColor = System.Drawing.Color.Black;
            this.tbDBFullName.ForeColor = System.Drawing.Color.White;
            this.tbDBFullName.Location = new System.Drawing.Point(162, 86);
            this.tbDBFullName.Name = "tbDBFullName";
            this.tbDBFullName.PreventEnterBeep = true;
            this.tbDBFullName.Size = new System.Drawing.Size(385, 21);
            this.tbDBFullName.TabIndex = 3;
            this.tbDBFullName.Text = "E:\\新绿能项目\\20190201新乡东-郑州东.db\r\n";
            // 
            // btnSelDBDir
            // 
            this.btnSelDBDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelDBDir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelDBDir.Location = new System.Drawing.Point(81, 86);
            this.btnSelDBDir.Name = "btnSelDBDir";
            this.btnSelDBDir.Size = new System.Drawing.Size(75, 23);
            this.btnSelDBDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelDBDir.TabIndex = 2;
            this.btnSelDBDir.Text = "数据库位置";
            this.btnSelDBDir.Click += new System.EventHandler(this.btnSelDBDir_Click);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpenDir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpenDir.Location = new System.Drawing.Point(81, 44);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOpenDir.TabIndex = 2;
            this.btnOpenDir.Text = "图片文件夹";
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // lblImgPath
            // 
            // 
            // 
            // 
            this.lblImgPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblImgPath.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.lblImgPath.Location = new System.Drawing.Point(162, 44);
            this.lblImgPath.Name = "lblImgPath";
            this.lblImgPath.Size = new System.Drawing.Size(585, 23);
            this.lblImgPath.TabIndex = 1;
            this.lblImgPath.Text = "E:\\新绿能项目\\20190201原始数据\\Galaxy\\201704260046_京广线_上行_新乡东站_郑州东站\\新乡东-郑州东\\";
            this.lblImgPath.Click += new System.EventHandler(this.lblImgPath_Click);
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCreateDB.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCreateDB.Location = new System.Drawing.Point(553, 86);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDB.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCreateDB.TabIndex = 0;
            this.btnCreateDB.Text = "创建数据库";
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // btnInsertImg
            // 
            this.btnInsertImg.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsertImg.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInsertImg.Location = new System.Drawing.Point(553, 167);
            this.btnInsertImg.Name = "btnInsertImg";
            this.btnInsertImg.Size = new System.Drawing.Size(75, 23);
            this.btnInsertImg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsertImg.TabIndex = 0;
            this.btnInsertImg.Text = "插入图片";
            this.btnInsertImg.Click += new System.EventHandler(this.btnInsertImg_Click);
            // 
            // FrmDBManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 247);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmDBManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDBManage";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnInsertImg;
        private DevComponents.DotNetBar.ButtonX btnOpenDir;
        private DevComponents.DotNetBar.LabelX lblImgPath;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDBFullName;
        private DevComponents.DotNetBar.ButtonX btnCreateDB;
        private DevComponents.DotNetBar.ButtonX btnSelDBDir;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbLineName;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDate;
    }
}