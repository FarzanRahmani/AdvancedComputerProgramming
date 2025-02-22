#include <vector>
#include <iostream>
#include <string.h>

using namespace std;

class farzanstr
{
public:
    // hint : string araye ii az character ha ast
    farzanstr(char* pch) // tabe ee initialize(tarid avalie) *** constructor ***
        : m_pData(nullptr) // initializer list
        , m_nSize(0)
    {
        assign(pch);
    }

    ~farzanstr() // destructor // vaghti ke az scope khrej mishe free kon
    {
        if (m_pData) // nullptr nabood
            free(m_pData);
    }

    int get_size()
    {
        return m_nSize;
    }

    const char* get_data()
    {
        return m_pData;
    }

    void assign(const char* pch)
    {
        if (m_pData) // m_pData != nullptr
            free(m_pData); // memory leak

        m_nSize = strlen(pch); // string.h
        m_pData = (char*) malloc( (m_nSize+1) * sizeof(char)); // +1 --> baraye sefr akhar
        strcpy(m_pData,pch);  // string.h (strcpy_s --> secure)
    }

private: // biroon az inja (dakhel tarif class) ghabel dast zadan va taghir nist
    char* m_pData;// m--> member variable , p -->pointer
    int m_nSize;// m--> member variable , n --> number
};

int main(int argc, char const *argv[])
{
    int x = 5; // primitive type
    char buf[5] = "asd";

    string str = "ali";// std::string // string --> class , str --> object
    str = "adafdjfkjhkvjsdfdsc";
    
    farzanstr name("hosseingholikhan"); // name har chi mitoone bashe

    cout << name.get_size() << endl;
    cout << name.get_data() << endl; // name.m_pData ghabel estefade nist chon ke private ast

    name.assign("khaleghezi");
    cout << name.get_size() << endl;
    cout << name.get_data() << endl;


    for(int i=0; i<10000; i++)
    {
        char buf[6] = "abcde";
        buf[4] = (i % 26) + 65;

        farzanstr name1(buf);
        cout << name1.get_data() << endl; // agar dar tarif mystr az ~mystr estefade nemikardim memory leak be vojood mioomad
    }
    return 0;
}
