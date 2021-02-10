#pragma once
#include "Datatype.h"
#include "sqlite3.h"
#include <vector>
#pragma comment(lib,"sqlite3.lib")

//#define GEOParse//���弸�β���
#define FAULTParse//����ȱ�ݲ���
using namespace std;
class SqliteHelper {


private:

	//��Ա����

	static bool isLog;
	bool isOpen; //���ݿ��Ƿ��
	bool isBeginTran; //�Ƿ���������

	int iBulkInsertNum; //���������ͼƬ����
	int iBulkInsertGeoNum; //�������뼸�β��� ����
	int iImgCount;
	const char* pStrDbPath; //sqliteλ��
	char *zErrMsg;

	sqlite3 *PicInfoDb;
	sqlite3_stmt *stmt;
	ResCode createTB();//������
	ResCode executeNonQuery(const char*sqlStr);
	bool IsTableExist(const char* strTableName);

	static int callback(void *pHandle, int iRet, char **szSrc, char **azColName);





public:
	SqliteHelper();
	~SqliteHelper();
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
public:

	//Singleton
	//static SqliteHelper *getInstance() { //2.�ṩȫ�ַ��ʵ�
	//	static SqliteHelper m_singletonConfig; //3.c++11��֤�˶��̰߳�ȫ�������˳�ʱ���ͷ���Դ
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
	///�����ݿ�
	//pstrFileName sqlite���ݿ��ļ�
	//bNew �ļ�����ʱ���Ƿ񴴽����ļ�
	bool Open(const char* pstrFileName, bool bNew, int syn);

	///����ͼ��
	// pData: 	jpeg�ļ�����
	// iLength��	jpeg�ļ����ݴ�С
	// strJason:	ͼƬ�����Ϣ
	bool AddImage(__int64 iImgGUID, unsigned char* pData, int iLength, const char* strJason);

	/**
	** д��·��Ϣ
	*/
	bool AddStation(const char*  strJson);

	/*
	** �־û���λ��ȱ����Ϣ
	** iImgGUIDs ͼ��id����
	** sJsons json�ַ�������
	** uSize �����С
	** ���أ� ȱ��������
	*/
	long AddLocFault(tFault*arrtFault, uint32_t uSize);

	bool AddFault(vector<tFault*>&vFault);

	bool AddGeo(__int64 gId, const char* sJson);
	bool AddGeoByArray(__int64 gId, const char* sJson);
	//�ر����ݿ�
	bool Close();

	//���߱������ݿ�
	int BackupDb(
		sqlite3 *pDb,               /* Database to back up */
		const char *zFilename,      /* Name of file to back up to */
		void(*xProgress)(int, int)  /* Progress function to invoke */
	);


};

