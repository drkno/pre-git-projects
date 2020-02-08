#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <fstream>
#include "resource.h"

using namespace std;

HINSTANCE hInst;
int blockAdobe(HWND dlg);

BOOL CALLBACK DialogProc(HWND hwndDlg, UINT uMsg, WPARAM wParam, LPARAM lParam){
    PAINTSTRUCT paintStruct;
	HDC hDC;

    switch(uMsg){
        case WM_CLOSE:
            EndDialog(hwndDlg, 0);
            return TRUE;

        case WM_PAINT:
            hDC = BeginPaint(hwndDlg,&paintStruct);
			SetBkMode(hDC,TRANSPARENT);
			//TextOut(hDC,10,10,"Are you running this program as an Administrator?",49);
			TextOut(hDC,10,10,"You must have administrive privileges to continue.",50);
            EndPaint(hwndDlg, &paintStruct);
            return TRUE;

        case WM_COMMAND:
            switch(LOWORD(wParam)){
                case IDC_BTN_QUIT:
                    EndDialog(hwndDlg, 0);
                    return TRUE;

                case IDC_BTN_BLOCK:
                    int ret = blockAdobe(hwndDlg);
                    switch(ret){
                        case 0: break;
                        case 1: PostQuitMessage(0); break;
                    }
                    return TRUE;
            }
    }
    return FALSE;
}


int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nShowCmd){
    hInst = hInstance;
    return DialogBox(hInstance, MAKEINTRESOURCE(DLG_MAIN), NULL, (DLGPROC)DialogProc);
}

int blockAdobe(HWND dlg){
    ifstream in("C:\\Windows\\System32\\drivers\\etc\\hosts");
    if(!in){
        MessageBox(dlg,"Permission denied, run this program as an administrator.","Error",MB_OK | MB_ICONERROR);
        in.close();
        return 1;
    }
    string temp;
    while(!in.eof()){
        getline(in,temp,'\n');
        if(temp.find("adobe") != string::npos){
            MessageBox(dlg,"Why would you try to block whats already blocked?","Adobe already blocked!",MB_OK | MB_ICONQUESTION);
            in.close();
            return 1;
        }
    }
    in.close();

    ofstream out("C:\\Windows\\System32\\drivers\\etc\\hosts",ios::app);
    if(!out){
        MessageBox(dlg,"Permission denied, run this program as an administrator.","Error",MB_OK | MB_ICONERROR);
        out.close();
        return 1;
    } else {
        out << "\n\n# BLOCK ADOBE ACTIVATON - Begin\n";
        out << "127.0.0.1\tactivate.adobe.com\n";
        out << "127.0.0.1\tpractivate.adobe.com\n";
        out << "127.0.0.1\tereg.adobe.com\n";
        out << "127.0.0.1\tactivate.wip3.adobe.com\n";
        out << "127.0.0.1\twip3.adobe.com\n";
        out << "127.0.0.1\t3dns-3.adobe.com\n";
        out << "127.0.0.1\t3dns-2.adobe.com\n";
        out << "127.0.0.1\tadobe-dns.adobe.com\n";
        out << "127.0.0.1\tadobe-dns-2.adobe.com\n";
        out << "127.0.0.1\tadobe-dns-3.adobe.com\n";
        out << "127.0.0.1\tereg.wip3.adobe.com\n";
        out << "127.0.0.1\tactivate-sea.adobe.com\n";
        out << "127.0.0.1\twwis-dubc1-vip60.adobe.com\n";
        out << "127.0.0.1\tactivate-sjc0.adobe.com\n";
        out << "127.0.0.1\tadobe.activate.com\n";
        out << "127.0.0.1\tadobeereg.com\n";
        out << "127.0.0.1\t125.252.224.90\n";
        out << "127.0.0.1\t125.252.224.91\n";
        out << "127.0.0.1\thl2rcv.adobe.com\n";
        out << "# BLOCK ADOBE ACTIVATON - End\n";
        out.close();
        MessageBox(dlg,"Adobe Blocked.","Complete",MB_OK | MB_ICONINFORMATION);
        return 0;
    }
}
