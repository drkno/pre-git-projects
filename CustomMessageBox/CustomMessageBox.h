#ifndef CUSTMGBOX
#define CUSTMGBOX

#if defined _WINDOWS_H && defined _TCHAR_H_

#define MB_ICONNONE 0x50

int CMessageBox(HWND hwnd, TCHAR *szText, TCHAR *szCaption, UINT uType, int numOfBtns, TCHAR * button1, TCHAR * button2, TCHAR * button3);

const char *btn1, *btn2, *btn3;
int numbtns;

HHOOK hMsgBoxHook;

LRESULT CALLBACK CBTProc(int nCode, WPARAM wParam, LPARAM lParam){
	HWND hwnd;
	HWND hwndButton;

	if(nCode < 0)
		return CallNextHookEx(hMsgBoxHook, nCode, wParam, lParam);

	switch(nCode){
        case HCBT_ACTIVATE:
            hwnd = (HWND)wParam;

            switch(numbtns){
                case 1: {
                    hwndButton = GetDlgItem(hwnd, IDOK);
                    SetWindowText(hwndButton, _T(btn1));
                    break;
                }
                case 2: {
                    hwndButton = GetDlgItem(hwnd, IDOK);
                    SetWindowText(hwndButton, _T(btn1));
                    hwndButton = GetDlgItem(hwnd, IDCANCEL);
                    SetWindowText(hwndButton, _T(btn2));
                    break;
                }
                case 3: {
                    hwndButton = GetDlgItem(hwnd, IDYES);
                    SetWindowText(hwndButton, _T(btn1));
                    hwndButton = GetDlgItem(hwnd, IDNO);
                    SetWindowText(hwndButton, _T(btn2));
                    hwndButton = GetDlgItem(hwnd, IDCANCEL);
                    SetWindowText(hwndButton, _T(btn3));
                    break;
                }
                default: return -1; break;
            } // switch
            return 0;
    } // switch
    return CallNextHookEx(hMsgBoxHook, nCode, wParam, lParam);
} // cbtproc


int CMessageBox(HWND hwnd, TCHAR *szText, TCHAR *szCaption, UINT uType, int numOfBtns, const char * button1, const char * button2, const char * button3){

	int retval;
	numbtns = numOfBtns;

    switch(numOfBtns){
        case 1: {
            uType = uType | MB_OK;
            btn1 = _T(button1);
            break;
        }
        case 2: {
            uType = uType | MB_OKCANCEL;
            btn1 = _T(button1);
            btn2 = _T(button2);
            break;
        }
        case 3: {
            uType = uType | MB_YESNOCANCEL;
            btn1 = _T(button1);
            btn2 = _T(button2);
            btn3 = _T(button3);
            break;
        }
        default: return -1;
    }

	hMsgBoxHook = SetWindowsHookEx(WH_CBT,CBTProc,NULL,GetCurrentThreadId());
	retval = MessageBox(hwnd, szText, szCaption, uType);
	UnhookWindowsHookEx(hMsgBoxHook);

	return retval;
}

#else
#error Please include windows.h and tchar.h .
#endif
#endif
