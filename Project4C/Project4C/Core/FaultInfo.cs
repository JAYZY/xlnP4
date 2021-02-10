using Newtonsoft.Json;
using Project4C.FileOp;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Project4C.Core {
    public class FaultInfo {
        public FaultInfo(string pID, int uID, List<int> fID, string mID, string pOL, string nAM, int cId, string kMV) {
            PID = pID;
            UID = uID;
            FID = fID;
            MID = mID;
            POL = pOL;
            LEV = "";
            YES = -1;
            TIM = "";
            NAM = nAM;
            CID = cId;
            KMV = kMV;
            MEM = "";
        }
        //全局缺陷id
        public string PID { get; set; }
        //缺陷标注ID
        public List<int> FID { get; set; }
        //mark 标注
        public Rectangle MAR { get; set; } 
        //部件ID
        public int UID { get; set; }
        //图像全局ID
        public string MID { get; set; }
        //支柱号
        public string POL { get; set; }
        //缺陷等级
        public string LEV { get; set; }
        //确定  0 未知 -1 不是  1 是
        public int YES { get; set; }
        //确定时间
        public string TIM { get; set; }
        //确定人员
        public string NAM { get; set; }
        //相机编号
        public int CID { get; set; }

        //公里标
        public string KMV { get; set; }
        //备注
        public string MEM { get; set; }

        public void SetNo(string sUser) {
            YES =0;
            TIM = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            NAM = sUser;            
            //写日志文档
            Log.GetInstance().Write(Log.Update, this);
        }
        public void SetYes(string sUser) {
            YES = 1;
            TIM = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            NAM = sUser;
            //写日志文档
            Log.GetInstance().Write(Log.Update, this);
        }
        public void SetUnknown(string sUser) {
            YES = -1;
            TIM = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            NAM = sUser;
            //写日志文档
            Log.GetInstance().Write(Log.Update, this);
        }
        public string GetUnitName() {
            if (this.UID == -1)
                return "";
            return LocFaultInfo.GetUName(this.UID);

        }
        public string GetFaultName() {
            if (this.FID == null) return "";
            return LocFaultInfo.GetFName(this.FID[0]);

        }
        public string ToJson() {
            return JsonConvert.SerializeObject(this);
        }


    }
}
