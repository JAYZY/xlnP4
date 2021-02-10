// Redis2Sqlite.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include "Datatype.h"
#include "SqliteHelper.h"
#include "hiredis.h" //头文件跟随文件存放路径改变
#include "win32fixes.h" //头文件跟随文件存放路径改变
#include <set>
#include <sstream>
#include "windows.h"
#include "UTN.h"
#include <cassert>
#pragma comment(lib,"hiredis.lib")
#pragma comment(lib,"Win32_Interop.lib")
#pragma comment(lib, "ws2_32.lib") 
using namespace std;
redisContext *redis = nullptr;
string m_sIpAddr;							//ip
string m_sDBFullName;						//db路径+名称
string m_sDBBackPath;						//备份DB路径+名称
string m_sLstDbIdx;							//图像信息数据库Id:
string m_sImgDbId;							//图像二进制存储数据库Id
string m_sAIFaultDbId;						//智能识别缺陷数据库Id
string m_sGeoDbId;							//几何参数数据库

int m_iMemLimit;							//MemLimit:内存限制
int m_iSaveImgNumByOnce;					//一次存储的图像数量
int m_iDelDataByOnce;						//一次删除的图像数据
int m_iSaveFaultNumByOnce;					//缺陷信息一次存储的大小-- 尽可能不去修改，由于数据量不大，默认为 10000
int m_iSaveGeoDataNumByOnce;				//几何参数数据 一次存储的大小
long  g_iFaultNum;							//总的缺陷个数

void ProcArg(int argc, char *argv[]);
void SelDb(string&sDbId);
void DelReply(redisReply ** reply);
void GetImgInfo(string*&sImgJson, redisReply *reImgLst);
bool WriteFaultDb(uint32_t &uFaultStartId);
bool WriteGeoDb(uint32_t &uFaultStartId);
bool WriteImgAndInfo(redisReply *rImgKeyLst);
double GetUsedMem();

SqliteHelper mainSqlit,backSqlit;
// #define TEST
//wstring AsciiToUnicode(const string& str);
#ifdef TEST
int main(int argc, char *argv[]) {
	mainSqlit.Open("d:\\test.db", true,2);
	string json = " { \"TIM\":19101520533279601,\"KMV\":\"80.966470\",\"CID\":1,\"POL\":\"64\",\"STA\":0,\"STN\":\"\xBA\xBC\xD6\xDD\xC4\xCF\",\"GPS\":\"\"}";
	string sss = AsciiToUtf8(json);
	mainSqlit.AddImage(12323, NULL,0, sss.c_str());

}
#else
int main(int argc, char *argv[]) {
	/*
	** A.不断的将数据持久化到sqlite中
	** B.监控内存，超过限制，则开始删除内存中的数据
	*/

	ProcArg(argc, argv);
	//set<INT64> usedImgId;
	uint32_t uGetimgId = 0;		//图像序号
	uint32_t uFaultStartId = 0;		//缺陷序号
	uint32_t uGeoStartId = 0;		//几何参数序号
	long iDelLstIdx = 0;				//记录删除的图像index
	INT64 delImgIdx = 0;				//记录删除的图像index
	INT64 iSaveImgGUID = 0;			//记录当前已经存储的图像编号
	int iGetMaxLstIdx = 0;			//记录得到的最大List编号
	g_iFaultNum = 0;
#pragma region 连接redis服务器
	struct timeval tv;
	tv.tv_sec = 3000 / 1000;
	tv.tv_usec = (3000 % 1000) * 1000;
	
	redis = redisConnectWithTimeout(m_sIpAddr.c_str(), 6379, tv);
	if (redis == NULL || redis->err) {
		if (redis) {
			printf("Error: 数据库连接超时！\n");
			return -1;
		}
		else {
			printf("Can't allocate redis context\n");
			return -1;
		}
	}
	else {
		printf("# 数据库服务器连接成功!\n");
	}
#pragma endregion

	if (!mainSqlit.Open(m_sDBFullName.c_str(), false, 2)) {
		cout << m_sDBFullName << "持久化数据库，创建失败！" << endl;
		return -1;
	}
	cout << "# 持久化数据库，创建成功！" << endl;
	if (!backSqlit.Open(m_sDBBackPath.c_str(), false, 2)) {
		cout << m_sDBBackPath << "备份数据库，创建失败！" << endl;
		return -1;
	}
	cout << "# 备份数据库，创建成功！" << endl;
	
	redisReply *replyImgLst; //获取数据列表
	//redisReply *replyDel = nullptr;
	Sleep(1000);
	while (true) {
		//------  sqlite 持久化 ------
		SelDb(m_sLstDbIdx);//选择 list 数据库 - m_sLstDbIdx
		//获取List 列表内容
		replyImgLst = (redisReply *)redisCommand(redis, "lrange list %ld %ld ", uGetimgId, uGetimgId + m_iSaveImgNumByOnce);
		cout << "读取图像数据：" << to_string(replyImgLst->elements) << endl;
		if (nullptr == replyImgLst || 0 == replyImgLst->elements) {
			DelReply(&replyImgLst);
			printf("\n#=== 已持久化图像数据信息共：%ld条! \t 等待新数据写入......\n\n", uGetimgId);
			Sleep(2000);//取不到数据休眠2秒继续取数据 并且判定是否没有提交的事务直接提交			
			continue;
		}
		//下一次取图像全局ID的起始值
		uGetimgId += replyImgLst->elements;
		bool res = false;
		try {//=== 写入图像信息	
			DWORD  timestart = GetTickCount();
			res = WriteImgAndInfo(replyImgLst);
			int timespan = (int)GetTickCount() - timestart;
			fprintf(stdout, "# insert Img&Info success,%d ms\n", to_string(replyImgLst->elements), timespan);
		}
		catch (void * e) {
			cout << "writeImage Error" << endl;
		}
		DelReply(&replyImgLst);
#ifdef FAULTParse
		try {
			if (res) {
				res = WriteFaultDb(uFaultStartId);
			}
		}
		catch (void * e) {
			cout << "WriteFaultDb Error" << endl;
		}
#endif
#ifdef GEOParse
		try {
			if (res) {
				res = WriteGeoDb(uGeoStartId);
			}
		}
		catch (void * e) {
			cout << "WriteGeoDb Error" << endl;
		}
#endif


#pragma region 內存监控&Del
		double usedMEM = GetUsedMem();
		cout << "#================ 已经使用内存:" << usedMEM << "M ================#" << endl;
		if (usedMEM > m_iMemLimit) {
			cout << "#--- 超过内存限制(" << m_iMemLimit << "M)，开始清除内存 ....." << endl;
			//====== 清除内存，注意没有持久化的数据不能删除 ======/
			SelDb(m_sLstDbIdx);
			//确保删除的数据都已经被持久化了
			INT64 iEndDelIdx = delImgIdx + m_iDelDataByOnce;
			if (iEndDelIdx > uGetimgId) {
				iEndDelIdx = uGetimgId;
			}
			redisReply *replyDel = (redisReply *)redisCommand(redis, "lrange list  %ld %ld ", delImgIdx, iEndDelIdx);
			size_t iDelSize = replyDel->elements;
			if (0 == iDelSize) {
				DelReply(&replyDel);
				//sqlite.endTranscation();
				printf("#--- 无数据删除，等待数据持久化...\n");
			}
			delImgIdx = iEndDelIdx;
			//算法修改，每次删除完数据后 将list[0]的值修改为未删除数据的list编号
			redisReply* redTmp = (redisReply *)redisCommand(redis, "lset list  0 %ld ", delImgIdx);
			DelReply(&redTmp);
			/*删除给定的图像数据*/
			SelDb(m_sImgDbId);
			redisReply *replyDelImg = nullptr;
			size_t delIdx = 0;
			for (; delIdx < iDelSize; ++delIdx) {
				INT64 iDelImgGUID = stoll(replyDel->element[delIdx]->str);
				replyDelImg = (redisReply *)redisCommand(redis, "DEL %lld", iDelImgGUID);
				printf("#--- %lld 删除成功！\t", iDelImgGUID);
				DelReply(&replyDelImg);
			}

			DelReply(&replyDelImg);
			DelReply(&replyDel);
			cout << "\n# === 删除图像数据:" << delIdx - 1 << "条 ===#\n\n";

			//删除数据后显示内存使用情况
			GetUsedMem();
			cout << "#================ 已经使用内存( 删除数据 ):" << usedMEM << "M ================#" << endl;
		}

#pragma endregion	
	}
	backSqlit.Close();
	mainSqlit.Close();
	redisFree(redis);
	system("pause");
}

#endif


//输入参数 ipAddr：Ip地址  m_sDBFullName：数据库所在位置; MemLimit：内存限制  bulkSaveImgNum：一次性持久化数据大小 iLst
//int main(int argc, char *argv[]) {
//	/*
//	** A.不断的将数据持久化到sqlite中
//	** B.监控内存，超过限制，则开始删除内存中的数据
//	*/
//
//	ProcArg(argc, argv);
//	//set<INT64> usedImgId;
//	uint32_t uGetimgId = 0;		//图像序号
//	uint32_t uFaultStartId = 0;		//缺陷序号
//	long iDelLstIdx = 0;				//记录删除的图像index
//	INT64 delImgIdx = 0;				//记录删除的图像index
//	INT64 iSaveImgGUID = 0;			//记录当前已经存储的图像编号
//	int iGetMaxLstIdx = 0;			//记录得到的最大List编号
//
//#pragma region 连接redis服务器
//	struct timeval tv;
//	tv.tv_sec = 3000 / 1000;
//	tv.tv_usec = (3000 % 1000) * 1000;
//	redis = redisConnectWithTimeout(m_sIpAddr.c_str(), 6379, tv);
//	if (redis == NULL || redis->err) {
//		if (redis) {
//			printf("Error: 数据库连接超时！\n");
//			return -1;
//		}
//		else {
//			printf("Can't allocate redis context\n");
//			return -1;
//		}
//	}
//	else {
//		printf("# 数据库服务器连接成功!\n");
//	}
//#pragma endregion
//
//	if (!SqliteHelper::getInstance()->Open(m_sDBFullName.c_str(), true, 2)) {
//		cout << m_sDBFullName << "sqlite Db 创建失败！" << endl;
//		return -1;
//	}
//	cout << "# 持久化数据库 创建成功！" << endl;
//
//	redisReply *replyImgLst; //获取数据列表
//	redisReply *replyDel = nullptr;
//	Sleep(1000);
//	while (true) {
//		//------  sqlite 持久化 ------
//		SelDb(m_sLstDbIdx);//选择 list 数据库 - m_sLstDbIdx
//		//获取List 列表内容
//		replyImgLst = (redisReply *)redisCommand(redis, "lrange list %ld %ld ", uGetimgId, uGetimgId + m_iSaveImgNumByOnce);
//		if (nullptr == replyImgLst || 0 == replyImgLst->elements) {
//			DelReply(&replyImgLst);
//			//sqlite.endTranscation();
//			printf("# 已持久化图像数据信息共：%ld条! \t 等待新数据写入......\n\n", uGetimgId);
//			Sleep(1000);//取不到数据休眠1秒继续取数据 并且判定是否没有提交的事务直接提交			
//			continue;
//		}
//		//下一次取图像全局ID的起始值
//		uGetimgId += replyImgLst->elements;
//		//=== 写入图像信息
//		bool res = WriteImgAndInfo(replyImgLst);
//		if (res) {
//			res = WriteFaultDb(uFaultStartId);
//		}
//		DelReply(&replyImgLst);
//
//#pragma region 內存监控&Del
//		double usedMEM = GetUsedMem();
//		cout << "#================ 已经使用内存:" << usedMEM << "M ================#" << endl;
//		if (usedMEM > m_iMemLimit) {
//			cout << "# 超过内存限制(" << m_iMemLimit << "M)，开始清除内存。。。" << endl;
//			//====== 清除内存，注意没有持久化的数据不能删除 ======/
//			SelDb(m_sLstDbIdx);
//			//确保删除的数据都已经被持久化了
//			INT64 iEndDelIdx = delImgIdx + m_iDelDataByOnce;
//			if (iEndDelIdx > uGetimgId) {
//				iEndDelIdx = uGetimgId;
//			}
//			replyDel = (redisReply *)redisCommand(redis, "lrange list  %ld %ld ", delImgIdx, iEndDelIdx);
//			size_t iDelSize = replyDel->elements;
//			if (0 == iDelSize) {
//				DelReply(&replyDel);
//				//sqlite.endTranscation();
//				printf("# 无数据删除，等待数据持久化...\n");
//			}
//			delImgIdx = iEndDelIdx;
//			//算法修改，每次删除完数据后 将list[0]的值修改为未删除数据的list编号
//			redisReply* redTmp = (redisReply *)redisCommand(redis, "lset list  0 %ld ", delImgIdx);
//			DelReply(&redTmp);
//			/*删除给定的图像数据*/
//			SelDb(m_sImgDbId);
//			redisReply *replyDelImg = nullptr;
//			size_t delIdx = 0;
//			for (; delIdx < iDelSize; ++delIdx) {
//				INT64 iDelImgGUID = stoll(replyDel->element[delIdx]->str);
//				replyDelImg = (redisReply *)redisCommand(redis, "DEL %lld", iDelImgGUID);
//				printf("#--%lld 删除成功！\t", iDelImgGUID);
//				DelReply(&replyDelImg);
//			}
//
//			DelReply(&replyDelImg);
//			cout << "\n# === 删除图像数据:" << delIdx - 1 << "条 ===#\n\n";
//
//			//删除数据后显示内存使用情况
//			GetUsedMem();
//			cout << "#================ 已经使用内存( 删除数据 ):" << usedMEM << "M ================#" << endl;
//		}
//
//#pragma endregion	
//	}
//	SqliteHelper::getInstance()->Close();
//	redisFree(redis);
//	system("pause");
//}
void ProcArg(int argc, char *argv[]) {
	if (argc < 4) return;

	m_sIpAddr = argv[1];									//ip		
	m_sDBFullName = argv[2];								//db路径+名称
	m_sDBBackPath = argv[3];
	m_iMemLimit = stoi(argv[4]);							//MemLimit:内存限制 （单位M)
	m_iSaveImgNumByOnce = (argc > 5) ? stoi(argv[5]) : 100; //一次存储的图像数量
	m_iDelDataByOnce = 200;									//一次删除的图像数据
	m_iSaveGeoDataNumByOnce = 10;							//一次事务处理的几何参数数据大小	
	m_sGeoDbId = "9";
	m_sLstDbIdx = (argc > 6) ? argv[6] : "11";				//图像信息数据库Id
	m_sImgDbId = (argc > 7) ? argv[7] : "10";				//图像二进制存储数据库Id
	m_sAIFaultDbId = (argc > 8) ? argv[8] : "12";				//智能识别缺陷数据库Id.
	 
	

	cout << "\n*=====================================\n" << endl;
	cout << "* 服务器IP:" << m_sIpAddr << endl;
	cout << "* 持久化数据库:" << m_sDBFullName << endl;
	cout << "* 备份数据库:" << m_sDBBackPath << endl;
	cout << "* 内存限制:" << m_iMemLimit << endl;
	cout << "* 批量存储图像数据:" << m_iSaveImgNumByOnce << endl;
	cout << "* 批量删除图像数据:" << m_iDelDataByOnce << endl;
#ifdef GEOParse
	cout << "* 几何参数数据库Id:" << m_sAIFaultDbId << endl;
	SqliteHelper::getInstance()->SetGeoBulkNum(m_iSaveGeoDataNumByOnce);
#endif
	cout << "* 图像信息数据库Id:" << m_sLstDbIdx << endl;
	cout << "* 图像数据库Id:" << m_sImgDbId << endl;
	mainSqlit.SetBulkNum(m_iSaveImgNumByOnce);
	//备份数据
	backSqlit.SetBulkNum(m_iSaveImgNumByOnce);
#ifdef FAULTParse
	cout << "* 缺陷数据库Id:" << m_sAIFaultDbId << endl;
#endif
	cout << "\n*=====================================\n" << endl;

	
}
//选择数据库
void SelDb(string&sDbId) {
	string sTmp = ("select " + sDbId);
	//cout << "debug:" << sTmp << endl;
	redisReply * replySelDb = (redisReply *)redisCommand(redis, sTmp.c_str());

	if (replySelDb) {
		freeReplyObject(replySelDb);//选择图像信息库
		replySelDb = nullptr;
	}
}
//删除使用过的 redisReply
void DelReply(redisReply ** reply) {
	if (*reply) {
		freeReplyObject(*reply);
		*reply = nullptr;
	}
}
//得到图像信息 json
void GetImgInfo(string*&sImgJson, redisReply *reImgLst) {
	redisReply *replyImgInfo = nullptr;

	for (size_t i = 0; i < reImgLst->elements; ++i) {
		//INT64 iTmp = stoll(replyImgLst->element[i]->str); //获取图像ID
		replyImgInfo = (redisReply *)redisCommand(redis, "GET %s", reImgLst->element[i]->str);;
		if (replyImgInfo == NULL || 0 == replyImgInfo->len) {
			printf("%lld  !\n", reImgLst->element[i]->str);
			DelReply(&replyImgInfo);
			sImgJson[i] = "";
		}
		else {
			sImgJson[i] = replyImgInfo->str;
		}
		DelReply(&replyImgInfo);
	}
	DelReply(&replyImgInfo);
}

double GetUsedMem() {
	redisReply *replyMem = (redisReply *)redisCommand(redis, "info memory");
	string strInfo = replyMem->str;
	DelReply(&replyMem);
	double usedMEM = -1.0;
	size_t pos = strInfo.find("used_memory:", 0);
	if (pos != string::npos) {
		size_t end = strInfo.find("\r", pos);
		pos += strlen("used_memory:");
		string strOut = strInfo.substr(pos, end - pos);
		usedMEM = (stod(strOut) / 1048576.0);

	}
	return usedMEM;
}

bool WriteGeoDb(uint32_t &uGeoStartId) {
	bool res = true;
	//选择几何参数数据库
	SelDb(m_sGeoDbId);
	//读取几何参数列表
	redisReply *rGeoLst = (redisReply *)redisCommand(redis, "lrange geoLst %ld %ld ", uGeoStartId, uGeoStartId + m_iSaveGeoDataNumByOnce);
	if (nullptr == rGeoLst || 0 == rGeoLst->elements) {
		DelReply(&rGeoLst);
		//sqlite.endTranscation();
		printf("\n#=== 已持久化几何参数信息共：%u条! \t 等待新数据写入......\n\n", uGeoStartId);
		res = false;
	}
	else {
		size_t iGeoKeyLen = rGeoLst->elements;
		cout << "读取几何参数信息" << iGeoKeyLen << endl;
		uGeoStartId += iGeoKeyLen; //修改起步ID编号
		redisReply* rGeoData = nullptr;
		for (int i = 0; i < iGeoKeyLen; ++i) {
			rGeoData = (redisReply *)redisCommand(redis, "GET %s", rGeoLst->element[i]->str);
			if (rGeoData == NULL || 0 == rGeoData->len) {
				printf(" 几何参数获取失败!\n");
				DelReply(&rGeoData);
			}
			else {
				mainSqlit.AddGeoByArray(stoll(rGeoLst->element[i]->str), rGeoData->element[i]->str);
				//备份数据
				backSqlit.AddGeoByArray(stoll(rGeoLst->element[i]->str), rGeoData->element[i]->str);
				DelReply(&rGeoData);
			}
		}
		mainSqlit.endTranscation();
		//备份数据
		backSqlit.endTranscation();
		//4.清除timgAndInfo,释放内存	 
		DelReply(&rGeoData);
		DelReply(&rGeoLst);
	}
	return res;
}

//************************************
// Method:    获取缺陷数据
// FullName:  GetFaultDb
// Access:    public 
// Returns:   void
// Qualifier:
// Parameter: int iStartId //开始的Id
//************************************
bool WriteFaultDb(uint32_t &uFaultStartId) {
	bool res = false;
	tFault* arrTFaults = nullptr;
	//选择缺陷数据库
	SelDb(m_sAIFaultDbId);
	//读取缺陷列表
	redisReply *rFaultLst = (redisReply *)redisCommand(redis, "lrange list %ld %ld ", uFaultStartId, uFaultStartId + m_iSaveImgNumByOnce);
	if (nullptr == rFaultLst || 0 == rFaultLst->elements) {
		DelReply(&rFaultLst);
		//sqlite.endTranscation();
		printf("\n#=== 已持久化定位信息共：%u条(缺陷信息：%ld条)! \t 等待新数据写入......\n\n", uFaultStartId, g_iFaultNum);
		res = false;
	}
	else {
		cout << "读取定位缺陷信息" << rFaultLst->elements << endl;
		size_t iFaultKeyLen = rFaultLst->elements;
		uFaultStartId += iFaultKeyLen; //修改起步ID编号
		arrTFaults = new tFault[iFaultKeyLen];

		//--- 1. 获取 imgKeys 
		ostringstream oStr;
		oStr << "MGET ";
		for (int i = 0; i < iFaultKeyLen; ++i) {
			oStr << rFaultLst->element[i]->str << " ";
			arrTFaults[i].imgGUID = stoll(rFaultLst->element[i]->str);
		}
		string sMget = oStr.str();

		//--- 2.获取 FaultJson 字符串
		redisReply *  rFaultJson = (redisReply *)redisCommand(redis, sMget.c_str());
		if (rFaultJson == NULL || 0 == rFaultJson->elements) {
			printf("# --- Error :定位缺陷批量获取失败!\n");
			DelReply(&rFaultJson);
			res = false;
		}
		else {
			//assert(iFaultKeyLen == rFaultJson->elements);
			for (int i = 0; i < iFaultKeyLen; ++i) {
				arrTFaults[i].sFaultJson = rFaultJson->element[i]->str;
			}
			long iFaultNum = mainSqlit.AddLocFault(arrTFaults, iFaultKeyLen);
			//备份数据
			backSqlit.AddLocFault(arrTFaults, iFaultKeyLen);
			if (iFaultNum != -1) {
				g_iFaultNum += iFaultNum;
			}
			//===释放内存					
		}
		if (arrTFaults) {
			delete[]arrTFaults;
		}
		DelReply(&rFaultJson);

	}

	DelReply(&rFaultLst);
	return res;
}

bool WriteImgAndInfo(redisReply *rImgKeyLst) {

	size_t iEleSize = rImgKeyLst->elements;
	string* sArryImgJsons = new string[iEleSize];
	//1.批量获取图像信息
	GetImgInfo(sArryImgJsons, rImgKeyLst);
	//2.批量获取图像内容		 
	SelDb(m_sImgDbId);
	redisReply* rImgData = nullptr;
	for (int i = 0; i < iEleSize; ++i) {
		rImgData = (redisReply *)redisCommand(redis, "GET %s", rImgKeyLst->element[i]->str);
		if (rImgData == NULL || 0 == rImgData->len) {
			printf(" :图像内容获取失败!\n");
			DelReply(&rImgData);
		}
		else {
			string strJason= sArryImgJsons[i];
			mainSqlit.AddImage(stoll(rImgKeyLst->element[i]->str), (unsigned char*)rImgData->str, rImgData->len, strJason.c_str());
			//备份数据
			backSqlit.AddImage(stoll(rImgKeyLst->element[i]->str), (unsigned char*)rImgData->str, rImgData->len, strJason.c_str());
			DelReply(&rImgData);
		}
	}
	mainSqlit.endTranscation();
	//备份数据
	backSqlit.endTranscation();
	//4.清除timgAndInfo,释放内存	 
	if (sArryImgJsons)
		delete[]sArryImgJsons;
	DelReply(&rImgData);
	return true;
}


