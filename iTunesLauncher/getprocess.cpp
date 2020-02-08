#define _WIN32_WINNT 0x0501

#include <Windows.h>
#include <stdio.h>
#include <tchar.h>
#include <Psapi.h>
#include <shlwapi.h>

#pragma comment (lib, "Psapi.lib")
#pragma comment (lib, "shlwapi.lib")

int _tmain (int argc, LPCTSTR argv[])
{
    DWORD arProcessIds[1024], cbNeeded, i, dwStatus;
    HANDLE hProcess = NULL;
    LPCTSTR pszProcessName = NULL;

    if (argc != 2) {
        _tprintf (TEXT("USAGE:\n")
                  TEXT("    \"%s\" ExeName\n\n")
                  TEXT("Examples:\n")
                  TEXT("    \"%s\" TaskMgr.exe\n"),
                  argv[0], argv[0]);
        return 1;   // error
    }
    pszProcessName = argv[1];

    if (!EnumProcesses (arProcessIds, sizeof(arProcessIds), &cbNeeded)) {
        // here shold be allocated array dynamically
        return 1;   // error
    }
    for (i = 0; i < cbNeeded/sizeof(DWORD); i++ ) {
        if (arProcessIds[i] != 0) {
            TCHAR szFileName[MAX_PATH];
            hProcess = OpenProcess (PROCESS_QUERY_INFORMATION | SYNCHRONIZE, FALSE, arProcessIds[i]);
            if (hProcess != NULL) {
                dwStatus = GetProcessImageFileName (hProcess, szFileName, sizeof(szFileName)/sizeof(TCHAR));
                if (dwStatus > 0 ) {
                    LPCTSTR pszFileName = PathFindFileName (szFileName);
                    //_tprintf(TEXT("Process: %s\n"),szFileName);
                    if (StrCmpI(pszFileName, pszProcessName) == 0) {
                        break;
                    }
                }
                CloseHandle (hProcess);
                hProcess = NULL;
            }
        }
    }
    //hProcess = OpenProcess (SYNCHRONIZE, FALSE, dwProcessId);
    if (hProcess == NULL) {
        _tprintf(TEXT("The process \"%s\" is not found.\n"), pszProcessName);
        return 1;
    }

    _tprintf(TEXT("Start waiting for the end of the process %s\n"), pszProcessName);
    WaitForSingleObject(hProcess, INFINITE);
    _tprintf(TEXT("The process is terminated"));
    CloseHandle (hProcess);

    return 0;
}
