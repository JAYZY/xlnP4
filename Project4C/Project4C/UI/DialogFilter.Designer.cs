namespace Project4C.UI {
    partial class DialogFilter {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogFilter));
            this.mCalendarSel = new System.Windows.Forms.MonthCalendar();
            this.rBtnOr = new System.Windows.Forms.RadioButton();
            this.rBtnAnd = new System.Windows.Forms.RadioButton();
            this.cb_EndCondition = new System.Windows.Forms.ComboBox();
            this.cb_secondLogic = new System.Windows.Forms.ComboBox();
            this.cb_StartCondition = new System.Windows.Forms.ComboBox();
            this.cb_FirstLogic = new System.Windows.Forms.ComboBox();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEndDate = new System.Windows.Forms.Button();
            this.btnStartDate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mCalendarSel
            // 
            this.mCalendarSel.Location = new System.Drawing.Point(208, 166);
            this.mCalendarSel.Name = "mCalendarSel";
            this.mCalendarSel.TabIndex = 20;
            this.mCalendarSel.Visible = false;
            // 
            // rBtnOr
            // 
            this.rBtnOr.AutoSize = true;
            this.rBtnOr.Location = new System.Drawing.Point(153, 105);
            this.rBtnOr.Name = "rBtnOr";
            this.rBtnOr.Size = new System.Drawing.Size(53, 16);
            this.rBtnOr.TabIndex = 18;
            this.rBtnOr.Text = "或(&D)";
            this.rBtnOr.UseVisualStyleBackColor = true;
            // 
            // rBtnAnd
            // 
            this.rBtnAnd.AutoSize = true;
            this.rBtnAnd.Checked = true;
            this.rBtnAnd.Location = new System.Drawing.Point(74, 106);
            this.rBtnAnd.Name = "rBtnAnd";
            this.rBtnAnd.Size = new System.Drawing.Size(53, 16);
            this.rBtnAnd.TabIndex = 19;
            this.rBtnAnd.TabStop = true;
            this.rBtnAnd.Text = "与(&A)";
            this.rBtnAnd.UseVisualStyleBackColor = true;
            // 
            // cb_EndCondition
            // 
            this.cb_EndCondition.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_EndCondition.FormattingEnabled = true;
            this.cb_EndCondition.Location = new System.Drawing.Point(185, 132);
            this.cb_EndCondition.Name = "cb_EndCondition";
            this.cb_EndCondition.Size = new System.Drawing.Size(247, 28);
            this.cb_EndCondition.TabIndex = 14;
            // 
            // cb_secondLogic
            // 
            this.cb_secondLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_secondLogic.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_secondLogic.FormattingEnabled = true;
            this.cb_secondLogic.Items.AddRange(new object[] {
            "==",
            "!=",
            ">=",
            ">",
            "<=",
            "<"});
            this.cb_secondLogic.Location = new System.Drawing.Point(19, 132);
            this.cb_secondLogic.Name = "cb_secondLogic";
            this.cb_secondLogic.Size = new System.Drawing.Size(147, 28);
            this.cb_secondLogic.TabIndex = 15;
            // 
            // cb_StartCondition
            // 
            this.cb_StartCondition.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_StartCondition.FormattingEnabled = true;
            this.cb_StartCondition.Location = new System.Drawing.Point(185, 67);
            this.cb_StartCondition.Name = "cb_StartCondition";
            this.cb_StartCondition.Size = new System.Drawing.Size(247, 28);
            this.cb_StartCondition.TabIndex = 16;
            // 
            // cb_FirstLogic
            // 
            this.cb_FirstLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FirstLogic.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_FirstLogic.FormattingEnabled = true;
            this.cb_FirstLogic.Items.AddRange(new object[] {
            "==",
            "!=",
            ">=",
            ">",
            "<=",
            "<"});
            this.cb_FirstLogic.Location = new System.Drawing.Point(19, 67);
            this.cb_FirstLogic.Name = "cb_FirstLogic";
            this.cb_FirstLogic.Size = new System.Drawing.Size(147, 28);
            this.cb_FirstLogic.TabIndex = 17;
            // 
            // line1
            // 
            this.line1.EndLineCap = DevComponents.DotNetBar.Controls.eLineEndType.Rectangle;
            this.line1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.line1.Location = new System.Drawing.Point(65, 39);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(392, 23);
            this.line1.TabIndex = 13;
            this.line1.Text = "line1";
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(9, 42);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(41, 12);
            this.lblFieldName.TabIndex = 11;
            this.lblFieldName.Text = "显示行";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "显示行";
            // 
            // btnEndDate
            // 
            this.btnEndDate.Image = ((System.Drawing.Image)(resources.GetObject("btnEndDate.Image")));
            this.btnEndDate.Location = new System.Drawing.Point(438, 132);
            this.btnEndDate.Name = "btnEndDate";
            this.btnEndDate.Size = new System.Drawing.Size(32, 32);
            this.btnEndDate.TabIndex = 7;
            this.btnEndDate.UseVisualStyleBackColor = true;
            // 
            // btnStartDate
            // 
            this.btnStartDate.Image = ((System.Drawing.Image)(resources.GetObject("btnStartDate.Image")));
            this.btnStartDate.Location = new System.Drawing.Point(438, 67);
            this.btnStartDate.Name = "btnStartDate";
            this.btnStartDate.Size = new System.Drawing.Size(32, 32);
            this.btnStartDate.TabIndex = 8;
            this.btnStartDate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(352, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 45);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(228, 347);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 45);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // DialogFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 407);
            this.Controls.Add(this.mCalendarSel);
            this.Controls.Add(this.rBtnOr);
            this.Controls.Add(this.rBtnAnd);
            this.Controls.Add(this.cb_EndCondition);
            this.Controls.Add(this.cb_secondLogic);
            this.Controls.Add(this.cb_StartCondition);
            this.Controls.Add(this.cb_FirstLogic);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEndDate);
            this.Controls.Add(this.btnStartDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "DialogFilter";
            this.Text = "DialogFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mCalendarSel;
        private System.Windows.Forms.RadioButton rBtnOr;
        private System.Windows.Forms.RadioButton rBtnAnd;
        private System.Windows.Forms.ComboBox cb_EndCondition;
        private System.Windows.Forms.ComboBox cb_secondLogic;
        private System.Windows.Forms.ComboBox cb_StartCondition;
        private System.Windows.Forms.ComboBox cb_FirstLogic;
        private DevComponents.DotNetBar.Controls.Line line1;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEndDate;
        private System.Windows.Forms.Button btnStartDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}