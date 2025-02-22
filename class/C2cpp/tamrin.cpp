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

    return 0;   
}


vector<int> get_list()
{
    vector<int> mylist;
    mylist.push_back(5);
    mylist.push_back(10);
    return mylist;    
}


