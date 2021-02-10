using DevComponents.DotNetBar;
using DevComponents.Editors;
using Project4C.Core;
using Project4C.DB;
using Project4C.Properties;
using Project4C.UI;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Project4C {
    public partial class FrmParent : RibbonForm {

        #region 创建单实例对象
        private static FrmParent _frmParent;
        private static object _obj = new object();
        public static FrmParent GetInstance() {
            if (_frmParent == null) {
                lock (_obj) {
                    if (_frmParent == null) {
                        _frmParent = new FrmParent();
                    }
                }
            }
            return _frmParent;
        }
        private FrmParent() {
            //StyleManager.ChangeStyle(eStyle.Office2007Blue, Color.Empty);
            _offLine = null;
            InitializeComponent();
           // StyleManager.Style = eStyle.VisualStudio2012Dark;
            //StyleManager.ChangeStyle(eStyle.Office2007Blue, Color.Empty);
        

        }
      
        #endregion
 // private SqliteHelper1 GetDB => SqliteHelper1.GetSqlite(Settings.Default.MDB);
        #region 子窗体打开
        private OffLineOp _offLine;
        private Form m_CurrentMdiChild;//声明窗体
        //子窗体只能打开一次      
        
        private void ShowMdiChild(Form mdiForm) {
            mdiForm.Visible = false;
            if (this.m_CurrentMdiChild != null) {
                this.m_CurrentMdiChild.Close(); //关闭当前窗体
            }
            this.m_CurrentMdiChild = mdiForm; //本窗体设置成为当前窗体          
            mdiForm.WindowState = FormWindowState.Maximized;
            mdiForm.MdiParent = this;
            mdiForm.Visible = true;
            mdiForm.Show();
        }
        /// <summary>
        /// 打开数据分析窗口
        /// </summary>
        public void ShowDataAnalyze(OffLineOp offLine) {
            try {
                ribbonControl1.Expanded = false;
                FrmOnline.GetInstance()._OffLineOpe = offLine;
                ShowMdiChild(FrmOnline.GetInstance());
                RibbonStateCommand.Checked = true;
                _offLine = offLine;

            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
           
        }
        /// <summary>
        /// 打开任务选择窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnIterm_TaskM_Click(object sender, EventArgs e) {
            ShowMdiChild(new FrmTaskMgr());
        }
        /// <summary>
        /// 打开报表窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnIterm_achieve_Click(object sender, EventArgs e) {
            if (_offLine == null) {
                MessageBox.Show("请先选择离线数据库！");
                return;
            }
            // ShowMdiChild(new CtrlReport());
            Form mdiForm = new CtrlReport(_offLine);
            mdiForm.Visible = false;


            mdiForm.WindowState = FormWindowState.Maximized;
            mdiForm.MdiParent = this;
            mdiForm.Visible = true;
            mdiForm.Show();
        }

        /// <summary>
        /// 打开密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIterm_PWDChange_Click(object sender, EventArgs e) {
            new FrmSetPwd().ShowDialog();
        }

        /// <summary>
        /// 用户管理窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIterm_UserMgr_Click(object sender, EventArgs e) {
            new FrmUserMgr().ShowDialog();
        }

        /// <summary>
        /// 导出一杆一档图像数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItem_ImportData_Click(object sender, EventArgs e) {
            if (_offLine == null) {
                ComClassLib.MsgBox.Show("请先选择离线数据！");
                return;
            }
            new FrmImportImg(_offLine).ShowDialog();
        }

        #endregion

        //属性设置
        public string LblTaskInfoTxt { set { lblTaskInfo.Text = value; this.Refresh(); } }


        private void FrmParent_Shown(object sender, EventArgs e) {
            FrmTaskMgr frmTask = new FrmTaskMgr();

            frmTask.SetPanelInfoVisible = false;
            ShowMdiChild(frmTask);
           

        }

        #region 样式管理
        private void RibbonStateCommand_Executed(object sender, EventArgs e) {
            ribbonControl1.Expanded = RibbonStateCommand.Checked;
            RibbonStateCommand.Checked = !RibbonStateCommand.Checked;
        }

        private void AppCommandTheme_Executed(object sender, EventArgs e) {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string) {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
                // Using StyleManager change the style and color tinting
                if (StyleManager.IsMetro(style)) {
                    // More customization is needed for Metro
                    // Capitalize App Button and tab
                    //buttonFile.Text = buttonFile.Text.ToUpper();
                    foreach (BaseItem item in RibbonControl.Items) {
                        // Ribbon Control may contain items other than tabs so that needs to be taken in account
                        RibbonTabItem tab = item as RibbonTabItem;
                        if (tab != null) {
                            tab.Text = tab.Text.ToUpper();
                        }
                    }

                    //buttonFile.BackstageTabEnabled = true; // Use Backstage for Metro

                    ribbonControl1.RibbonStripFont = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
                    if (style == eStyle.Metro) {
                        StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;
                    }

                    // Adjust size of switch button to match Metro styling
                    //switchButtonItem1.SwitchWidth = 12;
                    //switchButtonItem1.ButtonWidth = 42;
                    //switchButtonItem1.ButtonHeight = 19;

                    // Adjust tab strip style
                    //tabStrip1.Style = eTabStripStyle.Metro;

                    StyleManager.Style = style; // BOOM
                } else {
                    // If previous style was Metro we need to update other properties as well
                    if (StyleManager.IsMetro(StyleManager.Style)) {
                        ribbonControl1.RibbonStripFont = null;
                        // Fix capitalization App Button and tab
                        //buttonFile.Text = ToTitleCase(buttonFile.Text);
                        foreach (BaseItem item in RibbonControl.Items) {
                            // Ribbon Control may contain items other than tabs so that needs to be taken in account
                            RibbonTabItem tab = item as RibbonTabItem;
                            if (tab != null) {
                                tab.Text = ToTitleCase(tab.Text);
                            }
                        }
                        // Adjust size of switch button to match Office styling
                        switchButtonItem1.SwitchWidth = 28;
                        switchButtonItem1.ButtonWidth = 62;
                        switchButtonItem1.ButtonHeight = 20;
                    }
                    // Adjust tab strip style
                    //tabStrip1.Style = eTabStripStyle.Office2007Document;
                    StyleManager.ChangeStyle(style, Color.Empty);
                    //if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                    //    buttonFile.BackstageTabEnabled = false;
                    //else
                    //    buttonFile.BackstageTabEnabled = true;


                }

                if (style == eStyle.VisualStudio2012Dark) {
                    GetControls(this, Color.White);
                    lblTaskInfo.ForeColor = Color.Yellow;
                } else {
                    GetControls(this, Color.Black);
                    lblTaskInfo.ForeColor = Color.Blue;
                }
            } else if (source.CommandParameter is Color) {
                if (StyleManager.IsMetro(StyleManager.Style)) {
                    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
                } else {
                    StyleManager.ColorTint = (Color)source.CommandParameter;
                }
            }
        }

        private string ToTitleCase(string text) {
            if (text.Contains("&")) {
                int ampPosition = text.IndexOf('&');
                text = text.Replace("&", "");
                text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                if (ampPosition > 0) {
                    text = text.Substring(0, ampPosition) + "&" + text.Substring(ampPosition);
                } else {
                    text = "&" + text;
                }

                return text;
            }
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        //获取所有lableX控件

        private void GetControls(Control fatherControl, Color color) {
            Control.ControlCollection sonControls = fatherControl.Controls;
            //遍历所有控件
            foreach (Control ctrl in sonControls) {
                if (ctrl is LabelX || ctrl is IntegerInput|| ctrl is IpAddressInput) {
                    
                    ctrl.ForeColor = color;
                } else if (ctrl.Controls != null) {
                    GetControls(ctrl, color);
                }
            }
        }


        #endregion
       
        private void FrmParent_FormClosed(object sender, FormClosedEventArgs e) {
          
        }
       
    }
}
