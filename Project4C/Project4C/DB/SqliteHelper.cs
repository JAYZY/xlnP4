using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Project4C.DB {
    class SqliteHelper1 {


        public string dbFullName = "";// Environment.CurrentDirectory + "\\Data\\FaultDB.db";
        public static string date = ""; //日期
        public static string lineName = ""; //线路名称


        #region 单例+查找
        private static Dictionary<string, SqliteHelper1> mapSqlite = new Dictionary<string, SqliteHelper1>();
        public static SqliteHelper1 GenerateSqlite(string strName, string dbPath, string sPwd = "") {
            //if (!mapSqlite.ContainsKey(strName))
            mapSqlite[strName] = new SqliteHelper1(dbPath);
            if (!string.IsNullOrEmpty(sPwd)) {
                mapSqlite[strName].setPwd(sPwd);
            }
            return mapSqlite[strName];
        }
        public static void CreateDbWithPwd(string dbPath, string sPwd) {
            SQLiteConnection cnn = null;
            try {
                SQLiteConnection.CreateFile(dbPath);
                cnn = new SQLiteConnection("Data Source=" + dbPath);
                cnn.Open();
                cnn.ChangePassword(sPwd);

            } catch (Exception) {
                MessageBox.Show("用户数据库未找到！请联系管理员");
            } finally {
                cnn.Close();
            }
        }
        private SqliteHelper1(string dbPath) {
            dbFullName = dbPath;
            con = new SQLiteConnection("Data Source = " + dbPath);
            sPwd = null;
        }

        public static SqliteHelper1 GetSqlite(string strName) {
            if (!mapSqlite.ContainsKey(strName)) {
                return null;
            }
            return mapSqlite[strName];
        }

        #endregion

        private SQLiteConnection con;
        private string sPwd;

        public void setPwd(string _sPwd) {
            con.SetPassword(sPwd);
            this.sPwd = _sPwd;
        }
        private void OpenDb() {
            if (con.State != ConnectionState.Open) {
                try {
                   
                    if (!string.IsNullOrEmpty(this.sPwd)) {
                        con.SetPassword(this.sPwd);
                    }
                    con.Open();
                } catch (Exception ex) {
                    MessageBox.Show("数据库文件:" + dbFullName + ",打开失败！请检查文件是否被占用！\n" + ex.ToString());
                }
            }
        }

        private void CloseDb() {
            if (con.State == ConnectionState.Open) {
                con.Close();
            }
        }



        /// <summary>
        /// 创建缺陷表
        /// </summary>
        public void CreateFaultTb(string sDbFullPath) {
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + sDbFullPath)) {
                try {
                    cn.Open();
                    if (IsFieldExist("FaultRecode", "ImgB", cn)) {
                        return;
                    }
                    using (SQLiteCommand command = new SQLiteCommand(cn)) {
                        command.CommandText = "drop table if exists FaultRecode";
                        command.ExecuteNonQuery();
                        command.CommandText = "create TABLE FaultRecode(rid INTEGER primary key ,pid TEXT,uid INTEGER,fid INTEGER,fLevel char(10),analyzeDate DATETIME,comfirmDate DATETIME,OffsetX INTEGER NOT NULL,OffsetY INTEGER NOT NULL,width INTEGER NOT NULL,height INTEGER NOT NULL,memo text, faultCamId INTEGER,ImgA BLOB,ImgB BLOB);";
                        command.ExecuteNonQuery();
                    }
                } catch {
                    MessageBox.Show("数据库文件:" + dbFullName + " 打开失败！请检查文件是否被占用！");
                }
            }
        }
        //---添加表
        public void CreateTable() {

            OpenDb();
            using (SQLiteCommand cmd = new SQLiteCommand(con)) {
                cmd.CommandText = "drop table if exists pictureInfo";
                cmd.ExecuteNonQuery(); //--PRIMARY KEY
                cmd.CommandText = "CREATE TABLE pictureInfo(pId INTEGER PRIMARY KEY AUTOINCREMENT, shootTime INTEGER,poleNum INTEGER,KMValue INTEGER ,sId INTEGER, areaType INTEGER,imgContent BLOG)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY AUTOINCREMENT, sName varchar(50),sType tinyint,taskDate DATETIME NOT NULL)";
                cmd.ExecuteNonQuery();
            }
            CloseDb();
        }


        public int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters) {
            int affectedRows = 0;
            OpenDb();
            using (DbTransaction transaction = con.BeginTransaction()) {
                using (SQLiteCommand cmd = new SQLiteCommand(con)) {
                    cmd.CommandText = sql;
                    if (parameters != null) {
                        cmd.Parameters.AddRange(parameters);
                    }
                    affectedRows = cmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            CloseDb();
            return affectedRows;
        }
        /// <summary>
        /// 事务查询 返回值
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string cmdText, params SQLiteParameter[] parameters) {
            var dt = new DataTable();
            OpenDb();
            using (DbTransaction transaction = con.BeginTransaction()) {
                using (SQLiteCommand cmd = new SQLiteCommand(con)) {
                    try {
                        cmd.CommandText = cmdText;
                        if (parameters != null) {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        transaction.Commit();
                        dt.Load(reader);
                    } catch (Exception) {
                        dt = null;
                    } finally {
                        CloseDb();
                    }
                }

            }
            return dt;
        }
        /// <summary>
        /// 准备操作命令参数
        /// </summary>
        /// <param name="cmd">SQLiteCommand</param>
        /// <param name="cn">SQLitePicInfoDbection</param>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        private void PrepareCommand(SQLiteCommand cmd, string cmdText, Dictionary<String, String> data) {

            OpenDb();
            cmd.Parameters.Clear();
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (data != null && data.Count >= 1) {
                foreach (KeyValuePair<String, String> val in data) {
                    cmd.Parameters.AddWithValue(val.Key, val.Value);
                }
            }
        }

        /// <summary>
        /// 返回一行数据
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        /// <returns>DataRow</returns>
        public DataRow ExecuteDataRow(string cmdText, Dictionary<string, string> data) {
            DataSet ds = ExecuteDataset(cmdText, data);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                return ds.Tables[0].Rows[0];
            }

            return null;
        }

        /// <summary>
        /// 查询，返回DataSet
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataset(string cmdText, Dictionary<string, string> data) {
            var ds = new DataSet();
            OpenDb();

            using (SQLiteCommand command = new SQLiteCommand(con)) {
                try {
                    PrepareCommand(command, cmdText, data);
                    var da = new SQLiteDataAdapter(command);
                    da.Fill(ds);
                } catch (Exception) {
                    CloseDb();
                    command.Dispose();
                }
            }
            CloseDb();
            return ds;
        }

        /// <summary>
        /// 查询，返回DataTable
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        /// <returns>DataTable</returns>
        //public DataTable ExecuteDataTable(string cmdText, Dictionary<string, string> data) {
        //    var dt = new DataTable();
        //    OpenDb();
        //    using (SQLiteCommand command = new SQLiteCommand(con)) {
        //        try {
        //            PrepareCommand(command, cmdText, data);
        //            SQLiteDataReader reader = command.ExecuteReader();
        //            dt.Load(reader);
        //        } catch {
        //            CloseDb();
        //            command.Dispose();
        //            dt = null;
        //        }
        //    }
        //    CloseDb();
        //    return dt;
        //}
        /// <summary>
        /// 返回SqlDataReader对象
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">传入的参数</param>
        /// <returns>SQLiteDataReader</returns>
        public SQLiteDataReader ExecuteReader(string cmdText, Dictionary<string, string> data) {
            SQLiteDataReader reader = null;
            OpenDb();
            using (SQLiteCommand command = new SQLiteCommand(con)) {
                try {
                    PrepareCommand(command, cmdText, data);
                    reader = command.ExecuteReader();
                } catch {
                    command.Dispose();
                } finally {
                    CloseDb();
                }
            }
            return reader;

        }




        #region Trans(事务处理)
        public static void BeginTransaction(SQLiteCommand cmd) {
            cmd.CommandText = "begin transaction;";
            cmd.ExecuteNonQuery();
        }

        public static void Commit(SQLiteCommand cmd) {
            cmd.CommandText = "commit;";
            cmd.ExecuteNonQuery();
        }

        public static void Rollback(SQLiteCommand cmd) {
            cmd.CommandText = "rollback";
            cmd.ExecuteNonQuery();
        }


        private static List<SQLiteParameter> GetParametersList(Dictionary<string, object> dicParameters) {
            List<SQLiteParameter> lst = new List<SQLiteParameter>();
            if (dicParameters != null) {
                foreach (KeyValuePair<string, object> kv in dicParameters) {
                    lst.Add(new SQLiteParameter(kv.Key, kv.Value));
                }
            }
            return lst;
        }

        public object ExecuteScalar(string sql) {
            OpenDb();
            object obj = null;
            using (SQLiteCommand command = new SQLiteCommand(con)) {
                command.CommandText = sql;
                obj = command.ExecuteScalar();
            }
            CloseDb();
            return obj;
        }

        /// <summary>
        /// 返回结果集中的第一行第一列，忽略其他行或列
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">传入的参数</param>
        /// <returns>object</returns>
        public object ExecuteScalar(string cmdText, Dictionary<string, string> data) {
            OpenDb();
            object obj = null;
            using (SQLiteCommand cmd = new SQLiteCommand(con)) {
                PrepareCommand(cmd, cmdText, data);
                obj = cmd.ExecuteScalar();
            }
            CloseDb();
            return obj;
        }
        #endregion

        #region Select(查询相关)

        public bool IsTableExist(String tableName) {
            try {
                OpenDb();
                using (SQLiteCommand command = new SQLiteCommand(con)) {
                    command.CommandText = string.Format("select sql from sqlite_master where type = 'table' and name = '{0}'", tableName);
                    var rtn = command.ExecuteScalar();
                    if (rtn == null || String.IsNullOrEmpty(rtn.ToString())) {
                        return false;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(tableName + " 表存在检查失败！\n" + ex.ToString());
            } finally {
                CloseDb();
            }
            return true;
        }


        /// <summary>
        /// 判定表中字段是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        private bool IsFieldExist(String tableName, String fieldName, SQLiteConnection cn) {
            string tableCreateSql = "";
            try {
                using (SQLiteCommand command = new SQLiteCommand(cn)) {
                    if (cn.State != ConnectionState.Open) {
                        cn.Open();
                    }
                    command.CommandText = String.Format("select sql from sqlite_master where type = 'table' and name = '{0}'", tableName);
                    var rtn = command.ExecuteScalar();
                    if (rtn != null) {
                        tableCreateSql = rtn.ToString();
                    }
                }
            } catch (Exception ex) { MessageBox.Show(fieldName + " 字段检查失败\n" + ex.ToString()); }

            if (!string.IsNullOrEmpty(tableCreateSql) && tableCreateSql.Contains(fieldName)) {
                return true;
            }

            return false;
        }



        #endregion


        public int Insert(List<string> files) {
            System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
            int result = 0;

            using (SQLiteConnection cn = new SQLiteConnection("data source=" + dbFullName)) {
                using (SQLiteCommand cmd = cn.CreateCommand()) {
                    cn.Open();
                    DbTransaction trans = cn.BeginTransaction();
                    int count = 0;
                    cmd.CommandText = "INSERT INTO pictureInfo(shootTime,poleNum,KMValue,areaType,imgContent,sid) VALUES(@shootTime,@poleNum,@KMValue,@areaType,@imgContent,1)";

                    foreach (var item in files) {
                        sp.Reset();
                        sp.Start();
                        string fileNameNoExt = Path.GetFileNameWithoutExtension(item);
                        Console.Write("save " + fileNameNoExt);
                        string[] str = fileNameNoExt.Split('_');
                        if (str.Length != 5) {
                            continue;
                        }
                        try {
                            try {
                                cmd.Parameters.Add("shootTime", DbType.Int64).Value = Int64.Parse(date + str[0] + str[4]);
                                cmd.Parameters.Add("poleNum", DbType.Int32).Value = Int32.Parse(str[2]);
                                cmd.Parameters.Add("KMValue", DbType.Int32).Value = Int32.Parse(str[1].Substring(1));
                                cmd.Parameters.Add("areaType", DbType.Int16).Value = Int32.Parse(str[3]);
                                cmd.Parameters.Add("imgContent", DbType.Binary).Value = FileOp.FileHelper1.getImageByte(item);
                            } catch (Exception) {
                                Console.WriteLine("格式有问题！");
                                continue;
                            }
                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                            if (0 == ++count % 1000) {
                                trans.Commit();
                                trans = cn.BeginTransaction();
                            }
                            sp.Stop();
                            Console.WriteLine(string.Format("{0}, {1}, {2}ms.", count, "---", sp.ElapsedMilliseconds));
                        } catch (Exception ex) {
                            trans.Rollback();//回滚事务
                            throw ex;
                        }
                    }
                }
            }
            return result;
        }

        public int InsertByParam(string sName, byte[] byData) {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            SQLiteParameter[] sp = new SQLiteParameter[2];
            sql.Clear();
            sql.Append("INSERT INTO Info (Name,Code) VALUES(@Name,@Code) \r\n");
            sp[0] = new SQLiteParameter("@p1", sName);
            sp[1] = new SQLiteParameter("@p2", byData);
            ExecuteNonQuery(sql.ToString(), sp);

            return result;
        }


    }
}
