
#include "RedisHelperDll.h"
#include "RedisHelper.h"

void* OpenDb(const char* addrIp, int iTimeout, int  port) {
	RedisHelper *pDb = new RedisHelper();
	if (pDb->OpenDb(addrIp, iTimeout, port)) {
		cout << pDb->isConnction << endl;
		return pDb;
	}
	else
		return false;
}
bool WriteImg(void* pDb, long long int imgGuid, unsigned char * imgContent, int imgSize, const char * sJsonImgInfo) {
	bool	bRet = false;
	if (NULL != pDb) {
		if (((RedisHelper *)pDb)->WriteImg(imgGuid, imgContent, imgSize)) {
			if (NULL != pDb) {
				if (((RedisHelper *)pDb)->WriteImgInfo(imgGuid, sJsonImgInfo))
					bRet = true;
			}
		}
	}
	return bRet;
}
bool WriteFault(void* pDb, long long int imgGuid, char* sJsonFault) {
	//printf("input imgGuid first: %lld  str: %s\n", imgGuid, sJsonFault);

	return ((RedisHelper *)pDb)->WriteFaultInfo(imgGuid, sJsonFault);
}

bool WriteGeoData(void* pDb, long long imgGuid, const char* sJsonGeoInfo) {
	return ((RedisHelper *)pDb)->WriteGeoInfo(imgGuid, sJsonGeoInfo);
}

const char* GetErrInfo(void* pDb) {
	return ((RedisHelper *)pDb)->GetErrTip();
}

bool CloseDb(void* pDb) {
	if (pDb == nullptr)return false;
	((RedisHelper*)pDb)->CloseDb();
	delete(pDb);
	pDb = nullptr;
	printf("Db is closed!\n");
	return true;
}



