#include "TcpSocketClient.h"
#include <iostream>

namespace Sockets
{
    TcpSocketClient::TcpSocketClient (std::string host, int port)
    {
        if(!TcpSocket::create())
        {
            throw SocketException ("Could not create client socket.");
        }

        if(!TcpSocket::connect(host, port))
        {
            throw SocketException("Could not bind to port.");
        }
    }

    TcpSocketClient& TcpSocketClient::operator << (std::string& s)
    {
        if (!TcpSocket::send(s))
        {
            throw SocketException("Could not write to socket.");
        }
        return *this;
    }

    TcpSocketClient& TcpSocketClient::operator >> (std::string& s)
    {
        if(!TcpSocket::recv(s))
        {
            throw SocketException ("Could not read from socket.");
        }
        return *this;
    }
}
