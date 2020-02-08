#pragma once
#ifndef include_tcpsocket
#define include_tcpsocket 1.0

#if defined _WIN32 || defined _WIN64

#pragma comment(lib,"ws2_32.lib")
#define WINVER _WIN32_WINNT_VISTA
#include <winsock2.h>
#include <ws2tcpip.h>
#define EAFNOSUPPORT WSAEAFNOSUPPORT

#else

#define SOCKET unsigned int
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>
#include <arpa/inet.h>
#include <unistd.h>
#define EAFNOSUPPORT -1
#define errno 0
#include <cstdlib>

#endif

#include <sys/types.h>
#include <string>
#include "SocketException.h"

namespace Sockets
{
    const int MAXHOSTNAME = 200;
    const int MAXCONNECTIONS = 5;
    const int MAXRECV = 500;

    class TcpSocket
    {
        public:
            TcpSocket();
            virtual ~TcpSocket();
            bool create();
            bool bind(int port);
            bool listen();
            bool accept(TcpSocket&);
            bool connect(std::string host, int port);
            bool send(std::string);
            int recv(std::string&);
            void disconnect();
            SOCKET getBaseSocket() {
                return m_sock;
            }
        private:
            SOCKET m_sock;
            struct sockaddr_in m_addr;
            #if defined _WIN32 || defined _WIN64
            WSAData wsaData;
            #endif
            void memset(void * ptr, int value, size_t size);

            bool is_valid()
            {
                return (m_sock != 0);
            }
    };
}
#endif
