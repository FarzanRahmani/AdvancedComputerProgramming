#pragma once
#include "Book.cpp"
#include <string.h>
using namespace std;
#include<bits/stdc++.h>

namespace A1
{
    class Library
    {
    

    public:
        Library() // Default Constructor 
        {
            m_pVpBooks = new vector<Book*>;
            m_pVpMember = new vector<Member *>;
        }

        Library(string n) // Parameter Constructor
        : m_sName(n) // Initializer list
        {
            // if (m_pVpBooks == nullptr)
            m_pVpBooks = new vector<Book*>;
            // if (m_pVpMember == nullptr)
            m_pVpMember = new vector<Member *>;
        }

        Library(const Library& other) //Copy Constructor
        {// : Library(other) // be jaye do khat bad
            // if (this->m_pVpBooks == nullptr)
            this->m_pVpBooks = new vector<Book*>;
            // if (this->m_pVpMember == nullptr)
            this->m_pVpMember = new vector<Member *>;
            *m_pVpBooks =  *(other.m_pVpBooks); // ?
            // for (int i = 0; i < L.m_pvpBooks->size() ; i++)
            // {
            //     (*m_pvpBooks).push_back(new Book);
            //     *((*m_pvpBooks)[i]) = * ( (* (L.m_pvpBooks) ) [i] );
            // }
        }

        ~Library()
        {
            if (m_pVpBooks != nullptr)
            {
                // for (int i = 0; i < m_pVpBooks->size(); i++)
                //     if ((*m_pVpBooks)[i] != nullptr)
                //         delete (*m_pVpBooks)[i];
                delete m_pVpBooks;
                // free(m_pVpBooks);
                // (*m_pVpBooks).resize(0);
                m_pVpBooks = nullptr;
            }
            

            if (m_pVpMember != nullptr)
            {
                for (int i = 0; i < m_pVpMember->size(); i++)
                    if ((*m_pVpMember)[i] != nullptr)
                    {
                        delete (*m_pVpMember)[i];
                        (*m_pVpMember)[i] = nullptr;
                    }
                delete m_pVpMember;
                // (*m_pVpMember).resize(0);
                m_pVpMember = nullptr;
            }
            
            

            // free(this);
        }

        void AddBook(Book* pb)
        {
            m_pVpBooks->push_back(pb); // ???????????
        }

        string GetName()
        {
            return m_sName;
        }

        void SetName(string name)
        {
            m_sName = name;
        }

        vector<Book*>* GetAllBooks()
        {
            return m_pVpBooks; // ?
        }

        void RegisterMember(Member* pM)
        {
            if (pM->GetSavingMoney() > 1000)
                {
                    pM->setMoney( pM->GetSavingMoney() - 1000 );
                    (*m_pVpMember).push_back(pM);
                }
        }

        vector<Member *> * GetAllMembers()
        {
            return m_pVpMember;
        }

        void SortMembersByName()
        {
            Member* tmp;
            for (int i = 0; i < m_pVpMember->size(); i++)
            {
                for (int next = i+1; next < m_pVpMember->size(); next++)
                {
                    // if (strcmp( ((*m_pVpMember)[i])->GetName() , ((*m_pVpMember)[next])->GetName() ) > 0)
                    if (((*m_pVpMember)[i])->GetName() > ((*m_pVpMember)[next])->GetName())
                    {
                        tmp = ((*m_pVpMember)[i]);
                        ((*m_pVpMember)[i]) = (*m_pVpMember)[next];
                        (*m_pVpMember)[next] = tmp;
                    }
                }
            }
        }

        void BorrowBook(Book* pb,Member* pm)
        {
            if (pm->GetSavingMoney() > (0.25)*(pb->GetPrice()) )
            {
                if (       ( !( pb->is_borrowed() ) )          &&         ( !(pm->IsBorrowed()) )              )
                {
                    pm->setMoney(pm->GetSavingMoney() - (0.25)*(pb->GetPrice()) );
                    pb->set_borrowedMember(pm);
                    pm->set_borrowed(true); 
                }
            }
        }

        void DaysPassed(int days)
        {
            for (int i = 0; i < m_pVpBooks->size(); i++)
            {
                if ( (*m_pVpBooks)[i]->is_borrowed()  )
                {
                    (*m_pVpBooks)[i]->setDays( (*m_pVpBooks)[i]->getDays() + days );
                    (*m_pVpBooks)[i]->get_Member()->setMoney( (*m_pVpBooks)[i]->get_Member()->GetSavingMoney() - days*(0.1)*( (*m_pVpBooks)[i]->GetPrice() ) );
                    if ( (*m_pVpBooks)[i]->get_Member()->GetSavingMoney() <= 0 )
                    {
                        (*m_pVpBooks)[i]->get_Member()->set_borrowed(false);
                        (*m_pVpBooks)[i]->set_borrowed(false);
                        (*m_pVpBooks)[i]->setDays(0);
                    }

                    // if ( (*m_pVpBooks)[i]->getDays() < InitialBorrowDays )
                    // {
                    //     (*m_pVpBooks)[i]->get_Member()->setMoney( (*m_pVpBooks)[i]->get_Member()->GetSavingMoney() - days*(0.1)*( (*m_pVpBooks)[i]->GetPrice() ) );
                    // }
                    // if ( (*m_pVpBooks)[i]->getDays() > InitialBorrowDays )
                    // {
                    //     (*m_pVpBooks)[i]->get_Member()->setMoney(  (*m_pVpBooks)[i]->get_Member()->GetSavingMoney() - days*(0.2)*( (*m_pVpBooks)[i]->GetPrice() ) );
                    // }
                }
            }
        }

        vector<Book *> * FindBooks(string category,float rating)
        {
            string U = category;
            transform(U.begin(), U.end(), U.begin(), ::toupper);
            string L = category;
            transform(L.begin(), L.end(), L.begin(), ::tolower);
            vector<Book *> * result = new vector<Book *>;

            for (int i = 0; i < m_pVpBooks->size() ; i++)
            {
                if ( (*m_pVpBooks)[i]->GetRating() >= rating )
                {
                result->push_back((*m_pVpBooks)[i]);
                for (int j = 0; j < category.size(); j++)
                    {
                        if( (U[j] != (*m_pVpBooks)[i]->GetCategory()[j] ) && (L[j] != (*m_pVpBooks)[i]->GetCategory()[j]) )
                        {
                            result->pop_back();
                            break;
                        }
                    }
                }
            }
            return result;
        }


    private:
        const int InitialBorrowDays = 120; // do not change this
        string m_sName;

        vector<Book*>* m_pVpBooks;
        // vector<Book*>* m_pVpBooks = new vector<Book*>;

        vector<Member *> * m_pVpMember;
        // vector<Member *> * m_pVpMember = new vector<Member *>;
    };                                     // Library
} //A1
