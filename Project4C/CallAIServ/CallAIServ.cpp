// CallAIServ.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include "dll.h"
#pragma comment(lib, "zmqDLL.lib") 
using namespace std;
int main()
{
	init("192.168.100.10", 5555);
	return  openAlgoModule("192.168.100.58", 6379, 10, 11,12, "list");
}

 