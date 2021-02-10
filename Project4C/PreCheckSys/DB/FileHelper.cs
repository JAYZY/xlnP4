using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreCheckSys.DB {
    class FileHelper {
        #region 文件操作

        //打开文件选择对话框
        public static string _InitialDirectory = "C:\\";
        public static string OpenFile(string title,string sFilter="(*.*)|*.*") {
            string sFileName = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = _InitialDirectory;//初始化路径
            fileDialog.Filter = sFilter;//过滤选项设置，文本文件，所有文件。
            fileDialog.Title = title;// "选择导入的基础数据文件";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                sFileName = fileDialog.FileName;
                _InitialDirectory = Path.GetDirectoryName(sFileName);
            }
            return sFileName;

        }
        public static FileInfo FileCopy(string srcFile, string destFile, bool isOverwrite) {
            FileInfo file = new FileInfo(srcFile);
            FileInfo newFile=null;
            try {
                 newFile= file.CopyTo(destFile, isOverwrite);
            }
            catch (IOException ex) {
                newFile = null;
                throw ex;
            }
            return newFile;
        }
        #endregion

    }
}
