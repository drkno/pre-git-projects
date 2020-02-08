/*
    Cross Platform Sockets Header
    Version 1.01
    Authour: Matthew Knox
    Copyright Matthew Knox 2011 to Present.

    You are free to distribute, modify, copy, sell
    and do whatever you like with this code as long
    as this notice remains attached to the code.
*/

#ifndef CPSOCKET_H_INCLUDED
    #define CPSOCKET_H_INCLUDED
    #include <sys/types.h>

    #define CPS_ERROR 1
    #define CPS_SUCCESS 0

    int startup();
    void end();

    #if defined _WIN32 || defined _WIN64 // if windows
        int close(int socket);

        #include <winsock2.h>
        #include <ws2tcpip.h>

        //#define errno WSAGetLastError()
        #pragma comment(lib,"libws2_32.a")
        #pragma comment(lib,"ws2_32.lib")

        WSADATA wsaData;

        int startup(){
            if (WSAStartup(MAKEWORD(2,0), &wsaData) != 0){
                #ifdef _STDIO_H_
                    printf("WSAStartup failed.\n");
                #endif
                return CPS_ERROR;
            }
            return CPS_SUCCESS;
        }

        int close(int socket){
            closesocket(socket);
            end();
            return CPS_SUCCESS;
        }

        void end(){
            WSACleanup();
        }
    #else // any posix complient system
        #include <sys/socket.h>
        #include <arpa/inet.h>
        #include <netdb.h>
        #include <netinet/in.h>
        #include <unistd.h>

        int startup(){
            return CPS_SUCCESS;
        }

        void end(){
        }
    #endif // platform
#endif // CPSOCKET_H_INCLUDED

