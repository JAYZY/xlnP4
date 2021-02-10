using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace PreCheckSys.DB {
    public class RedisHelper {
        private string _redisServerIp = "127.0.0.1";
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static readonly string ConnectionString;
        private readonly object asyncState;
        private ConnectionMultiplexer redisClient;
        private Dictionary<int, IDatabase> dicDB;

        //Redis 服务器的位置
        public String ServerPath { set; get; }
        /// <summary>
        /// 运行redis服务
        /// </summary>
        /// <returns></returns>

        public string sServIp {
            get { return _redisServerIp; }

        }
        #region 创建单实例对象
        private static RedisHelper _redisHelper;
        private static readonly object _obj = new object();
        public static RedisHelper GetInstance() {
            if (_redisHelper == null) {
                lock (_obj) {
                    if (_redisHelper == null) {
                        _redisHelper = new RedisHelper();
                    }
                }
            }
            return _redisHelper;
        }
        private RedisHelper() {

            asyncState = new object();
            redisClient = null;
            dicDB = null;

        }
        #endregion
        /// <summary>
        /// 清除redis数据库中的所有数据
        /// </summary>
        /// <returns></returns>
        public bool ClearAllDB() {
            bool res = true;
            try {
                redisClient.GetServer(sServIp, 6379).FlushAllDatabasesAsync();
            }
            catch (Exception) {
                res = false;
            }
            return res;
        }
        public bool CheckConnect(string sSvrIp) {
            bool res = true;
            try {
                ConfigurationOptions config = ConfigurationOptions.Parse(sSvrIp);
                config.ConnectTimeout = 1000;
                var redis = ConnectionMultiplexer.Connect(config);
                res = redis.IsConnected;
            }
            catch (Exception) {
                res = false;
            }
            return res;
        }
        public bool IsConnect {
            get {
                bool res = true;
                try {
                    res = redisClient.IsConnected;
                }
                catch (Exception) {
                    res = false;

                }
                return res;
            }
        }
        public bool SetRedisServer(string svrIp) {
            try {
                ConfigurationOptions config = ConfigurationOptions.Parse(svrIp);
                config.ConnectTimeout = 1000;
                config.AllowAdmin = true;
                redisClient = ConnectionMultiplexer.Connect(config);
                _redisServerIp = svrIp;
                if (redisClient.IsConnected) {
                    dicDB = new Dictionary<int, IDatabase>();
                    dicDB.Add(10, redisClient.GetDatabase(10, asyncState));
                    return true;
                }

            }
            catch {
                return false;
            }
            return false;
        }

       

        private IDatabase getDB(int num) {
            if (!dicDB.ContainsKey(num)) {
                dicDB[num] = redisClient.GetDatabase(num, asyncState);
            }

            return dicDB[num];
        }
        //返回字符串
        public byte[] GetByte(string key, int dbNum = 10) {
            if (dicDB == null) {
                return null;
            }

            return getDB(dbNum).StringGet(key);
        }
        public string GetString(string key, int dbNum = 10) {
            if (dicDB == null) {
                return null;
            }

            return getDB(dbNum).StringGet(key);
        }

        ///// <summary>s
        ///// 获取一个key的对象
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public T GetObj<T>(string key, int dbNum = 10) where T : class {
        //    if (dicDB == null) return null;
        //    var result = getDB(dbNum).StringGet(key);
        //    if (string.IsNullOrEmpty(result)) {
        //        return null;
        //    }
        //    return JsonHelper.GetModel<T>(result);
        //}
        public string getList(string key, int index, int dbNum = 10) {
            RedisValue value = getDB(dbNum).ListGetByIndex(key, index);
            return value.ToString();
        }

    }
}
