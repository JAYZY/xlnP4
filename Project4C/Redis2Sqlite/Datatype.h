#pragma once
 
#include <string>
#include <iostream>
#include <stdlib.h>  
#include <stdio.h>
 using namespace std;

typedef unsigned char uchar;
//字段类型
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
	int64_t pId;//缺陷ID 智能的 尾号为0  人工的 尾号为1
	int64_t imgGUID;		
	string sFaultJson;//缺陷id的json拷贝
	string sMarkJson; //标注的json拷贝	
}tFault_t;

 

//void ASCIIToUTF8(char cACSII[], char cUTF8[]) {
//	int SQL_MAX_LENTH = 10000;
//	//先将ASCII码转换为Unicode编码
//	int nlen = MultiByteToWideChar(CP_ACP, 0, cACSII, -1, NULL, NULL);
//	wchar_t *pUnicode = new wchar_t[SQL_MAX_LENTH];
//	memset(pUnicode, 0, nlen * sizeof(wchar_t));
//	MultiByteToWideChar(CP_ACP, 0, cACSII, -1, (LPWSTR)pUnicode, nlen);
//	wstring wsUnicode = pUnicode;
//	//将Unicode编码转换为UTF-8编码
//	nlen = WideCharToMultiByte(CP_UTF8, 0, wsUnicode.c_str(), -1, NULL, 0, NULL, NULL);
//	WideCharToMultiByte(CP_UTF8, 0, wsUnicode.c_str(), -1, cUTF8, nlen, NULL, NULL);
//}
