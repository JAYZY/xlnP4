using DevComponents.DotNetBar;
using FVIL.Data;
using FVIL.Forms;
using FVIL.GDI;
using Project4C.Core;
using Project4C.DB;
using Project4C.FileOp;
using Project4C.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Project4C.UI {
    public partial class FrmOnline : OfficeForm {//UserControl {
        const bool isTestOnline = true;


        //const uint CAMNUM = 4;//相机个数
        const int iFaultDbId = 6;
        const int iImgDBIdx = 10;
        const int iImgListDBIdx = 11, iImgInfoDBIdx = 11;
        const int iAILocFaultDbId = 12;
        const int iCamStartID = 1;
        private const double dxNumPerPole = 32.0;
        private int iItemStepSelInd = -1;
        bool isShowOne = false;//是否只显示一张图片
        string[] result = { "O 待定", "X 误判", "√ 确认" };

        protected FigureHandlingOverlay[] m_FigHandOverlay = new FigureHandlingOverlay[4];


        //  protected FVIL.GDI.CFviOverlay m_OverlayA = new FVIL.GDI.CFviOverlay();
        //  protected FVIL.GDI.CFviOverlay m_OverlayB = new FVIL.GDI.CFviOverlay();
        protected FVIL.GDI.CFviOverlay[] m_Overlay = new FVIL.GDI.CFviOverlay[4];

        protected CFviImageView[] imgViews = new CFviImageView[4];
        protected Label[] lblTips = new Label[4];
        protected Panel[] imgPanel = new Panel[4];

        private DataTable dtFault;
        public OffLineOp _OffLineOpe { get; set; }
        private bool IsOnline { get { return _OffLineOpe == null; } }//Settings.Default.ViewMode == 1; } }
        //当前图片信息
        private string curImgKey { get; set; }
        private static long curImgId = 0;
        private bool IsPlay { get; set; }
        //最大支柱号
        private PicInfo MaxPicInfo { get; set; }
        //  private string CurKMV { get; set; }
        //记录当前加载的标注编号
        private Dictionary<Int64, CFviGdiFigure> dicMarkDataId;
        private Dictionary<string, List<PicInfo>> dicPoleName2PicInfo; //绑定支柱号与PicInfo列表

        private SqliteHelper1 GetDB => SqliteHelper1.GetSqlite(Settings.Default.MDB);


        #region 创建单实例对象
        private static FrmOnline _FrmOnlinet;
        private static object _obj = new object();
        public static FrmOnline GetInstance() {
            if (_FrmOnlinet == null) {
                lock (_obj) {
                    if (_FrmOnlinet == null) {
                        _FrmOnlinet = new FrmOnline();
                    }
                }
            }
            return _FrmOnlinet;
        }
        private FrmOnline() {
            InitializeComponent();
            bar2.Visible = true;


        }
        #endregion

        #region 初始化工作

        private void FrmOnline_Load(object sender, EventArgs e) {
            LoadInit();
        }

        public void LoadInit() {
            this.Dock = DockStyle.Fill;

            IniCtrl();
            progressSteps1.Visible = false;

            if (IsOnline) {
                try {
                    IniDtFault();
                    //读取已有数据，定位到最新数据。算法：1.获取最新的图像列表，获取杆号等信息生成进度控件。2，获取最新的定位&缺陷信息，生成缺陷表
                    //Thread th = new Thread(LocalLastData);th.Start();
                    //启动定位到最新的数据
                    List<string> allKey = RedisHelper.GetInstance().GetAllList("list");
                    if (isTestOnline) {
                        curImgId = 0;
                    }
                    else {
                        curImgId += allKey.Count;
                    }
                    progressSteps1.Width = 160;
                    progressSteps1.Visible = true;
                    progressSteps1.Refresh();
                    GetFaultData();
                    Play();
                }
                catch (Exception e) {
                    MessageBox.Show(e.ToString());
                    throw;
                }
            }
            else {
                IniDtFault();
                _OffLineOpe.RtnStationInfo = Invoke_AddCbStationInfo;
                _OffLineOpe.RtnFaultInfo = Invoke_DgvData;
                _OffLineOpe.IniData();

            }
        }
        /// <summary>
        /// 初始化缺陷表格
        /// </summary>
        private void IniDtFault() {
            dtFault = new DataTable();
            dtFault.Columns.Add("Id");
            dtFault.Columns.Add("POL");
            dtFault.Columns.Add("uId");
            dtFault.Columns.Add("unit");
            dtFault.Columns.Add("fId");
            dtFault.Columns.Add("Fault");
            dtFault.Columns.Add("CamId");
            dtFault.Columns.Add("KMV");
            dtFault.Columns.Add("ImgKey");
            dtFault.Columns.Add("Mark");
            dtFault.Columns.Add("TIM");
            dtFault.Columns.Add("FaultComfirm");
            dtFault.Columns.Add("isAI");
            //dtFault.Columns.Add("img");
            dgViewFault.AutoGenerateColumns = false;


        }
        /// <summary>
        /// 控件初始化
        /// </summary>
        private void IniCtrl() {
            timerPlay.Tag = 12;//一秒1帧
            timerPlay.Interval = 1000 / 12; ;
            IsPlay = false;
            rBarComfirm.Visible = false;
            FVIL._SetUp.InitVisionLibrary();

            imgViews[0] = ImgView1; imgViews[1] = ImgView2;
            imgViews[2] = ImgView3; imgViews[3] = ImgView4;
            lblTips[0] = lblTipA; lblTips[1] = lblTipB; lblTips[2] = lblTipC; lblTips[3] = lblTipD;
            lblTipA.ForeColor = lblTipB.ForeColor = lblTipC.ForeColor = lblTipD.ForeColor = Color.White;
            imgPanel[0] = panelImgA; imgPanel[1] = panelImgB; imgPanel[2] = panelImgC; imgPanel[3] = panelImgD;

            for (int i = 0; i < m_FigHandOverlay.Length; ++i) {
                m_FigHandOverlay[i] = new FigureHandlingOverlay();
                imgViews[i].Display.Overlays.Add(m_FigHandOverlay[i]);
                m_FigHandOverlay[i].AddMouseEventHandler(imgViews[i]);
                imgViews[i].MouseWheel += new System.Windows.Forms.MouseEventHandler(ImageView_MouseWheel);
                imgViews[i].MouseMove += new System.Windows.Forms.MouseEventHandler(ImgView_MouseMove);
                imgViews[i].MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(ImgView_MouseDoubleClick);
                imgViews[i].MouseDown += new System.Windows.Forms.MouseEventHandler(ImgView_MouseDown);
                imgViews[i].MouseUp += new System.Windows.Forms.MouseEventHandler(ImgView_MouseUp);
            }
            dicMarkDataId = new Dictionary<Int64, CFviGdiFigure>();
            dicPoleName2PicInfo = new Dictionary<string, List<PicInfo>>();
            tbLayoutPanelRight.Dock = DockStyle.Fill;

            sBtnItemModle.Visible = IsOnline; //离线不显示 实时/智能选框
            btnNext.Visible = btnPrev.Visible = !IsOnline; //在线不显示按钮
            bar1.Visible = IsOnline;
        }

        #endregion

        #region 离线操作
        private const int iBulkDataByOnce = 1000;//一次读取的数据大小
        private int iOffLineDataIdx = 0; //读取离线数据的索引
        private int iOffLineFaultIdx = 0;//读取离线数据的缺陷索引
        private DataTable dtOffDataInfo = null;     //离线图像&信息数据
        private DataTable dtOffLineFault = null; //离线缺陷数据
        private string sSTN = "";
        private bool isLastData = false;

        /// <summary>
        /// 读取离线信息数据
        /// </summary>
        private void ReadOffLineData() {
            ReadOffLinePicInfo();
            if (string.IsNullOrEmpty(sSTN)) {
                //读取站区信息
                ReadStationInfo();
            }
            //读取缺陷数据
            GetOffFaultData();
            //线程读取支柱号
            new Thread(GetOffLinePicInfo).Start();
            //线程读取缺陷数据
            // new Thread(GetOffFaultData).Start();


        }
        #region  读取离线图像数据
        /// <summary>
        /// 读取离线图像数据
        /// </summary>
        /// <param name="sSTN"></param>
        private void ReadOffLinePicInfo() {
            try {
                string sSqlA = "";

                if (string.IsNullOrEmpty(sSTN)) {
                    sSqlA = string.Format("select imgGuid,cId,shootTime,poleNum,KMValue,STN from picInfo Limit {0} offset {1}", iBulkDataByOnce, iOffLineDataIdx);
                }
                else {
                    sSqlA = string.Format("select imgGuid,cId,shootTime,poleNum,KMValue,STN from picInfo where STN='{0}' Limit {1} offset {2}", sSTN, iBulkDataByOnce, iOffLineDataIdx);
                }

                dtOffDataInfo = GetDB.ExecuteDataTable(sSqlA, null);
                if (dtOffDataInfo.Rows.Count < iBulkDataByOnce) {
                    isLastData = true;
                }
                //修改为根据时间排序
                dtOffDataInfo.DefaultView.Sort = "shootTime ASC";
                //根据上下行情况对公里标进行排序,上行公里标升序，下行公里标降序
                //if (StationInfo.GetInstance().IType == 0) {
                //    dtOffDataInfo.DefaultView.Sort = "KMValue ASC ";
                //} else {
                //    dtOffDataInfo.DefaultView.Sort = "KMValue desc ";
                //}
                dtOffDataInfo = dtOffDataInfo.DefaultView.ToTable();
                string station = dtOffDataInfo.Rows[0]["STN"].ToString();
                Invoke_Station(station);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Invoke_Station(string sStation) {
            if (lblStartStation.InvokeRequired) {
                Action<string> a = Invoke_Station;
                lblStartStation.Invoke(a, sStation);
            }
            else {
                String[] s = sStation.Split('-');
                lblStartStation.Text = s[0];
                lblEndStation.Text = (s.Length == 1) ? s[0] : s[1];
            }
        }
        #endregion

        private void Invoke_DgvData(DataTable dt) {
            if (dgViewFault.InvokeRequired) {
                Action<DataTable> a = Invoke_DgvData;
                lblStartStation.Invoke(a, dt);
            }
            else {
                if (dt != null) {
                    dtFault.Clear();
                    foreach (DataRow dr in dt.Rows) {

                        DataRow drNew = dtFault.NewRow();
                        int uId = Convert.ToInt32(dr["unitId"]);
                        string uName = LocFaultInfo.GetUName(uId);
                        int fId = Convert.ToInt32(LocFaultInfo.GetFaultIds(dr["fault"].ToString())[0]);
                        string fName = LocFaultInfo.GetFName(fId);
                        long imgKey = Convert.ToInt64(dr["imgGUID"]);
                        DataRow[] drImgInfo = _OffLineOpe.GetImgInfo(imgKey);
                        if (drImgInfo == null || drImgInfo.Length == 0) {
                            continue;
                        }
                        int iConfirmResult = Convert.ToInt32(dr["confirmResult"]);
                        string sConfirmR = result[iConfirmResult + 1];
                        drNew.ItemArray = new Object[] { dr["pId"], drImgInfo[0]["poleNum"], uId, uName, dr["fault"], fName, drImgInfo[0]["cId"], drImgInfo[0]["KMValue"], imgKey, dr["mark"], drImgInfo[0]["shootTime"], sConfirmR, dr["isAI"] };
                        dtFault.Rows.Add(drNew);

                    }


                    //isDataBindComplete = false;
                    dgViewFault.DataSource = null;
                    dgViewFault.AllowUserToAddRows = false;
                    dgViewFault.DataSource = dtFault.DefaultView;
                    dgViewFault.Refresh();
                }
            }
        }

        #region 读取站区信息
        /// <summary>
        /// 读取站点信息
        /// </summary>
        private void ReadStationInfo() {
            String sSqlA = "select distinct(STN) from picInfo";
            DataTable dt = GetDB.ExecuteDataTable(sSqlA, null);
            Invoke_AddCbStationInfo(dt);
        }
        private void Invoke_AddCbStationInfo(DataTable dt) {
            if (cbStationInfo.InvokeRequired) {
                Action<DataTable> a = Invoke_AddCbStationInfo;
                cbStationInfo.Invoke(a, dt);
            }
            else {
                cbStationInfo.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i) {
                    DataRow dr = dt.Rows[i];
                    if (dr[0] == null || string.IsNullOrEmpty(dr[0].ToString())) {
                        continue;
                    }
                    cbStationInfo.Items.Add(dr[0]);
                }
                if(cbStationInfo.Items.Count>0)
                cbStationInfo.SelectedIndex = 0;
            }
        }
        #endregion
        /// <summary>
        /// 读取离线图像数据，生成支柱号进度条
        /// </summary>
        private void GetOffLinePicInfo() {
            //dicPoleName2PicInfo.Clear();
            progressSteps1.Items.Clear();
            string sOldPoleNum = "";
            List<PicInfo> lstPicInfo = new List<PicInfo>();

            //统计点击情况
            int iClickedNum = 0;
            //---遍历离线数据
            bool isConfirmDefault = false;
            foreach (DataRow row in dtOffDataInfo.Rows) {
                Int64 imgId = Convert.ToInt64(row["imgGUID"]);
                PicInfo picInfo = new PicInfo(imgId, Convert.ToInt32(row["cId"]), Convert.ToInt64(row["shootTime"]), row["poleNum"].ToString(), row["KMValue"].ToString());
                if (picInfo.IsClick()) {
                    ++iClickedNum;
                }
                if (dtOffLineFault != null) {
                    DataRow[] drTmp = dtOffLineFault.Select("imgGUID=" + imgId);
                    if (drTmp.Length > 0 && 1 == Convert.ToInt32(drTmp[0]["confirmResult"])) {
                        isConfirmDefault = true;
                        picInfo.HasFault = true;
                    }
                }
                //修改为 不用 字典方式添加 poleNum
                if (!sOldPoleNum.Equals(picInfo.POL)) {
                    //添加/显示进度条
                    StepItem st = new StepItem(picInfo.GetImgKey().ToString(), picInfo.POL);
                    st.Cursor = System.Windows.Forms.Cursors.Hand;
                    st.Click += new System.EventHandler(this.StepItem_Click);
                    st.RecalcSize();
                    AddStepItem(st);
                    if (lastStepItem != null) {
                        lastStepItem.Value = (int)(++iClickedNum / (lstPicInfo.Count * 1.0) * 100);
                        if (isConfirmDefault) {//包含缺陷--文字颜色为红色
                            lastStepItem.TextColor = Color.Red;
                        }
                    }
                    lastStepItem = st;
                    MaxPicInfo = picInfo;
                    lstPicInfo = new List<PicInfo>();
                    sOldPoleNum = picInfo.POL;
                    st.Tag = lstPicInfo;
                    iClickedNum = 0;
                    isConfirmDefault = false;
                }
                lstPicInfo.Add(picInfo);
            }
            BtnEnable();
            DialogTaskTip.GetInstance().EndProc();
        }
        /// <summary>
        /// 分析离线数据，载入缺陷数据faultDT
        /// </summary>
        private void GetOffFaultData() {

            if (dtOffDataInfo == null) {
                return;
            }
            IniDtFault();
            try {
                string tmpStr = dtOffDataInfo.Rows[dtOffDataInfo.Rows.Count - 1]["imgGUID"].ToString();
                string sSql = "select * from FaultInfo where imgGUID <" + tmpStr;
                dtOffLineFault = GetDB.ExecuteDataTable(sSql, null);
                if (dtOffLineFault != null) {
                    foreach (DataRow dr in dtOffLineFault.Rows) {

                        DataRow drNew = dtFault.NewRow();
                        int uId = Convert.ToInt32(dr["unitId"]);
                        string uName = LocFaultInfo.GetUName(uId);
                        int fId = Convert.ToInt32(LocFaultInfo.GetFaultIds(dr["fault"].ToString())[0]);
                        string fName = LocFaultInfo.GetFName(fId);
                        string imgKey = dr["imgGUID"].ToString();
                        DataRow[] drImgInfo = dtOffDataInfo.Select("imgGUID=" + imgKey);
                        if (drImgInfo == null || drImgInfo.Length == 0) {
                            continue;
                        }
                        int iConfirmResult = Convert.ToInt32(dr["confirmResult"]);
                        string sConfirmR = result[iConfirmResult + 1];
                        drNew.ItemArray = new Object[] { dr["pId"], drImgInfo[0]["poleNum"], uId, uName, dr["fault"], fName, drImgInfo[0]["cId"], drImgInfo[0]["KMValue"], imgKey, dr["mark"], drImgInfo[0]["shootTime"], sConfirmR, dr["isAI"] };
                        dtFault.Rows.Add(drNew);

                    }
                    //Invoke_DgvData();
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>f
        /// 加载离线图像
        /// </summary>
        /// <param name="picInfo"></param>
        /// <param name="isAddFault"></param>
        /// <returns></returns>
        private bool LoadOffLineImg(PicInfo picInfo, bool isAddFault = true) {
            dicMarkDataId.Clear();
            int idx = picInfo.CID - iCamStartID;
            // DataRow[] drOffData = dtOffDataInfo.Select("imgGUID=" + picInfo.GetImgKey());
            byte[] imgbyte = picInfo.Getimg(_OffLineOpe.GetSubDB(picInfo.iSubDbInd.ToString()), true);
            DelAllLayerDel(idx); //删除标注        
            //载入图像 到指定 imgView
            LoadImgInvoke(imgViews[idx], imgbyte);

            //载入图片的定位 && 缺陷信息
            DataRow[] drfaults = _OffLineOpe.GetFault(picInfo.GetImgKey());
            if (drfaults == null) {
                return false;
            }
            for (int i = 0; i < drfaults.Length; ++i) {
                DataRow drFault = drfaults[i];
                RectangleConverter ss = new RectangleConverter();
                string sMark = drFault["mark"].ToString();
                sMark = sMark.Substring(1, sMark.Length - 2);
                Rectangle rc = (Rectangle)ss.ConvertFromString(sMark);
                string sFaults = drFault["fault"].ToString();
                List<int> lstFaultIDs = sFaults.Substring(1, sFaults.Length - 2).Split(',').Select(x => Convert.ToInt32(x)).ToList();
                LocFaultInfo locFaultInfo = new LocFaultInfo(Convert.ToInt64(drFault["pId"]), Convert.ToInt32(drFault["unitId"]), rc, lstFaultIDs);
                //载入定位和缺陷标注信息
                LoadMark(idx, locFaultInfo);

            }
            return true;
        }


        #endregion


        private int iMaxPoleCtrlNum = 300;


        #region 程序启动定位到最新数据
        /// <summary>
        /// 定位到最新的数据
        /// </summary>
        private void LocalLastData() {
            //读取所有的 list 数据
            List<string> allKey = RedisHelper.GetInstance().GetAllList("list");
            curImgId += allKey.Count;
            List<PicInfo> lstPicInfo = new List<PicInfo>();
            string sOldPoleNum = "";

            foreach (string key in allKey) {
                PicInfo picinfo = GetPicInfo(key);
                if (null == picinfo) {
                    continue;
                }

                if (!sOldPoleNum.Equals(picinfo.POL)) {
                    //添加/显示进度条
                    StepItem st = new StepItem(picinfo.GetImgKey().ToString(), picinfo.POL);
                    st.Cursor = System.Windows.Forms.Cursors.Hand;
                    st.Click += new System.EventHandler(this.StepItem_Click);
                    st.RecalcSize();

                    AddStepItem(st);
                    lastStepItem = st;
                    MaxPicInfo = picinfo;
                    lastStepItem.Value = 100;
                    lstPicInfo = new List<PicInfo>();
                    sOldPoleNum = picinfo.POL;
                    st.Tag = lstPicInfo;
                }
                lstPicInfo.Add(picinfo);
            }
            AddStepItem(null);
            // 
        }

        /// <summary>
        /// 获取最新的缺陷信息；
        /// </summary>
        private void GetFaultData() {

            //获取已经得到的缺陷列表
            List<string> lstFault = RedisHelper.GetInstance().GetAllList("faultLst", iFaultDbId);
            int iStartLocIdx = 0;
            if (0 != lstFault.Count) {
                iStartLocIdx = Convert.ToInt32(lstFault[0]);
                for (int i = 1; i < lstFault.Count; ++i) {
                    string pId = lstFault[i];
                    FaultInfo fInfo = RedisHelper.GetInstance().GetObj<FaultInfo>(pId, iFaultDbId);
                    DataRow dr = dtFault.NewRow();
                    string uName = LocFaultInfo.GetUName(fInfo.UID);
                    string fName = LocFaultInfo.GetFName(fInfo.FID[0]);
                    dr.ItemArray = new Object[] { pId, fInfo.POL, fInfo.UID, uName, fInfo.FID[0], fName, fInfo.CID, fInfo.KMV, fInfo.MID, fInfo.MAR, fInfo.TIM, result[fInfo.YES + 1], 1 };
                    dtFault.Rows.Add(dr);
                }
            }
            else {
                RedisHelper.GetInstance().RightLstPush("faultLst", "0", iFaultDbId);
            }

            List<string> lstLocFault = RedisHelper.GetInstance().GetAllList("list", iAILocFaultDbId);
            for (int i = iStartLocIdx; i < lstLocFault.Count; ++i) {
                string sImgKey = lstLocFault[i];
                PicInfo picInfo = GetPicInfo(sImgKey);
                List<LocFaultInfo> lsUnitLocFaults = GetUnitLocInfo(sImgKey);
                foreach (var LocInfo in lsUnitLocFaults) {
                    if (LocInfo.IsFault) {  //如果是缺陷，则添加
                        string unitName = LocInfo.GetUnitName();
                        //for (int ind = 0; ind < LocInfo.Fault.Count; ++ind) { //目前默认就只有一个缺陷，若有多个后续改进
                        string FaultName = LocInfo.GetFaultNameByInd(0);
                        string pID = LocInfo.ID + "" + 0;
                        FaultInfo faultInfo = new FaultInfo(pID, LocInfo.UnitId, LocInfo.Fault, sImgKey, picInfo.POL, "admin", picInfo.CID, picInfo.KMV);
                        faultInfo.MAR = LocInfo.Mark;
                        DataRow dr = dtFault.NewRow();
                        dr.ItemArray = new Object[] { pID, picInfo.POL, LocInfo.UnitId, unitName, LocInfo.Fault[0], FaultName, picInfo.CID, picInfo.KMV, sImgKey, LocInfo.Mark, picInfo.TIM, result[0], 1 };
                        dtFault.Rows.Add(dr);
                        string sFaultJson = faultInfo.ToJson();
                        RedisHelper.GetInstance().SetFaultValue(pID, sFaultJson, i, iFaultDbId);

                        //}
                    }
                }


            }

        }
        #endregion

        #region 数据载入
        private bool LoadImg(PicInfo picInfo, bool isAddFault = true) {

            bool isRet = false;
            if (picInfo.GetValid()) {
                string sImgKey = picInfo.GetImgKey().ToString();
                byte[] imgbyte = RedisHelper.GetInstance().GetByte(sImgKey, iImgDBIdx);
                int idx = picInfo.CID - iCamStartID;
                if (imgbyte == null) {
                    LoadImgInvoke(imgViews[idx], null); //空图像 到指定 imgView
                    isRet = false;
                    picInfo.SetValid(false);
                    lastStepItem.ProgressColors = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.White };
                    lastStepItem.Enabled = false;
                }
                else {
                    dicMarkDataId.Clear();

                    DelAllLayerDel(idx); //删除标注                   
                    LoadImgInvoke(imgViews[idx], imgbyte); //载入图像 到指定 imgView
                    //载入图片的定位 + 缺陷信息
                    List<LocFaultInfo> lsUnit = GetUnitLocInfo(sImgKey);
                    if (lsUnit != null && lsUnit.Count > 0) {

                        foreach (var unitMark in lsUnit) {

                            LoadMark(idx, unitMark);   //载入定位和缺陷标注信息
                            if (IsPlay && isAddFault && unitMark.IsFault) {  //添加到左侧缺陷列表
                                string unitName = unitMark.GetUnitName();
                                for (int ind = 0; ind < unitMark.Fault.Count; ++ind) {
                                    string FaultName = unitMark.GetFaultNameByInd(ind);
                                    // MessageBox.Show(unit.ID + " uName:" + unitName + "  " + strKey + " FName:" + FaultName);
                                    DataRow dr = dtFault.NewRow();
                                    //("Id");("POL");("uId");("unit");("fId");("Fault");("iCamId");("KMV");("sImgKey")("sJson");("FaultComfirm");
                                    dr.ItemArray = new Object[] { unitMark.ID, picInfo.POL, unitMark.UnitId, unitName, unitMark.Fault[ind], FaultName, picInfo.CID, picInfo.KMV, picInfo.GetImgKey(), unitMark.Mark, picInfo.TIM, result[0], 1 };
                                    dtFault.Rows.Add(dr);
                                }
                            }
                        }
                    }
                    isRet = true;
                }
            }
            return isRet;
        }

        #region 得到picInfo

        /// <summary>
        /// 得到图像信息
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private PicInfo GetPicInfo(string sImgKey) {
            PicInfo picInfo = RedisHelper.GetInstance().GetObj<PicInfo>(sImgKey, iImgInfoDBIdx);
            if (null != picInfo) {
                picInfo.SetImgKey(Convert.ToInt64(sImgKey));
                picInfo.SetValid(true);
            }
            return picInfo;
        }
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="picinfo">图像信息</param>
        /// <returns></returns>
        private string GetPicTip(PicInfo picinfo) {
            return "拍摄时间：" + picinfo.TIM + "  支柱号：" + picinfo.POL + "  公里标：" + picinfo.KMV + "  相机编号：" + picinfo.CID;// sImgKey.Substring(sImgKey.Length - 2);}
        }                                                                                                                                                 /// <summary>
                                                                                                                                                          /// <returns></returns>
        private List<LocFaultInfo> GetUnitLocInfo(string strKey) {
            string strJson = RedisHelper.GetInstance().GetString(strKey, iAILocFaultDbId);
            if (String.IsNullOrEmpty(strJson)) {
                return null;
            }
            List<LocFaultInfo> lsUnit = LocFaultInfo.getLstUnitPos(strJson);//JsonHelper.GetListModel<UnitPos>(strJson);
                                                                            //如果存在缺陷信息 添加到表格中
                                                                            //DataTable dtUnits = config.ConfigInfo.GetInstance().GetDtByName("InfoB");            
            return lsUnit;
        }
        #endregion

        private long GetLstLen() {
            int dbNum = sBtnItemModle.Value ? iImgListDBIdx : iAILocFaultDbId;
            return RedisHelper.GetInstance().GetLstLen("list", dbNum);
        }

        //读取图片Key
        private string GetImgKey(long imgInd) {
            int dbNum = sBtnItemModle.Value ? iImgListDBIdx : iAILocFaultDbId;
            return RedisHelper.GetInstance().getList("list", imgInd, dbNum);
        }

        #endregion

        /// <summary>
        /// 载入图像
        /// </summary>        
        private void LoadImgInvoke(CFviImageView imgView, byte[] imgByte) {
            if (imgView.InvokeRequired) {
                Action<CFviImageView, byte[]> a = LoadImgInvoke;
                imgView.Invoke(a, imgView, imgByte);
            }
            else {
                if (imgByte == null) {
                    imgView.Image = null;

                    //imgView.Image.ClearRGB(Color.Gray, 1); //没有图像用灰色填充
                }
                else {
                    imgView.Image = JpgCompress.Decompress(imgByte);
                    double mag = imgView.Height * 1.0 / imgView.Display.ImageSize.Height;
                    if (mag < 0.001) {
                        return;
                    }
                    imgView.Display.Magnification = mag;
                }
                imgView.Refresh();
            }
        }
        #region 进度条生成/选择
        StepItem lastStepItem = null;
        int viewImgCout = 0;
        /// <summary>
        /// 设置进度条
        /// </summary>
        private void SetProgress(PicInfo picinfo) {

            // System.Windows.Forms.MessageBox.Show(picinfo.POL);
            if (!sOnlineLastPole.Equals(picinfo.POL)) {
                if (progressSteps1.Items.Count > iMaxPoleCtrlNum) {
                    progressSteps1.Items.Clear();
                    progressSteps1.Width = 160;
                }

                //添加/显示进度条
                StepItem st = new StepItem(picinfo.GetImgKey().ToString(), picinfo.POL);
                //string station = FileHelper.ConvertToStr(picinfo.STN);
                // InvokeStation(station);
                st.Cursor = System.Windows.Forms.Cursors.Hand;
                st.Click += new System.EventHandler(this.StepItem_Click);
                st.Size = new Size(60, 20);
                int scrollvalue = progressSteps1.Width - panelProcess.Width;
                if (scrollvalue > 0) {
                    // MessageBox.Show(progressSteps1.HorizontalScroll.Maximum.ToString() + " "
                    //      + progressSteps1.HorizontalScroll.Maximum.ToString());
                    //  progressSteps1.HorizontalScroll.Value = progressSteps1.HorizontalScroll.Maximum;// scrollvalue;
                    panelProcess.HorizontalScroll.Value = scrollvalue;
                    panelProcess.Refresh();

                    //MessageBox.Show(progressSteps1.HorizontalScroll.Value.ToString());
                }

                if (lastStepItem != null) {
                    lastStepItem.Value = 100;
                }
                viewImgCout = 0;
                lastStepItem = st;
                MaxPicInfo = picinfo;

                lsOnlinePicInfo = new List<PicInfo>();
                sOnlineLastPole = picinfo.POL;
                st.Tag = lsOnlinePicInfo;
                progressSteps1.Items.Add(st);

                // lastStepItem.Value = (int)(viewImgCout / dxNumPerPole * 100);
            }
            int value = (int)(++viewImgCout / dxNumPerPole * 100);
            lastStepItem.Value = value > 100 ? 100 : value;
            lsOnlinePicInfo.Add(picinfo);

            // w += progressSteps1.Items[progressSteps1.Items.Count-1].Size.Width;
        }


        /// <summary>
        /// 单击支柱号进度条选择
        /// </summary>
        private void StepItem_Click(object sender, EventArgs e) {

            if (IsPlay) {
                Stop();
            }
            StepItem st = (StepItem)sender;
            iItemStepSelInd = progressSteps1.Items.IndexOf(st);
            ItemStepSel(st);

        }
        private int iDXBtnItemSelInd = -1;
        private void ItemStepSel(StepItem st) {
            if (lblItemDXTip.InvokeRequired) {
                Action<StepItem> a = ItemStepSel;
                lblItemDXTip.Invoke(a, st);
            }
            else {  
            sTabItemImg.Visible = true;
            if (lastStepItem != null) {
                lastStepItem.BackColors = st.BackColors;
                lastStepItem.TextColor = st.TextColor;
            }
            string selPOL = st.Text;//获取选择的支柱号
            st.ProgressColors = new Color[] { Color.FromArgb(89, 135, 214), Color.FromArgb(3, 56, 148) };
            st.BackColors = new Color[] { Color.Black };
            st.TextColor = Color.White;
            lastStepItem = st;
            lblItemDXTip.Text = "支柱号：" + st.Text;
            lblItemDXTip.Tag = st;

            //动态生成 吊弦提示
            int iDXidx = 0;
            itemPanelDXView.Items.Clear();

            // if (dicPoleName2PicInfo.ContainsKey(selPOL)) {
            List<PicInfo> lsPicDX = (List<PicInfo>)st.Tag;//dicPoleName2PicInfo[selPOL];
                                                          //按时间排序
            lsPicDX.Sort((a, b) => (a.TIM.CompareTo(b.TIM)));
            PicInfo[] bindPicInfo = new PicInfo[4];
            bool isAddDx = true;
            ButtonItem bt = null;
            bool hasFault = false;
            foreach (var picInfo in lsPicDX) {//获取列表
                if (picInfo.POL != st.Text) {
                    break;
                }
                if (isAddDx) {
                    bt = new ButtonItem("btnItemDX" + iDXidx, @"第" + config.ConfigInfo.strArr[iDXidx] + @"吊弦");
                    bt.FixedSize = new Size(bt.FixedSize.Width, 30);
                    bt.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                    bt.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
                    bt.Tag = bindPicInfo;
                    bt.Symbol = "";
                    bt.Click += new System.EventHandler(this.btnItemDx_Click);

                    itemPanelDXView.Items.Add(bt);
                    if (!IsOnline && !bt.Checked && picInfo.IsClick()) {
                        bt.Checked = true;
                    }
                    isAddDx = false;
                    if (hasFault) {
                        bt.ForeColor = Color.Red;
                        hasFault = false;
                    }
                }
                int iCid = picInfo.CID - iCamStartID;
                if (bindPicInfo[iCid] == null) {
                    bindPicInfo[iCid] = picInfo;
                    if (picInfo.HasFault) {
                        bt.ForeColor = Color.Red;
                        hasFault = true;
                    }
                }
                else {
                    if (iDXidx >= config.ConfigInfo.strArr.Length) {
                        continue;
                    }
                    bindPicInfo = new PicInfo[4];
                    bindPicInfo[iCid] = picInfo;
                    ++iDXidx;
                    isAddDx = true;
                    hasFault = false;
                    if (picInfo.HasFault) {
                        hasFault = true;
                    }
                }
            }
            itemPanelDXView.Refresh();
            superTabControl1.SelectedTabIndex = 1;
            rBarComfirm.Visible = false;
            if (isShowOne) {
                ShowOneImg(imgViews[0]);
            }
            //显示第一组吊弦
            ShowDXImg((ButtonItem)itemPanelDXView.Items[0]);
            iDXBtnItemSelInd = 0;
             }
        }

        /// <summary>
        /// 点击吊弦按钮，显示4副吊弦图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemDx_Click(object sender, EventArgs e) {
            ButtonItem btItem = (ButtonItem)sender;
            ShowDXImg(btItem);
            iDXBtnItemSelInd = itemPanelDXView.Items.IndexOf(btItem);
        }

        //显示一组吊弦
        private void ShowDXImgOld(ButtonItem btItem) {
            int iCount = 0;
            PicInfo[] picInfo = (PicInfo[])btItem.Tag;
            StringBuilder sb = new StringBuilder("INSERT INTO processedInfo (imgGUID,clickUser) ");
            bool isFirst = true;
            for (int i = 0; i < 4; ++i) {
                if (picInfo[i] == null) {
                    dicMarkDataId.Clear();
                    DelAllLayerDel(i); //删除标注  
                    LoadImgInvoke(imgViews[i], null); //空图像 到指定 imgView

                    lblTips[i].Text = @"未采集到图像数据";
                    continue;
                }
                else if (IsOnline && !picInfo[i].GetValid()) {
                    btItem.Text += "失效";
                    btItem.Enabled = false;
                }
                else {

                    //加载图片
                    if (IsOnline) {
                        LoadImg(picInfo[i]);
                    }
                    else {
                        LoadOffLineImg(picInfo[i]);
                    }
                    //图片提示

                    lblTips[i].Text = GetPicTip(picInfo[i]);
                    lblTips[i].Tag = picInfo[i];
                    btItem.ImageIndex = 2;
                    // Color.FromArgb(89, 135, 214);
                    btItem.Checked = true;
                    if (!IsOnline) {
                        picInfo[i].AddClickInfo(ComClassLib.core.StationInfo.User);
                        if (!picInfo[i].IsClick()) {
                            //增加点击情况
                            if (!isFirst) {
                                sb.Append(" UNION ALL ");
                            }
                            isFirst = false;
                            sb.Append(string.Format(" SELECT {0}, 'admin' ", picInfo[i].GetImgKey()));
                        }
                        ++iCount;
                    }
                }
            }
            if (!isFirst) {
                GetDB.ExecuteNonQuery(sb.ToString(), null);
            }
            if (!IsOnline) {
                //更新进度
                StepItem curSt = (StepItem)lblItemDXTip.Tag;
                curSt.Value += (int)(iCount / (((List<PicInfo>)curSt.Tag).Count * 1.0) * 100);
            }
        }

        #endregion
        #region 播放相关
        /// <summary>
        /// 自动播放图像
        /// </summary>
        private void Play() {
            if (IsPlay) {
                return;
            }

            btnItemPlay.ImageIndex = 1;
            btnItemPlay.Checked = true;
            timerPlay.Enabled = true;
            exPanelLeftInfo.Expanded = false;
            ToastNotification.Show(panelProcess, @"播放", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
            IsPlay = !IsPlay;
            sTabItemImg.Visible = false;
            lblTipB.Visible = true;
            lblThumbTip.Visible = false;
            rBarComfirm.Visible = false;
        }
        /// <summary>
        /// 暂停图像播放
        /// </summary>
        private void Stop() {
            if (IsPlay) { //表示播放中            
                btnItemPlay.ImageIndex = 0;
                btnItemPlay.Checked = false;
                timerPlay.Enabled = false;
                ToastNotification.Show(panelProcess, @"暂停", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                IsPlay = !IsPlay;
                exPanelLeftInfo.Expanded = true;
            }
        }
        /// <summary>
        /// 按钮事件--播放/停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemPlay_Click(object sender, EventArgs e) {
            if (IsPlay) {//表示播放中
                Stop();
            }
            else {
                Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            OneShow();
        }

        private void AddStepItem(StepItem st) {
            if (progressSteps1.InvokeRequired) {
                Action<StepItem> a = AddStepItem;
                progressSteps1.Invoke(a, st);
            }
            else {
                if (st == null) {
                    progressSteps1.Visible = true;
                    //progressSteps1.Width = iProcessLen  -1*(progressSteps1.Items.Count-1);
                    if (IsOnline) {
                        int scrollValue = progressSteps1.Width - panelProcess.Width;
                        progressSteps1.Refresh();
                        if (scrollValue > 0) {
                            panelProcess.VerticalScroll.Visible = false;
                            panelProcess.Refresh();
                        }
                    }
                }
                else {
                    progressSteps1.Items.Add(st);
                }
            }
        }

        private void progressSteps1_ItemAdded(object sender, EventArgs e) {
            progressSteps1.RecalcLayout();
            progressSteps1.Width += progressSteps1.Items[progressSteps1.Items.Count - 1].Size.Width - 1;
            progressSteps1.Visible = true;
            progressSteps1.Items[progressSteps1.Items.Count - 1].Focus();
        }
        private void panelProcess_ControlAdded(object sender, ControlEventArgs e) {


        }
        List<PicInfo> lsOnlinePicInfo = new List<PicInfo>();
        string sOnlineLastPole = "";
        /// <summary>
        /// 一次完整的显示
        /// </summary>
        private bool OneShow(bool isShowImg = true) {
            bool isExistImg = true;
            //不断读取imgKey值，匹配相机编号并显示到相应的imgView中 
            string sImgKey = GetImgKey(curImgId);
            if (string.IsNullOrEmpty(sImgKey)) {
                //Stop(); 不停止 继续等待
                return false;
            }
            ++curImgId;
            //图片信息
            PicInfo picinfo = GetPicInfo(sImgKey);

            if (null == picinfo) {
                isExistImg = false;
            }
            else {
                //设置进度
                SetProgress(picinfo);
                //添加到全局对应表--按照拍照时间排序

                if (isShowImg) {
                    lblTips[picinfo.CID - iCamStartID].Text = GetPicTip(picinfo);
                    lblTips[picinfo.CID - iCamStartID].Tag = picinfo;
                    //加载图片           
                    isExistImg = LoadImg(picinfo);//sImgKey.Substring(0, sImgKey.Length - 2) 
                }
                //List<PicInfo> sLst = new List<PicInfo>();

                //if (dicPoleName2PicInfo.ContainsKey(picinfo.POL)) {
                //    dicPoleName2PicInfo[picinfo.POL].Add(picinfo);
                //} else {
                //    List<PicInfo> sLst = new List<PicInfo>();
                //    sLst.Add(picinfo);
                //    dicPoleName2PicInfo.Add(picinfo.POL, sLst);
                //}
            }

            return isExistImg;

        }


        private void SetSpeedSlow_Click(object sender, EventArgs e) {

            iOffLineDataIdx -= iBulkDataByOnce;
            progressSteps1.Items.Clear();
            if (iOffLineDataIdx < 0) {
                iOffLineDataIdx = 0;
            }

            DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            new Thread(ReadOffLineData).Start();
            DialogTaskTip.GetInstance().ShowDialog();
            progressSteps1.Visible = true;
            progressSteps1.Refresh();
            //string FrameRate = timerPlay.Tag.ToString();
            //int iFrameRate = int.Parse(FrameRate);
            //if (iFrameRate == 1) {
            //    return;
            //}

            //timerPlay.Tag = (--iFrameRate);
            //timerPlay.Interval = 1000 / (iFrameRate);

            //Settings.Default.palyRate = iFrameRate;
            //Settings.Default.Save();

            //lblFrameNum.Text = iFrameRate.ToString() + "帧";
            //ToastNotification.Show(panelProcess, @"播放速度:" + timerPlay.Interval + " 毫秒 | " + lblFrameNum.Text, null, 2000, eToastGlowColor.Red, eToastPosition.TopRight);
        }
        private void SetSpeedFaster_Click(object sender, EventArgs e) {
            iOffLineDataIdx += iBulkDataByOnce;
            progressSteps1.Items.Clear();
            DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            new Thread(ReadOffLineData).Start();
            DialogTaskTip.GetInstance().ShowDialog();
            progressSteps1.Visible = true;
            progressSteps1.Refresh();
            //string FrameRate = timerPlay.Tag.ToString();
            //int iFrameRate = int.Parse(FrameRate);
            //if (iFrameRate == 50) {
            //    return;
            //}

            //timerPlay.Tag = (++iFrameRate);
            //timerPlay.Interval = 1000 / (iFrameRate);

            //Settings.Default.palyRate = iFrameRate;
            //Settings.Default.Save();
            //lblFrameNum.Text = iFrameRate.ToString() + "帧";
            //ToastNotification.Show(panelProcess, @"播放速度:" + timerPlay.Interval + " 毫秒 | " + lblFrameNum.Text, null, 2000, eToastGlowColor.Red, eToastPosition.TopRight);
        }
        #endregion

        #region 鼠标事件

        /// <summary>
        /// 滚轮事件--图像放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ImageView_MouseWheel(object sender, MouseEventArgs e) {

            if (IsPlay) {
                return;
            }

            CFviImageView ImgV = (CFviImageView)sender;
            if (e.Delta > 0) {
                ImgV.Display.Magnification = ImgV.Display.Magnification * 1.2;
            }
            else if (e.Delta < 0) {
                ImgV.Display.Magnification = ImgV.Display.Magnification * 0.8;
            }

            ImgV.Refresh();

        }
        /// <summary>
        /// 鼠标移动 -- 放大镜功能 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
            try {
                if (IsPlay) {
                    return;
                }
                CFviImageView ImgV = (CFviImageView)sender;
                if (ImgV == null) {
                    return;
                }
                if (isMark) {
                    CFviPoint p = ImgV.Display.DPtoIP(e.Location, FVIL.GDI.ScalingMode.TopLeft);
                    figure.Ed = new CFviPoint(p.X, p.Y);
                    ImgV.Refresh();
                }
                else {
                    int imgIdx = Convert.ToInt32(ImgV.Tag);
                    FigureHandlingOverlay figureOverlay = (FigureHandlingOverlay)ImgV.Display.Overlays[0];
                    if (ckBoxMagn.Checked || (figureOverlay.GetSelectedFigure(true) != null || figureOverlay.GetSelectedFigure(true) != null)) {
                        CFviPoint p = ImgV.Display.DPtoIP(e.Location, FVIL.GDI.ScalingMode.TopLeft);
                        Bitmap mainBitmap = (Bitmap)ImgV.Image;
                        int row = (int)(p.X - 150);
                        int col = (int)(p.Y - 150);
                        if (row < 0 || col < 0 || row > mainBitmap.Width || col > mainBitmap.Height) {
                            return;
                        }
                        int w = (row + 300 > mainBitmap.Width) ? mainBitmap.Width - row : 300;
                        int h = (col + 300 > mainBitmap.Height) ? mainBitmap.Height - col : 300;

                        Bitmap newImg = mainBitmap.Clone(new Rectangle(row, col, w, h), mainBitmap.PixelFormat);
                        //byte[]  = new byte[300 * 300];
                        if (ImgViewMagn.Image != null) {
                            ImgViewMagn.Image.Dispose();
                        }
                        imgPanel[imgIdx].Controls.Add(ImgViewMagn);
                        ImgViewMagn.BringToFront();
                        ImgViewMagn.Image = (CFviImage)newImg;
                        newImg.Dispose();
                        ImgViewMagn.Display.MaskEnable = true;
                        ImgViewMagn.Display.EssentialMaskEnable = true;
                        ImgViewMagn.AutoScroll = false;
                        int x = ImgV.Left + ((e.X + 330 < ImgV.Width) ? e.X + 15 : (e.X - 330));
                        int y = ImgV.Top + ((e.Y + 330 < ImgV.Height) ? e.Y + 15 : (e.Y - 330));
                        ImgViewMagn.Location = new Point(x, y);
                        ImgViewMagn.Visible = true;
                        ImgViewMagn.Refresh();
                        ImgV.Refresh();
                    }
                    else {
                        ImgViewMagn.Visible = false;
                        if (ImgViewMagn.Image != null) {
                            ImgViewMagn.Image.Dispose();
                        }
                    }
                }
            }
            catch (Exception) {

            }
        }

        /// <summary>
        /// 双击放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgView_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e) {

            if (e.Button == MouseButtons.Left) {
                ShowOneImg((CFviImageView)sender);
            }

        }


        bool isMark = false;
        CFviGdiRectangle figure = null;

        /// <summary>
        /// 右键单击-- 人工标注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (IsPlay) {
                return;
            }
            CFviImageView ImgV = (CFviImageView)sender;
            if (ImgV == null || ImgV.Image == null) {
                return;
            }
            int imgIdx = Convert.ToInt32(ImgV.Tag);
            if (e.Button == MouseButtons.Right) {//鼠标右键 - 人工标注
                CFviPoint p = ImgV.Display.DPtoIP(e.Location, FVIL.GDI.ScalingMode.TopLeft);
                figure = new CFviGdiRectangle();
                figure.Pen.Color = Color.Red;
                figure.St = new CFviPoint(p.X, p.Y);
                figure.Ed = new CFviPoint(p.X + 1, p.Y + 1);
                m_FigHandOverlay[imgIdx].Figures.Add(figure);
                isMark = true;

                //--- 添加人工标注框
                // CFviRectangle vis = ImgV.Display.VisibleRect;

                // figure.Pen.Color = Color.Red;
                // figure.St = new CFviPoint((p.X - config.ConfigInfo.GetInstance().defaultMarkW), p.Y - config.ConfigInfo.GetInstance().defaultMarkH);
                // figure.Ed = new CFviPoint(p.X + config.ConfigInfo.GetInstance().defaultMarkW, p.Y + config.ConfigInfo.GetInstance().defaultMarkH);
                //Rectangle markRect = new Rectangle(p.X, p.Y, config.ConfigInfo.GetInstance().defaultMarkW, config.ConfigInfo.GetInstance().defaultMarkH);
                // m_FigHandOverlay[imgIdx].Figures.Add(figure);
                // ImgV.Refresh();
                //--- 打开对话框
                // FrmFault frmFault=new FrmFault()
            }
        }

        private void ImgView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            //标注结束
            if (isMark) {
                isMark = false;
                CFviImageView ImgV = (CFviImageView)sender;
                if (ImgV == null || ImgV.Image == null) {
                    return;
                }
                int imgIdx = Convert.ToInt32(ImgV.Tag);
                //添加标注点判断，如果标注大小<20,20 则不判定
                if (figure.Width < 60 || figure.Height < 60) {
                    m_FigHandOverlay[imgIdx].Figures.Remove(figure);
                    ImgV.Refresh();
                    return;
                }


                //object obj = dgViewFault.CurrentRow.Cells["ColId"].Value;

                //if (obj == null) {
                //    m_FigHandOverlay[imgIdx].Figures.Remove(figure);
                //    return;
                //}
                //string sPId = obj.ToString();

                //if (string.IsNullOrEmpty(sPId)) {
                //    return;
                //}
                this.Enabled = false;
                //获取&生成对象，
                PicInfo picInfo = (PicInfo)lblTips[imgIdx].Tag;
                //人工标注的缺陷id PID= 时间+1
                FaultInfo faultInfo = new FaultInfo(DateTime.Now.ToString("yyMMddhhmmss") + "1", -1, null, picInfo.GetImgKey().ToString(), picInfo.POL, "admin", picInfo.CID, picInfo.KMV);
                FrmFault frmFault = new FrmFault(faultInfo, true);
                DialogResult dr = frmFault.ShowDialog();
                if (DialogResult.OK == dr) {
                    faultInfo.MAR = new Rectangle((int)figure.X, (int)figure.Y, (int)figure.Width, (int)figure.Height);
                    if (IsOnline) {
                        //写日志文档
                        Log.GetInstance().Write(Log.Add, faultInfo);
                        //写数据库
                        RedisHelper.GetInstance().SetString(faultInfo.PID, frmFault.faultInfo.ToJson(), iFaultDbId);
                        //添加到列表中
                        RedisHelper.GetInstance().RightLstPush("faultLst", faultInfo.PID, iFaultDbId);
                    }
                    else {
                        DateTime datetime = DateTime.Now;

                        string pId = datetime.ToString("yyyyMMddHHmmss") + "1";
                        string sFault = "[" + string.Join(",", frmFault.faultInfo.FID.ToArray()) + "]";
                        string sMark = "[" + frmFault.faultInfo.MAR.X + "," + frmFault.faultInfo.MAR.Y + "," + frmFault.faultInfo.MAR.Width + "," + frmFault.faultInfo.MAR.Height + "]";
                        //写数据库                        
                        String sInsert = String.Format("insert into faultInfo (pId,imgGUID,unitId,fault,mark,faultLevel,isAI,confirmDate,confirmUser,confirmResult,memo) " +
                            "values({0},{1},{2},'{3}','{4}','{5}',0,'{6}','admin',1,'{7}')", frmFault.faultInfo.PID, frmFault.faultInfo.MID, frmFault.faultInfo.UID, sFault, sMark, frmFault.faultInfo.LEV, datetime.ToString("s"), frmFault.faultInfo.MEM);
                        _OffLineOpe.IndDb.ExecuteNonQuery(sInsert, null);

                        //刷新
                       (new Thread( _OffLineOpe.GetFaultData)).Start();
                        //DataRow drfault = dtFault.NewRow();
                        //drfault.ItemArray = new Object[] { frmFault.faultInfo.PID, picInfo.POL, frmFault.faultInfo.UID, frmFault.faultInfo.GetUnitName(), "[" + frmFault.faultInfo.FID[0] + "]", frmFault.faultInfo.GetFaultName(), picInfo.CID, picInfo.KMV, picInfo.GetImgKey(), sMark, picInfo.TIM, result[2], 0 };
                        //dtFault.Rows.Add(drfault);
                        //dgViewFault.Refresh();

                        //dicMarkDataId[Convert.ToInt64(frmFault.faultInfo.PID)] = figure;

                    }
                }
                else {
                    m_FigHandOverlay[imgIdx].Figures.Remove(figure);
                    ImgV.Refresh();
                }
                this.Enabled = true;

            }
        }

        private void ShowOneImg(CFviImageView imgV) {
            int iRowId = 0, iColId = 0;
            if (imgV.Name == "ImgView1") {
                iRowId = 0; iColId = 0;
            }
            else if (imgV.Name == "ImgView2") {
                iRowId = 0; iColId = 1;
            }
            else if (imgV.Name == "ImgView3") {
                iRowId = 1; iColId = 0;
            }
            else if (imgV.Name == "ImgView4") {
                iRowId = 1; iColId = 1;
            }
            try {
                if (isShowOne) {
                    tbLayoutPanelRight.ColumnStyles[iColId].Width = 0.5f * tbLayoutPanelRight.Width;
                    tbLayoutPanelRight.ColumnStyles[1 - iColId].Width = 0.5f * tbLayoutPanelRight.Width;
                    tbLayoutPanelRight.RowStyles[iRowId].Height = 0.5f * tbLayoutPanelRight.Height;
                    tbLayoutPanelRight.RowStyles[1 - iRowId].Height = 0.5f * tbLayoutPanelRight.Height;
                    isShowOne = !isShowOne;
                }
                else {
                    //tbLayoutPanelRight.ColumnStyles[iColId].Width = 0.98f*tbLayoutPanelRight.Width;
                    //tbLayoutPanelRight.ColumnStyles[1 - iColId].Width = 0.02f * tbLayoutPanelRight.Width;
                    //tbLayoutPanelRight.RowStyles[iRowId].Height = 0.98f*tbLayoutPanelRight.Height;
                    //tbLayoutPanelRight.RowStyles[1 - iRowId].Height = 0.02f * tbLayoutPanelRight.Height; ;
                    tbLayoutPanelRight.ColumnStyles[iColId].Width = tbLayoutPanelRight.Width;
                    tbLayoutPanelRight.ColumnStyles[1 - iColId].Width = 0;
                    tbLayoutPanelRight.RowStyles[iRowId].Height = tbLayoutPanelRight.Height;
                    tbLayoutPanelRight.RowStyles[1 - iRowId].Height = 0;
                    isShowOne = !isShowOne;
                }
                double mag = imgV.Width * 1.0 / imgV.Display.ImageSize.Width;
                if (mag < 0.001) {
                    return;
                }
                imgV.Display.Magnification = mag;
            }
            catch (Exception) {

            }
        }

        private void DgViewFault_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

            if (dgViewFault.CurrentRow == null) {
                return;
            }
            IsPlay = false;

            SelImg();
            rBarComfirm.Visible = true;




        }

        #endregion

        #region 标注

        /// <summary>
        /// 从数据库中载入已有标注&&缺陷信息
        /// </summary>
        private void LoadMark(int iLayIdx, LocFaultInfo unitMark) {

            // foreach (LocFaultInfo unitMark in lsUnit) {
            CFviPoint p = new CFviPoint(unitMark.Mark.X, unitMark.Mark.Y);
            int w = unitMark.Mark.Width;
            int h = unitMark.Mark.Height;
            //  MessageBox.Show("x:" + p.X + "y:" + p.Y + "w:" + w + "h:" + h);
            m_FigHandOverlay[iLayIdx].Active = true;
            FVIL.Data.CFviRectangle vis = ImgView1.Display.VisibleRect;
            FVIL.GDI.CFviGdiRectangle figure = new FVIL.GDI.CFviGdiRectangle();

            figure.St = new CFviPoint(p.X, p.Y);
            figure.Ed = new CFviPoint(p.X + w, p.Y + h);

            if (unitMark.IsFault) {
                dicMarkDataId[unitMark.ID] = figure;
                figure.Pen.Color = Color.Red;
                //FVIL.GDI.CFviGdiFigure f1 = new FVIL.GDI.CFviGdiString(unitMark.GetUnitName() + " - " + unitMark.GetFaultNameByInd(0));
                FVIL.GDI.CFviGdiFigure f1 = new FVIL.GDI.CFviGdiString(unitMark.GetUnitName() + " - " + unitMark.GetFaultNameByInd(0), Color.Red, FVIL.GDI.TextAlign.Left, false);
                f1.Position = figure.St;
                m_FigHandOverlay[iLayIdx].Figures.Add(f1);
                //记录缺陷个数
                if (IsOnline) {
                    ++config.ConfigInfo.GetInstance().TotalFualt;
                }
                m_FigHandOverlay[iLayIdx].Figures.Add(figure);
                imgViews[iLayIdx].Refresh();
            }
            else if (ckBoxShowLoc.Checked) {
                figure.Pen.Color = Color.Green;

                m_FigHandOverlay[iLayIdx].Figures.Add(figure);
                imgViews[iLayIdx].Refresh();
            }
            // }
        }



        private void DelAllLayerDel(int iLayIdx) {
            m_FigHandOverlay[iLayIdx].Figures.Clear();
            imgViews[iLayIdx].Refresh();
        }
        #endregion




        #region 布局改变 
        /// <summary>
        /// 布局事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLayoutPanelRight_SizeChanged(object sender, EventArgs e) {
            lblTipA.Location = ImgView1.Location;
            lblTipB.Location = ImgView2.Location;
            lblTipC.Location = ImgView3.Location;
            lblTipD.Location = ImgView4.Location;
        }

        #endregion




        #region 缺陷判定
        private void SelImg() {
            DataGridViewRow dgdr = dgViewFault.CurrentRow;
            if (dgdr == null) {
                return;
            }
            int iCId = Convert.ToInt32(dgdr.Cells["ColCamId"].Value);
            Int64 iImgKey = Convert.ToInt64(dgdr.Cells["ColImgKey"].Value);
            Int64 Id = Convert.ToInt64(dgdr.Cells["colId"].Value);
            string poleNum = dgdr.Cells["ColPOL"].Value.ToString();

            //放大显示
            isShowOne = false;
            ShowOneImg(imgViews[iCId - iCamStartID]);

            PicInfo picinfo = null;
            //加载图片
            if (IsOnline) {
                //图片信息
                picinfo = GetPicInfo(iImgKey.ToString());
                LoadImg(picinfo, false);
                dicMarkDataId[Id / 10].Pen.Color = Color.Yellow;
            }
            else {
                picinfo = new PicInfo(iImgKey, iCId, Convert.ToInt64(dgdr.Cells["colTIM"].Value), poleNum, dgdr.Cells["ColKMValue"].Value.ToString());
                picinfo.SetImgKey(iImgKey);
                DataRow[] dr = _OffLineOpe.GetImgInfo(iImgKey);
                picinfo.iSubDbInd = Convert.ToInt32(dr[0]["SubDBId"]);
                LoadOffLineImg(picinfo);
                dicMarkDataId[Id].Pen.Color = Color.Yellow;
            }


            int iStartId = iCId - iCamStartID;


            imgViews[iStartId].Refresh();
            lblTips[iStartId].Text = GetPicTip(picinfo);
            lblTips[iStartId].Tag = picinfo;
        }
        /// <summary>
        /// 缺陷确认--插入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemYes_Click(object sender, EventArgs e) {

            ComfirmYes();
        }
        private void btnItemNo_Click(object sender, EventArgs e) {
            ComfirmNo();
        }
        private void btnItemUnknown_Click(object sender, EventArgs e) {
            ComfirmUnknown();
        }



        private void ComfirmYes() {
            object obj = dgViewFault.CurrentRow.Cells["ColId"].Value;
            if (obj == null) {
                return;
            }
            string sPId = obj.ToString();
            if (string.IsNullOrEmpty(sPId)) {
                return;
            }
            this.Enabled = false;
            //获取&生成对象，
            FaultInfo faultInfo = null;
            if (IsOnline) {
                faultInfo = RedisHelper.GetInstance().GetObj<FaultInfo>(sPId, iFaultDbId);
            }
            else {
                DataRow[] drf = dtFault.Select("Id='" + sPId + "'");
                //public FaultInfo(string pID, int uID, List<int> fID, string mID, string pOL, string nAM, int cId, string kMV) {
                string tmpStr = drf[0]["fId"].ToString();
                List<int> fId = new List<int>(); fId.Add(Convert.ToInt32(tmpStr.Substring(1, tmpStr.Length - 2)));
                faultInfo = new FaultInfo(sPId, Convert.ToInt32(drf[0]["uId"]), fId, drf[0]["ImgKey"].ToString(), drf[0]["POL"].ToString(), "admin", Convert.ToInt32(drf[0]["CamId"]), drf[0]["KMV"].ToString());

            }

            FrmFault frmFault = new FrmFault(faultInfo);
            if (DialogResult.OK == frmFault.ShowDialog()) {
                if (IsOnline) {
                    //写数据库
                    RedisHelper.GetInstance().SetString(sPId, frmFault.faultInfo.ToJson(), iFaultDbId);
                }
                else
                    if (!_OffLineOpe.UpdateFault(sPId, frmFault.faultInfo, 2)) {
                    ComClassLib.MsgBox.Error("写入缺陷信息失败！");
                }
                else {
                    DataView dv = dgViewFault.DataSource as DataView;
                    dv[dgViewFault.CurrentRow.Index]["FaultComfirm"] = "√ 确认";
                    dgViewFault.Refresh();
                    ToastNotification.Show(this, @"确认成功--[缺陷]！", null, 2000, eToastGlowColor.Orange, eToastPosition.BottomCenter);
                }
            }
            this.Enabled = true;
        }

        /// <summary>
        /// 确认误判事件
        /// </summary>
        private void ComfirmNo() {
            object obj = dgViewFault.CurrentRow.Cells["ColId"].Value;
            if (obj == null) {
                return;
            }

            string sPId = obj.ToString();
            if (string.IsNullOrEmpty(sPId)) {
                return;
            }
            //获取&生成对象，
            FaultInfo faultInfo = null;
            if (IsOnline) {
                faultInfo = RedisHelper.GetInstance().GetObj<FaultInfo>(sPId, iFaultDbId);
                faultInfo.SetNo("OnLineAdmin");
                //写入数据库
                RedisHelper.GetInstance().SetString(sPId, faultInfo.ToJson(), iFaultDbId);
            }
            else if (!_OffLineOpe.UpdateFault(sPId, null, 1)) {
                ComClassLib.MsgBox.Error("写入缺陷信息失败！");
            }
            //string sUpdate = string.Format("update FaultInfo SET confirmDate = '{0}', confirmUser = '{1}',confirmResult=0  " +
            //    " where pId={2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "admin", sPId);
            //GetDB.ExecuteNonQuery(sUpdate, null);
            else {

                DataView dv = dgViewFault.DataSource as DataView;
                dv[dgViewFault.CurrentRow.Index]["FaultComfirm"] = "X 误判";
                dgViewFault.Refresh();
                ToastNotification.Show(this, @"确认成功--[误判]！", null, 2000, eToastGlowColor.Orange, eToastPosition.BottomCenter);
            }
            this.Enabled = true;
        }

        private void ComfirmUnknown() {
            this.Enabled = false;
            object obj = dgViewFault.CurrentRow.Cells["ColId"].Value;
            if (obj == null) {
                return;
            }

            string sPId = obj.ToString();
            if (string.IsNullOrEmpty(sPId)) {
                return;
            }
            if (IsOnline) {
                //获取&生成对象，
                FaultInfo faultInfo = RedisHelper.GetInstance().GetObj<FaultInfo>(sPId, iFaultDbId);
                faultInfo.SetUnknown("admin");
                //写入数据库
                RedisHelper.GetInstance().SetString(sPId, faultInfo.ToJson(), iFaultDbId);
            }
            else if (!_OffLineOpe.UpdateFault(sPId, null, 0)) {
                ComClassLib.MsgBox.Error("写入缺陷信息失败！");
            }

            DataView dv = dgViewFault.DataSource as DataView;
            dv[dgViewFault.CurrentRow.Index]["FaultComfirm"] = "O 待定";
            dgViewFault.Refresh();
            ToastNotification.Show(this, @"缺陷确认成功！", null, 2000, eToastGlowColor.Orange, eToastPosition.BottomCenter);
            this.Enabled = true;
        }

        #endregion

        #region 缺陷表格相关


        /// <summary>
        /// 表格回车 设置误判并且到下一个缺陷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       

        private void dgViewFault_KeyDown(object sender, KeyEventArgs e) {

        }
        /// <summary>
        /// 选择下一行数据
        /// </summary>
        private void SelNextRow() {
            try {
                if (dgViewFault.CurrentCell.RowIndex != dgViewFault.Rows.Count - 1) {
                    dgViewFault.CurrentCell = dgViewFault.Rows[dgViewFault.CurrentRow.Index + 1].Cells[1];
                }
                else {
                    dgViewFault.CurrentCell = dgViewFault.Rows[0].Cells[1];
                }
                SelImg();
            }
            catch (Exception ex) {
                MessageBox.Show("选择下一行数据错误!\n" + ex.ToString());
            }

        }
        /// <summary>
        /// 选择上一行数据
        /// </summary>
        private void SelPrevRow() {
            try {
                if (dgViewFault.CurrentCell.RowIndex != 0) {
                    dgViewFault.CurrentCell = dgViewFault.Rows[dgViewFault.CurrentRow.Index - 1].Cells[1];
                }
                else {
                    dgViewFault.CurrentCell = dgViewFault.Rows[dgViewFault.Rows.Count - 1].Cells[1];
                }
                SelImg();
            }
            catch (Exception ex) {
                MessageBox.Show("选择上一行数据错误!\n" + ex.ToString());
            }

        }
        #endregion

        /// <summary>
        /// 看图模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sBtnItemModle_ValueChanged(object sender, EventArgs e) {
            //每次切换获取最新的Id
            if (IsPlay) {
                Stop();
            }
            curImgId = GetLstLen();

        }

        private void Prev() {
            iOffLineDataIdx -= iBulkDataByOnce;

            if (iOffLineDataIdx < 0) {
                iOffLineDataIdx = 0;
                btnPrev.Enabled = false;
                MessageBox.Show("已经是第一个支柱号");
                return;
            }

            progressSteps1.Items.Clear();
            progressSteps1.Width = 0;
            this.Enabled = false;
            isLastData = false;
            DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            new Thread(ReadOffLineData).Start();
            DialogTaskTip.GetInstance().ShowDialog();
            progressSteps1.Visible = true;
            progressSteps1.Refresh();
            iItemStepSelInd = 0;
            this.Enabled = true;
        }


        private void Next() {


            if (isLastData) {
                MessageBox.Show("已经是最后一个支柱号");
                btnNext.Enabled = false;
                return;
            }
            iOffLineDataIdx += iBulkDataByOnce;
            btnPrev.Enabled = true;
            progressSteps1.Items.Clear();
            progressSteps1.Width = 0;
            this.Enabled = false;
            iItemStepSelInd = 0;
            DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            new Thread(ReadOffLineData).Start();
            DialogTaskTip.GetInstance().ShowDialog();
            progressSteps1.Visible = true;
            progressSteps1.Refresh();

            this.Enabled = true;
        }



        private void itemPanelDXView_ItemClick(object sender, EventArgs e) {

        }
        //吊弦前移一组
        private void btnItemDXMoveToPrev_Click(object sender, EventArgs e) {

        }
        //吊弦后移一组
        private void btnItemDXMoveToNext_Click(object sender, EventArgs e) {

        }


        //下拉列表过滤状态
        private void cb_FilterState_SelectedIndexChanged(object sender, EventArgs e) {
            DataView dv = new DataView(dtFault);
            switch (cb_FilterState.SelectedIndex) {
                case 0://全部
                    dv = dtFault.DefaultView;
                    break;
                case 1://智能缺陷
                    dv.RowFilter = "isAI=1";
                    break;
                case 2://人工缺陷
                    dv.RowFilter = "isAI=0";
                    break;
                case 3: //待审核
                    dv.RowFilter = "iState=2 or iState=6";
                    break;
                case 4://已审核(签收\作废\改签)
                    dv.RowFilter = "iState>2 and iState<>6";
                    break;
                case 5://保管
                    dv.RowFilter = "保存编号 is not null";
                    break;

            }
            dgViewFault.DataSource = dv;

            // lblSum.Text = @"共 " + dv.Count + @" 条";
        }
        #region ============ 类似EXCEL的过滤功能模块============
        private string sFilterName;//过滤的字段名称
        private int colIndex;
        private Dictionary<string, HashSet<string>> dFilter = new Dictionary<string, HashSet<string>>();//存储过滤条件 
        private HashSet<string> arrSingleFilterValue;
        //datagridview事件-单击表头添加筛选条件
        private void dgViewFault_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (dgViewFault.DataSource == null) {
                return;
            }

            int dLeft, dTop;
            //获取dgv列标题位置相对坐标  
            Rectangle range = dgViewFault.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            //计算pl_dgv_extend位置坐标  
            dLeft = range.Left + dgViewFault.Left+5;
            dTop = range.Top + dgViewFault.Top + range.Height+exPanelLeftInfo.Top+ superTabControlPanel1.Top+20;
            //设置pl_dgv_extend位置，超出框体宽度时，和dgv右边对齐  
            if (dLeft + panel_dgvFilter.Width > this.Width) {
                panel_dgvFilter.SetBounds(dgViewFault.Width - panel_dgvFilter.Width, dTop, panel_dgvFilter.Width, panel_dgvFilter.Height);
            }
            else {
                panel_dgvFilter.SetBounds(dLeft, dTop, panel_dgvFilter.Width, panel_dgvFilter.Height);
            }
            //设置cb_condition下拉菜单内容 
            //加载现有选项 
            colIndex = e.ColumnIndex;
            sFilterName = dgViewFault.Columns[e.ColumnIndex].DataPropertyName;
            bool isFilter = dFilter.TryGetValue(sFilterName, out arrSingleFilterValue);//是否已经存在过滤条件
            btnFilterClear.Enabled = isFilter;
            lstB_condition.Items.Clear();
            //对字段去重
            DataView dv = new DataView((dgViewFault.DataSource as DataView).ToTable());

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
            DialogFilter dialogFilter = new DialogFilter(sFilterName, lstB_condition, sFilterName.Contains("日期"));
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
            }
            else {
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
        private void btnCancel_Click(object sender, EventArgs e) {
            panel_dgvFilter.Visible = false;
        }
        //清除筛选
        private void btnFilterClear_Click(object sender, EventArgs e) {
            dFilter.Remove(sFilterName);
            dgViewFault.Columns[colIndex].HeaderCell.Style.ForeColor = Color.White;
            FilterDatatable();
        }
        //过滤调用
        private void FilterDatatable() {
            dgViewFault.AutoGenerateColumns = false;
            if (dFilter.Count == 0) {
                dgViewFault.DataSource = dtFault.DefaultView;
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
                        }
                        else {
                            sFilter.Append(string.Format(" = '{0}'", s));
                        }
                    }
                }
                else {
                    sFilter.Append(" IN (");
                    foreach (string s in keyValuePair.Value) {
                        if (s == "(空白)") {
                            sTmpNull = keyValuePair.Key + " is null  or ";
                        }
                        else {
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
                dgViewFault.DataSource = dtFault.DefaultView;
                dgViewFault.Columns[colIndex].HeaderCell.Style.ForeColor = Color.White;
                cb_FilterState.Text = "";
                // lblSum.Text = @"共 " + dtFault.Rows.Count + @" 条";
            }
            else {
                DataView dv = new DataView(dtFault);
                dv.RowFilter = sTmpNull + sFilter;
                dgViewFault.DataSource = dv;
                dgViewFault.Columns[colIndex].HeaderCell.Style.ForeColor = Color.Red;
                cb_FilterState.Text = "自定义筛选";
                // lblSum.Text = @"共 " + dv.Count + @" 条";
            }

            panel_dgvFilter.Visible = false;

        }
        //升序排列
        private void btn_Asc_Click(object sender, EventArgs e) {
            DataView dv = new DataView(((DataView)dgViewFault.DataSource).ToTable());
            dv.Sort = sFilterName + " asc";
            dgViewFault.DataSource = dv;
            panel_dgvFilter.Visible = false;
        }
        //降序排列
        private void btn_desc_Click(object sender, EventArgs e) {
            DataView dv = new DataView(((DataView)dgViewFault.DataSource).ToTable());
            dv.Sort = sFilterName + " desc";
            dgViewFault.DataSource = dv;
            panel_dgvFilter.Visible = false;
        }

        private void FrmOnline_FormClosed(object sender, FormClosedEventArgs e) {
            _FrmOnlinet = null;
        }

        private void stepItem1_Click(object sender, EventArgs e) {

        }


        #endregion

        #region 全局键盘事件
        /// <summary>
        /// 全局键盘事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            #region PageDown
            if (exPanelLeftInfo.Expanded) {
                dgViewFault.Focus();
                if (keyData == Keys.Up) {
                    SelPrevRow();
                }
                else if (keyData == Keys.Down) {
                    SelNextRow();
                }
                else if (keyData == Keys.Enter) {
                    ComfirmNo();
                    SelImg();
                }
                else if (keyData == Keys.Space) {
                    ComfirmYes();
                    SelImg();
                }
            }
            //Ctrl+G 跳转到指定支柱号
            if (keyData == (Keys.Control | Keys.G)) {
                GoPoleNum();
                return false;
            }
            if (keyData == Keys.A) {
                if (iItemStepSelInd == 0) {
                    return false;
                }

                StepItem st = (StepItem)progressSteps1.Items[--iItemStepSelInd];
                ItemStepSel(st);
            }
            else if (keyData == Keys.D) {

                if (iItemStepSelInd >= progressSteps1.Items.Count - 1) {
                    return false;
                }

                StepItem st = (StepItem)progressSteps1.Items[++iItemStepSelInd];
                ItemStepSel(st);
                //更新滚动条
                int iPos = 100;
                for (int i = 0; i < iItemStepSelInd; ++i) {
                    iPos += ((StepItem)progressSteps1.Items[i]).Size.Width;
                }
                int scrollvalue = iPos - panelProcess.Width;
                if (scrollvalue > 0) {
                    panelProcess.HorizontalScroll.Value = scrollvalue;
                    panelProcess.Refresh();
                }


            }
            else if (keyData == Keys.W) {
                if (!sTabItemImg.Visible || iDXBtnItemSelInd <= 0) {
                    return false;
                }
                ButtonItem btnItem = (ButtonItem)itemPanelDXView.Items[--iDXBtnItemSelInd];
                ShowDXImg(btnItem);
            }
            else if (keyData == Keys.S) {
                if (!sTabItemImg.Visible || iDXBtnItemSelInd > itemPanelDXView.Items.Count - 2) {
                    return false;
                }
                ButtonItem btnItem = (ButtonItem)itemPanelDXView.Items[++iDXBtnItemSelInd];
                ShowDXImg(btnItem);
            }
            else if (keyData == Keys.Left) {
                NewPrev();
            }
            else if (keyData == Keys.Right) {
                NewNext();
            }

            #endregion
            return true;
        }


        #endregion

        #region 新修改 离线代码

        /// <summary>
        /// 上一页
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e) {
            NewPrev();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e) {
            NewNext();
        }
        /// <summary>
        /// 载入支柱号后 按钮状态
        /// </summary>
        private void BtnEnable() {
            if (btnNext.InvokeRequired) {
                Action a = BtnEnable;
                btnNext.Invoke(a);
            }
            else {
                if (_selPoleInd >= _drs.Length) {
                    btnNext.Enabled = false;
                    btnPrev.Enabled = true;
                    TxtShow(lblEndPole, "结束支柱号：" + _drs[_drs.Length - 1]["poleNum"].ToString());
                    return;
                }
                else if (_stSelPoleInd.Count == 0) { //第一个支柱号
                    btnPrev.Enabled = false;
                    btnNext.Enabled = true;
                }
                else {
                    btnNext.Enabled = true;
                    btnPrev.Enabled = true;
                }
                TxtShow(lblEndPole, "结束支柱号：" + _drs[_selPoleInd]["poleNum"].ToString());
            }
        }
        /// <summary>
        /// 站区选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStationInfo_SelectedIndexChanged(object sender, EventArgs e) {
            sSTN = cbStationInfo.Text;
            //iOffLineDataIdx = 0;
            //DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            //new Thread(ReadOffLineData).Start();
            //DialogTaskTip.GetInstance().ShowDialog();
            progressSteps1.Items.Clear();
            progressSteps1.Width = 0;
            _stSelPoleInd.Clear();
            _selPoleInd = 0;
            _stSelPoleInd.Push(_selPoleInd);
            _drs = _OffLineOpe.GetPoleName(sSTN);
            AddSItem();
            btnPrev.Enabled = false;

        }
        private DataRow[] _drs;
        private int _selPoleInd;//选择下标
        //记录下一页的序号，用于上一页
        private Stack<int> _stSelPoleInd = new Stack<int>();
        private void AddSItem() {
            //dicPoleName2PicInfo.Clear();

            string sOldPoleNum = "";
            List<PicInfo> lstPicInfo = new List<PicInfo>();

            //统计点击情况
            int iClickedNum = 0;
            //---遍历离线数据
            bool isConfirmDefault = false;
            int iNum = 0;
            TxtShow(lblStartPole, "起始支柱号：" + _drs[_selPoleInd]["poleNum"].ToString());
            StepItem firstSt = null;
            while (_selPoleInd < _drs.Length) {
                DataRow row = _drs[_selPoleInd++];
                Int64 imgId = Convert.ToInt64(row["imgGUID"]);
                PicInfo picInfo = new PicInfo(imgId, Convert.ToInt32(row["cId"]), Convert.ToInt64(row["shootTime"]), row["poleNum"].ToString(), row["KMValue"].ToString(), Convert.ToInt32(row["SubDBId"]));
                if (picInfo.IsClick()) {
                    ++iClickedNum;
                }

                if (dtOffLineFault != null) {
                    DataRow[] drTmp = dtOffLineFault.Select("imgGUID=" + imgId);
                    if (drTmp.Length > 0 && 1 == Convert.ToInt32(drTmp[0]["confirmResult"])) {
                        isConfirmDefault = true;
                        picInfo.HasFault = true;
                    }
                }

                //修改为 不用 字典方式添加 poleNum
                if (!sOldPoleNum.Equals(picInfo.POL)) {
                    if (progressSteps1.Width + 100 > panelProcess.Width) {
                        //--_selPoleInd;
                        _selPoleInd -= 2;
                        break;
                    }
                    //添加/显示进度条
                    StepItem st = new StepItem(picInfo.GetImgKey().ToString(), picInfo.POL);
                    st.Cursor = System.Windows.Forms.Cursors.Hand;
                    st.Click += new System.EventHandler(this.StepItem_Click);
                    st.RecalcSize();
                    if (firstSt == null) firstSt = st; //记录第一个StepItem
                    AddStepItem(st);
                    if (lastStepItem != null) {
                        lastStepItem.Value = (int)(++iClickedNum / (lstPicInfo.Count * 1.0) * 100);
                        if (isConfirmDefault) {//包含缺陷--文字颜色为红色
                            lastStepItem.TextColor = Color.Red;
                        }
                    }

                    lastStepItem = st;
                    MaxPicInfo = picInfo;

                    lstPicInfo = new List<PicInfo>();
                    sOldPoleNum = picInfo.POL;
                    st.Tag = lstPicInfo;
                    iClickedNum = 0;
                    isConfirmDefault = false;
                    ++iNum;
                }
                lstPicInfo.Add(picInfo);

            }

            BtnEnable();
            //加载第一杆的4副图片
            
            ItemStepSel(firstSt);
            DialogTaskTip.GetInstance().EndProc();

        }

        #region 支柱号跳转
        bool pageNextState = false;//
        private void NewPrev() {
            if (_stSelPoleInd.Count == 0) {
                return;
            }
            if (pageNextState) {
                _selPoleInd = _stSelPoleInd.Pop();
            }
            _selPoleInd = _stSelPoleInd.Pop();
            btnNext.Enabled = true;
            LoadPole();
            pageNextState = false;
        }
        private void NewNext() {
            pageNextState = true;
            btnPrev.Enabled = true;
            _stSelPoleInd.Push(_selPoleInd);
            LoadPole();
            
        }

        private void LoadPole() {
            progressSteps1.Items.Clear();
            progressSteps1.Width = 0;
            this.Enabled = false;
            
            DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            new Thread(AddSItem).Start();
            DialogTaskTip.GetInstance().ShowDialog();
            progressSteps1.Visible = true;
            progressSteps1.Refresh();
            this.Enabled = true;
        }
        private void GoPoleNum() {
            if (_drs == null)
                return;
            bool isFind = false;
            FrmGoPoleNum frmPole = new FrmGoPoleNum(lblStartPole.Text, lblEndPole.Text);
            if (DialogResult.OK == frmPole.ShowDialog()) {
                int ind = 0;
                for (; ind < _drs.Length; ind++) {
                    if (_drs[ind]["poleNum"].ToString().Equals(frmPole.rtnStr)) {
                        _stSelPoleInd.Push(_selPoleInd); //跳转前先保存下原来的位置
                        _selPoleInd = ind;
                        LoadPole();
                        isFind = true;

                        break;
                    }
                }
                if (!isFind) {
                    ComClassLib.MsgBox.Show("该站/站区间没有查询的支柱号，请确认!");
                }
            }

        }

        private void btnGoPoleNum_Click(object sender, EventArgs e) {
            GoPoleNum();
        }
        #endregion

        private void TxtShow(Control t, string str) {
            if (t.InvokeRequired) {
                Action<Control, string> a = TxtShow;
                t.Invoke(a, t, str);
            }
            else {
                if (t is LabelX) {
                    ((LabelX)t).Text = str;
                }
            }
        }
        #endregion
        /// <summary>
        /// 显示一组吊弦
        /// </summary>
        /// <param name="btItem"></param>
        private void ShowDXImg(ButtonItem btItem) {
            int iCount = 0;
            PicInfo[] picInfo = (PicInfo[])btItem.Tag;
            StringBuilder sb = new StringBuilder("INSERT INTO processedInfo (imgGUID,clickUser) ");
            bool isFirst = true;
            for (int i = 0; i < 4; ++i) {
                if (picInfo[i] == null) {
                    dicMarkDataId.Clear();
                    DelAllLayerDel(i); //删除标注  
                    LoadImgInvoke(imgViews[i], null); //空图像 到指定 imgView

                    lblTips[i].Text = @"未采集到图像数据";
                    continue;
                }
                else if (IsOnline && !picInfo[i].GetValid()) {
                    btItem.Text += "失效";
                    btItem.Enabled = false;
                }
                else {

                    //加载图片
                    if (IsOnline) {
                        LoadImg(picInfo[i]);
                    }
                    else {
                        LoadOffLineImg(picInfo[i]);
                    }
                    //图片提示

                    lblTips[i].Text = GetPicTip(picInfo[i]);
                    lblTips[i].Tag = picInfo[i];
                    btItem.ImageIndex = 2;
                    // Color.FromArgb(89, 135, 214);
                    btItem.Checked = true;
                    if (!IsOnline) {
                        picInfo[i].AddClickInfo();
                        if (!picInfo[i].IsClick()) {
                            //增加点击情况
                            if (!isFirst) {
                                sb.Append(" UNION ALL ");
                            }
                            isFirst = false;
                            sb.Append(string.Format(" SELECT {0}, 'admin' ", picInfo[i].GetImgKey()));
                        }
                        ++iCount;
                    }
                }
            }
            if (!isFirst) {
                GetDB.ExecuteNonQuery(sb.ToString(), null);
            }
            if (!IsOnline) {
                //更新进度
                StepItem curSt = (StepItem)lblItemDXTip.Tag;
                curSt.Value += (int)(iCount / (((List<PicInfo>)curSt.Tag).Count * 1.0) * 100);
            }
        }

        private void ShowFaultData() {
        }
    }
}
