#include "cpsocket.h"
#include <stdlib.h>
#include <string>
#include <iostream>
#include <ctype.h>

using namespace std;

#define DEFAULT_BUFFER      2048

int port = 23;
string serverAddress = "192.168.1.1";
string sendMsg = "telnet";

int main(int argc, char **argv)
{
    if(startup() == CPS_ERROR){
        return 0;
    }

    SOCKET sClient;
    char buffer[DEFAULT_BUFFER];
    int ret,i;
    struct sockaddr_in server;
    struct hostent *host = NULL;

    sClient = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (sClient == INVALID_SOCKET)
    {
        cout << "socket() failed: " << errno << "\n";
        return 1;
    }
    server.sin_family = AF_INET;
    server.sin_port = htons(port);
    server.sin_addr.s_addr = inet_addr(serverAddress.c_str());

    if (server.sin_addr.s_addr == INADDR_NONE)
    {
        host = gethostbyname(serverAddress.c_str());
        if (host == NULL)
        {
            cout << "Unable to resolve server: " << serverAddress.c_str() << "\n";
            return 1;
        }
        CopyMemory(&server.sin_addr, host->h_addr_list[0], host->h_length);
    }
    if (connect(sClient, (struct sockaddr *)&server, sizeof(server)) == SOCKET_ERROR)
    {
        cout << "connect() failed: " << errno << "\n";
        return 1;
    }

    while(true)
    {
        cout << buffer << "\n";
        getline(cin,sendMsg,'\n');
        if(sendMsg == "exit"){ break; }
        ret = send(sClient, sendMsg.c_str(), sendMsg.length(), 0);
        if (ret == 0)
            break;
        else if (ret == SOCKET_ERROR)
        {
            cout << "send() failed: " << errno << "\n";
            break;
        }
        ret = recv(sClient, buffer, DEFAULT_BUFFER, 0);
        if (ret == 0)
        {
            break;
        }
        else if (ret == SOCKET_ERROR)
        {
            cout << "recv() failed: " << errno << "\n";
            break;
        }
        buffer[ret] = '\0';
    }
    close(sClient);
    return 0;
}
