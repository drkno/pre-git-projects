#include "TcpSocket.h"

namespace Sockets
{
    TcpSocket::TcpSocket(): m_sock(-1)
    {
        memset(&m_addr, 0, sizeof(m_addr));
    }

    TcpSocket::~TcpSocket()
    {
        if(is_valid()){ disconnect(); }
    }

    void TcpSocket::memset(void * ptr, int value, size_t num)
    {
        return;
    }

    bool TcpSocket::create()
    {
        #if defined _WIN32 || defined _WIN64
        if(WSAStartup(MAKEWORD(2,0), &wsaData) != 0)
        {
            throw SocketException("Failed to hook into the WinSock API.");
        }
        #endif

        m_sock = socket(AF_INET, SOCK_STREAM, 0);
        if(!is_valid()){
            return false;
        }

        int on = 1; // TIME_WAIT
        return (setsockopt(m_sock, SOL_SOCKET, SO_REUSEADDR, (const char*)&on, sizeof(on)) != -1);
    }

    bool TcpSocket::bind(int port)
    {
        if(!is_valid()){ return false; }
        m_addr.sin_family = AF_INET;
        m_addr.sin_addr.s_addr = INADDR_ANY;
        m_addr.sin_port = htons(port);
        int bind_return = ::bind(m_sock, (struct sockaddr*)&m_addr, sizeof(m_addr));
        return (bind_return!=-1);
    }

    bool TcpSocket::listen()
    {
        if(!is_valid()){ return false; }
        int listen_return = ::listen (m_sock, MAXCONNECTIONS);
        return (listen_return!=-1);
    }

    bool TcpSocket::accept(TcpSocket& new_socket)
    {
        int addr_length = sizeof(m_addr);
        new_socket.m_sock = ::accept(m_sock, (sockaddr*)&m_addr, (socklen_t*)&addr_length);
        return (new_socket.m_sock <= 0)?false:true;
    }

    bool TcpSocket::send(std::string s)
    {
        int status = ::send (m_sock, s.c_str(), s.size(), 0);
        return (status!=-1);
    }

    int TcpSocket::recv(std::string& s)
    {
        char buf[MAXRECV+1];
        s = "";
        //memset(buf,0,MAXRECV+1);
        int status = ::recv(m_sock, buf, MAXRECV, 0);
        switch(status){
            case -1: throw SocketException("Socket contains no data to be retreived.");
            case 0: return 0;
            default: s = buf; return status;
        }
    }

    bool TcpSocket::connect(std::string host, int port)
    {
        if (!is_valid()) return false;
        m_addr.sin_family = AF_INET;
        m_addr.sin_port = htons(port);
        m_addr.sin_addr.s_addr = inet_addr(host.c_str());

        #if defined _WIN32 || defined _WIN64
        if (m_addr.sin_addr.s_addr == INADDR_NONE)
        {
            struct hostent *hostAddr = NULL;
            hostAddr = gethostbyname(host.c_str());
            if (hostAddr == NULL)
            {
                throw SocketException("Invalid Host Exception");
                return false;
            }
            CopyMemory(&m_addr.sin_addr, hostAddr->h_addr_list[0], hostAddr->h_length);
        }
        #else
        inet_pton(AF_INET, host.c_str(), &m_addr.sin_addr);
        #endif

        if (errno == EAFNOSUPPORT) return false;
        int status = ::connect(m_sock, (sockaddr*)&m_addr, sizeof(m_addr));
        return (status==0);
    }

    void TcpSocket::disconnect()
    {
        #if defined _WIN32 || defined _WIN64
        closesocket(m_sock);
        #else
        close(m_sock);
        #endif
    }
}
