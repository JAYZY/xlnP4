
// zmq_client_using_dll.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include "dll.h"

using namespace std;


int main()
{
    // 注意："C:\\Users\\hehai\\source\\repos\\zmq_client_using_dll\\zmq_client_using_dll" 为一个目录，该目录下放置配置文件 cfg.txt
    // 若想传入当前目录，传入 "./" 即可
    bool load_status = init(""C:\\Users\\hehai\\source\\repos\\zmq_client_using_dll\\zmq_client_using_dll"");
    if (!load_status)
    {
        cout << "load params from config file fail!" << endl;
        return -1;
    }

    string server_redis_ip = "192.168.1.4";
    int server_redis_port = 6379;
    int img_db_id = 10;
    int img_key_db_id = 11;
    string img_key_name = "list";
    int ret_open = openAlgoModule(server_redis_ip, server_redis_port, img_db_id, img_key_db_id, img_key_name);

    if (ret_open == 0)
    {
        cout << "open fail!\n"; // 打开算法模块失败
    }
    else if (ret_open == 1)
    {
        cout << "open ok!\n"; // 打开算法模块成功
    }
    else if (ret_open == 3)
    {
        cout << "repeat open!\n"; // 算法模块已经打开，open指令属于重复，打开无效
    }
    

    // 关闭模块可以使用，没问题
    //int ret_close = closeAlgoModule();
    //if (ret_close == 0)
    //{
    //  cout << "close fail!\n"; // 关闭算法模块失败
    //}
    //else if (ret_close == 2)
    //{
    //  cout << "close ok!\n"; // 关闭算法模块成功
    //}
    //else if (ret_close == 4)
    //{
    //  cout << "repeat close!\n"; // 算法模块已经关闭，close指令属于重复，关闭无效
    //}
    
    //  获取信息模块也没有问题，暂时返回一个字符串：cup和gpu的信息
    //string info = getAlgoModuleInfo();
    //cout << "info:" << info << endl;

    return 0;
}

