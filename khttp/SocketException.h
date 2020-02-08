#pragma once
#ifndef include_socketexceptions
#define include_socketexceptions 1.0

namespace Sockets
{
    class SocketException
    {
        public:
            SocketException(std::string s):m_s(s){};
            ~SocketException() {};
            std::string description()
            {
                return m_s;
            }
        private:
            std::string m_s;
    };
}
#endif
