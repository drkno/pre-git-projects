/*
C++ GTB1 MK Basic Language Interpreter
Copyright (c) Matthew Knox 2014-Present. All rights reserved.

This program is distributed under the LGPL 2 Licence which is avalible
from the GPL website.
*/

#include <iostream>
#include <vector>
#include <string>
#include <sstream>
#include <map>
#include <stack>

using namespace std;

/* Variables */
map<string,int> Variables;		// map to store variables
int lineIncrement;				// variable to store the difference between line numbers

/* Prototypes */
int EvalExpression(string);
bool Comparison(string&, string&, string&);
string ToLower(string);
int Priority(char a);
void ReplaceStringInPlace(std::string&, const std::string&,const std::string&);

/* Base Class */
class cmd
{
public:
	int line, command;
	virtual int execute() { return -1; }		// return default next line
	
	cmd(int aline, int acommand)
	{
		line = aline;			// set line number
		command = acommand;		// set command number
	}
};

vector<cmd*> Commands;			// vector to store commands

/* Let command class */
class letcmd : public cmd
{
public:
	string variable, expression;
	letcmd(int aline, string exp) : cmd(aline, 0)
	{
		variable = exp.substr(1, exp.find("=")-2);	// set the variable
		expression = exp.substr(exp.find("=")+2);	// set the expression
	}
	int execute()
	{
		Variables[variable] = EvalExpression(expression);	// evaluate the expression
		return -1;	// goto next line
	}
};

/* Out command class */
class outcmd : public cmd
{
public:
	string expression;
	outcmd(int aline, string exp) : cmd(aline, 6)
	{
		expression = exp;	// Set the expression
	}
	int execute()
	{
		cout << EvalExpression(expression) << endl;	// Evaluate and output the expression
		return -1;	// goto next line
	}
};

/* Evaluate command class */
class evalcmd : public outcmd
{
public:
	evalcmd(int aline, string exp) : outcmd(aline, exp)	{ command = 8; } // clone out command with new command number
};

/* Goto command class */
class gotocmd : public cmd
{
public:
	int gline;
	gotocmd(int aline, string expression) : cmd(aline, 1)
	{
		gline = EvalExpression(expression);	// get line number from expression
		gline /= lineIncrement;	// generate array iterator number from
		gline -= 1;				// input number
	}
	int execute()
	{
		return gline;	// return line num
	}
};

/* Comment command class */
class commentcmd : public cmd
{
public:
	commentcmd(int aline, string comment) : cmd(aline, 7) {} // stub command as dones nothing
};

/* If command class */
class ifcmd : public gotocmd
{
public:
	string expr1, expr2, oper;
	ifcmd(int aline, string expression) : gotocmd(aline,expression.substr(expression.find("goto")+5))
	{
		command = 2;
		unsigned int ipos;
		ipos = expression.find("=");
		ipos = ipos > expression.find(">") ? expression.find(">") : ipos;	// get operator
		ipos = ipos > expression.find("<") ? expression.find("<") : ipos;
		oper = expression.substr(ipos, 2);
		ReplaceStringInPlace(oper," ","");
		expr1 = expression.substr(0, expression.find("goto")-1);
		expr2 = expr1.substr(expr1.find(oper) + oper.length());	// get right hand side of if
		expr1 = expr1.substr(0, expr1.find(oper) - 1);			// get left hand side of if
	}
	int execute()
	{
		if(Comparison(oper,expr1,expr2)) return gotocmd::execute();	// do comparison, if true goto line
		return -1;													// otherwise goto next line
	}
};

/* For command class */
class forcmd : public letcmd
{
public:
	string variable;
	int to;
	forcmd(int aline, string expr) : letcmd(aline, expr.substr(0, expr.find(" to")))
	{
		command = 3;
		variable = expr.substr(1,expr.find(" =")-1);			// get variable
		to = EvalExpression(expr.substr(expr.find("to ")+3));	// get to number
	}
	int execute()
	{
		return letcmd::execute();	// set initial variable
	}
};

/* Next command class */
class nextcmd : public cmd
{
public:
	int gline;
	int to;
	string variable;
	nextcmd(int aline, string expression) : cmd(aline, 5)
	{
		variable = expression.substr(1);	// set variable
		int depth = 0;	// depth is a way of keeping track of the block
		for (unsigned int i = aline-1; i >= 0; i--)		// search for beginning of the form
		{
			if(Commands[i]->command == 5) { depth++; }	// increment depth for each next
			if(Commands[i]->command == 3) { depth--; }	// decrement depth for each for

			if (Commands[i]->command != 3 || depth != -1) continue; // check command and depth are correct
			forcmd* com = (forcmd*)Commands[i];						// convert back to for command
			if (com->variable != variable) continue;				// check variable is the same
			to = com->to;		// set the to variable
			gline = i+1;		// set the goto line to the line after the for
			break;
		}
	}
	int execute()
	{
		if(Variables[variable] == to) return -1;	// If variable has reached target, goto next line
		Variables[variable]++;						// Otherwise increment the variable
		return gline;								// Return the line after the beginning of the for
	}
};

/// <summary>
/// Main program entry point.
/// </summary>
/// <param name="argc">Number of arguments provided.</param>
/// <param name="argv">Array of char arrays containing program arguments.</param>
/// <returns>Success code.</returns>
int main(int argc, char** argv)
{
	int progCount = 0;	// program counter for output "Programme " << progCount << endl
	while(true)
	{
		progCount++;	// increment the program counter
		try
		{
			int n = 0;			// input number of lines
			cin >> n;
			if(n == 0) break;	// if no lines follow then quit
			cin.clear();		// make sure the input buffer is clear
			for(int i = 0; i < n; i++)	// for each line
			{
				int tempLine = 0;
				cin >> tempLine;	// input line number
				if (i == 0) { lineIncrement = tempLine; tempLine = 0; }	// if i is the first line then it will be the line increment
				else tempLine = (tempLine / lineIncrement) - 1;			// otherwise divide by the increment and -1
				string command;
				cin >> command;		// input command name
				string expression;
				getline(cin,expression,'\n');		// input command arguments
				expression = ToLower(expression);	// make everything lowercase
				cmd* line;

				switch(tolower(command[0]))
				{
				case 'l': line = new letcmd(tempLine, expression); break;
				case 'g': line = new gotocmd(tempLine, expression); break;
				case 'i': line = new ifcmd(tempLine, expression); break;
				case 'f': line = new forcmd(tempLine, expression); break;		// create an appropriate object for command
				case 'n': line = new nextcmd(tempLine, expression); break;
				case 'o': line = new outcmd(tempLine, expression); break;
				case 'c': line = new commentcmd(tempLine, expression); break;
				case 'e': line = new evalcmd(tempLine, expression); break;
				default: throw -1;
				}

				Commands.push_back(line);	// add to commands vector
			}

			cout << "Programme " << progCount << endl;				// output program number

			for (unsigned int i = 0; i < Commands.size(); i++)		// for each line in program
			{
				int currLine = 0;
				currLine = Commands[i]->execute();					// execute that line
				if (currLine >= 0)									// if the returned number is a valid line num
				{
					i = currLine - 1;								// set that line to current line
				}
			}

			Commands.clear();
			Variables.clear();		// clear input program data
			lineIncrement = 0;
		}
		catch(int e)	// some unknown error occured
		{
			cout << "Basic::Exception : Invalid syntax in program " << progCount << ". JIT execution aborted." << endl;
		}
	}
	return 0;
}

/// <summary>
/// Converts a string to lowercase.
/// </summary>
/// <param name="cmd">String to make lowercase.</param>
/// <returns>Lowercase string.</returns>
string ToLower(string cmd)
{
	for(unsigned int i = 0; i < cmd.length(); i++)
	{
		cmd[i] = tolower(cmd[i]);
	}
	return cmd;
}


/// <summary>
/// Finds and replaces all occurances of a string in a string.
/// </summary>
/// <param name="subject">The subject of the search.</param>
/// <param name="search">The string to search for.</param>
/// <param name="replace">The string to replace with.</param>
void ReplaceStringInPlace(string& subject,const string& search,const string& replace)
{
    size_t pos = 0;
    while ((pos = subject.find(search, pos)) != string::npos)
	{
         subject.replace(pos, search.length(), replace);
         pos += replace.length();
    }
}

/// <summary>
/// Returns the priority of different operators.
/// </summary>
/// <param name="a">Operand</param>
/// <returns>The priority of the operand.</returns>
int Priority(char a) {
    int temp = 0;
    if (a == '^')
        temp = 1;
    else if (a == '*' || a == '/')
        temp = 2;
    else if (a == '+' || a == '-')
        temp = 3;
	else if (a == '%')
		temp = 4;
	else if (a == '(' || a == ')')
		temp = 5;
    return temp;
}

/// <summary>
/// Evaluates an integer based infix expression.
/// <summary>
/// <param name="expression">Infix expression to evaluate.</param>
/// <returns>The result of the expression.</returns>
int EvalExpression(string expression)
{
	// Cleanup infix string and resolve variables
	ReplaceStringInPlace(expression,"("," ( ");
	ReplaceStringInPlace(expression,")"," ) ");
	ReplaceStringInPlace(expression,"+"," + ");
	ReplaceStringInPlace(expression,"-"," -");
	ReplaceStringInPlace(expression,"*"," * ");
	ReplaceStringInPlace(expression,"/"," / ");
	ReplaceStringInPlace(expression,"%"," % ");

    stringstream ss; ss << expression;
    vector<string> ivariables;
    while(!ss.eof())
    {
        string temp;
        getline(ss,temp,' ');
        if(temp.length() > 0 && ((temp[0] >= 'a' && temp[0] <= 'z') || (temp[0] >= 'A' && temp[0] <= 'Z')))
        {
            // Is Variable
			if (Variables.find(temp) == Variables.end())
			{
				ivariables.push_back(temp);
			}
			else
			{
				stringstream s1;
				s1 << Variables[temp];
				ivariables.push_back(s1.str());
			}
        }
        else if(temp.length() > 0 && ((temp[0] >= '0' && temp[0] <= '9')||temp[0]=='+'||temp[0]=='-'||temp[0]=='*'||temp[0]=='/'||temp[0]=='%'||temp[0]=='('||temp[0]==')'))
        {
            ivariables.push_back(temp);
        }
    }

	// Convert Infix to Postfix
    stack<char> operator_stack;

    int outIt = 0;
    for (unsigned i = 0; i < ivariables.size(); i++) {
		if (ivariables[i][0] == '+' || (ivariables[i][0] == '-' && ivariables[i].length() == 1) || ivariables[i][0] == '*' || ivariables[i][0] == '/' || ivariables[i][0] == '^' || ivariables[i][0] == '%') {
            while (!operator_stack.empty() && Priority(operator_stack.top()) <= Priority(ivariables[i][0])) {
                ivariables[outIt] = operator_stack.top();
                outIt++;
                operator_stack.pop();
            }
            operator_stack.push(ivariables[i][0]);
        } else if (ivariables[i][0] == '(') {
            operator_stack.push(ivariables[i][0]);
			ivariables.erase(ivariables.begin()+i);
			i--;
        } else if (ivariables[i][0] == ')') {
			ivariables.erase(ivariables.begin()+i);
			i--;
			while (!operator_stack.empty()) {
				if(operator_stack.top() == '(')
				{
					operator_stack.pop();
					break;
				}

                ivariables[outIt] = operator_stack.top();
                outIt++;
                operator_stack.pop();
            }
        } else {
            ivariables[outIt] = ivariables[i];
            outIt++;
        }
    }

    while (!operator_stack.empty()) {
        ivariables[outIt] = operator_stack.top();
        outIt++;
        operator_stack.pop();
    }

	// Evaluate Postfix
    stack<int> infixStack;

    int nr1, nr2; int length = ivariables.size();

    for (int i = 0; i < length; i++)
    {
        if (isdigit(ivariables[i][0]) || (ivariables[i][0] == '-' && ivariables[i].length() > 1 && isdigit(ivariables[i][1])))
        {
            stringstream s1; s1 << ivariables[i];
            int temp; s1 >> temp;
            infixStack.push(temp);
        }
        else
        {
			nr1 = infixStack.top();
            infixStack.pop();
            nr2 = infixStack.top();
            infixStack.pop();
            switch(ivariables[i][0])
            {
                case '+':
                    infixStack.push(nr2 + nr1);
                    break;
                case '-':
                    infixStack.push(nr2 - nr1);
                    break;
                case '*':
                    infixStack.push(nr2 * nr1);
                    break;
                case '/':
                    infixStack.push(nr2 / nr1);
                    break;
				case '%':
					infixStack.push(nr2 % nr1);
					break;
                default:
					infixStack.push(nr2);
					infixStack.push(nr1);
                    break;
            }
        }
    }

    return infixStack.top();
}

/// <summary>
///	Evaluates a boolean string expression compairing integer values.
/// </summary>
/// <param name="expr1">Left side of the expression</param>
/// <param name="expr2">Right side of the expression</param>
/// <param name="op">Preselected operator to check.</param>
/// <returns>The result of the expression.</returns>
bool Comparison(string &op, string &expr1, string &expr2)
{
	int res1 = EvalExpression(expr1);			// get left hand side of if
	int res2 = EvalExpression(expr2);			// get right hand side of if

	if (op == "<>") return true;				// this operator is always going to be true

	for (unsigned int i = 0; i < op.length(); i++)	// for each character in operator
	{
		bool result;
		switch(op[i])
		{
		case '=': result = res1 == res2; break;
		case '<': result = (res1 < res2); break;	// check operators
		case '>': result = (res1 > res2); break;
		}
		if(result) return true; // will always return true if an operand is true
	}
	return false; // no trues == false
}