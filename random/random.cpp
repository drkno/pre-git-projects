#include <cstdlib>
#include <stdio.h>
#include <ctime>

using namespace std;

double random(int low, int high);

double seed, total;

int main() {
    seed = (double)time(NULL);

    for(int i=0; i<30; i++){
        double temp = random(1,10);
        total += temp;
        printf("%f\n",temp);
    }

    double average = total / 30;
    printf("TOTAL: %f\nAVERAGE = %f", total, average);

    return 0;
} // main

double random(int low, int high){
    double num1, num2, num3, num4;
    srand(seed);

    num1 = rand();
    num2 = rand();
    num3 = rand();
    num4 = rand();

    num1 = num1 * num2 / num3 + num4;
    num1 = num1 - num3 + num2;
    num1 = num1 * num1 / num4;
    num1 = num1 * rand() / rand();
    srand(num1);
    seed = num1 * (double)time(NULL) / num2;

    return (rand() % (high - low + 1) + low);
}
