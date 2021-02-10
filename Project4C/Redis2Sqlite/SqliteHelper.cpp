#include "pch.h"
#include "SqliteHelper.h"
#include <io.h>
#include <direct.h>
#include "rapidjson/document.h"
#include "rapidjson/prettywriter.h"  
#include "rapidjson/writer.h"
#include "rapidjson/stringbuffer.h"
#include "Datatype.h"
#include <Windows.h>
#include "UTN.h"
#include <vector>
using namespace rapidjson;

bool  SqliteHelper::isLog = false; //Ĭ��״̬��дlog�ļ� 
bool const isWriteFile = false;
string filePath;
SqliteHelper::SqliteHelper() {
	isOpen = false;
	isBeginTran = false;
	stmt = nullptr;
	iImgCount = 0;
	PicInfoDb = nullptr;
	iBulkInsertNum = 10;
}
static bool createDirectory(const std::string &folder) {
	const char  PATH_DELIMITER = '/';
	std::string folder_builder;
	std::string sub;
	sub.reserve(folder.size());
	for (auto it = folder.begin(); it != folder.end(); ++it) {
		//cout << *(folder.end()-1) << endl;
		const char c = *it;
		sub.push_back(c);
		if (c == PATH_DELIMITER || it == folder.end() - 1) {
			folder_builder.append(sub);
			if (0 != ::_access(folder_builder.c_str(), 0)) {
				// this folder not exist
				if (0 != ::_mkdir(folder_builder.c_str())) {
					// create failed
					return false;
				}
			}
			sub.clear();
		}
	}
	return true;
}

SqliteHelper::~SqliteHelper() {
	Close();
}

///�����ݿ�
//pstrFileName sqlite���ݿ��ļ�
//bNew �ļ�����ʱ���Ƿ񴴽����ļ�
bool SqliteHelper::Open(const char* pstrFileName, bool bNew, int syn) {
	if (isWriteFile) {
		filePath = pstrFileName;
		size_t posEnd = filePath.find_last_of('.');
		filePath = filePath.substr(0, posEnd) + "/";
		createDirectory(filePath.c_str());
	}

	pStrDbPath = pstrFileName;
	if (bNew) { //�������ļ�--ɾ�������ļ�
		Close();
		if (remove(pStrDbPath) != 0) {
			fprintf(stderr, "DbFile not exist!");
		}
		isOpen = false;
	}
	if (isOpen)
		return true;

	int r = sqlite3_open(AsciiToUtf8(pStrDbPath).c_str(), &PicInfoDb);// , SQLITE_OPEN_READWRITE | SQLITE_OPEN_CREATE, NULL);
	if (SQLITE_OK == r) {
		int ret = 0;
		if (syn < 2) {
			ret = (syn == 0) ? sqlite3_exec(PicInfoDb, "PRAGMA synchronous = OFF; ", 0, 0, 0)
				: sqlite3_exec(PicInfoDb, "PRAGMA synchronous = NORMAL; ", 0, 0, 0);
		}
		else {
			ret = sqlite3_exec(PicInfoDb, "PRAGMA synchronous = FULL; ", 0, 0, 0);
		}
		if (SQLITE_OK != ret) {
			fprintf(stderr, "���ݿ��ʧ��!\n synchronous����ʧ�ܣ�\n%s", sqlite3_errmsg(PicInfoDb));
			isOpen = false;
			return  false;
		}
		isOpen = true;
		if (!IsTableExist("picInfo")) {		//2.�жϱ��Ƿ���ڣ�
			createTB();
		}
		return true;
	}
	else {
		fprintf(stderr, "���ݿ��ʧ��!/n%s", sqlite3_errmsg(PicInfoDb));
		Close();
		return false;
	}
}

/*
** Perform an online backup of database pDb to the database file named
** by zFilename. This function copies 5 database pages from pDb to
** zFilename, then unlocks pDb and sleeps for 250 ms, then repeats the
** process until the entire database is backed up.
**
** The third argument passed to this function must be a pointer to a progress
** function. After each set of 5 pages is backed up, the progress function
** is invoked with two integer parameters: the number of pages left to
** copy, and the total number of pages in the source file. This information
** may be used, for example, to update a GUI progress bar.
**
** While this function is running, another thread may use the database pDb, or
** another process may access the underlying database file via a separate
** connection.
**
** If the backup process is successfully completed, SQLITE_OK is returned.
** Otherwise, if an error occurs, an SQLite error code is returned.
*/
int SqliteHelper::BackupDb(
	sqlite3 *pDb,               /* Database to back up */
	const char *zFilename,      /* Name of file to back up to */
	void(*xProgress)(int, int)  /* Progress function to invoke */
) {
	int rc;                     /* Function return code */
	sqlite3 *pFile;             /* Database connection opened on zFilename */
	sqlite3_backup *pBackup;    /* Backup handle used to copy data */

	/* Open the database file identified by zFilename. */
	rc = sqlite3_open(zFilename, &pFile);
	if (rc == SQLITE_OK) {

		/* Open the sqlite3_backup object used to accomplish the transfer */
		pBackup = sqlite3_backup_init(pFile, "main", pDb, "main");
		if (pBackup) {

			/* Each iteration of this loop copies 5 database pages from database
			** pDb to the backup database. If the return value of backup_step()
			** indicates that there are still further pages to copy, sleep for
			** 250 ms before repeating. */
			do {
				rc = sqlite3_backup_step(pBackup, 5);
				xProgress(
					sqlite3_backup_remaining(pBackup),
					sqlite3_backup_pagecount(pBackup)
				);
				if (rc == SQLITE_OK || rc == SQLITE_BUSY || rc == SQLITE_LOCKED) {
					sqlite3_sleep(250);
				}
			} while (rc == SQLITE_OK || rc == SQLITE_BUSY || rc == SQLITE_LOCKED);

			/* Release resources allocated by backup_init(). */
			(void)sqlite3_backup_finish(pBackup);
		}
		rc = sqlite3_errcode(pFile);
	}

	/* Close the database connection opened on database file zFilename
	** and return the result of this function. */
	(void)sqlite3_close(pFile);
	return rc;
}
bool SqliteHelper::AddGeo(__int64 gId, const char* sJson) {
	if (strlen(sJson) < 2) {
		cout << "��Ч������Ϣ���ݣ�" << endl;
		return false;
	}
	int ret = 0;
	//����json
	//1����json��ʽ�ַ���ת��
	/*{		id,  //int32  id
			ZIG1 ��// int32   ����ֵ1
			HEl1,   // int32  ����1
			ZIG2 ��// int32   ����ֵ2
			HEl2,   //  int32  ����2
			POS, //  int 32   ��λ����
			TIME�� // INT64  ʱ��
	}*/
	Document document;
	document.Parse<0>(sJson);
	//2,����JSONȡֵ	
	Value &ID = document["ID"];
	Value &ZIG1 = document["ZIG1"];
	Value &HEI1 = document["HEl1"];
	Value &ZIG2 = document["ZIG1"];
	Value &HEI2 = document["HEl2"];
	Value &POS = document["POS"];
	Value &TIME = document["TIME"];
	if (0 == iImgCount % iBulkInsertGeoNum) {
		//��������
		transaction();
		stmt = nullptr;
		zErrMsg = nullptr;
		//create table GeoData( geoId int64 primary key,ZIG1 integer,HEI1 integer,ZIG2 integer,HEI2 integer,POS integer,TIME INT64
		ret = sqlite3_prepare_v2(PicInfoDb, "INSERT INTO GeoData(TIME,ZIG1,HEI1,ZIG2,HEI2,POS) VALUES(?,?,?,?,?,?)", -1, &stmt, (const char **)&zErrMsg);
		if (SQLITE_OK != ret) {
			fprintf(stderr, "sqlite prepare error: %s\n", zErrMsg);
			sqlite3_free(zErrMsg);
			Close();
			return false;
		}
	}
	sqlite3_reset(stmt);
	ret = sqlite3_bind_int(stmt, 1, TIME.GetInt64());// ID
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int(stmt, 2, ZIG1.GetFloat());//ZIG1		
	}
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int(stmt, 3, HEI1.GetFloat());//HEI1		
	}
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int(stmt, 4, ZIG2.GetFloat());//ZIG2		
	}
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int(stmt, 5, HEI2.GetFloat());//HEI2		
	}
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int(stmt, 6, POS.GetInt());//POS����		
	}
	if (SQLITE_OK != ret) {
		fprintf(stderr, "SQLite bind error by GeoData: %d\n", ret);
		Close();
		return false;
	}
	ret = sqlite3_step(stmt);
	if (SQLITE_DONE != ret) {
		printf("%s", sqlite3_errmsg(PicInfoDb));
	}
	//------ �ύ���� --
	if (0 == (iImgCount + 1) % iBulkInsertGeoNum) {
		if (!this->endTranscation())
			return false;
	}
	else {
		++iImgCount;
	}
	return true;
}

//һ�ν���100������
bool SqliteHelper::AddGeoByArray(__int64 gId, const char* sJson) {
	if (strlen(sJson) < 2) {
		cout << "��Ч������Ϣ���ݣ�" << endl;
		return false;
	}
	int ret = 0;
	//����json
	//1����json��ʽ�ַ���ת��
	/*{		id,  //int32  id
			ZIG1 ��// int32   ����ֵ1
			HEl1,   // int32  ����1
			ZIG2 ��// int32   ����ֵ2
			HEl2,   //  int32  ����2
			POS, //  int 32   ��λ����
			TIME�� // INT64  ʱ��
	}*/
	Document dom;
	dom.Parse<0>(sJson);
	//��������
	transaction();
	stmt = nullptr;
	zErrMsg = nullptr;
	//create table GeoData( geoId int64 primary key,ZIG1 integer,HEI1 integer,ZIG2 integer,HEI2 integer,POS integer,TIME INT64
	ret = sqlite3_prepare_v2(PicInfoDb, "INSERT INTO GeoData(TIME,ZIG1,HEI1,ZIG2,HEI2,POS) VALUES(?,?,?,?,?,?)", -1, &stmt, (const char **)&zErrMsg);
	if (SQLITE_OK != ret) {
		fprintf(stderr, "sqlite prepare error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
		Close();
		return false;
	}

	if (dom.HasMember("geo") && dom["geo"].IsArray()) {
		const Value& arr = dom["geo"];
		for (uint32_t i = 0; i < arr.Size(); ++i) {
			const Value& obj = arr[i];
			//2,����JSONȡֵ	
			const Value &ID = obj["ID"];
			const Value &ZIG1 = obj["ZIG1"];
			const Value &HEI1 = obj["HEl1"];
			const Value &ZIG2 = obj["ZIG1"];
			const Value &HEI2 = obj["HEl2"];
			const Value &POS = obj["POS"];
			const Value &TIME = obj["TIME"];

			sqlite3_reset(stmt);
			ret = sqlite3_bind_int(stmt, 1, TIME.GetInt64());// ID
			if (SQLITE_OK == ret) {
				ret = sqlite3_bind_int(stmt, 2, ZIG1.GetFloat());//ZIG1		
			}
			if (SQLITE_OK == ret) {
				ret = sqlite3_bind_int(stmt, 3, HEI1.GetFloat());//HEI1		
			}
			if (SQLITE_OK == ret) {
				ret = sqlite3_bind_int(stmt, 4, ZIG2.GetFloat());//ZIG2		
			}
			if (SQLITE_OK == ret) {
				ret = sqlite3_bind_int(stmt, 5, HEI2.GetFloat());//HEI2		
			}
			if (SQLITE_OK == ret) {
				ret = sqlite3_bind_int(stmt, 6, POS.GetInt());//POS����		
			}
			if (SQLITE_OK != ret) {
				fprintf(stderr, "SQLite bind error by GeoData: %d\n", ret);
				Close();
				return false;
			}
			ret = sqlite3_step(stmt);
			if (SQLITE_DONE != ret) {
				printf("%s", sqlite3_errmsg(PicInfoDb));
			}
		}
		//------ �ύ���� ------
		if (!this->endTranscation())
			return false;
	}
	else {
		cout << "ȱ�ټ�����Ϣ���ݣ�" << endl;
		return false;
	}

	return true;
}
///����ͼ��
// pData: 	jpeg�ļ�����
// iLength��jpeg�ļ����ݴ�С
// strJason��ͼƬ�����Ϣ
bool SqliteHelper::AddImage(__int64 iImgGUID, unsigned char * pData, int iLength, const char * strJason) {
	if (strlen(strJason) < 2) {
		cout << "ͼ����ϢΪ��" << endl;
		return false;
	}

	/*int64_t  iImgGUID = timgInfo->iImgGUID;
	unsigned char * pData = timgInfo->arrImgData;
	int iLength = timgInfo->uImgDataLen;
	const char * strJason = timgInfo->sJson;*/
	//DWORD  timestart = GetTickCount();
	int ret = 0;
	//����json
	//1����json��ʽ�ַ���ת��
	//{"CID":2,"TIM":190519165853518,"GPS":"","POL":"-1","STA":0}
	Document document;
	document.Parse<0>(strJason);
	//2,ȡ���Լ���Ҫ��ֵ	
	Value &TIM = document["TIM"];//document["TIM"];
	Value &KMValue = document["KMV"]; //document["KMV"];
	Value &POL = document["POL"]; //document["POL"];
	Value &CID = document["CID"]; //document["CID"];
	Value &STN = document["STNUTF"];
	string fileName;
	int iCid = CID.GetInt();
	if (isWriteFile) {
		fileName = to_string(TIM.GetInt64()) + "_" + to_string(iCid) + ".jpg";
		FILE *pf = fopen((filePath + fileName).c_str(), "wb");
		fwrite(pData, 1, iLength, pf);
		//  GPS POL STA����Ϣд�����ݿ���
		fclose(pf);
	}
	if (0 == iImgCount % iBulkInsertNum) {
		//��������
		transaction();
		stmt = nullptr;
		zErrMsg = nullptr;
		ret = sqlite3_prepare_v2(PicInfoDb, "INSERT INTO picInfo(imgGUID,cId,shootTime,poleNum,KMValue,STN,imgContent,sJson) VALUES(?,?,?,?,?,?,?,?)", -1, &stmt, (const char **)&zErrMsg);
		if (SQLITE_OK != ret) {
			fprintf(stderr, "sqlite prepare error: %s\n", zErrMsg);
			sqlite3_free(zErrMsg);
			Close();
			return false;
		}
	}
	/*else if(cid> {
		fprintf(stderr, "Cid is error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
		Close();
		return false;
	}*/
	sqlite3_reset(stmt);
	ret = sqlite3_bind_int64(stmt, 1, iImgGUID);// imgGUID
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int(stmt, 2, iCid);//cid
		//fprintf(stdout, "cid: %d\n", iCid);
	}
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int64(stmt, 3, TIM.GetInt64());//shootTime
		//fprintf(stdout, "tim: %ld\n", TIM.GetInt64());
	}
	if (SQLITE_OK == ret) {
		const char* strPol = POL.GetString(); //poleNum		 
		ret = sqlite3_bind_text(stmt, 4, strPol, strlen(strPol), SQLITE_STATIC);
	}
	if (SQLITE_OK == ret) {
		const char* strKMV = KMValue.GetString();
		ret = sqlite3_bind_text(stmt, 5, strKMV, strlen(strKMV), SQLITE_STATIC);
	}
	if (SQLITE_OK == ret) {
		const char* strSTN = STN.GetString();
		if (strSTN == NULL)
			ret = sqlite3_bind_text(stmt, 6, "", 0, SQLITE_STATIC);
		else
			ret = sqlite3_bind_text(stmt, 6, strSTN, strlen(strSTN), SQLITE_STATIC);
	}
	if (SQLITE_OK == ret) {
		if (isWriteFile) {
			ret = sqlite3_bind_text(stmt, 7, fileName.c_str(), fileName.length(), SQLITE_STATIC);
		}
		else {
			ret = sqlite3_bind_blob(stmt, 7, pData, iLength, SQLITE_STATIC);
		}
	}if (SQLITE_OK == ret) {
		ret = sqlite3_bind_text(stmt, 8, strJason, strlen(strJason), SQLITE_STATIC);
		//cout << strJason << endl;
	}
	if (SQLITE_OK != ret) {
		fprintf(stderr, "sqlite bind error: %d\n", ret);
		Close();
		return false;
	}
	ret = sqlite3_step(stmt);
	if (SQLITE_DONE != ret) {
		printf("%s", sqlite3_errmsg(PicInfoDb));
	}
	//int timespan = (int)GetTickCount() - timestart;
	//fprintf(stdout, "# %d insert success,%d ms\n", iImgCount, timespan);
	//if (isLog&&logfp) {
	//	fprintf(logfp, "#%d insert success,%dms\n", imgCount, timespan);
	//}
	//------ �ύ���� --
	if (0 == (iImgCount + 1) % iBulkInsertNum) {
		if (!this->endTranscation())
			return false;
	}
	else {
		++iImgCount;
	}

	return true;
}


bool SqliteHelper::AddStation(const char*  strJason) {
	//����json 
	Document document;
	document.Parse<0>(strJason);
	//2,ȡ���Լ���Ҫ��ֵ
	Value &ID = document["sId"];
	Value &NAME = document["sName"];
	Value &TYPE = document["sType"];  //sType  ���ͣ�0 - վ����  1 - վ̨
	Value &DAT = document["taskDate"];
	Value &UPDOWN = document["updown"];// updown int 0 - ����   2 - ����
	string sName = NAME.GetString();
	int iType = TYPE.GetInt();
	int iUpdown = UPDOWN.GetInt();
	iType |= iUpdown;
	string sDate = DAT.GetString();

	transaction();
	stmt = nullptr;
	zErrMsg = nullptr;
	int ret = sqlite3_prepare_v2(PicInfoDb, "INSERT INTO stationInfo(sId,sName,sType,taskDate) VALUES(?,?,?,?)", -1, &stmt, (const char **)&zErrMsg);
	if (SQLITE_OK != ret) {
		fprintf(stderr, "sqlite prepare error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
		Close();
		return false;
	}
	sqlite3_reset(stmt);

	ret = sqlite3_bind_int(stmt, 1, ID.GetInt());
	if (SQLITE_OK == ret) {
		ret = sqlite3_bind_text(stmt, 2, sName.c_str(), sName.length(), SQLITE_STATIC);
	}
	else if (SQLITE_OK == ret) {
		ret = sqlite3_bind_int(stmt, 3, iType);
	}
	else if (SQLITE_OK == ret) {
		ret = sqlite3_bind_text(stmt, 4, sDate.c_str(), sDate.length(), SQLITE_STATIC);
	}
	else if (SQLITE_OK != ret) {
		fprintf(stderr, "sqlite bind error: %d\n", ret);
		Close();
		return false;
	}
	ret = sqlite3_step(stmt);
	if (SQLITE_DONE != ret) {
		printf("%s", sqlite3_errmsg(PicInfoDb));
	}
	sqlite3_finalize(stmt);
	if (!commitTransaction()) {
		rollbackTransaction();
		Close();
		return false;
	}
	return true;
}

long SqliteHelper::AddLocFault(tFault*arrtLocFault, uint32_t uSize) {
	DWORD  timestart = GetTickCount();
	int ret = 0;
	Document dom;
	//1.��������
	transaction();
	stmt = nullptr;
	zErrMsg = nullptr;
	ret = sqlite3_prepare_v2(PicInfoDb, "INSERT INTO locFaultInfo(imgGUID,sJson,ExistFault) VALUES(?,?,?)", -1, &stmt, (const char **)&zErrMsg);
	if (SQLITE_OK != ret) {
		fprintf(stderr, "sqlite prepare error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
		Close();
		return -1;
	}
	int64_t iImgGUID = 0;
	int isExistFault = 0;
	vector<tFault*>vFault; vFault.reserve(uSize);
	//uint32_t uFaultSize = 0;
	for (uint32_t i = 0; i < uSize; ++i) {
		//cout << "��ʼѭ��" << i << endl;
		iImgGUID = arrtLocFault[i].imgGUID;
		string  sJson = arrtLocFault[i].sFaultJson;
		trim(sJson);
		dom.Parse<0>(sJson.c_str());
		//2,����json�ж��Ƿ����ȱ��	
		if (dom.HasMember("seg") && dom["seg"].IsArray()) {
			const Value& arr = dom["seg"];
			for (uint32_t j = 0; j < arr.Size(); ++j) {
				const Value& obj = arr[j];
				const Value& fault = obj["Fault"];
				if (fault.IsArray()) {//�Ƿ����ȱ��
					int iFaultId = fault[0].GetInt();
					if (iFaultId > 0) {  //0 ��ʾ���� -1 ��ʾδ��� 
						isExistFault = 1;
						tFault* tfault = new tFault();
						tfault->imgGUID = iImgGUID;
						const Value&pId = obj["ID"];
						tfault->pId = stoll(to_string(pId.GetInt()) + "0");
						//cout << tfault->pId << endl;
						const Value&unitId = obj["unitId"];
						tfault->iUnitId = unitId.GetInt();

						const Value&faultIds = obj["Fault"];
						StringBuffer bufFault;
						Writer<StringBuffer> wrFault(bufFault);
						faultIds.Accept(wrFault);
						string str = bufFault.GetString(); trim(str);
						tfault->sFaultJson = str;

						const Value&mark = obj["mark"];
						StringBuffer bufMark;
						Writer<StringBuffer>wrMark(bufMark);
						mark.Accept(wrMark);
						str = bufMark.GetString(); trim(str);
						tfault->sMarkJson = str; //�ַ�������						
						vFault.push_back(tfault);
					}
				}
			}
		}

		//3.д��locFaultInfo
		sqlite3_reset(stmt);
		ret = sqlite3_bind_int64(stmt, 1, iImgGUID);// imgGUID
		if (SQLITE_OK == ret) {
			ret = sqlite3_bind_text(stmt, 2, sJson.c_str(), sJson.length(), SQLITE_STATIC);//sJsons
		}
		if (SQLITE_OK == ret) {
			ret = sqlite3_bind_int(stmt, 3, isExistFault);//isExistFault			
		}
		if (SQLITE_OK != ret) {
			fprintf(stderr, "sqlite bind error: %d\n", ret);
			Close();
			return -1;
		}
		ret = sqlite3_step(stmt);
		if (SQLITE_DONE != ret) {
			printf("%s", sqlite3_errmsg(PicInfoDb));
		}
		dom.Clear();
	}
	//4.��������
	sqlite3_finalize(stmt);
	if (!commitTransaction()) {
		rollbackTransaction();
		Close();
		return -1;
	}
	//5.�����Ϣ
	int timespan = (int)GetTickCount() - timestart;
	fprintf(stdout, "# insert LocFault success,%d ms\n", uSize, timespan);
	//6.�����µ�����д��ȱ��
	long ifaultNum = vFault.size();
	if (ifaultNum > 0) {
		AddFault(vFault);
		//�������,��ֹ�ڴ����
		for (int i = 0; i < vFault.size(); ++i) {
			delete vFault[i];
		}
	}
	return ifaultNum;
}



bool SqliteHelper::AddFault(vector<tFault*>&vFault) {
	if (vFault.empty())
		return false;
	DWORD  timestart = GetTickCount();
	int ret = 0;
	//1.��������
	transaction();
	stmt = nullptr;
	zErrMsg = nullptr;
	ret = sqlite3_prepare_v2(PicInfoDb, "INSERT INTO FaultInfo(pId,imgGUID,unitId,fault,mark) VALUES(?,?,?,?,?)", -1, &stmt, (const char **)&zErrMsg);
	if (SQLITE_OK != ret) {
		fprintf(stderr, "sqlite prepare error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
		Close();
		return false;
	}
	for (uint32_t i = 0; i < vFault.size(); ++i) {
		//3.д��locFaultInfo
		sqlite3_reset(stmt);
		tFault* fault = vFault[i];
		ret = sqlite3_bind_int64(stmt, 1, fault->pId);// imgGUID
		if (SQLITE_OK == ret) {
			ret = sqlite3_bind_int64(stmt, 2, fault->imgGUID);// imgGUID
		}
		if (SQLITE_OK == ret) {
			ret = sqlite3_bind_int(stmt, 3, fault->iUnitId);//isExistFault			
		}
		if (SQLITE_OK == ret) {
			ret = sqlite3_bind_text(stmt, 4, fault->sFaultJson.c_str(), fault->sFaultJson.length(), SQLITE_STATIC);//sJsons
		}
		if (SQLITE_OK == ret) {
			ret = sqlite3_bind_text(stmt, 5, fault->sMarkJson.c_str(), fault->sMarkJson.length(), SQLITE_STATIC);//sJsons
		}
		if (SQLITE_OK != ret) {
			fprintf(stderr, "sqlite bind error: %d\n", ret);
			Close();
			return false;
		}
		ret = sqlite3_step(stmt);
		if (SQLITE_DONE != ret) {
			printf("%s", sqlite3_errmsg(PicInfoDb));
		}
	}
	//4.��������
	sqlite3_finalize(stmt);
	if (!commitTransaction()) {
		rollbackTransaction();
		Close();
		return false;
	}
	//5.�����ϢDWORD  timestart = GetTickCount();
	int timespan = (int)GetTickCount() - timestart;
	fprintf(stdout, "# insert Fault success,%d ms\n", vFault.size(), timespan);
	return true;
}

//�ر����ݿ�
bool SqliteHelper::Close() {
	if (!isOpen)
		return true;
	endTranscation();
	if (SQLITE_OK == sqlite3_close(PicInfoDb)) {
		isOpen = false;
		return true;
	}
	else {
		fprintf(stderr, "can't close db!/n%s", sqlite3_errmsg(PicInfoDb));
		return false;
	}
}

/*
** ������
*/
ResCode SqliteHelper::createTB() {
	if (!isOpen) {
		return ResCode::CreateTbFailed;
	}
	int result;
	zErrMsg = nullptr;
	//���� ͼ��� pID ��shootTime����ʱ��
	string strCreateImgTb;
	if (isWriteFile) { //�����д�ļ��������ݿ�洢ͼ��·������洢ͼ�����������
		strCreateImgTb = "CREATE TABLE picInfo(imgGUID INT64 PRIMARY KEY , cId INTEGER,shootTime INT64,poleNum TEXT,KMValue TEXT,STN TEXT,imgContent TEXT);";
		result = sqlite3_exec(PicInfoDb, strCreateImgTb.c_str(), nullptr, nullptr, &zErrMsg);
		if (SQLITE_OK != result) {
			Close();
			sqlite3_free(zErrMsg);
			PicInfoDb = nullptr;
			std::clog << "������ʧ�ܣ�";
			return ResCode::CreateTbFailed;
		}
	}
	else {//pId ���;imgGUID cId ������; poleNum �˺�; KMValue �����
		strCreateImgTb = "CREATE TABLE picInfo(imgGUID INT64 PRIMARY KEY ,cId INTEGER,shootTime INT64,poleNum TEXT,KMValue TEXT,STN TEXT,imgContent BLOB,sJson TEXT );";
		result = sqlite3_exec(PicInfoDb, strCreateImgTb.c_str(), nullptr, nullptr, &zErrMsg);
		if (SQLITE_OK != result) {
			Close();
			sqlite3_free(zErrMsg);
			PicInfoDb = nullptr;
			std::clog << "������ʧ�ܣ�";
			return ResCode::CreateTbFailed;
		}
		/*strCreateImgTb = "CREATE TABLE picInfoB(pId INTEGER PRIMARY KEY ,cId INTEGER,shootTime INT64,poleNum TEXT,GPS TEXT,sId INTEGER,imgContent BLOB );";
		result = sqlite3_exec(PicInfoDb, strCreateImgTb.c_str(), nullptr, nullptr, &zErrMsg);
		if (SQLITE_OK != result) {
			Close();
			sqlite3_free(zErrMsg);
			PicInfoDb = nullptr;
			std::clog << "������ʧ�ܣ�";
			return ResCode::CreateTbFailed;
		}*/
	}
	//���� ��·��Ϣ�� pID ��shootTime����ʱ��
	string strCreateStationTB = "CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY AUTOINCREMENT,sLineName varchar(50),sStartStation varchar(50),sEndStation varchar(50),sType tinyint,taskDate DATE );";
	if (SQLITE_OK == result) {
		result = sqlite3_exec(PicInfoDb, strCreateStationTB.c_str(), nullptr, nullptr, &zErrMsg);
	}
#ifdef FAULTParse

	//������λȱ�ݱ� 

	//char *zErrMsg=nullptr;
	if (SQLITE_OK == result) {
		string sCreateLocFaultTB = "CREATE TABLE locFaultInfo(imgGUID INT64 PRIMARY KEY ,ExistFault INTEGER,sJson TEXT);";
		result = sqlite3_exec(PicInfoDb, sCreateLocFaultTB.c_str(), nullptr, nullptr, &zErrMsg);
	}
	if (SQLITE_OK == result) {
		//���� ȱ�ݱ�
		string strCreateFaultTB = "create table FaultInfo( pId INT64 primary key,imgGUID INT64,unitId int,fault varchar(255),mark varchar(100),faultLevel varchar(5),";
		strCreateFaultTB += "isAI int DEFAULT 1, analyzeDate datetime NOT NULL DEFAULT(datetime('now', 'localtime')),";
		strCreateFaultTB += " confirmDate datetime, confirmUser varchar(50), confirmResult int DEFAULT -1, memo varchar(100) )";
		result = sqlite3_exec(PicInfoDb, strCreateFaultTB.c_str(), nullptr, nullptr, &zErrMsg);
	}
#endif

#ifdef GEOParse
	//���� ���β�����
	if (SQLITE_OK == result) {
		string strCreateGeoTB = "create table GeoData( TIME INT64 primary key,ZIG1 integer,HEI1 integer,ZIG2 integer,HEI2 integer,POS integer)";
		result = sqlite3_exec(PicInfoDb, strCreateGeoTB.c_str(), nullptr, nullptr, &zErrMsg);
	}
#endif

	if (SQLITE_OK != result) {
		Close();
		sqlite3_free(zErrMsg);
		PicInfoDb = nullptr;
		std::clog << "������ʧ�ܣ�";
		return ResCode::CreateTbFailed;
	}
	std::clog << "�����ɹ�";
	return ResCode::SqliteOk;
}
/*
** ͨ�õ�sql����ִ��
*/
ResCode SqliteHelper::executeNonQuery(const char*sqlStr) {
	if (!isOpen) {
		return ResCode::ExecuteFailed;
	}
	int rc = sqlite3_exec(PicInfoDb, sqlStr, nullptr, 0, &zErrMsg);
	if (SQLITE_OK == rc) {
		sqlite3_free(zErrMsg);
		Close();
		return ResCode::SqliteOk;
	}
	else {
		Close();
		return ResCode::ExecuteFailed;
	}
}

int SqliteHelper::callback(void *pHandle, int iRet, char **szSrc, char **azColName) {

	if (1 == iRet) {
		int iTableExist = atoi(*(szSrc));  //�˴�����ֵΪ��ѯ��ͬ����ĸ�����û����Ϊ0���������0
		if (pHandle != nullptr) {
			int* pRes = (int*)pHandle;
			*pRes = iTableExist;
		}
		// szDst ָ�������Ϊ"count(*)"
	}
	return 0;
}
bool SqliteHelper::IsTableExist(const char* strTableName) {
	if (!isOpen)
		return false;
	string strFindTable = "SELECT COUNT(*) FROM sqlite_master where type ='table' and name ='";
	strFindTable += strTableName;
	strFindTable += "'";
	//void *pHandle = ***;
	int nTableNums = 0;
	if (sqlite3_exec(PicInfoDb, strFindTable.c_str(), &callback, &nTableNums, &zErrMsg) != SQLITE_OK) {
		return false;
	}
	//�ص������޷���ֵ����˴���һ��ʱ����SQLITE_OK�� ��n�λ᷵��SQLITE_ABORT
	return nTableNums > 0;
}

#pragma region ������
//����������
bool SqliteHelper::transaction() {
	bool result = true;
	zErrMsg = NULL;
	/*int ret = sqlite3_exec(PicInfoDb, "PRAGMA synchronous = OFF; ", 0, 0, 0);
	if (SQLITE_OK == ret)*/
	int	ret = sqlite3_exec(PicInfoDb, "begin transaction", 0, 0, &zErrMsg); // ��ʼһ������
	if (SQLITE_OK != ret) {
		printf("start transaction failed:%s", zErrMsg);
		result = false;
	}
	sqlite3_free(zErrMsg);
	isBeginTran = true;
	return result;
}

//�ύ������
bool SqliteHelper::commitTransaction() {
	if (!isBeginTran) return false;
	bool result = true;
	zErrMsg = NULL;
	int ret = sqlite3_exec(PicInfoDb, "commit transaction", 0, 0, &zErrMsg); // �ύ����
	if (ret != SQLITE_OK) {
		printf("commit transaction failed:%s", zErrMsg);
		result = false;
	}
	sqlite3_free(zErrMsg);
	isBeginTran = false;
	return result;
}

//�ع�������
bool SqliteHelper::rollbackTransaction() {
	bool result = true;
	zErrMsg = NULL;
	int     ret = sqlite3_exec(PicInfoDb, "rollback transaction", 0, 0, &zErrMsg);
	if (ret != SQLITE_OK) {
		printf("rollback transaction failed:%s", zErrMsg);
		result = false;
	}
	sqlite3_free(zErrMsg);
	isBeginTran = false;
	return result;
}



bool SqliteHelper::endTranscation() {
	if (!isBeginTran)
		return false;
	iImgCount = 0;
	sqlite3_finalize(stmt);
	if (!commitTransaction()) {
		rollbackTransaction();
		isBeginTran = false;
		Close();
		return false;
	}
	stmt = nullptr;
	zErrMsg = nullptr;
	return true;
}
#pragma endregion