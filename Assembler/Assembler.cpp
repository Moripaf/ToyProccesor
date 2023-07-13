// Assembler.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>
#include <string>
using namespace std;


string turnCommand(string command)
{
    if ((command == "JMP") || (command == "jmp"))
        return "0000";
    else if ((command == "ADC") || (command == "adc"))
        return "0001";
    else if ((command == "XOR") || (command == "xor"))
        return "0010";
    else if ((command == "SBC") || (command == "sbc"))
        return "0011";
    else if ((command == "ROR") || (command == "ror"))
        return "0100";
    else if ((command == "TAT") || (command == "tat"))
        return "0101";
    else if ((command == "OR") || (command == "or"))
        return "0110";
   
    else if ((command == "AND") || (command == "and"))
        return "1000";
    else if ((command == "LDC") || (command == "ldc"))
        return "1001";
    else if ((command == "BCC") || (command == "bcc"))
        return "1010";
    else if ((command == "BNE") || (command == "bne"))
        return "1011";
    else if ((command == "LDI") || (command == "ldi"))
        return "1100";
    else if ((command == "STT") || (command == "stt"))
        return "1101";
    else if ((command == "LDA") || (command == "lda"))
        return "1110";
    else if ((command == "STA") || (command == "sta"))
        return "1111";
    
   
}
string turnAddr(string addr)
{
    int a = stoi(addr);
    string b = "000000000000";
    for(int i=11;a>0;i--)
    {
        b[i] = (a % 2) ? '1' : '0';
        a /= 2;
    }
    return b;
}
string assemble(string line)
{
    string out;
    string command, addr;
    int i,c;
    for (i = 0;  (i < line.length() && (line[i] != 32)); i++)
        command += line[i];
    out = turnCommand(command);
    for (c = ++i; i<line.length(); i++)
        addr += line[i];
    if (addr.length() > 1)
        addr = turnAddr(addr);
    else addr = "000000000000";
    return out + addr;
}
int main()
{
    string filename;
    cout << "enter the name of the file you wish to assemble :"<<endl;
    cin >> filename;
    ifstream input(filename);
    ofstream output(filename + ".out.txt");
    string line;
    int i=0;
    while (getline(input, line))
    {     
        cout << "line " << ++i<<": "<<line <<endl;
        output << assemble(line)<<endl;
    }
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu
