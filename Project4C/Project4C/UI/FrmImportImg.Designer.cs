namespace Project4C.UI {
    partial class FrmImportImg {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportImg));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lnkImportDir = new System.Windows.Forms.LinkLabel();
            this.lblValue = new DevComponents.DotNetBar.LabelX();
            this.lblTip = new DevComponents.DotNetBar.LabelX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.btnOpenDir = new DevComponents.DotNetBar.ButtonX();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel2.Controls.Add(this.lnkImportDir);
            this.groupPanel2.Controls.Add(this.lblValue);
            this.groupPanel2.Controls.Add(this.lblTip);
            this.groupPanel2.Controls.Add(this.progressBarX1);
            this.groupPanel2.Controls.Add(this.btnOpenDir);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel2.Location = new System.Drawing.Point(47, 35);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(598, 138);
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
            this.groupPanel2.TabIndex = 38;
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
            // btnOpenDir
            // 
            this.btnOpenDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpenDir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpenDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDir.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btnOpenDir.Location = new System.Drawing.Point(40, 21);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(87, 37);
            this.btnOpenDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOpenDir.TabIndex = 32;
            this.btnOpenDir.Text = "导出目录";
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.Location = new System.Drawing.Point(559, 182);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(82, 37);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.TabIndex = 33;
            this.btnImport.Text = "导出数据";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FrmImportImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 243);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.btnImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出一杆一档数据";
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.LinkLabel lnkImportDir;
        private DevComponents.DotNetBar.LabelX lblValue;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.LabelX lblTip;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private DevComponents.DotNetBar.ButtonX btnOpenDir;
    }
}