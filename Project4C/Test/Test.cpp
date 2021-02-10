// Test.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include "sqlite3.h"
#include <io.h>
#include <direct.h>
#include <string>
#include <Windows.h>
#include "RedisHelperDll.h"

#pragma comment(lib,"sqlite3.lib")
#pragma comment(lib,"RedisHelper.lib")
using namespace  std;
 
int main()
{
	string str = "\xBA\xBC\xD6\xDD\xC4\xCF";
	string strA = str;
	cout <<   strA<<endl;
		
/*
	CreateTable();
	int timestart = GetTickCount();
	BeginTrans();
InsertByPrep();
	EndTrans();

	int timespan = (int)GetTickCount() - timestart;
	fprintf(stdout, "#%d insertByStr success,%dms\n", insertCount, timespan);*/
	return 1;
}
