/*
** WOL XBMC Launcher
*/

#include "cpsocket.h"
#include <cstdlib>
#include <iostream>
#include <string.h>
#include <iomanip>
#if !defined _WIN32 && !defined _WIN64
#include <sys/ioctl.h>
#include <net/if.h>
#endif

using namespace std;

#define port "9"

unsigned char mac_address[6];

void getMacAddr();

const char * getusername()
{
    #if defined _WIN32 || defined _WIN64
        return getenv("USERNAME");
    #else
        return getenv("USER");
    #endif
}

void *get_in_addr(struct sockaddr *sa)
{
	if (sa->sa_family == AF_INET) {
		return &(((struct sockaddr_in*)sa)->sin_addr);
	}

	return &(((struct sockaddr_in6*)sa)->sin6_addr);
}

int main(int argc, char** argv)
{
	cout << "XBMC WOL Launcher 1.0. Running as " << getusername() << "." << endl;

    startup();
    getMacAddr();

	struct addrinfo hints, *servinfo, *p;
	struct sockaddr_storage their_addr;

	socklen_t addr_len;
	char s[INET6_ADDRSTRLEN];

	memset(&hints, 0, sizeof hints);
	hints.ai_family = AF_UNSPEC;
	hints.ai_socktype = SOCK_DGRAM;
	hints.ai_flags = AI_PASSIVE;

	int rv;
	if ((rv = getaddrinfo(NULL, port, &hints, &servinfo)) != 0)
	{
	    cerr << "WOL: getaddrinfo error: " << gai_strerror(rv) << endl;
		return 1;
	}

	int sockfd;
	for(p = servinfo; p != NULL; p = p->ai_next) {
		if ((sockfd = socket(p->ai_family, p->ai_socktype,p->ai_protocol)) == -1)
		{
			cerr << "WOL: Socket Error." << endl;
			continue;
		}

		if (bind(sockfd, p->ai_addr, p->ai_addrlen) == -1)
		{
			close(sockfd);
			cerr << "WOL: Bind Error." << endl;
			continue;
		}

		break;
	}

	if (p == NULL) {
		cerr << "WOL: Failed to bind socket." << endl;
		return 2;
	}

	freeaddrinfo(servinfo);

	cout << "WOL: Waiting to receive magic packet." << endl;

	addr_len = sizeof their_addr;

	while (true)
	{
		int numbytes;
		char buf[200];
		if ((numbytes = recvfrom(sockfd, buf, 150 - 1, 0, (struct sockaddr *)&their_addr, &addr_len)) == -1) {
		    cerr << "WOL: Recvfrom error." << endl;
			return -1;
		}

		cout << "WOL: Got packet from " << inet_ntop(their_addr.ss_family, get_in_addr((struct sockaddr *)&their_addr), s, sizeof s) << "." << endl;
		cout << "WOL: Received packet length is " << numbytes << "." << endl;
		if (numbytes == 102)
		{
		    cout << "WOL: Received packet for mac ";
		    bool valid = true;
		    for(unsigned int i = 6; i < 12; i++)
		    {
		        cout << std::hex << (int)buf[i] << ((i==11)?"":":");
		        if(buf[i] != mac_address[i-6]) valid = false;
		    }
		    cout << "." << endl;

		    if(!valid) continue;

			cout << "WOL: Correct magic packet, executing command." << endl;

			system("sudo -u pi /usr/bin/xbmc-standalone &");
			close(sockfd);
			break;
		}
	}

	return 0;
}

void getMacAddr()
{
    #if defined _WIN32 || defined _WIN64
    // needs manual assigning
    #else
    struct ifreq ifr;
    struct ifconf ifc;
    char buf[1024];
    int success = 0;

    int sock = socket(AF_INET, SOCK_DGRAM, IPPROTO_IP);
    if (sock == -1) {return;};

    ifc.ifc_len = sizeof(buf);
    ifc.ifc_buf = buf;
    if (ioctl(sock, SIOCGIFCONF, &ifc) == -1) {return;}

    struct ifreq* it = ifc.ifc_req;
    const struct ifreq* const end = it + (ifc.ifc_len / sizeof(struct ifreq));

    for (; it != end; ++it) {
        strcpy(ifr.ifr_name, it->ifr_name);
        if (ioctl(sock, SIOCGIFFLAGS, &ifr) == 0) {
            if (! (ifr.ifr_flags & IFF_LOOPBACK)) {
                if (ioctl(sock, SIOCGIFHWADDR, &ifr) == 0) {
                    success = 1;
                    break;
                }
            }
        }
        else {return;}
    }
    if (success) memcpy(mac_address, ifr.ifr_hwaddr.sa_data, 6);
    #endif
}
