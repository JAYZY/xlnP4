using DevComponents.DotNetBar;
using FVIL.Data;
using FVIL.Forms;
using Project4C.Core;
using Project4C.DB;
using Project4C.FileOp;
using Project4C.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class CtrlReport : OfficeForm {//UserControl {

        private DataTable dtFault;
        private bool IsOnline => Settings.Default.ViewMode == 1;

        private FigureHandlingOverlay m_FigHandOverlay;

        private bool isImport = false;

        private OffLineOp _offLine;

        //private SqliteHelper1 GetDB => SqliteHelper1.GetSqlite(Settings.Default.MDB);
        public CtrlReport(OffLineOp offLine) {
            InitializeComponent();
            m_FigHandOverlay = new FigureHandlingOverlay();
            ImgView1.Display.Overlays.Add(m_FigHandOverlay);
            ImgView1.MouseWheel += new System.Windows.Forms.MouseEventHandler(ImageView_MouseWheel);
            _offLine = offLine;
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
            if (dgvFaultData.DataSource == null) {
                return;
            }

            int dLeft, dTop;
            //获取dgv列标题位置相对坐标  
            Rectangle range = dgvFaultData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            //计算pl_dgv_extend位置坐标  
            dLeft = range.Left + dgvFaultData.Left;
            dTop = range.Top + dgvFaultData.Top + range.Height;
            //设置pl_dgv_extend位置，超出框体宽度时，和dgv右边对齐  
            if (dLeft + panel_dgvFilter.Width > this.Width) {
                panel_dgvFilter.SetBounds(dgvFaultData.Width - panel_dgvFilter.Width, dTop, panel_dgvFilter.Width, panel_dgvFilter.Height);
            } else {
                panel_dgvFilter.SetBounds(dLeft, dTop, panel_dgvFilter.Width, panel_dgvFilter.Height);
            }
            //设置cb_condition下拉菜单内容 
            //加载现有选项 
            colIndex = e.ColumnIndex;
            sFilterName = dgvFaultData.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(sFilterName)) {
                return;
            }

            bool isFilter = dFilter.TryGetValue(sFilterName, out arrSingleFilterValue);//是否已经存在过滤条件
            btnFilterClear.Enabled = isFilter;
            lstB_condition.Items.Clear();
            //对字段去重
            DataView dv = new DataView((dgvFaultData.DataSource as DataView).ToTable());

            dv.Sort = sFilterName + " asc";
            DataTable dt = dv.ToTable(true, sFilterName);
            for (int i = 0; i < dt.Rows.Count; i++) {
                string str = dt.Rows[i][0].ToString();
                if (string.IsNullOrEmpty(str)) {
                    str = "(空白)";
                }

                lstB_condition.Items.Add(str);
                if (isFilter && arrSingleFilterValue.Contains(str)) {
                    lstB_condition.SetItemChecked(lstB_condition.Items.Count - 1, true);
                }
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
            if (arrSingleFilterValue == null) {
                arrSingleFilterValue = new HashSet<string>();
            } else {
                arrSingleFilterValue.Clear();
            }

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
                dgvFaultData.DataSource = dtFault.DefaultView;
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
                if (sFilter.Length > 0) {
                    sFilter.Append(" and ");
                }

                sFilter.Append(keyValuePair.Key);
                //为了解决 isNull 和其他条件一起使用 in (null, xx)出现无法查询到null的数据问题

                if (keyValuePair.Value.Count == 1) {
                    foreach (string s in keyValuePair.Value) {
                        if (s == "(空白)") {
                            sFilter.Append(" is null  ");
                        } else {
                            sFilter.Append(string.Format(" = '{0}'", s));
                        }
                    }
                } else {
                    sFilter.Append(" IN (");
                    foreach (string s in keyValuePair.Value) {
                        if (s == "(空白)") {
                            sTmpNull = keyValuePair.Key + " is null  or ";
                        } else {
                            sFilter.Append(string.Format("'{0}',", s));
                        }
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
                dgvFaultData.DataSource = dtFault.DefaultView; ;
                dgvFaultData.Columns[colIndex].HeaderCell.Style.ForeColor = Color.White;
                //  cb_FilterState.Text = "";
                //lblSum.Text = @"共 " + dtDistCont.Rows.Count + @" 条";
            } else {
                DataView dv = new DataView(dtFault);
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
            if (IsOnline) {
                timer1.Start();
            }
            UpdateData();
        }
        private void UpdateData() {
            DialogTaskTip.GetInstance().SetTipTxt(@"缺陷数据加载中...");
            new Thread(ReadAllFault).Start();
            DialogTaskTip.GetInstance().ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            //记录缺陷个数
            if (IsOnline) {
                lblAIFault.Text = lblTotalFault.Text = config.ConfigInfo.GetInstance().TotalFualt.ToString();
            }
        }
        #region 离线数据读取
        private void ReadAllFault() {
            dtFault = new DataTable();
            dtFault = _offLine.IndDb.ExecuteDataTable("select a.* ,b.poleNum pol ,b.cId cid ,b.KMValue kmv, b.STN stn ,b.SubDBId subDBId from faultInfo a left join picInfoInd  b on a.imgGUID=b.imgGUID ", null);
            //MessageBox.Show(GetDB.ExecuteDataTable("select * from faultInfo where isAI=0", null).Rows.Count.ToString());
            DialogTaskTip.GetInstance().EndProc();
            InvokeLbl();
        }
        private void InvokeLbl() {
            if (lblTotalFault.InvokeRequired) {
                Action a = new Action(InvokeLbl);
                lblTotalFault.Invoke(a);
            } else {
                lblTotalFault.Text = dtFault.Rows.Count.ToString();

                lblmanFault.Text = dtFault.Select("isAI = 0").Length.ToString();
                lblAIFault.Text = dtFault.Select("isAI =1").Length.ToString();

                lblConfirmFault.Text = dtFault.Select("confirmResult> -1").Length.ToString();
                lblUnknownFault.Text = dtFault.Select("confirmResult=-1").Length.ToString();
                dgvFaultData.AutoGenerateColumns = false;
                DataView dv = new DataView(dtFault);
                dv.RowFilter = "confirmResult = 1";
                dgvFaultData.DataSource = dv;
                dgvFaultData.Refresh();


            }
        }

        #endregion

        private void dgvFaultData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            foreach (DataGridViewRow row in dgvFaultData.Rows) {
                row.Cells["colUName"].Value = LocFaultInfo.GetUName(Convert.ToInt32(row.Cells["colUID"].Value));
                int fId = Convert.ToInt32(LocFaultInfo.GetFaultIds(row.Cells["colFID"].Value.ToString())[0]);
                string fName = LocFaultInfo.GetFName(fId);
                row.Cells["colFName"].Value = fName;
            }
        }

        private void LoadImg(string sImgKey, string pid, string subDbId) {
            try {
                //this.Enabled = false;
                m_FigHandOverlay.Figures.Clear();
                ImgView1.Refresh();
                //查找数据库得到图像                
                ImgView1.Image = JpgCompress.Decompress(_offLine.GetImg(subDbId, sImgKey));
                this.Enabled = true;
                double mag = ImgView1.Width * 1.0 / ImgView1.Display.ImageSize.Width;
                if (mag < 0.001) {
                    return;
                }
                ImgView1.Display.Magnification = mag;

                //载入图片的定位 && 缺陷信息
                DataRow[] drfaults = dtFault.Select("pId=" + pid);

                // for (int i = 0; i < drfaults.Length; ++i) {
                DataRow drFault = drfaults[0];
                RectangleConverter ss = new RectangleConverter();
                string sMark = drFault["mark"].ToString();
                sMark = sMark.Substring(1, sMark.Length - 2);
                Rectangle rc = (Rectangle)ss.ConvertFromString(sMark);
                string sFaults = drFault["fault"].ToString();
                List<int> lstFaultIDs = sFaults.Substring(1, sFaults.Length - 2).Split(',').Select(x => Convert.ToInt32(x)).ToList();
                LocFaultInfo locFaultInfo = new LocFaultInfo(Convert.ToInt64(drFault["pId"]), Convert.ToInt32(drFault["unitId"]), rc, lstFaultIDs);
                //载入定位和缺陷标注信息
                LoadMark(locFaultInfo);

                if (!isImport) {
                    ImgView1.Refresh();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                 
            } finally {
                //  this.Enabled = true;
            }



        }

        private Image GetFaultImg() {
            //保存当前缺陷截图
            CFviImage cvImg = new CFviImage();
            ImgView1.Display.Magnification = 0.5; ;
            double dMgn = ImgView1.Display.Magnification;
            ImgView1.Display.SaveImage(cvImg, ImgView1.Image.ImageSize.ToRectangle(), dMgn);
            return (Image)cvImg;
        }

        void ImageView_MouseWheel(object sender, MouseEventArgs e) {

            CFviImageView ImgV = (CFviImageView)sender;
            if (e.Delta > 0) {
                ImgV.Display.Magnification = ImgV.Display.Magnification * 1.2;
            } else if (e.Delta < 0) {
                ImgV.Display.Magnification = ImgV.Display.Magnification * 0.8;
            }

            ImgV.Refresh();

        }

        /// <summary>
        /// 从数据库中载入已有标注&&缺陷信息
        /// </summary>
        private void LoadMark(LocFaultInfo unitMark) {

            // foreach (LocFaultInfo unitMark in lsUnit) {
            CFviPoint p = new CFviPoint(unitMark.Mark.X, unitMark.Mark.Y);
            int w = unitMark.Mark.Width;
            int h = unitMark.Mark.Height;
            //  MessageBox.Show("x:" + p.X + "y:" + p.Y + "w:" + w + "h:" + h);
            m_FigHandOverlay.Active = true;
            FVIL.Data.CFviRectangle vis = ImgView1.Display.VisibleRect;
            FVIL.GDI.CFviGdiRectangle figure = new FVIL.GDI.CFviGdiRectangle();

            figure.St = new CFviPoint(p.X, p.Y);
            figure.Ed = new CFviPoint(p.X + w, p.Y + h);



            figure.Pen.Color = Color.Red;

            //FVIL.GDI.CFviGdiFigure f1 = new FVIL.GDI.CFviGdiString(unitMark.GetUnitName() + " - " + unitMark.GetFaultNameByInd(0));
            FVIL.GDI.CFviGdiString f1 = new FVIL.GDI.CFviGdiString(unitMark.GetUnitName() + " - " + unitMark.GetFaultNameByInd(0), Color.Red, FVIL.GDI.TextAlign.Left, false);
            f1.Position = figure.St;
            if (isImport) {
                figure.Pen.Width = 5;
                f1.Font.Height = 50;
            }
            m_FigHandOverlay.Figures.Add(f1);
            //记录缺陷个数
            if (IsOnline) {
                ++config.ConfigInfo.GetInstance().TotalFualt;
            }
            m_FigHandOverlay.Figures.Add(figure);

            // }
        }

        private void dgvFaultData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (dgvFaultData.CurrentRow == null) {
                return;
            }
            string pid = dgvFaultData.CurrentRow.Cells["colPid"].Value.ToString();
            string subDbId = dgvFaultData.CurrentRow.Cells["ColSubDbId"].Value.ToString();
            LoadImg(dgvFaultData.CurrentRow.Cells["ColImgGUID"].Value.ToString(), pid, subDbId);

        }
        //导出缺陷图片
        private void tsMenuItemSaveImg_Click(object sender, EventArgs e) {
            if (dgvFaultData.CurrentRow == null) {
                return;
            }
            SaveImg();

        }
        private void SaveImg() {
            FolderBrowserDialog of = new FolderBrowserDialog();
            string sDir = StationInfoP4.GetInstance().GetShortInfo() + "缺陷图片";

            try {
                this.Enabled = false;
                of.Description = "请选择导出缺陷图像的文件夹";
                of.SelectedPath = Path.GetDirectoryName(SqliteHelper1.GetSqlite(Settings.Default.MDB).dbFullName);
                if (of.ShowDialog() == DialogResult.OK) {
                    string savePath = Path.Combine(of.SelectedPath, sDir);
                    FileHelper1.CreateDir(savePath);
                    isImport = true;
                    foreach (DataGridViewRow item in dgvFaultData.SelectedRows) {
                        //拼接 路径
                        StringBuilder sImgName = new StringBuilder(StationInfoP4.GetInstance().GetShortInfo()); ;
                        sImgName.Append(" " + item.Cells["colSTN"].Value.ToString());
                        sImgName.Append(" " + item.Cells["colPOL"].Value.ToString());
                        sImgName.Append("#" + item.Cells["colUName"].Value.ToString());
                        sImgName.Append(item.Cells["colFName"].Value.ToString());
                        sImgName.Append(".jpg");
                        string imgFullPath = Path.Combine(savePath, sImgName.ToString());
                        string pid = item.Cells["colPid"].Value.ToString();
                        LoadImg(item.Cells["ColImgGUID"].Value.ToString(), pid, item.Cells["colSubDbInd"].Value.ToString());
                        GetFaultImg().Save(imgFullPath);
                    }
                    this.Enabled = true;
                    MessageBox.Show(String.Format("成功导出缺陷：{0}条", dgvFaultData.SelectedRows.Count));
                    isImport = false;
                }
            } catch (Exception) {

            }






        }

        private void tsMenuItemDelFault_Click(object sender, EventArgs e) {
            if (DialogResult.No == MessageBox.Show("确定删除选择的缺陷", "删除警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                return;
            }
            foreach (DataGridViewRow item in dgvFaultData.SelectedRows) {
                //拼接 路径
                string pid = item.Cells["colPid"].Value.ToString();
                string sSql = "update  faultInfo set confirmResult=0 where pId=" + pid;
                _offLine.IndDb.ExecuteNonQuery(sSql);
            }
            UpdateData();
        }

        private void tsMenuItemFresh_Click(object sender, EventArgs e) {
            UpdateData();
        }

        private void panelEx5_Resize(object sender, EventArgs e) => ImgView1.Height = (int)(ImgView1.Width * 0.6);

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
