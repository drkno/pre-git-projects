/*
    Title:     WakeOnLan
    Version:   1.0
    Language:  C++ [C# Version Also Exists]
    Authour:   Matthew Knox
    Platforms: Windows NT+, MacOS X 10.0+, Ubuntu 12.0+,
               and most POSIX complient operating systems.
    Copyright Matthew Knox 2012 to Present.

    Permission must be sort from the authour of this
    code to distribute, modify, copy, sell or anything
    else with it.

    Notice:
    If not using the MS Visual C++ Compiler you must link to
    either libws2_32.a or ws2_32.lib (compiler dependent).

    When using the MS Visual C++ Compiler, depending on
    version the line #pragma comment(lib,"ws2_32.lib")
    may have to be commented out in cpsocket.h  in order to
    compile.
*/

// required librarys
#include <iostream>
#include <string>
#include <algorithm>
#include <ctype.h>
#include "cpsocket.h"

// default namespace
using namespace std;

// prototype functions
char cstringToHex(const char *);
bool checkString(string &hex);

int main(int argc, char ** argv)
{
    string hex; // define a string  to store the hex in
    if(argc == 2){  // if command line arguments are supplied
        hex = argv[1];  // set the hex value
    } else if(argc > 2){ // check for extra arguments
        cout << "Unknown command line arguments."; // display error
        return 0; // stop program
    } else {
        cout << "Enter Mac Address: "; // ask for mac address
        cin >> hex; // input the hex string
    }

    if(!checkString(hex)) // check input
    {
        cout << "Invalid Mac Address"; // output error
        return 0; // stop execution
    }

    // ### Generate Packet ###
    cout << "Generating Packet...\n";
    char macAddress[6], packet[102]; // char arrays
    for(int i = 0; i < 6; i++)
    {
        packet[i] = 0xFF; // opening 6 255 values
        macAddress[i] = cstringToHex(hex.substr(i*2,2).c_str()); // set initial mac address
    }
    for(int i = 1; i < 16; i++) // copy mac address 16 times to packet
    {
        memcpy(&packet[i * 6], &macAddress, 6 * sizeof(unsigned char));
    }
    for(int i = 96; i < 102; i++){ // fix for randomly occuring end of array last iteration copy error
        packet[i] = macAddress[i-96]; // set the mac address
    }
    cout << "Complete.\n";

    // ### Send Packet ###
    cout << "Sending Packet...\n";
    if(startup() != CPS_SUCCESS){ // if windows socket initialisation is required
        cout << "An error occured.\n";
        return -1; // return error
    }
    int socketnum = socket(AF_INET,SOCK_DGRAM,0); // connect to socket
    int bcast = 1;  // broadcast is set to 1
    struct sockaddr_in sendClient, sendServer;  // socket structs
    if(setsockopt(socketnum,SOL_SOCKET, SO_BROADCAST, (char *)&bcast, sizeof bcast) == -1) { // set socket type to udp broadcast
        cout << "An error occured.\n";
        return -1; // return error
    }
    sendServer.sin_family = AF_INET; // set socket family to ipv4
    sendServer.sin_addr.s_addr = inet_addr("255.255.255.255"); // set broadcast address
    sendServer.sin_port = htons(9); // set the packet port to udp 9
    bind(socketnum, (struct sockaddr*)&sendServer, sizeof(sendServer)); // bind the socket
    sendto(socketnum, packet, sizeof(unsigned char) * 102, 0, (struct sockaddr*)&sendServer, sizeof(sendServer)); // send the packet
    close(socketnum); // close the socket
    cout << "Wake On Lan packet sent.\n";

    return 0; // return success
}

char cstringToHex(const char * str) // convert a string to hex
{
    char * check; // check character
    long res = strtol(str,&check,16); // convert to base 16 (hex)
    return (*check==0)?res:' '; // if the check character = 0 then res is correct else return ' '
}

bool checkString(string &hex) // check the validity of the entered mac address
{
    hex.erase(remove(hex.begin(), hex.end(), ':'), hex.end()); // remove :'s
    hex.erase(remove(hex.begin(), hex.end(), '-'), hex.end()); // remove -'s
    if(hex.length() != 12){ return false; } // check length
    for(int i = 0; i < hex.length(); i++) // for each character
    {
        hex[i] = toupper(hex[i]); // convert to uppercase
        if(!(((int)hex[i] >= 48 && (int)hex[i] <= 57) || ((int)hex[i] >= 65 && (int)hex[i] <= 70))) // check valid characters
        {
            return false; // if invalid char return false
        }
    }
    return true; // return correct
}
