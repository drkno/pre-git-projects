#include <string>
#include <stdio.h>

//#define CP_LOCAL_INCLUDES
#include "crossplatform.h"

using namespace std;

int main(){

    clrscreen();
    printf("Username: ");
    string username = TextInput();
    printf("\nPassword: ");
    string password = PasswdInput();

    if(username == password){
        printf("\nCorrect Login\n");
    } else {
        printf("\nIncorrect Login\n");
    }

    pauser();
    printf("\n");
    return 0;
}
