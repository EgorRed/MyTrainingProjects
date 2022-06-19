#include <iostream>
#include <Windows.h>

// Changing the color of the text in the console
// Only for Windows!


enum Colors {
    Black, 
    Blue, 
    Green, 
    Cyan, 
    Red, 
    Magenta, 
    Brown, 
    LightGray,
    DarkGray, 
    LightBlue, 
    LightGreen, 
    LightCyan, 
    LightRed, 
    LightMagenta, 
    Yellow, 
    White
};


template<Colors txt = LightGray, Colors bg = Black>
std::ostream& color(std::ostream& text) {
    HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleTextAttribute(hStdOut, (WORD)((bg << 4) | txt));
    return text;
}



int main() 
{
    std::cout << color<Green> << "Hello " << color<Red> << "World" << color << std::endl;
    
    return 0;
}