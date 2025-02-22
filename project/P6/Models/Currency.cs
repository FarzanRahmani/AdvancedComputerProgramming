using System;

namespace P6.Models
{
    public class Currency
    {
        public Currency(){}
        public Currency(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name{get;set;}
        public double Price{get;set;}
        public DateTime Date{get;set;}
    }
}