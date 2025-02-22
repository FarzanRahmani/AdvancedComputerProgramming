#include<vector>
#include<iostream>
#include<string>
#include<string.h>

using namespace std;

class myvector
{
public:
    myvector()
    : m_pData(nullptr)
    , m_nSize(0)
    , m_nCapacity(5) 
    {
        m_pData = (int*) malloc( m_nCapacity * sizeof(int));
    }

    ~myvector()
    {
        if (m_pData)
            free(m_pData);
    }

    void resize(int size,int x = NULL)
    {
        if (size > m_nSize)
        {
            if (m_nCapacity <= size)
            {
                int* fr = m_pData + m_nCapacity;
                fr = (int*) malloc( 5 * sizeof(int));
                m_nCapacity += 5;
            }
            for (int i = m_nSize; i < size; i++)
                m_pData[i] = x;
            m_nSize = size;
        }
        
        if (size < m_nSize)
        {
            for (int i = size; i < m_nSize; i++)
                m_pData[i] = NULL;
            m_nSize = size;
        }
    }

    void push_back(int x)
    {
        if (m_nCapacity <= m_nSize)
        {
            int* fr = m_pData + m_nCapacity;
            fr = (int*) malloc( 5 * sizeof(int));
            m_nCapacity += 5;
        }
        m_pData[m_nSize] = x;
        m_nSize++;
    }

    int get(int i)
    {
        return m_pData[i];
    }

    int size()
    {   
        return m_nSize;
    }

    int capacity()
    {
        return m_nCapacity;
    }

private:
    int* m_pData;
    int m_nSize;
    int m_nCapacity;
};


class mystr
{
// hint : string araye ii az character ha ast
public:
    mystr(const char* pch)  // tabe ee initialize(tarid avalie) *** constructor ***
        : m_pData(nullptr)  // initializer list
        , m_nSize(0)
    {        
        assign(pch);
    }

    ~mystr() // destructor // vaghti ke az scope khrej mishe free kon
    {
        if (m_pData)  // nullptr nabood
            free(m_pData);
    }

    int get_size()
    {
        return m_nSize;
    }

    void assign(const char* pch)
    {
        if (m_pData)  // m_pData != nullptr
            free(m_pData);  // memory leak

        m_nSize = strlen(pch);  // string.h
        m_pData = (char*) malloc((m_nSize+1) * sizeof(char));  // +1 --> baraye sefr akhar
        strcpy(m_pData, pch);  // string.h (strcpy_s --> secure)
    }

    const char* get_data()
    {
        return m_pData;
    }

private:  // biroon az inja (dakhel tarif class) ghabel dast zadan va taghir nist
    int m_nSize;  // m--> member variable , p -->pointer
    char* m_pData;  // m--> member variable , n --> number
};

vector<int> get_list()
{
    vector<int> mylist;
    mylist.push_back(5);
    mylist.push_back(10);
    return mylist;    
}

void myvector_main()
{
    myvector v;
    cout << v.size() << endl;
    v.push_back(5);
    v.push_back(3);
    cout << v.size() << endl;
    v.push_back(12);
    v.push_back(15);
    v.push_back(-1);
    v.push_back(0);
    v.push_back(1);
    cout << v.size() << endl;
    for(int i=0; i<v.size(); i++)
        cout << v.get(i) << endl;  

    for(int i=0; i<10000; i++)
    {
        myvector farzan;
        farzan.push_back(5);
        cout << farzan.get(0) << endl; // agar dar tarif mystr az ~mystr estefade nemikardim memory leak be vojood mioomad
    }

    myvector farzan;
    farzan.push_back(1);
    farzan.push_back(2);
    farzan.push_back(3);
    farzan.push_back(4);
    farzan.resize(5,6);

    for(int i=0; i<farzan.size(); i++)
        cout << farzan.get(i) << endl; 
    
    farzan.resize(2);
    for(int i=0; i<farzan.size(); i++)
        cout << farzan.get(i) << endl; 

    farzan.resize(6,7);
    for(int i=0; i<farzan.size(); i++)
        cout << farzan.get(i) << endl;       
}

int main(int argc, char const *argv[])
{
    vector<int> thelist = get_list();

    int x = 5;  // primitive type
    char buf[5] = "asd";
    string str = "ali";  // std::string // string --> class , str --> object
    str = "alksdjflas;kdjf;alsdkfj"; 

    mystr name("hosseingholikhan");  // name har chi mitoone bashe

    cout << name.get_size() << endl;
    cout << name.get_data() << endl;  // name.m_pData ghabel estefade nist chon ke private ast

    name.assign("khaleghezi");
    cout << name.get_size() << endl;
    cout << name.get_data() << endl;

    for(int i=0; i<10000; i++)
    {
        char buf[6] = "abcde";
        buf[4] = (i % 26) + 65;

        mystr name1(buf);
        cout << name1.get_data() << endl; // agar dar tarif mystr az ~mystr estefade nemikardim memory leak be vojood mioomad
    }
    if (0)
    {
        mystr name2("ali");
    }


    myvector_main();

    return 0;
}

void test()
{
    mystr name3("ali");
}
