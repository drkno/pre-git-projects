/*
 Cross Platform Programming Header
 Authour:   Matthew Knox
 Copyright: Copyright © Knox Microsystems 2011-12. All rights reserved.
 Local:     EN-AU
 Language:  C/C++
 Platform:  Windows NT 4.0+, Mac OS X 10.5+, Theoretical Linux and UNIX
 Licence:   GNU General Public Licence
*/

#ifndef CP_LOCAL_INCLUDES
#include <string>
#include <iostream>
#include <sstream>
#include <cstdlib>
#include <vector>
#include <stdlib.h>
#include <stdio.h>
#include <dirent.h>
#include <ctime>

#ifdef _WIN32
    #include <windows.h>
    #include <conio.h>
    #define getch _getch
    #define AlertBox MessageBox
#else
    #include <termios.h>
    #include <unistd.h>

#endif
#endif

int sleeper(seconds);
#ifdef INCLUDE_STRING
string TextInput();
string PasswdInput();
bool isNumeric(std::string number);
int open(std::string location,std::string exeloc);
#endif
#ifdef INCLUDE_IOSTREAM
bool validNum(double number);
#endif
void pauser();
void clrscreen();
bool wildcmp(const char *wild, const char *string);
int gen(int low,int high);
bool isPrime(int num);
#ifdef INCLUDE_VECTOR
vector<string> getdircontents(string dir);
#endif
#ifndef _WIN32
int getch();

int getch(){
    struct termios oldt,
    newt;
    int ch;
    tcgetattr( STDIN_FILENO, &oldt );
    newt = oldt;
    newt.c_lflag &= ~( ICANON | ECHO );
    tcsetattr( STDIN_FILENO, TCSANOW, &newt );
    ch = getchar();
    tcsetattr( STDIN_FILENO, TCSANOW, &oldt );
    return ch;
}
#endif
#ifdef APPLECOCOA
#import <Cocoa/Cocoa.h>
NSString STR2NS(string stringval){
    NSString *temp = [NSString stringWithCString:temp.c_str() encoding:[NSString defaultCStringEncoding]];
    return temp;
} // string to NSString

string NS2STR(NSString *stringval){
    string temp;
    temp = [stringval UTF8String];
} // string to NSString
#endif

#ifdef INCLUDE_STRING
#ifdef INCLUDE_STDIO_H
string TextInput(){
    string text;
    int looper(1);
    while(looper == 1){                       // pass input loop
        char c = getch();                   // input a character
        switch(c){
            case 27: text = "!~ESC~!"; looper = 0; break;
            case 13: looper = 0; break;
            case '\n': looper = 0; break; // break loop
            case '\b':{ // if backspace key is pressed
                if(text.length() != 0){    // if the text actually contains something
                    text.erase(text.size() - 1, 1); // remove last character
                    printf("\b \b");
                } // if
                break;  // break
            } // case backspace
            default: text.push_back(c); printf("%c",c); break;   // output to screen
        } // switch
    } // while
    return text;
} // PasswdInput

string PasswdInput(){
    string password;
    int looper(1);
    while(looper == 1){                       // pass input loop
        char c = getch();                   // input a character
        switch(c){
            case 27: password = "!~ESC~!"; looper = 0; break;
            case 13: looper = 0; break;
            case '\n': looper = 0; break; // break loop
            case '\b':{ // if backspace key is pressed
                if(password.length() != 0){    // if the password actually contains something
                    password.erase(password.size() - 1, 1); // remove last character
                    printf("\b \b");    // backspace a cout
                } // if
                break;  // break
            } // case backspace
            default: password.push_back(c); printf("*"); break;   // output * to screen
        } // switch
    } // while
    return password;
} // PasswdInput
#endif
#endif

#ifdef INCLUDE_IOSTREAM
bool validNum(double number){                         // validate if input is int

    if (cin.fail()){ // no cin actually happened
        cin.clear(); // reset
        cin.ignore(1000, '\n'); // clear bad input from the stream
        return false;
    }

    cin.ignore(1000, '\n'); // clear remaining input from the stream
    if (cin.gcount() > 1){ // cleared >1 additional character?
        return false;
    }

    if (number <= 0){ // is not positive?
        return false;
    }
    return true;    // real num
}
#endif

#ifdef INCLUDE_SSTREAM
bool isNumeric(string number){
    istringstream iss(number.c_str());
    double dTestSink;
    iss >> dTestSink;
    if(!iss){return false;}
	return (iss.rdbuf()->in_avail() == 0);
}
#endif

#ifdef INCLUDE_STDIO_H
void pauser(){ // pause function
    printf("Press any key to continue . . .");
    getch();
} // pause
#endif

#ifdef INCLUDE_CSTDLIB
void clrscreen(){
    #ifdef _WIN32
    system("cls");
    #else
    system("clear");
    #endif
} // clear screen

bool wildcmp(const char *wild, const char *string) {
    const char *cp = NULL, *mp = NULL;
    while ((*string) && (*wild != '*')) {
        if ((*wild != *string) && (*wild != '?')) {
            return 0;
        }
        wild++;
        string++;
    }
    while (*string) {
        if (*wild == '*') {
            if (!*++wild) {
                return 1;
            }
            mp = wild;
            cp = string+1;
        } else if ((*wild == *string) || (*wild == '?')) {
            wild++;
            string++;
        } else {
            wild = mp;
            string = cp++;
        }
    }
    while (*wild == '*') {
        wild++;
    }
    return !*wild;
}
#endif

#ifdef INCLUDE_VECTOR
std::vector<string> getdircontents(string dir){
    vector<string> filelist;
    DIR *dp;
    struct dirent *dirp;
    if((dp  = opendir(dir.c_str())) == NULL) {
        filelist.push_back("NULL");
        return filelist; // error
    } // if

    unsigned int i=0;
    while ((dirp = readdir(dp)) != NULL) {
        string temp = dirp->d_name;

        if(temp[0] != '.'){
            #ifdef _WIN32
                temp = dir + "\\" + temp;
            #else
                temp = dir + "/" + temp;
            #endif

            if(i < filelist.size() && filelist.size() != 0){
                filelist[i] = temp;
            } else {
                filelist.push_back(temp);
            } // if

            i++;
        } // if
    } // while

    closedir(dp);
    return filelist;
} // get directory contents
#endif

#ifdef INCLUDE_CTIME
int gen(int low,int high){
    #ifndef seeder
    int seeder(0);
    long tme;
    #endif
    if(seeder < 500 && seeder != 0){
        srand(tme);
        seeder++;
        int i(0), randNum;
        while(i != seeder){
            randNum = ((rand() % high) + low);
            i++;
        } // while
        return randNum - 1;
    } else {
        tme = time(0);
        srand(time(0));
        seeder = 1;
        return ((rand() % high) + low);
    } // if
} // randnum
#endif

#ifdef INCLUDE_STRING
int open(std::string location,std::string exeloc){
    std::string temp="", temp2;
    std::stringstream ss;
    ss << exeloc;
    while(temp.find(".") == std::string::npos){
        #ifdef _WIN32
            getline(ss,temp,'\\');
            if(temp.find(".") == std::string::npos){
                temp2 = temp2 + temp + "\\";
            } // if
        #else
            getline(ss,temp,'/');
            if(temp.find(".") == std::string::npos){
                temp2 = temp2 + temp + "/";
            } // if
        #endif
    } // while

    location = temp2 + location;

    #ifdef _WIN32
        location = "start \"Random Episode\" \"" + location + "\"";
    #else
        location = "open '" + location + "'";
    #endif
    int error(0);
    error = system(location.c_str());

    if(error != 0){
        return 1;
    } // if
    return 0;
} // open
#endif

bool isPrime(int num){
    if(num == 1) {return false;}
    if(num == 2 || num == 3 || num == 5){return true;}
    if(num%2 == 0 || num%3 == 0 || num%5 == 0){return false;}
    return true;
} // is prime

int sleeper(int seconds){
    #if defined _WIN32 || defined _WIN64
        seconds *= 1000;
        Sleep(seconds);
    #else
        sleep(seconds);
    #endif
} // sleeper
