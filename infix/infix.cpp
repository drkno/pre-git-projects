#include <iostream>
#include <stack>
#include <string>

using namespace std;

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

int precedence(char e)
{
    switch(e)
    {
        case ' ': return 999;
        case ')':
        case '(': return 3;
        case '*':
        case '/':
        case '%': return 2;
        case '+':
        case '-': return 1;
    }
    return 0;
}

string InfixToPostfix(string infix, unsigned int base, char numsArray[])
{
    // Consecutive Number Scan
    for(unsigned int i = 2; i < infix.length(); i++)
    {
        if(precedence(infix[i]) > 0 && precedence(infix[i-1]) == 0 && precedence(infix[i-2]) == 0)
        {
            infix = infix.insert(i," ");
        }
    }

    stack<char> operatorStack;
    string postfix = "";
    for(unsigned int i = 0; i < infix.length(); i++)
    {
        switch(precedence(infix[i])>0)
        {
            case true:
            {
                if(operatorStack.empty() || precedence(infix[i]) >= precedence(operatorStack.top()))
                {
                    operatorStack.push(infix[i]);
                    break;
                }
                else
                {
                    while(!operatorStack.empty() && precedence(infix[i]) < precedence(operatorStack.top()))
                    {
                        postfix += operatorStack.top();
                        operatorStack.pop();
                    }
                    operatorStack.push(infix[i]);
                }
            }
            default:
            {
                postfix += infix[i];
                break;
            }
        }
    }

    while(!operatorStack.empty())
    {
        postfix += operatorStack.top();
        operatorStack.pop();
    }
    return postfix;
}

int main()
{
    char chars[] = {'A','B','C','D','E','F'};
    string str;
    getline(cin,str);
    cout << InfixToPostfix(str,10,chars) << endl;
}
