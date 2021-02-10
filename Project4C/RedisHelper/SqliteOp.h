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
	static bool isBeginTran; //�Ƿ���������
	static FILE* logfp;
	static bool isLog;
	static sqlite3_stmt *stmt;
	
	//��Ա����
	const int iBulkInsertNum = 100; //���������ͼƬ����
	const string sPicInfoDb = "PicInfoDb.db";
	char *zErrMsg;
	
	SqliteOp();
	~SqliteOp();
	
public:
	//Singleton
	static SqliteOp *getInstance() { //2.�ṩȫ�ַ��ʵ�
		static SqliteOp m_singletonConfig; //3.c++11��֤�˶��̰߳�ȫ�������˳�ʱ���ͷ���Դ
		return &m_singletonConfig;
	}
	static void OpenLog() {
		isLog = true;
		logfp = fopen("insertImg.log","wb");
	}
public:

	
	sqlite3 *PicInfoDb;
	static  int callback(void *NotUsed, int argc, char **argv, char **azColName);

	//˽�еĴ������ݿ⣬�û��޷����á������ݿ�����򷵻أ����򴴽����ݿ�ͱ�
	bool createTB();
	//�����ݿ�
	bool openDB();
	bool closeDB();
	/*
	** ���뵥��ͼ���ļ� -- ִ��׼��
	*/
	bool insertImg(long long int imgGUID, const uchar* imgByte, const int blobSize);

	/*
	** �жϱ��Ƿ����
	** strTableName ������	
	*/
	bool IsTableExist(const char* strTableName);

#pragma region ������

	/*
	** ����������
	*/
	bool transaction();
	/*
	** �ύ������
	*/
	bool commitTransaction();
	/*
	** �ع�������
	*/
	bool rollbackTransaction();

	bool endTranscation();
#pragma endregion



};

