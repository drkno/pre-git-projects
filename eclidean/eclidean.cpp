#include <iostream>

using namespace std;

int gcd(int small, int big)
{
    int remainer = 0, premainder=1;
    while(remainer != 1)
    {
        remainer = big%small;
        premainder = remainer;
        big = small;
        small = remainer;
    }
    return premainder;
}

int main()
{
    cout << gcd(24,68);
    return 0;
}
