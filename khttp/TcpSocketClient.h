#pragma once
#ifndef include_tcpsocketclient
#define include_tcpsocketclient 1.0
#include "TcpSocket.h"
#include <vector>
#include <sstream>

namespace Sockets
{
    class TcpSocketClient : private TcpSocket
    {
        public:
            TcpSocketClient(std::string host, int port);
            virtual ~TcpSocketClient() {};
            TcpSocketClient& operator << (std::string&);
            TcpSocketClient& operator >> (std::string&);
            int latestStatus();
    };
}
#endif
