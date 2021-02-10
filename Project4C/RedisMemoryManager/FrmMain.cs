using ComClassLib.core;
using ComClassLib.DB;
using DevComponents.DotNetBar;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RedisMemoryManager {
    public partial class FrmMain : Form {
        #region 属性
        private double totalPys;//总内存
        private RedisHelper imgDB;
        private RedisHelper imgInfoDB;
        private RedisHelper locDB;
        //图像二进制存储数据库Id//图像信息数据库Id//智能识别缺陷数据库Id.
        private const int m_sImgDbId = 10, m_sInfoDbIdx = 11, m_sAIFaultDbId = 12;
        private long _iImgInd, _iLocInd, _iFaultInd, _iDelImgIdx;//当前图像id，当前定位id,当前缺陷id，当前删除图像id
        private  int m_iDelDataByOnce;                   //一次删除的图像数据
        private int m_iMemLimit;
        private bool isRun;
        #endregion
        public FrmMain() {
            InitializeComponent();
            ShowInfo("准备运行。。。");
            IniRedis();
            _iImgInd = _iLocInd = _iFaultInd = _iDelImgIdx = 0;
            totalPys = IOUtils.GetTotalPhys(); //获取总内存信息      
            ShowMemoryInfo();
            GetCameraImgInfo();
            isRun = true;
            
            
            
            RedisDataDel();
          
        }

        private void ShowMemoryInfo() {
            Task task = new Task(() =>
            {
                while (true) {
                    //获取总内存信息
                    LblInfoShow(lblMemory, $"{IOUtils.FormatSize(IOUtils.GetUsedPhys())}/{IOUtils.FormatSize(totalPys)}");
                    LblInfoShow(lblReidsMemory, $"{IOUtils.FormatSize(RedisHelper.GetUsedMem())}");
                    Thread.Sleep(1000);
                }
            });
            task.Start();
        }
        //获取相机图像数量
        private void GetCameraImgInfo() {
            Task task = new Task(() =>
            {
                while (true) {
                    LblInfoShow(lblCameraA, imgInfoDB.StringGet("CameraID1"));
                    LblInfoShow(lblCameraB, imgInfoDB.StringGet("CameraID2"));
                    LblInfoShow(lblCameraC, imgInfoDB.StringGet("CameraID3"));
                    Thread.Sleep(500);
                }
            });
            task.Start();
       

        }
        private void LblInfoShow(Label lblCtrl, string msg) {
            if (lblMemory.InvokeRequired) {
                Action<Label, string> a = LblInfoShow;
                lblMemory.Invoke(a, lblCtrl, msg);
            } else {
                lblCtrl.Text = msg;
            }
        }

        private void btnDelNumByOnce_Click(object sender, EventArgs e) {
            m_iDelDataByOnce  = iInputDelImgNum.Value;
            ToastNotification.Show(this, $"一次性批量删除图像-{m_iDelDataByOnce} 张，设置成功！", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
        }
        #region #Redis 操作
        private void IniRedis() {
            imgDB = new RedisHelper(m_sImgDbId);                     //图像数据库ID
            imgInfoDB = new RedisHelper(m_sInfoDbIdx);               //图像信息数据库ID
            locDB = new RedisHelper(m_sAIFaultDbId);                 //定位数据库ID  
            m_iMemLimit = iInputMaxMemory.Value;
            m_iDelDataByOnce = 100;
        }

        private void btnSetMemLimit_Click(object sender, System.EventArgs e) {
            m_iMemLimit = iInputMaxMemory.Value;
            ToastNotification.Show(this, $"内存限制设置成功：{m_iMemLimit}MB", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
        }

        private void RedisDataDel() {
           
            Task task = new Task(
                () =>
                {
                    Thread.Sleep(20000);
                    ShowInfo("Redis内存监听中。。。。。。");
                    while (isRun) {
                        double usedMEM = RedisHelper.GetUsedMem();// Console.WriteLine($"#================ 已经使用内存:{usedMEM}M ================#");
                        if (usedMEM > m_iMemLimit) {
                            RemoveMEM();
                        }                    //Console.WriteLine($"#================ 已经使用内存(删除数据后）:{RedisHelper.GetUsedMem()}M ================#");
                    }
                });
            task.Start();
            
        }


        /// <summary>
        /// 清除内存
        /// </summary>
        public void RemoveMEM() {
            ShowInfo($"超过内存限制({m_iMemLimit} M)，开始清除内存 .....");
            //====== 清除内存，注意没有持久化的数据不能删除 ======/
            long iEndDelIdx = _iDelImgIdx + m_iDelDataByOnce;
            //if (iEndDelIdx > _iImgInd) {//删除的图像结束为止> 持久化的图像
            //    iEndDelIdx = _iImgInd;
            // }
            //if (iEndDelIdx > _iDelImgIdx) {
            try {
                string[] keys = imgInfoDB.ListRange("list", _iDelImgIdx, iEndDelIdx);
                if (keys == null || keys.Length == 0) {
                    Console.WriteLine($"#--- 无数据删除，等待数据持久化...");
                    return;
                }
                _iDelImgIdx = iEndDelIdx;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                imgInfoDB.ListSetValueInHead("list", _iDelImgIdx);
                for (int i = 0; i < keys.Length; i++) {
                    imgDB.KeyDelete(keys[i]);
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                ShowInfo($"删除图像数量:{_iDelImgIdx}，用时：{sw.ElapsedMilliseconds}ms");

            } catch (Exception e) {
                ShowInfo($"=====内存清除失败\t原因:{e.ToString()}=====");

            }
            //}
        }
        private void ShowInfo(string sMsg) {
            if (rTxtBoxInfo.InvokeRequired) {
                Action<string> a = ShowInfo;
                rTxtBoxInfo.Invoke(a, sMsg);
            } else {
                try {
                    if (rTxtBoxInfo.Lines.Length > 50) {
                        rTxtBoxInfo.Clear();
                    }
                    string sTip = $"# {DateTime.Now.ToString()} : {sMsg}";
                    rTxtBoxInfo.AppendText(sTip + "\n");
                    rTxtBoxInfo.ScrollToCaret();
                } catch { }

            }
        }
        #endregion
    }
}
