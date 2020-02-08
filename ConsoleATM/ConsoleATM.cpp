/*
    CONSOLE ATM SIMULATOR
    Authour:    Matthew Knox
    Copyright:  Knox Microsystems 2008-11.
    Language:   C++
    Local:      EN-AU
    Platforms:  Windows NT 4.0+, Mac OSX 10.4+, Linux (Solaris Tested), UNIX Like
*/

#include <iostream>
#include <fstream>
#include <vector>   // include required librarys
#include <cstdlib>
#include <string>
#include <sstream>
#include <ctime>
#ifdef _WIN32 || _WIN64
    #include <windows.h>
    #include <conio.h>
#endif

using namespace std;

void splash();  // splash screen
void clear();   // clear screen
void pauser();   // pause output
void coutWinColour(string text, int colour);       // colours for windows console
bool credChecker(string user);  // check credentials
void loggedIn(string AccName);  // logged in function
void createAcc(); // account creator
void crypt(string file, string key); // encrypter/decrypter
void receipt(string type,double amount);    // recipt generator
bool validInt(int number); // check if input is a valid number

int main()
{   
    // initialiser
    #ifdef _WIN32 || _WIN64
        system("title ATM");
        //coutWinColour("AuthReq", 12);   // auth to prevent running wihtout permission
        //pauser();
        //return 0;
    #endif
    clear();
    splash();
    clear();
    // end inititaliser

    // begin post
    int input;
    while(1){       // main menu while loop
        #ifdef _WIN32 || _WIN64
            coutWinColour("Main Menu\n-----------------\n",12);
            coutWinColour("[1] New Account\n[2] Login\n[3] Quit\n: ",15);
        #else
            cout << "Main Menu\n-----------------\n";                   // main menu
            cout << "[1] New Account\n[2] Login\n[3] Quit\n: ";
        #endif
        cin >> input;
        
        if(validInt(input) == false){
            clear();                                        // check input
            input = 0;
        } // if
        
        switch(input){
            case 1: clear(); createAcc(); break;    // create account
            case 2: {
                clear();
                string username;
                cin.clear();                    // login
                cin.ignore(4000,'\n');
                #ifdef _WIN32 || _WIN64
                    coutWinColour("Username: ", 14);
                #else
                    cout << "Username: ";
                #endif
                cin >> username;
                if(credChecker(username) == true) {     // retrive input
                    loggedIn(username);             // check input
                } else {
                    cout << "Incorrect Credentials\n";
                } // if
                clear();    // clear screen
                break;
            } // case 2
            case 3: return 0; break;    // quit
            default: clear(); break;    // just clear screen
        } // switch
        
    } // while
    // end post

    // begin destruction
    return 0;
    // end destruction
} // main

void receipt(string type,double amount){    // recipt generator

    #ifdef _WIN32 || _WIN64
        coutWinColour("Do you want to print a receipt? (y/n)", 14); // print prompt
        char c = _getch();  // get input
        if(c=='Y', c=='y'){
            cout << " Yes.\nPrinting....";
        } else {
            cout << " No.";
            Sleep(2000);            // check input
            clear();
            return;
        } // if
    #else
        char c = getchar(); // get input
        if(c=='Y', c=='y'){
            cout << "\nPrinting....";   // check input
        } else {
            cout << " No.";
            sleep(2);
            clear();
            return;
        } // if
    #endif

    ofstream print("print.txt");
    print << "RECEIPT\nThe bearer " << type << " the amount of $" << amount << "only."; // output receipt
    print.close();

    #ifdef _WIN32 || _WIN64
        system("start /min notepad /P print.txt");  // print using notepad windows
    #else
        system("open print.txt");
        cout << "On your platform you will have to manually print\n the document that just opened.\n";  // open under UNIX/Linux distros
        pauser();
    #endif

    return;
} // recipt

void loggedIn(string AccName){  // logged in function
    int input(0);   // initialise variables
    double balance(0);
    string password, history, file, temp, startbal, temp2;
    char date[9];
    #ifdef _WIN32 || _WIN64
        _strdate(date); // get date windows
    #else
        date[0] = '0';
        date[0] = '0';
        date[0] = '/';
        date[0] = '0';
        date[0] = '0';  // use blank date UNIX/Linux
        date[0] = '/';
        date[0] = '0';
        date[0] = '0';
    #endif

    file = AccName + ".srb";
    ifstream in(file.c_str());
    getline(in,temp,'\n');
    getline(in,temp,'\n');
    getline(in,password,';');   // retrive user information
    getline(in,temp,'\n');
    getline(in,startbal,';');
    getline(in,temp,'\n');
    getline(in,history,'~');
    in.close();

    stringstream ss;
    ss << startbal;     // convert balance to double
    ss >> balance;

    while(1){
        clear();
        temp = "Welcome back " + AccName + "\n-----------------------------------\n";
        #ifdef _WIN32 || _WIN64
            coutWinColour(temp, 12);
            coutWinColour("[1] Deposit Funds\n", 15);
            coutWinColour("[2] Withdraw Funds\n", 15);
            coutWinColour("[3] View History\n", 15);
            coutWinColour("[4] Print Statement\n", 15);         // present menu to user
            coutWinColour("[5] Change Password\n", 15);
            coutWinColour("[6] Logout\n", 15);
        #else
            cout << temp;
            cout << "[1] Deposit Funds\n";
            cout << "[2] Withdraw Funds\n";
            cout << "[3] View History\n";               // present basic menu to user
            cout << "[4] Print Statement\n";
            cout << "[5] Change Password\n";
            cout << "[6] Logout\n";
        #endif

        cin >> input;       // get input
        
        if(validInt(input) == false){   // if not a number
            input = 0;
        } // if

        switch(input){ 
            case 1: {       // deposit
                #ifdef _WIN32 || _WIN64
                    double amount;
                    coutWinColour("Enter the amount to deposit: $",14);     // prompt for deposit amount
                    cin >> amount;
                    balance += amount;      // change balance
                    receipt("Deposited",amount);    // generate receipt
                #else
                    double amount;
                    cout << "Enter the amount to deposit: $";   // prompt for deposit amount
                    cin >> amount;
                    balance += amount;      // change balance
                    receipt("Deposited",amount);    // generate receipt
                #endif
                history = history + "\n";
                history = history + date;   // add to account transaction history
                history = history + " - Deposit: ";
                stringstream ss;
                ss << amount;
                ss >> temp2;        // generate history
                history += temp2;
                cout << "$" << balance << " is what you now have.\n";   // display new balance
                pauser();
                break;
                } // case 1
            case 2: {       // withdraw
                #ifdef _WIN32 || _WIN64
                    double amount;
                    coutWinColour("Enter the amount to withdraw: $",14);    // prompt for amount
                    cin >> amount;
                    balance -= amount;  // subtract amount from balance
                    receipt("Withdrew",amount); // generate balance
                #else
                    double amount;
                    cout << "Enter the amount to withdraw: $";  // prompt for amount
                    cin >> amount;
                    balance -= amount;  // remove amount from balance
                    receipt("Withdrew",amount); // generate receipt
                #endif
                history = history + "\n";
                history = history + date;       // generate account transaction history
                history = history + " - Withdrew: ";
                stringstream ss;
                ss << amount;
                ss >> temp2;        // save history to variable
                history += temp2;
                cout << "$" << balance << " is what you now have.\n";   // display current balance
                pauser();
                break;
                } // case 2
            case 3: {
                #ifdef _WIN32 || _WIN64
                    coutWinColour("We have the following history on record for you transactions:\n",14);
                    coutWinColour(history,15);      // display history
                    cout << "\n";
                    pauser();
                #else
                    cout << "We have the following history on record for you transactions:\n";
                    cout << history << "\n";    // display history
                    pauser();
                #endif
                break;
                } // case 3
            case 4: {   // statement
                ofstream statement("statement.txt");
                statement << "STATEMENT\nUser: " << AccName << "\nBalance: $" << balance << "\nHistory:\n" << history;  // output statement
                statement.close();
                #ifdef _WIN32 || _WIN64
                    system("start /min notepad /P statement.txt");  //  print using notepad windows
                #else
                    system("open statement.txt");   // open under NIX/Linux distros
                #endif
                break;
            } // case 4
            case 5: {
                #ifdef _WIN32 || _WIN64
                int looper(1), error(0);
                while(looper == 1){         // loop forever
                    clear();                // clear screen
                    coutWinColour("Change Password\n--------------------------\n",14);
                    coutWinColour("Press ESC to Cancel Anytime",15);        // output info
                    coutWinColour("\nNew Password: ",15);

                    if(temp2.length() < 5 || temp2.length() == NULL){
                        coutWinColour("",12);                                   // display red and disallow continue if password is less than 5 characters
                        error = 1;
                    } else {
                        coutWinColour("",10);               // password is fine
                        error = 0;
                    } // if

                    for(int i=0;i<temp2.length();i++){
                        cout << "*";       // output *'s to screen
                    }

                    char c = _getch();           // get next character

                    if(c == 27){            // if escape character pressed
                        clear();
                        looper = 0;             // end routinue
                        break;
                    } // if

                    switch(c){
                        case '\r': {        // if enter/return is pressed
                        if(error == 0){
                            cout << "\n";   // no errors, break loop and continue
                            looper = 0;
                            password = temp2;       // change the password variable
                        } // if
                        break; // break loop        // otherwise just break switch
                        } // case return
                        case '\b':{ // if backspace key is pressed
                            if(temp2.length() != NULL && temp2.length() != 0){    // if the password actually contains something
                                temp2.erase(temp2.size() - 1, 1); // remove last character
                                cout << "\b \b";    // backspace a cout
                            } // if
                            break;  // break
                        } // case backspace
                        default: temp2 = temp2 + c; break;   // output * to screen
                    } // switch
                } // while
                #else
                clear();
                cin.clear();
                cin.ignore(4000,'\n');
                cout << "New Password: ";       // input new password through getline for other platforms
                getline(cin,password,'\n');
                #endif
                break;
                } // case 5
            case 6: {       // logout
                ofstream out(file.c_str());
                out << "fledcr;\n" << AccName << ";\n" << password << ";\n" << balance << ";\n" << history << "~";  // output new user file
                out.close();
                crypt(file,password);   // encrypt user file
                clear();
                return; // clear end exit
                break;
        } // case 5
    } // switch
    } // while
} // logged in

void createAcc(){ // account creator
    clear();
    string temp, username="", password;
    char c;
    double startbal(0);         // required variables
    int looper(1), error(0);

    #ifdef _WIN32 || _WIN64

        // USERNAME
        while(looper == 1){         // loop forever
            clear();                // clear screen
            coutWinColour("Create Account\n--------------------------\n",14);
            coutWinColour("Press ESC to Cancel Anytime\n\n",15);        // output info
            coutWinColour("Username: ",15);

            if(username.length() < 5 || username.length() == NULL){
                coutWinColour("",12);                                   // display red and disallow continue if username is less than 5 characters
                error = 1;
            } else {
                temp = username + ".srb";
                ifstream exists;
                exists.open(temp.c_str(), ifstream::in);            // check is username exists
                exists.close();
                if(exists.fail()){
                    coutWinColour("",10);               // username does not exist show green and allow continue
                    error = 0;
                } else {
                    coutWinColour("This User Already Exists: ",7);
                    coutWinColour("",12);               // username exists, show red and disallow continue
                    error = 1;
                } // if
            } // if
            cout << username;       // output username to screen

            c = _getch();           // get next character

            if(c == 27){            // if escape character pressed
                clear();
                return;             // end routinue
                break;
            } // if

            switch(c){
                case '\r': {        // if enter/return is pressed
                    if(error == 0){
                        cout << "\n";   // no errors, break loop and continue
                        looper = 0;
                    } // if
                    break; // break loop        // otherwise just break switch
                    } // case return
                case '\b':{ // if backspace key is pressed
                    if(username.length() != NULL && username.length() != 0){    // if the username actually contains something
                        username.erase(username.size() - 1, 1); // remove last character
                        cout << "\b \b";    // backspace a cout
                    } // if
                    break;  // break
                } // case backspace
                default: username = username + c; break;   // output * to screen
            } // switch
        } // while

        // PASSWORD
        looper = 1;
        while(looper == 1){         // loop forever
            clear();                // clear screen
            coutWinColour("Create Account\n--------------------------\n",14);
            coutWinColour("Press ESC to Cancel Anytime\n\n",15);        // output info
            coutWinColour("Username: ",15);
            coutWinColour(username,14);
            coutWinColour("\nPassword: ",15);

            if(password.length() < 5 || password.length() == NULL){
                coutWinColour("",12);                                   // display red and disallow continue if password is less than 5 characters
                error = 1;
            } else {
                coutWinColour("",10);               // password is fine
                error = 0;
            } // if

            for(int i=0;i<password.length();i++){
                cout << "*";       // output *'s to screen
            }

            c = _getch();           // get next character

            if(c == 27){            // if escape character pressed
                clear();
                return;             // end routinue
                break;
            } // if

            switch(c){
                case '\r': {        // if enter/return is pressed
                    if(error == 0){
                        cout << "\n";   // no errors, break loop and continue
                        looper = 0;
                    } // if
                    break; // break loop        // otherwise just break switch
                    } // case return
                case '\b':{ // if backspace key is pressed
                    if(password.length() != NULL && password.length() != 0){    // if the password actually contains something
                        password.erase(password.size() - 1, 1); // remove last character
                        cout << "\b \b";    // backspace a cout
                    } // if
                    break;  // break
                } // case backspace
                default: password = password + c; break;   // output * to screen
            } // switch
        } // while

        // STARTING BALANCE
        looper = 1;
        temp = "";
        for(int i=0; i<password.length();i++){
            temp = temp + "*";
        } // for
        string passTemp = temp;
        temp = "";
        while(looper == 1){         // loop forever
            clear();                // clear screen
            coutWinColour("Create Account\n--------------------------\n",14);
            coutWinColour("Press ESC to Cancel Anytime\n\n",15);        // output info
            coutWinColour("Username: ",15);
            coutWinColour(username,14);
            coutWinColour("\nPassword: ",15);
            coutWinColour(passTemp,14);                     // output already entered info
            coutWinColour("\nStarting Balance: $",15);
            coutWinColour("",14);

            cin >> startbal;        // get startbalance

            if(startbal < 0 || startbal > 50 || validInt(startbal) == false){   // input only numbers
                error = 1;
                coutWinColour("Invalid Start Balance. Enter the number only between 0 and 50.\n", 12);  // display requirements
                Sleep(3000);
            } else {
                looper = 0;
                coutWinColour("",7);    // break loop if amount is ok
            } // if
        } // while

        clear();
        coutWinColour("CREATING ACCOUNT",15);
        temp = username + ".srb";               // open usernamefile
        coutWinColour(" .",10);
        ofstream output(temp.c_str(),ios::app);     // output to username file while giving progress reports
        coutWinColour(" .",10);
        output << "fledcr;\n" << username << ";\n" << password << ";\n" << startbal << ";\n~";  // continue outputing
        coutWinColour(" .",10);
        output.close();
        crypt(temp,password);   // encrypt the file
        coutWinColour("\nDone!\n",15);
        coutWinColour("",7);
        pauser();
    #else
        while(1){         // loop forever
            clear();                // clear screen
            cout << "Create Account\n--------------------------\n";
            cout << "Username: ";
            getline(cin,username,'\n');                     // ask for username
            cout << "Password: ";
            getline(cin,password,'\n');                     // ask for password
            cout << "Starting Balance: $";
            cin >> startbal;        // get startbalance

            if(startbal < 0 || startbal > 50 || validInt(startbal) == false){   // input only numbers
                cout << "Account Creation Error.\n";
                break;
            } else {
                break;    // break loop if amount is ok
            } // if
        } // while

        clear();
        cout << "CREATING ACCOUNT";
        temp = username + ".srb";               // open usernamefile
        cout<<" .";
        ofstream output(temp.c_str(),ios::app);     // output to username file while giving progress reports
        cout<<" .";
        output << "fledcr;\n" << username << ";\n" << password << ";\n" << startbal << ";\n~";  // continue outputing
        cout<<" .";
        output.close();
        crypt(temp,password);   // encrypt the file
        cout << "\nDone!\n";
        pauser();
    #endif

} // account creator

bool credChecker(string user){  // check credentials
    string password; // password string

    #ifdef _WIN32 || _WIN64
        char c;                         // input char
        int looper(1);
        clear();                        // clear screen
        coutWinColour("Username: ", 14);
        coutWinColour(user, 10);            // output existing information in colour
        coutWinColour("\nPassword: ", 14);
        coutWinColour("",10);

        while(looper == 1){                       // pass input loop
            c = _getch();                   // input a character

            switch(c){
                case '\r': cout << "\n"; looper = 0; break; // break loop
                case '\b':{ // if backspace key is pressed
                    if(password.length() != NULL && password.length() != 0){    // if the password actually contains something
                        password.erase(password.size() - 1, 1); // remove last character
                        cout << "\b \b";    // backspace a cout
                    } // if
                    break;  // break
                } // case backspace
                default: password = password + c; cout << "*"; break;   // output * to screen
            } // switch
        } // while

        coutWinColour("",7);            // reset colour
    #else       // if other platform
        clear();    // clear screen
        cout << "Username: " << user << "\n";
        cout << "Password: ";       // output data
        getline(cin,password,'\n'); // request password
    #endif

    string temp = user + ".srb";    // evaluate file name
    crypt(temp,password);   // decrypt file using password provided
    ifstream check(temp.c_str());   // file to be checked for decryption

    getline(check,temp,'~');        // get file contents
    if(temp.find("fledcr;") == string::npos){   // if decryption notice not found
        temp = user + ".srb";
        crypt(temp,password);       // undo the fake decryption
        return false;               // return failure
    } else {
        return true;                // return correct password
    }

    check.close();
    return false;                   // failsafe return false

} // credential checker

void crypt(string file, string key){ // encrypter decrypter

    string temp;
    ifstream in(file.c_str());       // input stuff to be edited
    getline(in,temp,'~');
    in.close();

    int j(0);
    for(int i=0; i<temp.length(); i++){   // rase file contents to the power of the key
        temp[i] = temp[i] ^ key[j];     // what it says above
        if(j<key.length()){
            j++;        // increment the loop counter by one
        } else {
            j = 0;      // reset key length counter
        } // if
    } // for

    ofstream out(file.c_str());       // input stuff to be edited
    out << temp << "~";         // output changed contents to file
    out.close();

    return;
} // crypt

void splash(){  // splash screen
    vector<string> details;
    details.push_back("ATM Simulator\n");
    details.push_back("-------------------------------\n");
    details.push_back("Version 2.0");             // splash details
    details.push_back("Written by Matthew Knox");
    details.push_back("Copyright © Knox Microsystems 2008-11.");

    #ifdef _WIN32 || _WIN64                 // add some colour on windows
        coutWinColour(details[0],12);
        coutWinColour(details[1],12);
    #else
        cout << details[0] << details[1];   // and no colour on other platforms
    #endif

    for(int i = 2; i<details.size(); i++){
        cout << details[i] << "\n";             // output version details
    } // for

    #ifdef _WIN32 || _WIN64
        Sleep(4000);                        // add delay
    #else
        sleep(4);
    #endif
} // splash

void clear(){ // clear screen
    // these are the easiest ways to clear the screen on most systems
    // however these interrupt all current systems processes and have
    // nasty side effects such as security holes.
    // the reason that i have used them is because there is no cross
    // platform method for clearing the screen.
    #ifdef _WIN32 || _WIN64
        system("cls");
    #else
        system("clear");
    #endif
} // clear

void pauser(){ // pause function
    #ifdef _WIN32 || _WIN64
        system("pause");
    #else
        cout << "Press return/enter to continue....";
        cin.clear();
        cin.get();                      // wait for return/enter key
    #endif
} // pause

void coutWinColour(string text, int colour){       // colours for windows console
    #ifdef _WIN32 || _WIN64
        HANDLE conColour;                    // console handeler
        conColour = GetStdHandle(STD_OUTPUT_HANDLE);    // assign the console handeler to the console window
        SetConsoleTextAttribute(conColour, colour); // set console colour to variable colour
        cout << text;                               // output text
        if(text != ""){                             // just leve the colour changed
            SetConsoleTextAttribute(conColour, 7);     // reset to grey as default colour
        } // if
    #else
        cout << "THIS FUNCTION IS NOT AVAILIBLE YET FOR OTHER PLATFORMS.\n";        // if not windows
    #endif
} // coutWinColour

bool validInt(int number){                         // validate if input is int
    
    if (cin.fail()){ // no cin actually happened
        cin.clear(); // reset
        cin.ignore(1000, '\n'); // clear bad input from the stream
        return false;
    }
    
    cin.ignore(1000, '\n'); // clear remaining input from the stream
    if (cin.gcount() > 1){ // cleared >1 additional character?
        return false;
    }
    
    if (number <= 0){ // is not positive?
        return false;
    }
    return true;    // real num
}

