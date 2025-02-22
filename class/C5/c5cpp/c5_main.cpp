#include<iostream>
using namespace std;
class Student
{
public:
    Student(string name, int id) // default constructor
        : m_Name(name)
        , m_StdId(id)
    {
    }

    void PrintName() // baraye object
    {
        cout << m_Name << "\t" << m_StdId << endl;
    }

    void swap(int &a, int& b) // baraye object // path by reference
    {
        int tmp = a;
        a = b;
        b = tmp;
    }

    static int NewStudentId(); // baraye class e na object
    // static int NewStudentId()
    // {
    //     return ++s_LastStudentId;
    // }

private:
    static int s_LastStudentId; // static marboot be class ee na object az aval ta akhar ham hast va taghir nemikone mesl global be khater hamin migan static(paydar)
    int m_StdId; // baraye object ee shabihe locale
    string m_Name; // baraye object
};

int Student::s_LastStudentId  = 99521000; // initializing static variable // chon biroon main ee mishe private ro dast zad

int Student::NewStudentId()
{
    // s_LastStudentId += rand(1, 5);
    return ++s_LastStudentId;
}



int main(int argc, char const *argv[])
{
    Student ali("Ali", Student::NewStudentId()); // syntax estefade az tabe static(marboot be class)
    ali.PrintName();

    Student alex("Alex", Student::NewStudentId()); // syntax estefade az tabe static(marboot be class)
    alex.PrintName();

    Student* pZohreh = new Student("Zohreh", Student::NewStudentId()); // new = malloc // new automatic ye seri kara ro anjam mide
    int* pArray = new int[10]; // (int*)malloc(sizeof(int)*10)

    (*pZohreh).PrintName();
    pZohreh->PrintName();

    for (int i = 0; i < 10; i++)
        pArray[i] = i;
    for (int i = 0; i < 10; i++)
        cout << pArray[i] << endl;
    
    delete pZohreh; // free
    delete pArray; // free
    // free != malloc
    // delete != new

    // Student::s_LastStudentId += 1; agar private nabashe

    std::cout << "Hello World" << std::endl;
    return 0;
}
