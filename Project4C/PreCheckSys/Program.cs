using PreCheckSys.DB;
using PreCheckSys.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreCheckSys {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Settings.Default.DbServIP = "192.168.100.58";
            //Settings.Default.DBPath = "F:\\天窗数据";
            Settings.Default.Save();
            // Redis2Sqlite redis = new Redis2Sqlite(Settings.Default.ipAddr, "sdf");
            // Settings.Default.currDBIndex = 0;
            //Settings.Default.Save();
            // redis.ToSqlite();
            //MessageBox.Show(RedisHelperNew.GetUsedMem().ToString());
            try {

                Application.Run(new FrmMain());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            




        }
    }
}
