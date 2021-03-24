﻿

using ComClassLib.Properties;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace ComClassLib.DB {

    /// <summary>
    /// 这是一个手动封装的完整RedisHelper
    /// </summary>
    public class RedisHelper {
        /// <summary>
        /// 连接字符串
        /// </summary>
        //private static readonly string ConnectionString;

        public static readonly string ServIP;
        public static readonly int Port;
        private static readonly int Timeout;

        /// <summary>
        /// redis 连接对象
        /// </summary>
        public static IConnectionMultiplexer ConnMultiplexer;


        public static ConfigurationOptions Config;

        /// <summary>
        /// 数据库服务器连接是否正常
        /// </summary>
        public static bool IsServConnect;
        /// <summary>
        /// 默认的key值（用来当作RedisKey的前缀）
        /// </summary>
        public static string DefaultKey { get; private set; }
        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object Locker = new object();


        #region 静态构造函数
        /// <summary>
        /// 静态的构造函数,
        /// 构造函数是属于类的，而不是属于实例的
        /// 就是说这个构造函数只会被执行一次。也就是在创建第一个实例或引用任何静态成员之前，由.NET自动调用。
        /// </summary>
        static RedisHelper() {
            ServIP ="192.168.1.158";//Settings.Default.RedisServIP;
            Port = Settings.Default.RedisPort;
            Timeout = Settings.Default.RedisDBTimeout;
            if (Config == null) {
                Config = new ConfigurationOptions() {
                    EndPoints = { { ServIP, Port } },
                    AllowAdmin = true,
                    ConnectTimeout = Timeout //超时设置 
                };
            }
            IsServConnect = false;
            DefaultKey = "";
            //RegisterEvent();
        }
        #endregion

        #region 通用方法(静态方法)
        /// <summary>
        /// 得到使用内存 单位字节
        /// </summary>
        /// <returns></returns>
        public static double GetUsedMem() {
            double usedMEM = 0;
            try {

                if (RedisConnect) {
                    lock (Locker) {
                        var servInfo = ConnMultiplexer.GetServer(ServIP, Port).Info();

                        foreach (var info in servInfo) {
                            if (info.Key.Equals("Memory")) {
                                foreach (var item in info) {
                                    Console.WriteLine(item.Value);
                                    if (item.Key.Equals("used_memory")) {
                                        usedMEM = Double.Parse(item.Value);
                                        goto end;
                                    }
                                }
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"GetUsedMem is Error:{ex.ToString()}");
                usedMEM = -1;
            }
        end:
            return usedMEM;
        }
        /// <summary>
        /// 清除所有数据库
        /// </summary>
        /// <returns></returns>
        public static bool ClearAllDB() {
            bool res = true;
            try {
                ConnMultiplexer.GetServer(ServIP, Port).FlushAllDatabasesAsync();
            } catch {
                res = false;
            }
            return res;
        }
        public static bool CheckConnect(string sSvrIp, int iPort) {
            bool res = true;
            try {
                ConfigurationOptions config = new ConfigurationOptions() {
                    EndPoints = { { sSvrIp, iPort } },
                    AllowAdmin = true,
                    ConnectTimeout = 1000 //超时设置1s
                };
                res = ConnectionMultiplexer.Connect(config).IsConnected;
            } catch (Exception) {
                res = false;
            }
            return res;
        }
        /// <summary>
        /// 连接Redis数据服务器 
        /// </summary>
        public static bool RedisConnect {
            get {
                if (IsServConnect) {
                    return true;
                }
                try {
                    if (Config == null) {
                        Config = new ConfigurationOptions() {
                            EndPoints = { { ServIP, Port } },
                            AllowAdmin = true,
                            ConnectTimeout = Timeout //超时设置 
                        };
                    }
                    if (ConnMultiplexer == null) {
                        if ((ConnMultiplexer == null || !ConnMultiplexer.IsConnected)) {
                            lock (Locker) {
                                if ((ConnMultiplexer == null || !ConnMultiplexer.IsConnected)) {
                                    ConnMultiplexer = ConnectionMultiplexer.Connect(Config);
                                }
                            }
                        }
                    }
                    IsServConnect = ConnMultiplexer.IsConnected;
                } catch (Exception) {
                    IsServConnect = false;
                }
                return IsServConnect;
            }
        }
        /// <summary>
        /// 添加 key 的前缀
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string AddKeyPrefix(string key) {

            return string.IsNullOrEmpty(DefaultKey) ? key : $"{DefaultKey}:{key}";
        }
        /// <summary>
        /// 序列化,用于存储对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static byte[] Serialize(object obj) {
            try {
                if (obj == null) {
                    return null;
                }
                var binaryFormatter = new BinaryFormatter();
                using (var memoryStream = new MemoryStream()) {
                    binaryFormatter.Serialize(memoryStream, obj);
                    var data = memoryStream.ToArray();
                    return data;
                }
            } catch (SerializationException ex) {
                throw ex;
            }
        }
        /// <summary>
        /// 反序列化，用于解码对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private static T Deserialize<T>(byte[] data) {
            if (data == null) {
                return default(T);
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(data)) {
                var result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }

        #endregion


        #region 成员属性
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        private IDatabase db;

        /// <summary>
        /// 数据库编号
        /// </summary>
        private int dbInd;

        /// <summary>
        /// 采用双重锁单例模式，保证数据访问对象有且仅有一个
        /// </summary>
        /// <returns></returns>
        public IConnectionMultiplexer GetConnectionRedisMultiplexer() {
            if ((ConnMultiplexer == null || !ConnMultiplexer.IsConnected)) {
                lock (Locker) {
                    if ((ConnMultiplexer == null || !ConnMultiplexer.IsConnected)) {
                        ConnMultiplexer = ConnectionMultiplexer.Connect(Config);
                    }
                }
            }
            return ConnMultiplexer;
        }
        /// <summary>
        /// 添加事务处理
        /// </summary>
        /// <returns></returns>
        public ITransaction GetTransaction() {
            //创建事务
            return this.db.CreateTransaction();
        }
        #endregion

        /// <summary>
        /// 重载构造器，获取redis内部数据库的交互式连接
        /// </summary>
        /// <param name="dbInd">要获取的数据库ID</param>
        public RedisHelper(int dbInd = -1) {
            this.dbInd = dbInd;
        }
        private bool IsDbConnect { get; set; }

        public bool DbConnect() {
            if (IsDbConnect) {
                return true;
            }
            IsDbConnect = false;
            try {
                if (true == RedisConnect) {
                    //链接指定的库
                    db = ConnMultiplexer.GetDatabase(dbInd);
                    IsDbConnect = true;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                IsDbConnect = false;
            }
            return IsDbConnect;
        }


        #region stringGet 
        /// <summary>
        /// 设置key，并保存字符串（如果key 已存在，则覆盖）
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <param name="expried"></param>
        /// <returns></returns>
        public bool StringSet(string redisKey, string redisValue, TimeSpan? expried = null) {
            redisKey = AddKeyPrefix(redisKey);
            bool res = false;
            try {
                if (DbConnect()) {
                    res = db.StringSet(redisKey, redisValue, expried);
                } else {
                    res = false;
                    IsDbConnect = false;
                }
            } catch {
                res = false;
                IsDbConnect = false;
            }
            return res;
        }
        /// <summary>
        /// 保存多个key-value
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        public bool StringSet(IEnumerable<KeyValuePair<RedisKey, RedisValue>> keyValuePairs) {
            bool res = false;
            try {
                if (DbConnect()) {
                    keyValuePairs = keyValuePairs.Select(x => new KeyValuePair<RedisKey, RedisValue>(AddKeyPrefix(x.Key), x.Value));
                    res = db.StringSet(keyValuePairs.ToArray());
                } else {
                    res = false;
                    IsDbConnect = false;
                }
            } catch {
                res = false;
                IsDbConnect = false;
            }
            return res;


        }
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public string StringGet(string redisKey) {

            string resStr = string.Empty;
            try {
                if (DbConnect()) {
                    redisKey = AddKeyPrefix(redisKey);
                    resStr = db.StringGet(redisKey);
                }
            } catch {
                IsDbConnect = false;
            }
            return resStr;


        }
        /// <summary>
        /// 返回图像字节
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public byte[] GetByte(string redisKey) {
            byte[] rByt = null;
            try {
                if (DbConnect()) {
                    redisKey = AddKeyPrefix(redisKey);
                    RedisValue rdv = db.StringGet(redisKey);
                    if (rdv.IsNullOrEmpty) {
                        rByt = null;
                    } else {
                        rByt = rdv;
                    }
                }
            } catch (System.Exception) {
                rByt = null;
                IsDbConnect = false;
            }
            return rByt;

        }
        /// <summary>
        /// 存储一个对象，该对象会被序列化存储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public bool StringSet<T>(string redisKey, T redisValue, TimeSpan? expired = null) {
            bool res = false;
            try {
                if (DbConnect()) {
                    redisKey = AddKeyPrefix(redisKey);
                    var json = Serialize(redisKey);
                    res = db.StringSet(redisKey, json, expired);
                }

            } catch {
                res = false;
                IsDbConnect = false;
            }

            return res;
        }
        /// <summary>
        /// 获取一个对象(会进行反序列化)
        /// </summary>ha
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public T StringGet<T>(string redisKey) {
            try {
                if (DbConnect()) {
                    redisKey = AddKeyPrefix(redisKey);
                    return FileOp.JsonHelper.GetModel<T>(db.StringGet(redisKey));
                }
            } catch {
                IsDbConnect = false;
            }
            return default(T);
        }

        /// <summary>
        /// 保存一个字符串值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync(string redisKey, string redisValue, TimeSpan? expired = null) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.StringSetAsync(redisKey, redisValue, expired);
        }
        /// <summary>
        /// 保存一个字符串值
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync(IEnumerable<KeyValuePair<RedisKey, RedisValue>> keyValuePairs) {
            keyValuePairs
                = keyValuePairs.Select(x => new KeyValuePair<RedisKey, RedisValue>(AddKeyPrefix(x.Key), x.Value));
            return await db.StringSetAsync(keyValuePairs.ToArray());
        }
        /// <summary>
        /// 获取单个值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public async Task<string> StringGetAsync(string redisKey, string redisValue, TimeSpan? expired = null) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.StringGetAsync(redisKey);
        }
        /// <summary>
        /// 存储一个对象（该对象会被序列化保存）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync<T>(string redisKey, string redisValue, TimeSpan? expired = null) {
            redisKey = AddKeyPrefix(redisKey);
            var json = Serialize(redisValue);
            return await db.StringSetAsync(redisKey, json, expired);
        }
        /// <summary>
        /// 获取一个对象（反序列化）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public async Task<T> StringGetAsync<T>(string redisKey, string redisValue, TimeSpan? expired = null) {
            redisKey = AddKeyPrefix(redisKey);
            return Deserialize<T>(await db.StringGetAsync(redisKey));
        }
        #endregion

        #region  Hash
        /// <summary>
        /// 判断字段是否在hash中
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public bool HashExist(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashExists(redisKey, hashField);
        }
        /// <summary>
        /// 从hash 中删除字段
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public bool HashDelete(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashDelete(redisKey, hashField);
        }
        /// <summary>
        /// 从hash中移除指定字段
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public long HashDelete(string redisKey, IEnumerable<RedisValue> hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashDelete(redisKey, hashField.ToArray());
        }
        /// <summary>
        /// 在hash中设定值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HashSet(string redisKey, string hashField, string value) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashSet(redisKey, hashField, value);
        }
        /// <summary>
        /// 从Hash 中获取值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public RedisValue HashGet(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashGet(redisKey, hashField);
        }
        /// <summary>
        /// 从Hash 中获取值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public RedisValue[] HashGet(string redisKey, RedisValue[] hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashGet(redisKey, hashField);
        }
        /// <summary>
        /// 从hash 返回所有的key值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public IEnumerable<RedisValue> HashKeys(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashKeys(redisKey);
        }
        /// <summary>
        /// 根据key返回hash中的值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public RedisValue[] HashValues(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.HashValues(redisKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HashSet<T>(string redisKey, string hashField, T value) {
            redisKey = AddKeyPrefix(redisKey);
            var json = Serialize(value);
            return db.HashSet(redisKey, hashField, json);
        }
        /// <summary>
        /// 在hash 中获取值 （反序列化）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public T HashGet<T>(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return Deserialize<T>(db.HashGet(redisKey, hashField));
        }
        /// <summary>
        /// 判断字段是否存在hash 中
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<bool> HashExistsAsync(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashExistsAsync(redisKey, hashField);
        }
        /// <summary>
        /// 从hash中移除指定字段
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<bool> HashDeleteAsync(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashDeleteAsync(redisKey, hashField);
        }
        /// <summary>
        /// 从hash中移除指定字段
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<long> HashDeleteAsync(string redisKey, IEnumerable<RedisValue> hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashDeleteAsync(redisKey, hashField.ToArray());
        }
        /// <summary>
        /// 在hash 设置值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> HashSetAsync(string redisKey, string hashField, string value) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashSetAsync(redisKey, hashField, value);
        }
        /// <summary>
        /// 在hash 中设定值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public async Task HashSetAsync(string redisKey, IEnumerable<HashEntry> hashFields) {
            redisKey = AddKeyPrefix(redisKey);
            await db.HashSetAsync(redisKey, hashFields.ToArray());
        }
        /// <summary>
        /// 在hash 中设定值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<RedisValue> HashGetAsync(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashGetAsync(redisKey, hashField);
        }
        /// <summary>
        /// 在hash 中获取值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RedisValue>> HashGetAsync(string redisKey, RedisValue[] hashField, string value) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashGetAsync(redisKey, hashField);
        }
        /// <summary>
        /// 从hash返回所有的字段值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RedisValue>> HashKeysAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashKeysAsync(redisKey);
        }
        /// <summary>
        /// 返回hash中所有的值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RedisValue>> HashValuesAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.HashValuesAsync(redisKey);
        }
        /// <summary>
        /// 在hash 中设定值（序列化）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> HashSetAsync<T>(string redisKey, string hashField, T value) {
            redisKey = AddKeyPrefix(redisKey);
            var json = Serialize(value);
            return await db.HashSetAsync(redisKey, hashField, json);
        }
        /// <summary>
        /// 在hash中获取值（反序列化）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<T> HashGetAsync<T>(string redisKey, string hashField) {
            redisKey = AddKeyPrefix(redisKey);
            return Deserialize<T>(await db.HashGetAsync(redisKey, hashField));
        }
        #endregion

        #region list operation
        /// <summary>
        /// 返回list中 指定范围内key
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public string[] ListRange(string redisKey, long start, long stop) {

            try {
                if (DbConnect()) {
                    redisKey = AddKeyPrefix(redisKey);
                    return db.ListRange(redisKey, start, stop).ToStringArray();
                }
            } catch {
                IsDbConnect = false;
            }
            return null;
        }

        /// <summary>
        /// 移除并返回key所对应列表的第一个元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public string ListLeftPop(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListLeftPop(redisKey);
        }
        /// <summary>
        /// 移除并返回key所对应列表的最后一个元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public string ListRightPop(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListRightPop(redisKey);
        }
        /// <summary>
        /// 移除指定key及key所对应的元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListRemove(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListRemove(redisKey, redisValue);
        }
        /// <summary>
        /// 在列表尾部插入值，如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListRightPush(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListRightPush(redisKey, redisValue);
        }
        /// <summary>
        /// 在列表头部插入值，如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListLeftPush(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListLeftPush(redisKey, redisValue);
        }
        /// <summary>
        /// 返回列表上该键的长度，如果不存在，返回0
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public long ListLength(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListLength(redisKey);
        }
        /// <summary>
        /// 返回在该列表上键所对应的元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public IEnumerable<RedisValue> ListRange(string redisKey) {
            try {
                redisKey = AddKeyPrefix(redisKey);
                return db.ListRange(redisKey);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public T ListLeftPop<T>(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return Deserialize<T>(db.ListLeftPop(redisKey));
        }
        /// <summary>
        /// 移除并返回该列表上的最后一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public T ListRightPop<T>(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return Deserialize<T>(db.ListRightPop(redisKey));
        }
        /// <summary>
        /// 在列表尾部插入值，如果键不存在，先创建再插入值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListRightPush<T>(string redisKey, T redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListRightPush(redisKey, Serialize(redisValue));
        }
        /// <summary>
        /// 在列表头部插入值，如果键不存在，创建后插入值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListLeftPush<T>(string redisKey, T redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return db.ListLeftPush(redisKey, Serialize(redisValue));
        }
        public void ListSetValueInHead(string redisKey, long redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            db.ListSetByIndex(redisKey, 0, redisValue);
        }
        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<string> ListLeftPopAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListLeftPopAsync(redisKey);
        }
        /// <summary>
        /// 移除并返回存储在该键列表的最后一个元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<string> ListRightPopAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListRightPopAsync(redisKey);
        }
        /// <summary>
        /// 移除列表指定键上与值相同的元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<long> ListRemoveAsync(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListRemoveAsync(redisKey, redisValue);
        }
        /// <summary>
        /// 在列表尾部差入值，如果键不存在，先创建后插入
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<long> ListRightPushAsync(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return await ListRightPushAsync(redisKey, redisValue);
        }
        /// <summary>
        /// 在列表头部插入值，如果键不存在，先创建后插入
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<long> ListLeftPushAsync(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListLeftPushAsync(redisKey, redisValue);
        }
        /// <summary>
        /// 返回列表上的长度，如果不存在，返回0
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<long> ListLengthAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListLengthAsync(redisKey);
        }
        /// <summary>
        /// 返回在列表上键对应的元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RedisValue>> ListRangeAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListRangeAsync(redisKey);
        }
        /// <summary>
        /// 移除并返回存储在key对应列表的第一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<T> ListLeftPopAsync<T>(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return Deserialize<T>(await db.ListLeftPopAsync(redisKey));
        }
        /// <summary>
        /// 移除并返回存储在key 对应列表的最后一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<T> ListRightPopAsync<T>(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return Deserialize<T>(await db.ListRightPopAsync(redisKey));
        }
        /// <summary>
        /// 在列表尾部插入值，如果值不存在，先创建后写入值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<long> ListRightPushAsync<T>(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListRightPushAsync(redisKey, Serialize(redisValue));
        }
        /// <summary>
        /// 在列表头部插入值，如果值不存在，先创建后写入值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<long> ListLeftPushAsync<T>(string redisKey, string redisValue) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.ListLeftPushAsync(redisKey, Serialize(redisValue));
        }
        #endregion

        #region SortedSet 操作
        /// <summary>
        /// sortedset 新增
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="member"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool SortedSetAdd(string redisKey, string member, double score) {
            redisKey = AddKeyPrefix(redisKey);
            return db.SortedSetAdd(redisKey, member, score);
        }
        /// <summary>
        /// 在有序集合中返回指定范围的元素，默认情况下由低到高
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public IEnumerable<RedisValue> SortedSetRangeByRank(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.SortedSetRangeByRank(redisKey);
        }
        /// <summary>
        /// 返回有序集合的个数
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public long SortedSetLength(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.SortedSetLength(redisKey);
        }
        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool SortedSetLength(string redisKey, string member) {
            redisKey = AddKeyPrefix(redisKey);
            return db.SortedSetRemove(redisKey, member);
        }
        /// <summary>
        ///  sorted set Add
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="member"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool SortedSetAdd<T>(string redisKey, T member, double score) {
            redisKey = AddKeyPrefix(redisKey);
            var json = Serialize(member);
            return db.SortedSetAdd(redisKey, json, score);
        }

        #region SortedSet-Async
        /// <summary>
        /// SortedSet 新增
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="member"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public async Task<bool> SortedSetAddAsync(string redisKey, string member, double score) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.SortedSetAddAsync(redisKey, member, score);
        }
        /// <summary>
        /// 在有序集合中返回指定范围的元素，默认情况下由低到高
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RedisValue>> SortedSetRangeByRankAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.SortedSetRangeByRankAsync(redisKey);
        }
        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<long> SortedSetLengthAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.SortedSetLengthAsync(redisKey);
        }
        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task<bool> SortedSetRemoveAsync(string redisKey, string member) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.SortedSetRemoveAsync(redisKey, member);
        }
        /// <summary>
        /// SortedSet 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="member"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public async Task<bool> SortedSetAddAsync<T>(string redisKey, T member, double score) {
            redisKey = AddKeyPrefix(redisKey);
            var json = Serialize(member);
            return await db.SortedSetAddAsync(redisKey, json, score);
        }
        #endregion SortedSet-Async

        #endregion

        #region key operation
        /// <summary>
        /// 移除指定key
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public bool KeyDelete(string redisKey) {



            bool res = false;
            try {
                if (DbConnect()) {
                    redisKey = AddKeyPrefix(redisKey);

                    res = db.KeyDelete(redisKey);
                }

            } catch {
                res = false;
                IsDbConnect = false;
            }

            return res;


        }
        /// <summary>
        /// 删除指定key
        /// </summary>
        /// <param name="redisKeys"></param>
        /// <returns></returns>
        public long KeyDelete(IEnumerable<string> redisKeys) {
            var keys = redisKeys.Select(x => (RedisKey)AddKeyPrefix(x));
            return db.KeyDelete(keys.ToArray());
        }
        /// <summary>
        /// 检验key是否存在
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public bool KeyExists(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return db.KeyExists(redisKey);
        }
        /// <summary>
        /// 重命名key
        /// </summary>
        /// <param name="oldKeyName"></param>
        /// <param name="newKeyName"></param>
        /// <returns></returns>
        public bool KeyReName(string oldKeyName, string newKeyName) {
            oldKeyName = AddKeyPrefix(oldKeyName);
            return db.KeyRename(oldKeyName, newKeyName);
        }
        /// <summary>
        /// 设置key 的过期时间
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public bool KeyExpire(string redisKey, TimeSpan? expired = null) {
            redisKey = AddKeyPrefix(redisKey);
            return db.KeyExpire(redisKey, expired);
        }

        #region key-async
        /// <summary>
        /// 移除指定的key
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<bool> KeyDeleteAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.KeyDeleteAsync(redisKey);
        }
        /// <summary>
        /// 删除指定的key
        /// </summary>
        /// <param name="redisKeys"></param>
        /// <returns></returns>
        public async Task<long> KeyDeleteAsync(IEnumerable<string> redisKeys) {
            var keys = redisKeys.Select(x => (RedisKey)AddKeyPrefix(x));
            return await db.KeyDeleteAsync(keys.ToArray());
        }
        /// <summary>
        /// 检验key 是否存在
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<bool> KeyExistsAsync(string redisKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.KeyExistsAsync(redisKey);
        }
        /// <summary>
        /// 重命名key
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisNewKey"></param>
        /// <returns></returns>
        public async Task<bool> KeyRenameAsync(string redisKey, string redisNewKey) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.KeyRenameAsync(redisKey, redisNewKey);
        }
        /// <summary>
        /// 设置 key 时间
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="expired"></param>
        /// <returns></returns>
        public async Task<bool> KeyExpireAsync(string redisKey, TimeSpan? expired) {
            redisKey = AddKeyPrefix(redisKey);
            return await db.KeyExpireAsync(redisKey, expired);
        }
        #endregion key-async

        #endregion

        #region 发布订阅
        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="channel">频道</param>
        /// <param name="handle">事件</param>
        public void Subscribe(RedisChannel channel, Action<RedisChannel, RedisValue> handle) {
            //getSubscriber() 获取到指定服务器的发布者订阅者的连接
            var sub = ConnMultiplexer.GetSubscriber();
            //订阅执行某些操作时改变了 优先/主动 节点广播
            sub.Subscribe(channel, handle);
        }
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public long Publish(RedisChannel channel, RedisValue message) {
            var sub = ConnMultiplexer.GetSubscriber();
            return sub.Publish(channel, message);
        }
        /// <summary>
        /// 发布（使用序列化）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public long Publish<T>(RedisChannel channel, T message) {
            var sub = ConnMultiplexer.GetSubscriber();
            return sub.Publish(channel, Serialize(message));
        }

        #region 发布订阅-async
        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="redisChannel"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        public async Task SubscribeAsync(RedisChannel redisChannel, Action<RedisChannel, RedisValue> handle) {
            var sub = ConnMultiplexer.GetSubscriber();
            await sub.SubscribeAsync(redisChannel, handle);
        }
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="redisChannel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<long> PublishAsync(RedisChannel redisChannel, RedisValue message) {
            var sub = ConnMultiplexer.GetSubscriber();
            return await sub.PublishAsync(redisChannel, message);
        }
        /// <summary>
        /// 发布（使用序列化）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisChannel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<long> PublishAsync<T>(RedisChannel redisChannel, T message) {
            var sub = ConnMultiplexer.GetSubscriber();
            return await sub.PublishAsync(redisChannel, Serialize(message));
        }
        #endregion 发布订阅-async

        #endregion

        #region 注册事件
        /// <summary>
        /// 注册事件
        /// </summary>
        private static void RegisterEvent() {
            ConnMultiplexer.ConnectionRestored += ConnMultiplexer_ConnectionRestored;
            ConnMultiplexer.ConnectionFailed += ConnMultiplexer_ConnectionFailed;
            ConnMultiplexer.ErrorMessage += ConnMultiplexer_ErrorMessage;
            ConnMultiplexer.ConfigurationChanged += ConnMultiplexer_ConfigurationChanged;
            ConnMultiplexer.HashSlotMoved += ConnMultiplexer_HashSlotMoved;
            ConnMultiplexer.InternalError += ConnMultiplexer_InternalError;
            ConnMultiplexer.ConfigurationChangedBroadcast += ConnMultiplexer_ConfigurationChangedBroadcast;
        }
        /// <summary>
        /// 重新配置广播时(主从同步更改)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConfigurationChangedBroadcast(object sender, EndPointEventArgs e) {
            Console.WriteLine($"{nameof(ConnMultiplexer_ConfigurationChangedBroadcast)}: {e.EndPoint}");
        }
        /// <summary>
        /// 发生内部错误时(调试用)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_InternalError(object sender, InternalErrorEventArgs e) {
            Console.WriteLine($"{nameof(ConnMultiplexer_InternalError)}: {e.Exception}");
        }
        /// <summary>
        /// 更改集群时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_HashSlotMoved(object sender, HashSlotMovedEventArgs e) {
            Console.WriteLine($"{nameof(ConnMultiplexer_HashSlotMoved)}: {nameof(e.OldEndPoint)}-{e.OldEndPoint} To {nameof(e.NewEndPoint)}-{e.NewEndPoint} ");
        }
        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConfigurationChanged(object sender, EndPointEventArgs e) {
            Console.WriteLine($"{nameof(ConnMultiplexer_ConfigurationChanged)}: {e.EndPoint}");
        }
        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ErrorMessage(object sender, RedisErrorEventArgs e) {
            Console.WriteLine($"{nameof(ConnMultiplexer_ErrorMessage)}: {e.Message}");
        }
        /// <summary>
        /// 物理连接失败时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConnectionFailed(object sender, ConnectionFailedEventArgs e) {
            IsServConnect = false;
            Console.WriteLine($"{nameof(ConnMultiplexer_ConnectionFailed)}: {e.Exception}");
        }
        /// <summary>
        /// 建立物理连接时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConnectionRestored(object sender, ConnectionFailedEventArgs e) {
            Console.WriteLine($"{nameof(ConnMultiplexer_ConnectionRestored)}: {e.Exception}");
        }
        #endregion

    }

}
