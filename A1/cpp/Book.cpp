#pragma once
#include "Member.cpp"
#include <iostream>
#include<string>

namespace A1
{
    class Book
    {
    public:
        Book(){} // Default Constructor

        Book(string A,string T,long int P,float R,string I,string PD,string C) // Parameter Constructor
        : Author(A) // Initializer List
        , Title(T)
        , Price(P)
        , Rating(R)
        , ISBN_10(I)
        , PublishDate(PD)
        , Category(C)
        {
            SetPrice(P);
        }

        Book(const Book& other) // Copy Constructor
        {
            this->Author = other.Author;
            this->Title = other.Title;
            this->Price = other.Price;
            (*this).Rating = other.Rating;
            (*this).ISBN_10 = other.ISBN_10;
            (*this).PublishDate = other.PublishDate;
            (*this).Category = other.Category;
        }

        string GetAuthor()
        {
            return Author;
        }
        string GetTitle()
        {
            return Title;
        } 
        long int GetPrice() 
        {
            return Price;
        }
        float GetRating()
        {
            return Rating;
        }
        string GetISBN_10()
        {
            return ISBN_10;
        }
        string GetPublishDate()
        {
            return PublishDate;
        }
        string GetCategory()
        {
            return Category;
        }

        void SetPrice(long int NewPrice)
        {
            int remain = NewPrice % 100;
            if (remain != 0)
                NewPrice = NewPrice - remain + 100;
            this->Price = NewPrice;
        }

        void SetRating(float rate)
        {
            if (rate < 1 || rate > 5)
                this->Rating = 3.5;
            else
                this->Rating = rate;
        }

        void set_borrowedMember(Member* m)
        {
            borrowedMember = m;
            IsBorrowed = true;
        }

        Member* get_Member()
        {
            return borrowedMember;
        }

        bool is_borrowed()
        {
            return IsBorrowed;
        }

        void set_borrowed(bool b)
        {
           IsBorrowed = b;
        }

        void setDays(int d)
        {
            borrowDays = d;
        }

        int getDays()
        {
            return borrowDays;
        }

    private:
        string Author;
        string Title;
        long int Price;
        float Rating;
        string ISBN_10;
        string PublishDate;
        string Category;
        Member* borrowedMember = new Member;
        int borrowDays = 0;
        bool IsBorrowed = false;
    };
}