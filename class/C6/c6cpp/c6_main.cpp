#include<stdlib.h>


void swap(int* pa, int*pb)
{
    int tmp = *pa;
    *pa = *pb;
    *pb = tmp;    
}

void swap(int& a, int& b)
{
    int tmp = a;
    a = b;
    b = tmp;    
}

void swapv(int a, int b)
{
    int tmp = a;
    a = b;
    b = tmp;    
}




int main(int argc, char const *argv[])
{
    int x = 5;
    int y = 6;
    int* pNums = (int*) malloc(100 * sizeof(int));
    swapv(x, y);

    
    swap(x, y);
    /* code */
    return 0;
}
