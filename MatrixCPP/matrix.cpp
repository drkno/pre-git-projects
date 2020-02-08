#include <iostream>
#include <windows.h>
#include <cstdlib>
#include <time.h>

using namespace std;

#define wdth 79

int width,height;

void matrix();
int main(int argc, char** argv){

    CONSOLE_SCREEN_BUFFER_INFO csbi;
    GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE), &csbi);
    width = csbi.srWindow.Right - csbi.srWindow.Left + 1;
    height = csbi.srWindow.Bottom - csbi.srWindow.Top + 1;
    srand(time(NULL));
    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    system("color A");
    matrix();
    return 0;
}

void matrix(){
    char p[wdth];
    int w = width, h = height;
	for(int i = 0; i <wdth; p[i++] = 1);

	while(1){
        //Sleep();
        for(int j = 0; j < wdth; j++){
            if(rand()%5 + 1 == 1){ cout << ' '; continue; }
            char v = rand() % 33 + 3e4;
            p[j]=v>758+rand()*1e4?0:v+10;
            cout << p[j];
        }
        cout << "\n";
	}
}
