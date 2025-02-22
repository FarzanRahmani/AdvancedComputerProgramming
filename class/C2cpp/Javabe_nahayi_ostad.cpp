#include<vector>
#include<iostream>
#include<string>
#include<string.h>


using namespace std;


class myvector
{
public:
    myvector(int capacity=5) //constructor
    : m_pData(nullptr)
    , m_nSize(0)
    , m_nCapacity(capacity) 
    {
        m_pData = (int*) malloc( m_nCapacity * sizeof(int));
    }

    myvector(const myvector& other) // copy constructor (& --> khode other ro mizare dige copy nemigire)
    {
        // mikhahim other ro copy konim (beerizim) too ye my vector jadid 
        m_nSize = other.m_nSize;
        m_nCapacity = other.m_nCapacity;
        m_pData = (int*) malloc(sizeof(int) * m_nCapacity);
        for (int i = 0; i < m_nSize; i++)
            m_pData[i] = other.m_pData[i];
    }

    ~myvector()
    {
        if (m_pData)
            free(m_pData);
    }

    myvector clone() // khorooji tabe --> myvector
    {
        return *this;// this:address   *this:myvector
    }

    void resize()
    {
        m_nCapacity *= 2;
        int* newMem = (int*) malloc(m_nCapacity * sizeof(int));
        for (int i = 0; i < m_nSize; i++)
        {
            newMem[i] = m_pData[i];
        }
        free(this->m_pData);
        (*this).m_pData = newMem;
    }

    void push_back(int x)
    {
        if (m_nSize == m_nCapacity) // hint ya size < capasity  ya size == capasicity  bozorg tar nemishe hich vaght
            resize();
        
        // this  -->  myvector*  ee  in class ee
        this->m_pData[m_nSize] = x; // m_nSize < m_nCapacity
        (*this).m_nSize++;
    }

    int get(int i)
    {
        if (i < m_nSize )
            return m_pData[i];            
        cout << "error,index out of range " << i << endl;
        return -99999
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

int main()
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


    myvector copy_farzan(farzan);
    myvector farzan22 = farzan.clone();
    return 0;   
}
