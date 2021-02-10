﻿using PreCheckSys.core;
using PreCheckSys.DB;
using PreCheckSys.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PreCheckSys {
    class Redis2Sqlite {
        private static string m_sIpAddr;                           //ip
        private static string m_sDBFullName;                       //db路径+名称
        private static string m_sDBBackPath;                       //备份DB路径+名称
        private static readonly int m_sInfoDbIdx;                         //图像信息数据库Id:
        private static readonly int m_sImgDbId;                          //图像二进制存储数据库Id
        private static readonly int m_sAIFaultDbId;                      //智能识别缺陷数据库Id
        private static readonly int m_sGeoDbId;                         //几何参数数据库

        public static int IMemLimit { get; set; }                            //MemLimit:内存限制 默认10GB
        public static int ISaveImgNumByOnce { get; set; }                  //一次存储的图像数量
        public static int IDelDataByOnce { get; set; }                        //一次删除的图像数据
        public static int ISaveFaultNumByOnce { get; set; }                   //缺陷信息一次存储的大小-- 尽可能不去修改，由于数据量不大，默认为 10000
        public static int ISaveGeoDataNumByOnce { get; set; }                 //几何参数数据 一次存储的大小
        /// <summary>
        /// 分库大小 默认 3000
        /// </summary>
        public static int ISubDbSize{ get; set; }                            
        /// <summary>
        /// 两杆之间大小 默认为50；
        /// </summary>
        public static int IImgNumTwoPole { get; set; }              

        private int curDBIndex;                                            //当前分库下标
        private bool isLogSubDb;                                            //是否记录子库信息

        private int saveImgNum, saveFaultNum;

        public long IFaultNum { get; set; }                           //总的缺陷个数

        private Int64 IDelImgIdx { get; set; }                        //记录删除的图像index  

        public bool ExecProc { get; set; }

        private readonly RedisHelperNew imgDB;
        private readonly RedisHelperNew imgInfoDB;
        private readonly RedisHelperNew locDB;


        private int getFaultInd;
        private int getImgInd;

        private SqliteHelper mainDB = null;
        private SqliteHelper currDB = null;



        static Redis2Sqlite() {
            m_sGeoDbId = 9;
            m_sImgDbId = 10;               //图像二进制存储数据库Id
            m_sInfoDbIdx = 11;              //图像信息数据库Id
            m_sAIFaultDbId = 12;                //智能识别缺陷数据库Id.
            IMemLimit = 20480;                                      //MemLimit:内存限制 （单位M)
            ISaveImgNumByOnce = 100;                                //一次事务处理的的图像数量
            IDelDataByOnce = 200;                                   //一次删除的图像数据
            ISaveGeoDataNumByOnce = 10;                             //一次事务处理的几何参数数据大小
            IImgNumTwoPole = 50;
            ISubDbSize = Settings.Default.SubDbSize;
        }
        public Redis2Sqlite(string serveIP, string DBPath, string DBBackPath = "") {
            m_sIpAddr = serveIP;                                    //ip		
            m_sDBFullName = DBPath;                                 //db路径+名称
            m_sDBBackPath = DBBackPath;

            imgDB = new RedisHelperNew(m_sImgDbId);
            imgInfoDB = new RedisHelperNew(m_sInfoDbIdx);
            locDB = new RedisHelperNew(m_sAIFaultDbId);


            //创建索引数据库-- 主数据库
            createIndexDB();
            curDBIndex = Settings.Default.currDBIndex; //当前分库下标
            createCurrentDB();
            isLogSubDb = false;
            saveImgNum = saveFaultNum = 0;
        }
        /// <summary>
        /// 创建主索引表
        /// </summary>
        private void createIndexDB() {
            mainDB = SqliteHelper.GenerateSqlite("mainDB", m_sDBFullName + "_m.db");
            if (mainDB.IsTableExist("indexTB")) {
                return;
            }

            string strTB = "create table indexTB (id int primary key ,begImgGUID INT64," +
                "endImgGUID INT64, begPoleNum varchar(50),endPoleNum varchar(50),begKMV varchar(50),endKMV varchar(50)," +
                "imgCount  int, locFaultInfo int)";
            mainDB.ExecuteNonQuery(strTB);

            strTB = "CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY AUTOINCREMENT,sLineName varchar(50),sStartStation varchar(50),sEndStation varchar(50),sType tinyint,taskDate DATE );";
            mainDB.ExecuteNonQuery(strTB);
        }

        /// <summary>
        /// 创建分表
        /// </summary>
        private void createCurrentDB() {
            try {
                //var oldDB = SqliteHelper.GetSqlite("currDB");
                //if (oldDB != null) {

                //}

                currDB = SqliteHelper.GenerateSqlite("currDB", m_sDBFullName + $"_{++curDBIndex}.db");
                if (currDB.IsTableExist("indexTB")) {
                    return;
                }
                //创建 图像表
                string strCreateImgTb = "CREATE TABLE picInfo(imgGUID INT64 PRIMARY KEY ,cId INTEGER,shootTime INT64,poleNum TEXT,KMValue TEXT,STN TEXT,imgContent BLOB,sJson TEXT );";
                currDB.ExecuteNonQuery(strCreateImgTb);
                //创建定位缺陷表 
                string sCreateLocFaultTB = "CREATE TABLE locFaultInfo(imgGUID INT64 PRIMARY KEY ,ExistFault INTEGER,sJson TEXT);";
                currDB.ExecuteNonQuery(sCreateLocFaultTB);

                //创建 缺陷表
                string strCreateFaultTB = "create table FaultInfo( pId INT64 primary key,imgGUID INT64,unitId int,fault varchar(255),mark varchar(100),faultLevel varchar(5),";
                strCreateFaultTB += "isAI int DEFAULT 1, analyzeDate datetime NOT NULL DEFAULT(datetime('now', 'localtime')),";
                strCreateFaultTB += " confirmDate datetime, confirmUser varchar(50), confirmResult int DEFAULT -1, memo varchar(100) )";

                currDB.ExecuteNonQuery(strCreateFaultTB);

                Settings.Default.currDBIndex = curDBIndex;
                Settings.Default.Save();
                isLogSubDb = false;
                getImgInd = getFaultInd = 0;
            } catch (Exception e) {
                currDB.CloseDb();
                MessageBox.Show("分表创建失败\n" + e.ToString());
            }
        }
        public void ToSqlite() {
            ExecProc = true;
            getImgInd = getFaultInd = 0;
            try {
                while (ExecProc) {
                    string[] keys = imgInfoDB.ListRange("list", getImgInd, getImgInd + ISaveImgNumByOnce);
                    Console.WriteLine($"读取图像数据：[{keys.Length}]");
                    if (keys == null || keys.Length == 0) {
                        Console.WriteLine($"#=== 已持久化图像数据信息共：{keys.Length}条! \t 等待新数据写入......\n");
                    }
                    //下一次取图像全局ID的起始值
                    getImgInd += keys.Length;
                    saveImgNum += keys.Length;
                    //写入图片信息
                    WriteImgAndInfo(keys);
                    //写入定位与缺陷信息
                    WriteFaultDb();
                    #region  内存监控

                    double usedMEM = RedisHelperNew.GetUsedMem();
                    Console.WriteLine($"#================ 已经使用内存:{usedMEM}M ================#");
                    if (usedMEM > IMemLimit) {
                        RemoveMEM();
                    }
                    Console.WriteLine($"#================ 已经使用内存(删除数据后）:{RedisHelperNew.GetUsedMem()}M ================#");
                    #endregion

                    if (getImgInd > ISubDbSize - IImgNumTwoPole) {
                        createCurrentDB(); //分库
                    }
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
        /// <summary>
        /// 清除内存
        /// </summary>
        public void RemoveMEM() {
            Console.WriteLine($"#--- 超过内存限制({IMemLimit} M)，开始清除内存 .....");
            //====== 清除内存，注意没有持久化的数据不能删除 ======/
            Int64 iEndDelIdx = IDelImgIdx + IDelDataByOnce;
            if (iEndDelIdx > getImgInd) {
                iEndDelIdx = getImgInd;
            }
            try {
                string[] keys = imgInfoDB.ListRange("list", IDelImgIdx, iEndDelIdx);
                if (keys == null || keys.Length == 0) {
                    Console.WriteLine($"#--- 无数据删除，等待数据持久化...");
                    return;
                }
                IDelImgIdx = iEndDelIdx;
                //算法修改，每次删除完数据后 将list[0]的值修改为未删除数据的list编号
                imgInfoDB.ListLeftPush("list", IDelImgIdx);
                foreach (var imgKey in keys) {
                    imgDB.KeyDelete(imgKey);
                    Console.WriteLine($"#--- {imgKey} 删除成功！\t");
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
        public void WriteImgAndInfo(string[] keys) {
            currDB.OpenDb();
            currDB.BeginTransaction();
            try {
                PicInfo picInfo = null;
                int i = 0;
                //遍历所有的 imgKey
                foreach (var imgKey in keys) {
                    //获取所有的图像信息
                    string sJson = imgInfoDB.StringGet(imgKey);
                    //获取所有的图像
                    byte[] img = imgDB.GetByte(imgKey);
                    picInfo = JsonHelper.GetModel<PicInfo>(sJson);
                    SQLiteParameter sqlparm = new SQLiteParameter();
                    if (!isLogSubDb) {
                        mainDB.ExecuteNonQuery($"insert into indexTB values({curDBIndex},{imgKey},0,'{picInfo.POL}',null,'{picInfo.KMV}',null,0,0)");
                        isLogSubDb = true;
                    }
                    //写入数据库
                    string strSQL = $"INSERT INTO picInfo(imgGUID,cId,shootTime,poleNum,KMValue,STN,imgContent,sJson) " +
                        $"VALUES({imgKey},{picInfo.CID},{picInfo.TIM},'{picInfo.POL}','{picInfo.KMV}','{picInfo.STNUTF}',@img,@sJson)";
                    SQLiteParameter[] parameters = { new SQLiteParameter("@img", DbType.Binary), new SQLiteParameter("@sJson", DbType.String) };
                    parameters[0].Value = img;
                    parameters[1].Value = sJson;
                    try {
                        currDB.ExecuteNonQueryByTran(strSQL, parameters);
                    } catch {
                    }
                    Console.WriteLine(++i);
                }
                currDB.Commit();
                if (picInfo != null) {
                    //修改索引表
                    string str = $"update indexTB set endImgGUID={keys[keys.Length - 1]},endPoleNum='{picInfo.POL}',endKMV='{picInfo.KMV}',imgCount={saveImgNum} where id={curDBIndex}";
                    mainDB.ExecuteNonQuery(str);
                }
            } catch (Exception e) {
                Console.WriteLine("图像&信息写入失败！\n" + e.ToString());
                currDB.Rollback();
            } finally {
                currDB.CloseDb();
            }
        }

        public void WriteFaultDb() {
            string[] keys = locDB.ListRange("list", getFaultInd, getFaultInd + ISaveImgNumByOnce);
            if (keys == null || keys.Length == 0) {
                Console.WriteLine($"#=== 已持久化定位信息共：{getFaultInd}条(缺陷信息：{IFaultNum}条)! \t 等待新数据写入......\n\n");
                return;
            }
            Console.WriteLine($"#=== 读取定位缺陷信息{keys.Length}");
            List<LocFaultInfo> lsFault = new List<LocFaultInfo>();
            //修改起步ID编号
            getFaultInd += keys.Length;
            saveFaultNum += keys.Length;

            SqliteHelper.GetSqlite("mainDB").OpenDb();
            currDB.OpenDb();
            currDB.BeginTransaction();
            try {
                foreach (var locKey in keys) {

                    string sJson = locDB.StringGet(locKey);
                    List<LocFaultInfo> lsUnit = LocFaultInfo.getLstUnitPos(sJson);
                    //遍历事务写入缺陷信息
                    foreach (var locInfo in lsUnit) {
                        if (locInfo.IsFault) {
                            locInfo.setImgGUID(Int64.Parse(locKey));
                            lsFault.Add(locInfo);
                        }
                    }
                    string strSQL = $"INSERT INTO locFaultInfo(imgGUID,sJson,ExistFault) VALUES({locKey},{sJson},{lsFault.Count > 0})";
                    currDB.ExecuteNonQueryByTran(strSQL, null);
                }
                currDB.Commit();
                mainDB.ExecuteNonQuery($"update picInfo set locFaultInfo={saveFaultNum} where id={curDBIndex}");

            } catch (Exception e) {
                Console.WriteLine("#---定位信息写入失败！\n" + e.ToString());
                currDB.Rollback();
            } finally {
                currDB.CloseDb();
            }
            //写入 缺陷信息
            if (lsFault.Count > 0) {
                currDB.OpenDb();
                currDB.BeginTransaction();
                try {
                    foreach (var fault in lsFault) {
                        string strSQL = $"INSERT INTO FaultInfo(pId,imgGUID,unitId,fault,mark) " +
                            $"VALUES({fault.ID},{fault.UnitId},{fault.getImgGUID()},{fault.Fault},{fault.Mark})";
                        currDB.ExecuteNonQueryByTran(strSQL, null);
                    }
                } catch (Exception e) {
                    Console.WriteLine("#---缺陷信息写入失败！\n" + e.ToString());
                    currDB.Rollback();
                    throw;
                } finally {
                    currDB.CloseDb();
                }
            }

        }
    }


}