using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4C.Ctrl {
    public partial class CtrlReport : UserControl {

        private DataView dvFaultStat;

        public CtrlReport() {
            InitializeComponent();
        }

        private void symbolBox1_Click(object sender, EventArgs e) {

        }


        #region  ============ 类似EXCEL的过滤功能模块============
        private string sFilterName;//过滤的字段名称
        private int colIndex;
        private Dictionary<string, HashSet<string>> dFilter = new Dictionary<string, HashSet<string>>();//存储过滤条件 
        private HashSet<string> arrSingleFilterValue;
        /// <summary>
        /// [事件]-单击表头添加筛选条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFaultData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (dgvFaultData.DataSource == null) return;

            int dLeft, dTop;
            //获取dgv列标题位置相对坐标  
            Rectangle range = dgvFaultData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            //计算pl_dgv_extend位置坐标  
            dLeft = range.Left + dgvFaultData.Left;
            dTop = range.Top + dgvFaultData.Top + range.Height;
            //设置pl_dgv_extend位置，超出框体宽度时，和dgv右边对齐  
            if (dLeft + panel_dgvFilter.Width > this.Width) {
                panel_dgvFilter.SetBounds(dgvFaultData.Width - panel_dgvFilter.Width, dTop, panel_dgvFilter.Width, panel_dgvFilter.Height);
            }
            else {
                panel_dgvFilter.SetBounds(dLeft, dTop, panel_dgvFilter.Width, panel_dgvFilter.Height);
            }
            //设置cb_condition下拉菜单内容 
            //加载现有选项 
            colIndex = e.ColumnIndex;
            sFilterName = dgvFaultData.Columns[e.ColumnIndex].HeaderText;
            bool isFilter = dFilter.TryGetValue(sFilterName, out arrSingleFilterValue);//是否已经存在过滤条件
            btnFilterClear.Enabled = isFilter;
            lstB_condition.Items.Clear();
            //对字段去重
            DataView dv = new DataView(((DataView)dgvFaultData.DataSource).ToTable());

            dv.Sort = sFilterName + " asc";
            DataTable dt = dv.ToTable(true, sFilterName);
            for (int i = 0; i < dt.Rows.Count; i++) {
                string str = dt.Rows[i][0].ToString();
                if (string.IsNullOrEmpty(str))
                    str = "(空白)";
                lstB_condition.Items.Add(str);
                if (isFilter && arrSingleFilterValue.Contains(str))
                    lstB_condition.SetItemChecked(lstB_condition.Items.Count - 1, true);
            }
            panel_dgvFilter.Visible = true;

            //初始化选择项  
            btnFilterClear.Text = @"从""" + sFilterName + @"""中清除筛选";
            btn_UserFilter.Text = sFilterName.Contains("日期") ? @"日期筛选" : @"文本筛选";
            panel_dgvFilter.Focus();
        }

        //过滤面板失去焦点时隐藏
        private void panel_dgvFilter_Leave(object sender, EventArgs e) {
            panel_dgvFilter.Visible = false;
        }
        //过滤面板-自定义筛选按钮事件
        private void btn_UserFilter_Click(object sender, EventArgs e) {
            panel_dgvFilter.Visible = false;
            UI.DialogFilter dialogFilter = new UI.DialogFilter(sFilterName, lstB_condition, sFilterName.Contains("日期"));
            if (dialogFilter.ShowDialog() == DialogResult.OK) {
                dFilter[sFilterName] = dialogFilter.SFilter;
                FilterDatatable();
            }
        }
        //按钮事件--确定筛选
        private void btnOk_Click(object sender, EventArgs e) {
            //遍历取出所有的选定项目
            if (arrSingleFilterValue == null)
                arrSingleFilterValue = new HashSet<string>();
            else
                arrSingleFilterValue.Clear();

            for (int i = 0; i < lstB_condition.Items.Count; i++) {
                if (lstB_condition.GetItemChecked(i)) {
                    arrSingleFilterValue.Add(lstB_condition.GetItemText(lstB_condition.Items[i]));
                }
                dFilter[sFilterName] = arrSingleFilterValue;
            }
            FilterDatatable();
        }
        //清除筛选
        private void btnFilterClear_Click(object sender, EventArgs e) {
            dFilter.Remove(sFilterName);
            dgvFaultData.Columns[colIndex].HeaderCell.Style.ForeColor = Color.White;
            FilterDatatable();
        }
        //过滤调用
        private void FilterDatatable() {
            dgvFaultData.AutoGenerateColumns = false;
            if (dFilter.Count == 0) {
                dgvFaultData.DataSource = dvFaultStat;
                panel_dgvFilter.Visible = false;
                return;
            }
            List<string> removeKey = new List<string>();
            StringBuilder sFilter = new StringBuilder();
            string sTmpNull = "";
            foreach (KeyValuePair<string, HashSet<string>> keyValuePair in dFilter) {

                if (keyValuePair.Value.Count == 0) {
                    removeKey.Add(keyValuePair.Key);
                    continue;
                }
                if (sFilter.Length > 0)
                    sFilter.Append(" and ");
                sFilter.Append(keyValuePair.Key);
                //为了解决 isNull 和其他条件一起使用 in (null, xx)出现无法查询到null的数据问题

                if (keyValuePair.Value.Count == 1) {
                    foreach (string s in keyValuePair.Value) {
                        if (s == "(空白)")
                            sFilter.Append(" is null  ");
                        else
                            sFilter.Append(string.Format(" = '{0}'", s));
                    }
                }
                else {
                    sFilter.Append(" IN (");
                    foreach (string s in keyValuePair.Value) {
                        if (s == "(空白)")
                            sTmpNull = keyValuePair.Key + " is null  or ";
                        else
                            sFilter.Append(string.Format("'{0}',", s));
                    }
                    sFilter.Remove(sFilter.Length - 1, 1);
                    sFilter.Append(")");

                }
            }
            if (removeKey.Count > 0) {
                foreach (string s in removeKey) {
                    dFilter.Remove(s);
                }
            }
            if (sFilter.Length == 0) {
                dgvFaultData.DataSource = dvFaultStat; ;
                dgvFaultData.Columns[colIndex].HeaderCell.Style.ForeColor = Color.White;
              //  cb_FilterState.Text = "";
               //lblSum.Text = @"共 " + dtDistCont.Rows.Count + @" 条";
            }
            else {
                DataView dv = new DataView(dvFaultStat.Table);
                dv.RowFilter = sTmpNull + sFilter;
                dgvFaultData.DataSource = dv;
                dgvFaultData.Columns[colIndex].HeaderCell.Style.ForeColor = Color.Red;
               // cb_FilterState.Text = "自定义筛选";
               //lblSum.Text = @"共 " + dv.Count + @" 条";
            }

            panel_dgvFilter.Visible = false;

        }
        //升序排列
        private void btn_Asc_Click(object sender, EventArgs e) {
            DataView dv = new DataView(((DataView)dgvFaultData.DataSource).ToTable());
            dv.Sort = sFilterName + " asc";
            dgvFaultData.DataSource = dv;
            panel_dgvFilter.Visible = false;
        }
        //降序排列
        private void btn_desc_Click(object sender, EventArgs e) {
            DataView dv = new DataView(((DataView)dgvFaultData.DataSource).ToTable());
            dv.Sort = sFilterName + " desc";
            dgvFaultData.DataSource = dv;
            panel_dgvFilter.Visible = false;
        }
        #endregion

        private void CtrlReport_Load(object sender, EventArgs e) {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //记录缺陷个数
            lblAIFault.Text= lblTotalFault.Text=config.ConfigInfo.GetInstance().TotalFualt.ToString();
        }
    }
}
