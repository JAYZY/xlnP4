using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class DialogFilter : Form {
        private bool isDate;
        public HashSet<string> SFilter;
        //
        public DialogFilter(string sFieldName, CheckedListBox clCondition, bool _isDate) {
            InitializeComponent();
            isDate = _isDate;
            lblFieldName.Text = sFieldName;
            //加载列表控件
            foreach (var item in clCondition.Items) {
                cb_StartCondition.Items.Add(item);
                cb_EndCondition.Items.Add(item);
            }

        }
        //窗体显示事件
        private void DialogFilter_Shown(object sender, EventArgs e) {
            btnStartDate.Visible = btnEndDate.Visible = isDate;
            mCalendarSel.Visible = false;
            cb_FirstLogic.SelectedIndex = cb_secondLogic.SelectedIndex = 0;
        }

        private bool isStartMonthSel;
        private void btnDateSel_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            isStartMonthSel = btn.Name == "btnStartDate";
            mCalendarSel.Top = btn.Top + btn.Height;
            mCalendarSel.Visible = !mCalendarSel.Visible;
            mCalendarSel.Left = btn.Right - mCalendarSel.Width;

        }
        //选中日期
        private void mCalendarSel_DateSelected(object sender, DateRangeEventArgs e) {
            if (isStartMonthSel)
                cb_StartCondition.Text = mCalendarSel.SelectionStart.ToShortDateString();
            else
                cb_EndCondition.Text = mCalendarSel.SelectionStart.ToShortDateString();
            mCalendarSel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(cb_StartCondition.Text)) {
                MessageBox.Show(@"请至少选择一个条件");
                cb_StartCondition.Focus();
                return;
            }
            SFilter = new HashSet<string>();
            //==    !=  >=  >   <=  <

            switch (cb_FirstLogic.SelectedIndex) {
                case 0://==
                    SFilter.Add(cb_StartCondition.Text.Trim());
                    break;
                case 1://!=
                    foreach (var item in cb_StartCondition.Items) {
                        if (item.ToString() == cb_StartCondition.Text)
                            continue;
                        SFilter.Add(item.ToString());
                    }
                    break;
                case 2:
                case 3://>=  >
                    if (cb_StartCondition.SelectedIndex == 2)
                        SFilter.Add(cb_StartCondition.Text.Trim());
                    foreach (var item in cb_StartCondition.Items) {
                        if (item.ToString() == "(空白)") continue;
                        if (string.Compare(item.ToString(), cb_StartCondition.Text) > 0)
                            SFilter.Add(item.ToString());
                    }
                    break;
                case 4:
                case 5://<=  <
                    if (cb_StartCondition.SelectedIndex == 4)
                        SFilter.Add(cb_StartCondition.Text.Trim());
                    foreach (var item in cb_StartCondition.Items) {
                        if (item.ToString() == "(空白)") continue;
                        if (string.Compare(item.ToString(), cb_StartCondition.Text) < 0)
                            SFilter.Add(item.ToString());
                    }
                    break;

            }
            //是否存在与或 第二个比较条件
            bool isAnd = rBtnAnd.Checked; //-1 没有第二个比较条件；0-OR 1-And
            if (!string.IsNullOrEmpty(cb_EndCondition.Text)) {
                switch (cb_secondLogic.SelectedIndex) {
                    case 0://==
                        SFilter.Add(cb_EndCondition.Text.Trim());
                        break;
                    case 1://!=
                        if (isAnd)
                            SFilter.Remove(cb_EndCondition.Text.Trim());
                        else {
                            foreach (var item in cb_EndCondition.Items) {
                                if (item.ToString() == cb_EndCondition.Text)
                                    continue;
                                SFilter.Add(item.ToString());
                            }
                        }
                        break;
                    case 2:
                    case 3://<=  <
                        if (isAnd) {
                            List<string> lstDelItem = new List<string>();
                            if (cb_EndCondition.SelectedIndex == 3)
                                lstDelItem.Add(cb_EndCondition.Text.Trim());
                            foreach (var item in SFilter) {
                                if (item.ToString() == "(空白)") continue;
                                if (string.Compare(item, cb_EndCondition.Text) < 0)
                                    lstDelItem.Add(item);
                            }
                            foreach (var delItem in lstDelItem)
                                SFilter.Remove(delItem);
                        }
                        else {
                            if (cb_EndCondition.SelectedIndex == 2)
                                SFilter.Add(cb_EndCondition.Text.Trim());
                            foreach (var item in cb_EndCondition.Items) {
                                if (item.ToString() == "(空白)") continue;
                                if (string.Compare(item.ToString(), cb_EndCondition.Text) > 0)
                                    SFilter.Add(item.ToString());
                            }
                        }
                        break;
                    case 4:
                    case 5://>=  >
                        if (isAnd) {
                            List<string> lstDelItem = new List<string>();
                            if (cb_EndCondition.SelectedIndex == 5)
                                lstDelItem.Add(cb_EndCondition.Text.Trim());
                            foreach (var item in SFilter) {
                                if (item.ToString() == "(空白)") continue;
                                if (string.Compare(item, cb_EndCondition.Text) > 0)
                                    lstDelItem.Add(item);
                            }
                            foreach (var delItem in lstDelItem)
                                SFilter.Remove(delItem);
                        }
                        else {
                            if (cb_EndCondition.SelectedIndex == 4)
                                SFilter.Add(cb_EndCondition.Text.Trim());
                            foreach (var item in cb_EndCondition.Items) {
                                if (item.ToString() == "(空白)") continue;
                                if (string.Compare(item.ToString(), cb_EndCondition.Text) < 0)
                                    SFilter.Add(item.ToString());
                            }
                        }
                        break;
                }
            }
        }

    }
}
