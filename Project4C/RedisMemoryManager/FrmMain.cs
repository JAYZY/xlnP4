using ComClassLib.core;
using ComClassLib.DB;
using DevComponents.DotNetBar;
using RedisMemoryManager.Properties;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RedisMemoryManager {
    public partial class FrmMain : Form {
        #region 属性
        private double totalPys;//总内存
        private RedisHelper imgDB, imgInfoDB, locDB;
        //图像二进制存储数据库Id//图像信息数据库Id//智能识别缺陷数据库Id.
        private const int ImgDbId = 10, InfoDbIdx = 11, AIFaultDbId = 12;
        private long iImgInd, iLocInd, iFaultInd, iDelImgIdx;//当前图像id，当前定位id,当前缺陷id，当前删除图像id
        private int iDelDataByOnce;                   //一次删除的图像数据
        private long iMemLimit;
        private bool isRun;
        #endregion
        public FrmMain() {
            InitializeComponent();
            ShowInfo("内存监控和数据持久化后台服务--运行准备。。。");            
            OpenRedis();
            iImgInd = iLocInd = iFaultInd = iDelImgIdx = 0;
            totalPys = IOUtils.GetTotalPhys(); //获取总内存信息      
            llblDataPath.Text = Settings.Default.DbSavePath;
            ShowMemoryInfo();
            ShowInfo($"主机&数据库服务器IP:{RedisHelper.ServIP}。内存监控 -- 开启[OK]");
            GetCameraImgInfo();
            isRun = true;             
            RedisDataDel();

        }
      
        /// <summary>
        /// 显示主机内存 、Redis数据库内存
        /// </summary>
        private void ShowMemoryInfo() {
            Task task = new Task(() =>
            {
                while (true) {
                    //获取总内存信息
                    LblInfoShow(lblMemory, $"{IOUtils.FormatSize(IOUtils.GetUsedPhys())}/{IOUtils.FormatSize(totalPys)}");
                    double redisMem = RedisHelper.GetUsedMem();
                    if (redisMem > -1) {
                        LblInfoShow(lblReidsMemory, $"{IOUtils.FormatSize(redisMem)}");

                    } else {
                        LblInfoShow(lblReidsMemory, "未知");
                    }
                    Thread.Sleep(5000);
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
                    LblInfoShow(lblCameraD, imgInfoDB.StringGet("CameraID4"));
                    LblInfoShow(lblDelImgNum, imgInfoDB.StringGet("DelImgIndex"));
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
            iDelDataByOnce = iInputDelImgNum.Value;
            ToastNotification.Show(this, $"一次性批量删除图像-{iDelDataByOnce} 张，设置成功！", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
        }
        #region Redis操作
        //打开&连接 Redis 数据库
        private void OpenRedis() {
            iMemLimit = iInputMaxMemory.Value;
            iDelDataByOnce = 100;
            imgDB = new RedisHelper(ImgDbId);                     //图像数据库ID
            imgInfoDB = new RedisHelper(InfoDbIdx);               //图像信息数据库ID
            locDB = new RedisHelper(AIFaultDbId);                 //定位数据库ID  

        } 

        private void btnSetMemLimit_Click(object sender, System.EventArgs e) {
            iMemLimit = iInputMaxMemory.Value;
            ToastNotification.Show(this, $"内存限制设置成功：{iMemLimit}MB", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
        }

        private void RedisDataDel() {

            Task task = new Task(
                () =>
                {
                    Thread.Sleep(1000);
                    ShowInfo("Redis内存监听中。。。。。。");
                    while (isRun) {
                        double usedMEM = RedisHelper.GetUsedMem()/ 1048576;// Console.WriteLine($"#================ 已经使用内存:{usedMEM}M ================#");

                        //数据库持久化
                        

                        if (usedMEM > iMemLimit) {
                            RemoveMEM();
                        }                    //Console.WriteLine($"#================ 已经使用内存(删除数据后）:{RedisHelper.GetUsedMem()}M ================#");
                    }
                });
            task.Start();

        }


        private void Redis2Sqlit() {

        }
        /// <summary>
        /// 清除内存
        /// </summary>
        public void RemoveMEM() {
            ShowInfo($"超过内存限制({iMemLimit} M)，开始清除内存 .....");
            //====== 清除内存，注意没有持久化的数据不能删除 ======/
            long iEndDelIdx = iDelImgIdx + iDelDataByOnce;
            //if (iEndDelIdx > _iImgInd) {//删除的图像结束为止> 持久化的图像
            //    iEndDelIdx = _iImgInd;
            // }
            //if (iEndDelIdx > _iDelImgIdx) {
            try {
                string[] keys = imgInfoDB.ListRange("list", iDelImgIdx, iEndDelIdx);
                if (keys == null || keys.Length == 0) {
                    Console.WriteLine($"#--- 无数据删除，等待数据持久化...");
                    return;
                }
                iDelImgIdx += keys.Length;

                Stopwatch sw = new Stopwatch();
                sw.Start();
                imgInfoDB.StringSet("DelImgIndex", iDelImgIdx.ToString());
                int iDelSuccessNum = 0;
                for (int i = 0; i < keys.Length; i++) {
                    if (imgDB.KeyDelete(keys[i])) {
                        ++iDelSuccessNum;
                    }
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                ShowInfo($"成功删除图像:{iDelSuccessNum}张，用时：{sw.ElapsedMilliseconds}ms");

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
