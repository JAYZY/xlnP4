using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckSys.core {
    class PicInfo {
        private string sPol;
        //拍摄时间
        public Int64 TIM { get; set; }
        //公里标
        public string KMV { get; set; }
        //相机编号
        public int CID { get; set; }
        //支柱号
        public string POL {
            get {
                return sPol;
            }
            set { sPol = value.Substring(value.IndexOf(':') + 1); }

        }
        //站区编号
        public int STA { get; set; }
        //GPS
        public string GPS { get; set; }
        private string sStationName;
        //站区间
        public string STN {
            get { return sStationName; }
            set {
                if (String.IsNullOrEmpty(value)) {
                    sStationName = "";
                }
                sStationName = value;
            }// FileOp.FileHelper.ConvertToStr(value); }

        }
        public string STNUTF {
            get; set;
        }
        public PicInfo(Int64 iImgKey, int cID, long tIM, string pOL, string kMV) {
            this.iImgKey = iImgKey;
            CID = cID;
            TIM = tIM;
            KMV = kMV;
            POL = pOL;
        }


        ////拍摄时间
        //public Int64 TIM { get; set; }
        ////公里标
        //public string KMV { get; set; }
        ////相机编号
        //public int CID { get; set; }
        ////支柱号
        //public string POL { get; set; }
        ////站区编号
        //public int STA { get; set; }
        ////GPS
        //public string GPS { get; set; }

        private Int64 iImgKey;
        public void SetImgKey(Int64 _iImgKey) { iImgKey = _iImgKey; }
        public Int64 GetImgKey() { return iImgKey; }

        private bool isValid;
        public void SetValid(bool _isValid) { isValid = _isValid; }
        public bool GetValid() { return isValid; }

        //离线使用
        private byte[] img;
        public void SetImg(byte[] _img) { this.img = _img; }
        //public byte[] Getimg(bool isReadDb = false) {
        //    if (isReadDb && this.img == null) {
        //        string strSQL = "select imgContent from picInfo where imgGUID=" + this.iImgKey;
        //        this.img = (byte[])SqliteHelper.GetSqlite(Settings.Default.MDB).ExecuteDataRow(strSQL, null)["imgContent"];
        //    }
        //    return this.img;
        //}
        public bool HasFault { get; set; }
       // private bool isClicked = false;
        //检查该图像是否被点击过
        //public bool IsClick() {
        //    if (isClicked) {
        //        return true;
        //    }
        //    string sSQL = "select * from processedInfo where imgGUID=" + this.iImgKey;
        //    return null != SqliteHelper.GetSqlite(Settings.Default.MDB).ExecuteScalar(sSQL);
        //}

        

    }
}
