using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComClassLib;
using ComClassLib.core;
using ComClassLib.DB;
using ComClassLib.FileOp;
using Project4C.UI;

namespace Project4C.Core {
    public class OffLineOp {

        #region 静态方法


        #endregion




        private DataTable _dtOffLineDataInfo;     //离线图像信息数据
        private DataTable _dtOffLineFault; //离线缺陷数据
        private DataTable _dtAllPoleNum;
        private StationInfo _station;

        public SqliteHelper IndDb => SqliteHelper.GetSqlite(DbName.IndexDb.ToString());

        public StationInfo Station { get => _station; }

        private SqliteHelper[] CurDb;
        private string _LineName;



        public Action<DataTable> RtnStationInfo; //返回站区信息
        public Action<DataTable> RtnFaultInfo; //返回站区信息
        /// <summary>
        /// 打开文件夹路径，读取后缀为 .ind的文件，多个就给出提示
        /// </summary>
        /// <param name="dbDir"></param>
        public OffLineOp(string dbDir) {

            _dtOffLineDataInfo = null;
            _dtOffLineFault = null;
            _dtAllPoleNum = null;
            DirectoryInfo fdir = new DirectoryInfo(dbDir);
            FileInfo[] file = fdir.GetFiles("*.ind");//获取索引数据文件
            if (file.Length == 0)
                return;
            //创建索引数据库对象
            SqliteHelper indDB= SqliteHelper.GenerateSqlite(DbName.IndexDb.ToString(), file[0].FullName);
            //创建点击信息表
            DBM.CreateClickInfoTB(indDB);
            //载入所有分库数据库对象
            FileInfo[] subFile = fdir.GetFiles("*.s*");
            CurDb = new SqliteHelper[subFile.Length];
            for (int i = 0; i < subFile.Length; i++) {
                CurDb[i] = SqliteHelper.GenerateSqlite(DbName.CurrDb.ToString() + subFile[i].Extension, subFile[i].FullName);
            }

            //读取 station 信息
            _station = StationInfo.FromDb();

        }
        public SqliteHelper GetSubDB(string ind) {
            return SqliteHelper.GetSqlite(DbName.CurrDb.ToString() + ".s" + ind);
        }

        public byte[] GetImg(string sSubDbId, string sImgKey) {
            String strSQL = "select imgContent from imgInfo where imgGUID=" + sImgKey;
            byte[] imgByte = (byte[])GetSubDB(sSubDbId).ExecuteDataRow(strSQL, null)["imgContent"];
            return imgByte;
        }
        //数据初始化
        public void IniData() {
            DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            new Thread(ReadOffLineData).Start();
            DialogTaskTip.GetInstance().ShowDialog();

        }
        /// <summary>
        /// 读取所有的离线图像数据
        /// </summary>
        private void ReadOffLineData() {
            try {
                //读取所有图像信息数据
                _dtOffLineDataInfo = IndDb.ExecuteDataTable("select * from picInfoInd order by shootTime", null);
                //开启线程
                new Thread(GetStationInfoFromMem).Start(); //读取站区信息
                GetFaultData();
                DialogTaskTip.GetInstance().EndProc();
            }
            catch (Exception ex) {
                MsgBox.Error(ex.ToString());
            }
        }
        public void GetFaultData() {
            //读取所有异常数据
            _dtOffLineFault = IndDb.ExecuteDataTable("select * from FaultInfo ", null);
            RtnFaultInfo?.Invoke(_dtOffLineFault);
        }

        #region 获取站区信息
        //获取站区信息 -- 基于数据库查询
        private void GetStationInfoFromDB() {
            String sSqlA = "select distinct(STN) from picInfoInd";
            DataTable dt = IndDb.ExecuteDataTable(sSqlA, null);
            RtnStationInfo?.Invoke(dt);
        }
        //获取站区信息 -- 基于内存中的所有离线图像信息数据
        private void GetStationInfoFromMem() {
            if (_dtOffLineDataInfo == null) return;
            DataTable dt = _dtOffLineDataInfo.DefaultView.ToTable(true, "STN");
            RtnStationInfo?.Invoke(dt);
        }
        #endregion

        /// <summary>
        /// 获取指定站区的支柱号
        /// </summary>
        /// <param name="stn"></param>
        /// <returns></returns>
        public DataRow[] GetPoleName(string station) {
            return _dtOffLineDataInfo.Select($"STN='{station}'");
        }

        //读取图像
        public DataRow[] GetFault(Int64 iImgGUi) {
            DataRow[] drs = _dtOffLineFault.Select("imgGUID=" + iImgGUi);
            return drs;
        }
        public DataRow[] GetImgInfo(Int64 iImgGUi) {
            DataRow[] drs = _dtOffLineDataInfo.Select("imgGUID=" + iImgGUi);
            return drs;
        }

        /// <summary>
        /// 更新缺陷信息
        /// </summary>
        /// <param name="sPId"></param>
        /// <param name="fault"></param>
        /// <param name="state">0 未知，1-误判 ；2-确认</param>
        /// <returns></returns>
        public bool UpdateFault(string sPId, FaultInfo fault, int state) {
            string sUpdate = "";
            if (state == 0) {
                sUpdate = string.Format("update FaultInfo SET   confirmDate =null, confirmUser = '',confirmResult=-1  " +
                   " where pId={0}", sPId);
            }
            else if (state == 1) {
                sUpdate = string.Format("update FaultInfo SET confirmDate = '{0}', confirmUser = '{1}',confirmResult=0  " +
                    " where pId={2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), StationInfo.User, sPId);
            }
            else if (state == 2) {
                string sFault = "[" + string.Join(",", fault.FID.ToArray()) + "]";
                sUpdate = string.Format("update FaultInfo SET unitId={0}, fault='{1}',faultLevel = '{2}', confirmDate = '{3}', confirmUser = '{4}',confirmResult=1,memo='{5}' " +
                  " where pId={6}", fault.UID, sFault, fault.LEV, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), fault.NAM, fault.MEM, fault.PID);

            }

            int affterRow = IndDb.ExecuteNonQuery(sUpdate, null);
            return affterRow > 0;
        }

        public int GetTotalImgNum() {
            int iImgCount = Convert.ToInt32(IndDb.ExecuteScalar("select count(*) from picInfoInd"));
            return iImgCount;
        }
    }
}
