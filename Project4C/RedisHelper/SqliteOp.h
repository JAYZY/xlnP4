#pragma once


#include <string>
#include <iostream>
#include <stdlib.h>  
#include <stdio.h>
#include "sqlite3.h" 

using namespace std;
typedef unsigned char uchar;
class SqliteOp
{
private:
	static long long int iInsertImgCount;
	static bool isOpen;	
	static bool isBeginTran; //是否开启事务处理
	static FILE* logfp;
	static bool isLog;
	static sqlite3_stmt *stmt;
	
	//成员参数
	const int iBulkInsertNum = 100; //批量插入的图片个数
	const string sPicInfoDb = "PicInfoDb.db";
	char *zErrMsg;
	
	SqliteOp();
	~SqliteOp();
	
public:
	//Singleton
	static SqliteOp *getInstance() { //2.提供全局访问点
		static SqliteOp m_singletonConfig; //3.c++11保证了多线程安全，程序退出时，释放资源
		return &m_singletonConfig;
	}
	static void OpenLog() {
		isLog = true;
		logfp = fopen("insertImg.log","wb");
	}
public:

	
	sqlite3 *PicInfoDb;
	static  int callback(void *NotUsed, int argc, char **argv, char **azColName);

	//私有的创建数据库，用户无法调用。若数据库存在则返回，否则创建数据库和表
	bool createTB();
	//打开数据库
	bool openDB();
	bool closeDB();
	/*
	** 插入单张图像文件 -- 执行准备
	*/
	bool insertImg(long long int imgGUID, const uchar* imgByte, const int blobSize);

	/*
	** 判断表是否存在
	** strTableName 表名称	
	*/
	bool IsTableExist(const char* strTableName);

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



};

