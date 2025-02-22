#include<iostream>

void swap1(int* x,int* y) // int* --> path by pointer
{
    int temp = *x;
    *x = *y;
    *y = temp;
}

void swap2(int& x , int& y) // int& --> path by reference
{                           // dige age & bezri az moteghyer copy nemigire khodesho mizare
    int temp = x;
    x = y;
    y = temp;
}


int main(int argc, char const *argv[])
{
    int a=7, b=9 ;
    std::cout << "a = " << a << "  ";
    std::cout << "b = " << b << std::endl;
    swap1(&a,&b);
    std::cout << "a = " << a << "  ";
    std::cout << "b = " << b << std::endl;
    swap2(a,b);
    std::cout << "a = " << a << "  ";
    std::cout << "b = " << b << std::endl;
    return 0;
}
