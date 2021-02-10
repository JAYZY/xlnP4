namespace Project4C.UI {
    partial class FrmLogin {
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
            this.cbLoginName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.symbolBox1 = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.txtB_PWD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.lblInfo = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cbLoginName);
            this.panelEx1.Controls.Add(this.symbolBox1);
            this.panelEx1.Controls.Add(this.txtB_PWD);
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.Controls.Add(this.lblInfo);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(428, 184);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 32;
            // 
            // cbLoginName
            // 
            this.cbLoginName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLoginName.DisplayMember = "Text";
            this.cbLoginName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoginName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoginName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLoginName.ForeColor = System.Drawing.Color.Black;
            this.cbLoginName.FormattingEnabled = true;
            this.cbLoginName.ItemHeight = 20;
            this.cbLoginName.Location = new System.Drawing.Point(144, 48);
            this.cbLoginName.Name = "cbLoginName";
            this.cbLoginName.Size = new System.Drawing.Size(192, 26);
            this.cbLoginName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbLoginName.TabIndex = 24;
            // 
            // symbolBox1
            // 
            // 
            // 
            // 
            this.symbolBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.symbolBox1.Location = new System.Drawing.Point(51, 53);
            this.symbolBox1.Name = "symbolBox1";
            this.symbolBox1.Size = new System.Drawing.Size(75, 78);
            this.symbolBox1.Symbol = "58725";
            this.symbolBox1.SymbolColor = System.Drawing.Color.Purple;
            this.symbolBox1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.symbolBox1.TabIndex = 23;
            this.symbolBox1.Text = "symbolBox1";
            // 
            // txtB_PWD
            // 
            this.txtB_PWD.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtB_PWD.Border.Class = "TextBoxBorder";
            this.txtB_PWD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtB_PWD.DisabledBackColor = System.Drawing.Color.White;
            this.txtB_PWD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtB_PWD.ForeColor = System.Drawing.Color.Black;
            this.txtB_PWD.Location = new System.Drawing.Point(144, 79);
            this.txtB_PWD.Name = "txtB_PWD";
            this.txtB_PWD.PasswordChar = '*';
            this.txtB_PWD.PreventEnterBeep = true;
            this.txtB_PWD.Size = new System.Drawing.Size(192, 23);
            this.txtB_PWD.TabIndex = 0;
            this.txtB_PWD.WatermarkText = "输入密码";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(144, 109);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(192, 33);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.Symbol = "";
            this.btnOk.SymbolColor = System.Drawing.Color.Purple;
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "登录";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            // 
            // 
            // 
            this.lblInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(162, 150);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 0);
            this.lblInfo.TabIndex = 22;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 184);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4C智能分析系统-登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtB_PWD;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.LabelX lblInfo;
        private DevComponents.DotNetBar.Controls.SymbolBox symbolBox1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLoginName;
    }
}