#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include <stdio.h>
#include <conio.h>

FILE * file;

void toggleService(const char *service, BOOL logging){
	SC_HANDLE serviceDbHandle = OpenSCManager(NULL,NULL,SC_MANAGER_ALL_ACCESS);
    SC_HANDLE serviceHandle = OpenService(serviceDbHandle, service, SC_MANAGER_ALL_ACCESS);

    SERVICE_STATUS_PROCESS status;
    DWORD bytesNeeded;
    QueryServiceStatusEx(serviceHandle, SC_STATUS_PROCESS_INFO,(LPBYTE) &status,sizeof(SERVICE_STATUS_PROCESS), &bytesNeeded);

	BOOL b;
    if (status.dwCurrentState == SERVICE_RUNNING)
    {
        b = ControlService(serviceHandle, SERVICE_CONTROL_STOP, (LPSERVICE_STATUS) &status);
    }
    else
    {
        b = StartService(serviceHandle, NULL, NULL); 
    }

	if (logging)
	{
		fprintf(file, "%s did %s at %s.", service, b?"succeed":"failed", status.dwCurrentState == SERVICE_RUNNING?"stopping":"starting");
	}

    CloseServiceHandle(serviceHandle);
    CloseServiceHandle(serviceDbHandle);
}

int WINAPI WinMain(HINSTANCE inst,HINSTANCE prev,LPSTR cmd,int show)
{
	BOOL logging = FALSE;
	if(cmd != ""){
		if(cmd == "-l"){
			logging = TRUE;
			file = fopen ("VMwareLauncher.log","w");
		} else {
			printf("VMWareLauncher - A Service/Daemon Free Launcher for VMWare Workstation.\nUsage: VMWareLauncher.exe [options]\nOptions:\n--l Enables Logging to VMWareLauncher.log");
		}
	}

	toggleService("VMAuthdService", logging);
	toggleService("VMnetDHCP", logging);
	toggleService("VMware NAT Service", logging);
	toggleService("VMUSBArbService", logging);
	toggleService("VMwareHostd", logging);

	if(logging)
	{ 
		fprintf(file,"Launching VMWare Workstation\n"); 
	}

    DWORD nBufferLength = MAX_PATH;
    char szCurrentDirectory[MAX_PATH + 1];
    nBufferLength = GetCurrentDirectory(nBufferLength, szCurrentDirectory);
	sprintf(szCurrentDirectory, "%s%s", szCurrentDirectory, "\\vmware.exe\0");

	STARTUPINFO si = { sizeof(si) };
    PROCESS_INFORMATION pi;
    if(CreateProcess(NULL, szCurrentDirectory, 0, 0, FALSE, 0, 0, 0, &si, &pi))
	{
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    }

	toggleService("VMwareHostd", logging);
	toggleService("VMUSBArbService", logging);
	toggleService("VMware NAT Service", logging);
	toggleService("VMnetDHCP", logging);
	toggleService("VMAuthdService", logging);

	if(logging == TRUE)
	{
		fclose (file);
	}

	return 0;
}
