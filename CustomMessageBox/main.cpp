#include <windows.h>
#include <tchar.h>
#include "CustomMessageBox.h"

using namespace std;

int main(){
    CMessageBox(NULL,"The Random Episode I Have Chosen is:\nTop Gear - [0x0]","Top Gear",MB_SYSTEMMODAL | MB_DEFBUTTON1,3,"New Episode","Open","Quit");
    return 0;
}
