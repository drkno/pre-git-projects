/*
Grandad Settings Reseter
1.0 18/12/13
*/

#include <vector>
#include <fstream>
#include <sstream>
#include <windows.h>

#define WINDOWS_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN

using namespace std;

int main()
{
    ifstream in("reset.ini");
    if(!in) return -1;
    string buf;
    vector<string> cmds;
    while(!in.eof())
    {
        getline(in,buf);
        cmds.push_back(buf);
    }
    in.close();

    for(unsigned int i = 0; i < cmds.size(); i++)
    {
        stringstream ss; ss << cmds[i];
        if(cmds[i].length() > 7 && cmds[i].substr(0,7) == "replace")
        {
            buf = ""; ss >> buf;
            buf = ""; string loc;
            ss >> loc; ss >> buf;
            CopyFile(buf.c_str(),loc.c_str(),false);
        }

        if(cmds[i].length() > 5 && cmds[i].substr(0,5) == "start")
        {
            STARTUPINFO si;
            PROCESS_INFORMATION pi;

            ZeroMemory(&si, sizeof(si));
            si.cb = sizeof(si);
            ZeroMemory(&pi, sizeof(pi));

            CreateProcess(NULL,LPTSTR(cmds[i].substr(6).c_str()),0,0,false,0,0,0,&si,&pi);
            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
        }
    }
    return 0;
}
