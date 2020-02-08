#include <iostream>
#include <string>
#include <cmath>

using namespace std;

string decimalToBase(unsigned int base, unsigned int number, char resultCharacters[]);
string decimalToBaseWithNumbers(unsigned int base, unsigned int number, char resultCharacters[]);
unsigned int baseToDecimal(unsigned int base, string number, char fromCharacters[]);
unsigned int baseToDecimalWithNumbers(unsigned int base, string number, char fromCharacters[]);

int main()
{
    char chars[] = {'A','B','C','D','E','F'};
    unsigned int thenum;
    cin >> thenum;
    string str2 = decimalToBaseWithNumbers(2,thenum,chars);
    string str13 = decimalToBaseWithNumbers(13,thenum,chars);
    string str16 = decimalToBaseWithNumbers(16,thenum,chars);
    string str12 = decimalToBaseWithNumbers(12,thenum,chars);
    cout << str2 << "\n" << str13 << "\n" << str16 << "\n" << str12;
    return 0;
}

string decimalToBaseWithNumbers(unsigned int base, unsigned int number, char resultCharacters[])
{
    string result;
    unsigned int temp;
    while(number > 0)
    {
        temp = number%base;
        result = ((temp >= 10)?resultCharacters[temp-10]:(char)(temp+48)) + result;
        number -= temp;
        number /= base;
    }
    return result;
}

string decimalToBase(unsigned int base, unsigned int number, char resultCharacters[])
{
    string result;
    unsigned int temp;
    while(number > 0)
    {
        temp = number%base;
        result = resultCharacters[temp] + result;
        number -= temp;
        number /= base;
    }
    return result;
}

unsigned int baseToDecimalWithNumbers(unsigned int base, string number, char fromCharacters[])
{
    unsigned int result = 0;
    for(unsigned int i = 0; i < number.length(); i++)
    {
        unsigned int pos = number.length() - i - 1, temp = 0;
        if(number[pos]-48 >= 0 && number[pos]-48 <= 9){ temp = number[pos] - 48; }
        else {
            for(unsigned int j = 0; j < base-10; j++)
            {
                if(toupper(fromCharacters[j]) != toupper(number[pos])) continue;
                temp = j + 10;
                break;
            }
        }
        result += pow(base,i) * temp;
    }
    return result;
}

unsigned int baseToDecimal(unsigned int base, string number, char fromCharacters[])
{
    unsigned int result = 0;
    for(unsigned int i = 0; i < number.length(); i++)
    {
        unsigned int pos = number.length() - i - 1, temp = 0;
        for(unsigned int j = 0; j < base; j++)
        {
            if(toupper(fromCharacters[j]) != toupper(number[pos])) continue;
            temp = j;
            break;
        }
        result += pow(base,i) * temp;
    }
    return result;
}
