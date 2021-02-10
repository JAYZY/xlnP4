using System;
using System.Text;
using System.Windows.Forms;
namespace TaskMonitoring {
    class Program {
       
        static void Main(string[] args) {
            //string str = "\xBA\xBC\xD6\xDD\xC4\xCF-\xBA\xBC\xD6\xDD\xC4\xCF";
            //MessageBox.Show(str);
            //byte[] gb = new byte[str.Length ];
            //for (int i = 0; i < str.Length; i++) {
            //    gb[i]= Convert.ToByte(str[i]);
            //}         
            //MessageBox.Show(Encoding.Default.GetString(gb));

            FileWatcher fileWatcher = new FileWatcher("G:\\4C\\Galaxy\\");
            fileWatcher.Open();
            while (true) { }
        }
    }
}
