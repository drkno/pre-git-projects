#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <tlhelp32.h>
#include <stdio.h>

using namespace std;

bool startServices(const char *service);
bool KillProcess(const char *Process);

FILE * file;

int main(int argc, char* argv[]){

    file = fopen ("C:\\Program Files (x86)\\iTunes\\ituneslauncher.log","w");

    // startup
    if(startServices("Bonjour Service") == false){
        fprintf(file,"Skipping Bonjour...\n");
    } // if
    if(startServices("Apple Mobile Device") == false){
        fprintf(file,"Skipping Apple Mobile Device Service...\n");
    } // if
    if(startServices("iPod Service") == false){
        fprintf(file,"Skipping iPod Service...\n");
    } // if
    Sleep(1000);

    //launch itunes and wait for it to close
    fprintf(file,"iTunes Launching...\n");
    STARTUPINFO si = { sizeof(si) };
    PROCESS_INFORMATION pi;
    char szExe[] = "C:\\Program Files (x86)\\iTunes\\iTunes.exe";
    if(CreateProcess(NULL, szExe, 0, 0, FALSE, 0, 0, 0, &si, &pi)){
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    } // if
    fprintf(file,"iTunes just quit\n");

    // terminate
    KillProcess("mDNSResponder.exe");
    KillProcess("AppleMobileDeviceService.exe");
    KillProcess("iPodService.exe");
    KillProcess("iTunesHelper.exe");

    fclose (file);

    return 0;
} // main

bool KillProcess(const char *Process){

    HANDLE hProcessSnap;
    HANDLE hProcess=NULL;
    PROCESSENTRY32 pe32;
    int returned(0);

    char Report[6];

    hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	pe32.dwSize = sizeof(PROCESSENTRY32);
	Process32First(hProcessSnap, &pe32);

	while(Process32Next(hProcessSnap, &pe32)){
        if(!strcmp(pe32.szExeFile, Process)){
            strcpy(Report, "Found");
		    hProcess = OpenProcess(PROCESS_TERMINATE, 0, pe32.th32ProcessID);

		    if(TerminateProcess(hProcess, 0) == 0){
                fprintf(file,"Terminating %s failed!\n",Process);
                returned = 1;
            } else {
                fprintf(file,"%s terminated successfully!\n",Process);
                returned = 0;
            }
        }
    }

	CloseHandle(hProcess);
    CloseHandle(hProcessSnap);

    if(strcmp(Report, "Found")){
        fprintf(file,"%s cannot be found!\n",Process);
    }

	strcpy(Report, "\\");

	return returned;
} // kill process

bool startServices(const char *service){
    SERVICE_STATUS SvcStatus;
    SC_HANDLE hSchSvc=NULL;
    hSchSvc = OpenSCManager(NULL, NULL, SC_MANAGER_CONNECT);
    fprintf(file,"Systems Check:\n");
    if (hSchSvc == NULL){
        return false;
    } else {
        fprintf(file,"OpenSCManager() is OK.\n");
    } // if

    hSchSvc = OpenService(hSchSvc, service, SERVICE_START | SERVICE_QUERY_STATUS);
    if (hSchSvc == NULL){
        return false;
    } else {
        fprintf(file,"OpenService() is OK.\n");
    } // if
    if (QueryServiceStatus(hSchSvc, &SvcStatus) == FALSE){
        CloseServiceHandle(hSchSvc);
        return false;
    } else {
        fprintf(file,"QueryServiceStatus() is OK.\n");
    } // if

    fprintf(file,"\nService Startup:\n");
    if (SvcStatus.dwCurrentState == SERVICE_RUNNING){
        CloseServiceHandle(hSchSvc);
        fprintf(file,"%s is already running.\n---\n\n",service);
        return true;
    } // if

    if (StartService(hSchSvc, 0, NULL) == FALSE){
        CloseServiceHandle(hSchSvc);
        fprintf(file,"Could not start %s.\n---\n\n",service);
        return false;
    } // if

    CloseServiceHandle(hSchSvc);
    fprintf(file,"%s has been started.\n---\n\n",service);
    return true;
} // main

