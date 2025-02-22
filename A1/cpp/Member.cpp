#pragma once

using namespace std;

namespace A1
{
    class Member
    {
    public:
        Member()//Default Constructor
        {}

        Member(int money,string name) // Parameter Constructor
        : m_sName(name)
        , m_nMoney(money)
        {}

        Member(const Member& other) // Copy Constructor
        {
            m_nMoney = other.m_nMoney;
        }
        
        int GetSavingMoney()
        {
            return m_nMoney;
        }

        void setMoney(int M)
        {
            m_nMoney = M;
        }

        string GetName() const
        {
            return m_sName;
        }

        void set_borrowed(bool b)
        {
            m_bIsBorrowed = b;
        }

        bool IsBorrowed()
        {
            return m_bIsBorrowed;
        }
    private:
        string m_sName;
        int m_nMoney;
        bool m_bIsBorrowed = false;
    };
}