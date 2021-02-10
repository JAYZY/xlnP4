#pragma once
 
#include <string>
#include <iostream>
#include <stdlib.h>  
#include <stdio.h>
 using namespace std;

typedef unsigned char uchar;
//�ֶ�����
/*
INTEGER
SMALLINT
TEXT
BLOG
*/
enum class ResCode :uint16_t {
	SqliteOk,
	OpenDBFailed,
	CreateTbFailed,
	PrepareFailed,
	InsertFailed,
	ExecuteFailed
};

typedef struct tjp_info {
	int outwidth;
	int outheight;
	unsigned long jpg_size;
}tjp_info_t;

typedef struct tImgAndInfo {	
	unsigned char* arrImgData;
	uint32_t uImgDataLen;
	const char*  sJson;
	int64_t iImgGUID;	
}tImgAndInfo_t;

typedef struct tFault {		
	int iUnitId;
	int64_t pId;//ȱ��ID ���ܵ� β��Ϊ0  �˹��� β��Ϊ1
	int64_t imgGUID;		
	string sFaultJson;//ȱ��id��json����
	string sMarkJson; //��ע��json����	
}tFault_t;

 

//void ASCIIToUTF8(char cACSII[], char cUTF8[]) {
//	int SQL_MAX_LENTH = 10000;
//	//�Ƚ�ASCII��ת��ΪUnicode����
//	int nlen = MultiByteToWideChar(CP_ACP, 0, cACSII, -1, NULL, NULL);
//	wchar_t *pUnicode = new wchar_t[SQL_MAX_LENTH];
//	memset(pUnicode, 0, nlen * sizeof(wchar_t));
//	MultiByteToWideChar(CP_ACP, 0, cACSII, -1, (LPWSTR)pUnicode, nlen);
//	wstring wsUnicode = pUnicode;
//	//��Unicode����ת��ΪUTF-8����
//	nlen = WideCharToMultiByte(CP_UTF8, 0, wsUnicode.c_str(), -1, NULL, 0, NULL, NULL);
//	WideCharToMultiByte(CP_UTF8, 0, wsUnicode.c_str(), -1, cUTF8, nlen, NULL, NULL);
//}
