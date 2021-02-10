#pragma once
#include "Datatype.h"
#include "sqlite3.h"
#include <vector>
#pragma comment(lib,"sqlite3.lib")

//#define GEOParse//定义几何参数
#define FAULTParse//定义缺陷参数
using namespace std;
class SqliteHelper {


private:

	//成员参数

	static bool isLog;
	bool isOpen; //数据库是否打开
	bool isBeginTran; //是否开启事务处理

	int iBulkInsertNum; //批量插入的图片个数
	int iBulkInsertGeoNum; //批量插入几何参数 个数
	int iImgCount;
	const char* pStrDbPath; //sqlite位置
	char *zErrMsg;

	sqlite3 *PicInfoDb;
	sqlite3_stmt *stmt;
	ResCode createTB();//创建表
	ResCode executeNonQuery(const char*sqlStr);
	bool IsTableExist(const char* strTableName);

	static int callback(void *pHandle, int iRet, char **szSrc, char **azColName);





public:
	SqliteHelper();
	~SqliteHelper();
#pragma region 事务处理

	/*
	** 开启事务处理
	*/
	bool transaction();
	/*
	** 提交事务处理
	*/
	bool commitTransaction();
	/*
	** 回滚事务处理
	*/
	bool rollbackTransaction();

	bool endTranscation();
#pragma endregion
public:

	//Singleton
	//static SqliteHelper *getInstance() { //2.提供全局访问点
	//	static SqliteHelper m_singletonConfig; //3.c++11保证了多线程安全，程序退出时，释放资源
	//	return &m_singletonConfig;
	//}

	static void OpenLog() {
		isLog = true;
	}

	void SetBulkNum(int num) {
		iBulkInsertNum = num;
	}

	void SetGeoBulkNum(int num) {
		iBulkInsertGeoNum = num;
	}
	///打开数据库
	//pstrFileName sqlite数据库文件
	//bNew 文件存在时候是否创建新文件
	bool Open(const char* pstrFileName, bool bNew, int syn);

	///插入图像
	// pData: 	jpeg文件数据
	// iLength：	jpeg文件数据大小
	// strJason:	图片相关信息
	bool AddImage(__int64 iImgGUID, unsigned char* pData, int iLength, const char* strJason);

	/**
	** 写线路信息
	*/
	bool AddStation(const char*  strJson);

	/*
	** 持久化定位和缺陷信息
	** iImgGUIDs 图像id数组
	** sJsons json字符串数组
	** uSize 数组大小
	** 返回： 缺陷总条数
	*/
	long AddLocFault(tFault*arrtFault, uint32_t uSize);

	bool AddFault(vector<tFault*>&vFault);

	bool AddGeo(__int64 gId, const char* sJson);
	bool AddGeoByArray(__int64 gId, const char* sJson);
	//关闭数据库
	bool Close();

	//在线备份数据库
	int BackupDb(
		sqlite3 *pDb,               /* Database to back up */
		const char *zFilename,      /* Name of file to back up to */
		void(*xProgress)(int, int)  /* Progress function to invoke */
	);


};

