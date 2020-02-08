#include <iostream>
#include <string>
#include <cmath>
#include <stack>
#include <windows.h>

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

string EvaluatePostFix(string input, unsigned int base, char numsArray[])
{
    stack<unsigned int> postfixEval;
    for(unsigned int i = 0; i < input.length(); i++)
    {
        switch(input[i])
        {
            case ' ':
            {
                unsigned int temp = postfixEval.top(), iterator = 1;
                postfixEval.pop();
                while(!postfixEval.empty() && postfixEval.top() >= 0 && postfixEval.top() <= 9)
                {
                    temp += (postfixEval.top()*pow(10,iterator));
                    postfixEval.pop();
                    iterator++;
                }
                postfixEval.push(temp);
                break;
            }
            case '*':
            {
                unsigned int temp = postfixEval.top();
                postfixEval.pop();
                temp *= postfixEval.top();
                postfixEval.pop();
                postfixEval.push(temp);
                break;
            }
            case '/':
            {
                unsigned int temp1 = postfixEval.top();
                postfixEval.pop();
                unsigned int temp2 = postfixEval.top();
                postfixEval.pop();
                temp2 /= temp1;
                postfixEval.push(temp2);
                break;
            }
            case '+':
            {
                unsigned int temp = postfixEval.top();
                postfixEval.pop();
                temp += postfixEval.top();
                postfixEval.pop();
                postfixEval.push(temp);
                break;
            }
            case '-':
            {
                unsigned int temp1 = postfixEval.top();
                postfixEval.pop();
                unsigned int temp2 = postfixEval.top();
                postfixEval.pop();
                temp2 -= temp1;
                postfixEval.push(temp2);
                break;
            }
            default:
            {
                postfixEval.push(input[i]-48);
                break;
            }
        }
    }
    return decimalToBaseWithNumbers(base,postfixEval.top(),numsArray);
}

string InfixToPostfix(string input, unsigned int base, char numsArray[])
{
    string output="";
    stack<unsigned int> thestack;
    for(unsigned int i = 0; i < input.length(); i++)
    {
        switch(input[i])
        {
            case '+':
            case '/':
            case '*':
            case '-':
            {
                if(!thestack.empty()) {
                    output += thestack.top();
                    thestack.pop();
                }
                thestack.push(input[i]);
                break;
            }
            default:
            {
                if(output.length() > 0)
                {
                    if(output.back() == ' ')
                    {
                        output.resize(output.length()-1);
                    }

                    if(output.back()-48 <= 9)
                    {
                        output += input[i] + " ";
                        break;
                    }
                }

                output += input[i];
                break;
            }
        }
    }
    while(!thestack.empty())
    {
        output += thestack.top();
        thestack.pop();
    }
    return output;
}

int main(int argc, char* argv[])
{
    char chars[] = {'A','B','C','D','E','F'};
    string rpn = "12 4*";
    cout << InfixToPostfix("12*2+5-5",10,chars);
    return 0;
}
