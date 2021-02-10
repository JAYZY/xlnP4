using System;
using System.IO;
using System.Windows.Forms;

namespace TaskMonitoring {
    /// <summary>
    /// 文件监控类，用于监控指定目录下文件以及文件夹的变化
    /// </summary>
    public class FileWatcher {
        private FileSystemWatcher _watcher = null;
        private readonly string _path = string.Empty;
        private readonly string _filter = string.Empty;
        private bool _isWatch = false;


        /// <summary>
        /// 监控是否正在运行
        /// </summary>
        public bool IsWatch {
            get {
                return _isWatch;
            }
        }

        /// <summary>
        /// 文件变更信息队列
        /// </summary>


        /// <summary>
        /// 初始化FileWatcher类
        /// </summary>
        /// <param name="path">监控路径</param>
        public FileWatcher(string path) {
            _path = path;

        }
        /// <summary>
        /// 初始化FileWatcher类，并指定是否持久化文件变更消息
        /// </summary>
        /// <param name="path">监控路径</param>
        /// <param name="isPersistence">是否持久化变更消息</param>
        /// <param name="persistenceFilePath">持久化保存路径</param>
        public FileWatcher(string path, bool isPersistence, string persistenceFilePath) {
            _path = path;

        }

        /// <summary>
        /// 初始化FileWatcher类，并指定是否监控指定类型文件
        /// </summary>
        /// <param name="path">监控路径</param>
        /// <param name="filter">指定类型文件，格式如:*.txt,*.doc,*.rar</param>
        public FileWatcher(string path, string filter) {
            _path = path;
            _filter = filter;

        }

        /// <summary>
        /// 初始化FileWatcher类，并指定是否监控指定类型文件，是否持久化文件变更消息
        /// </summary>
        /// <param name="path">监控路径</param>
        /// <param name="filter">指定类型文件，格式如:*.txt,*.doc,*.rar</param>
        /// <param name="isPersistence">是否持久化变更消息</param>
        /// <param name="persistenceFilePath">持久化保存路径</param>
        public FileWatcher(string path, string filter, bool isPersistence, string persistenceFilePath) {
            _path = path;
            _filter = filter;

        }

        /// <summary>
        /// 打开文件监听器
        /// </summary>
        public void Open() {
            if (!Directory.Exists(_path)) {
                Directory.CreateDirectory(_path);
            }
            MessageBox.Show("开始监听目录：" + _path);

            Console.WriteLine("开始监听目录：" + _path);

            if (string.IsNullOrEmpty(_filter)) {
                _watcher = new FileSystemWatcher(_path);
            }
            else {
                _watcher = new FileSystemWatcher(_path, _filter);
            }
            //注册监听事件
            _watcher.Created += new FileSystemEventHandler(OnProcess);
            Console.WriteLine("事件注册成功：" + _path);
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
            _isWatch = true;
        }

        /// <summary>
        /// 关闭监听器
        /// </summary>
        public void Close() {
            _isWatch = false;
            _watcher.Created -= new FileSystemEventHandler(OnProcess);           
            _watcher.EnableRaisingEvents = false;
            _watcher = null;
        }



        /// <summary>
        /// 监听事件触发的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnProcess(object sender, FileSystemEventArgs e) {
            try {
                if (e.ChangeType == WatcherChangeTypes.Created) {
                    Console.WriteLine(e.FullPath);
                    if (File.GetAttributes(e.FullPath) == FileAttributes.Directory) {
                        Console.WriteLine("发送到redis：" + _path);
                        RedisHelper redis = new RedisHelper("192.168.100.58");
                        redis.SetString("TaskInfo", e.FullPath, 11);
                        Console.WriteLine("写入成功：" + _path);
                    }
                } else {
                    MessageBox.Show("阿斯蒂芬");
                }

                string sFullPath = e.FullPath;                
                
            }
            catch(Exception ex) {
                MessageBox.Show("出错了"+ex.ToString());
                Close();
            }
        }


    }
}
