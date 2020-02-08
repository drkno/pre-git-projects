#include <winsock2.h>
#include <iostream>

using namespace std;

int main()
{
	char MAC[13];
	cout << "Enter MAC Address for Machine to wake up:" << endl;
	cin >> MAC;

	cout << "Waking up..." << endl;

	char L = (char)255;
	cout << L << endl;

	WSADATA WS2Info;
	if (!WSAStartup(MAKEWORD(2,2), &WS2Info)){
		SOCKET MagicPacket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
		if (MagicPacket != INVALID_SOCKET){
			hostent *ResolveHost;
			char* HostAddress = ""; // Target IP
			ResolveHost = gethostbyname(HostAddress);

			SOCKADDR_IN Host;
			Host.sin_family = AF_INET;
			Host.sin_port = 0;
			Host.sin_addr.s_addr = *((unsigned long*)ResolveHost->h_addr);


			short MACconv[6];
			memset(MACconv, '\0', 6);

			bool FirstDigit = true;
			int Pos = 0;

			for ( int i = 0; i < 12; i++){
				//cout << MAC[i] << Pos << endl;
				switch(MAC[i]){
				case '0':
					if (FirstDigit){
						MACconv[Pos] = 00000000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000000 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '1':
					if (FirstDigit)
					{
						MACconv[Pos] = 00010000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000001 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '2':
					if (FirstDigit)
					{
						MACconv[Pos] = 00100000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000010 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '3':
					if (FirstDigit)
					{
						MACconv[Pos] = 00110000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000011 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '4':
					if (FirstDigit)
					{
						MACconv[Pos] = 01000000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000100 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '5':
					if (FirstDigit)
					{
						MACconv[Pos] = 00010000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000001 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '6':
					if (FirstDigit)
					{
						MACconv[Pos] = 01100000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000110 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '7':
					if (FirstDigit)
					{
						MACconv[Pos] = 01110000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00000111 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '8':
					if (FirstDigit)
					{
						MACconv[Pos] = 10000000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001000 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case '9':
					if (FirstDigit)
					{
						MACconv[Pos] = 10010000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001001 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case 'A':
					if (FirstDigit)
					{
						MACconv[Pos] = 10100000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001010 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case 'B':
					if (FirstDigit)
					{
						MACconv[Pos] = 10110000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001011 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case 'C':
					if (FirstDigit)
					{
						MACconv[Pos] = 11000000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001100 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case 'D':
					if (FirstDigit)
					{
						MACconv[Pos] = 11010000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001101 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case 'E':
					if (FirstDigit)
					{
						MACconv[Pos] = 11100000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001110 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				case 'F':
					if (FirstDigit)
					{
						MACconv[Pos] = 11110000 | MACconv[Pos];
						FirstDigit = false;
					}
					else
					{
						MACconv[Pos] = 00001111 | MACconv[Pos];
						FirstDigit = true;
						Pos += 1;
					}
					break;
				}
			}


			short WakeUpMsg[103]; // 103

			memset(WakeUpMsg, '\0', 103);

			memset(WakeUpMsg, 255, 6);

			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);

			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);

			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);

			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);
			memcpy(WakeUpMsg, MACconv, 6);

			sendto(MagicPacket, (char*)WakeUpMsg, 128, 0, (SOCKADDR *)&Host, sizeof(Host));
		}
	}
	return 0;
}
