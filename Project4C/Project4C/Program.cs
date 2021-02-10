using DevComponents.DotNetBar;
using Project4C.DB;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project4C {
    static class Program {

        public static FrmMain mainForm;
        public static FrmParent frmParent;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                //Application.Run(mainForm = new ECMDIParent(Option.Parameter.UserLanguage));
                ////Application.Run(new FormCreateOrder());
                Run();
            } catch (Exception ex) {
                MessageBox.Show("程序发生未知原因异常,将终止运行!异常是\n" + ex.ToString());
            }
            // ReadTestData("127.0.0.1");
            //ReadTestData("192.168.100.58");

            // Application.Run(FrmMain.GetInstance());
            //Application.Run(new FrmParent());

            //try {
            //   Application.Run(new FrmOnline());
            // }
            // catch ( Exception ex)
            // { MessageBox.Show(ex.ToString()); }
        }
        /// <summary>
        /// 测试命令生成 缺陷测试数据
        /// </summary>
        static void ReadTestData(String ipAddr) {
            if (RedisHelper.GetInstance().SetRedisServer(ipAddr)) {

                // Console.WriteLine("Server PicInfoDbected!");
                string sDbPath = Path.Combine(System.Environment.CurrentDirectory, "Location.db");
                string[] text = System.IO.File.ReadAllText(sDbPath).Split('\n');

                int idx = 0;
                foreach (var value in text) {
                    string sKey = RedisHelper.GetInstance().getList("list", idx++, 11);
                    if (String.IsNullOrEmpty(sKey)) {
                        continue;
                    }

                    RedisHelper.GetInstance().WriteValue(sKey, value, 12);
                }
                MessageBox.Show(@"定位&&缺陷测试数据生成成功！");
            } else {
                Console.WriteLine("Server PicInfoDbect Failed!");
            }
        }
        static void Run() {

            bool createNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew)) {
                if (createNew) {                  
                    Application.Run(frmParent = FrmParent.GetInstance());
                    //Application.Run(mainForm = FrmMain.GetInstance());
                } else {
                    MessageBox.Show(@"客户端程序已经在运行中...");
                    System.Threading.Thread.Sleep(1000);
                    System.Environment.Exit(1);
                }
            }
        }
    }
}
