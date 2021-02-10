#pragma once
 
#include "windows.h"  
#include <iostream>  
#include <string>  
using namespace std;



//**************string******************//  
// ASCII��Unicode��ת  
wstring AsciiToUnicode(const string& str);
string  UnicodeToAscii(const wstring& wstr);
// UTF8��Unicode��ת  
wstring Utf8ToUnicode(const string& str);
string  UnicodeToUtf8(const wstring& wstr);
// ASCII��UTF8��ת  
string  AsciiToUtf8(const string& str);
string  Utf8ToAscii(const string& str);
 
/************string-int***************/
// string ת Int  
int StringToInt(const string& str);
string IntToString(int i);
string IntToString(char i);
string IntToString(double i);


inline void trim(string &s) {
	/*
	if( !s.empty() )
	{
		s.erase(0,s.find_first_not_of(" "));
		s.erase(s.find_last_not_of(" ") + 1);
	}
	*/
	int index = 0;
	if (!s.empty()) {
		while ((index = s.find(' ', index)) != string::npos) {
			s.erase(index, 1);
		}
	}
}