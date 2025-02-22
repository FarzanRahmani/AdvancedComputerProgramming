using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Snake : IAnimal, ICrawlable
    {
        public Snake(string name, int age, double health, double speedRate)
        {
            Name = name;
            this.age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Name { get ; set ; }
        public int age { get ; set ; }
        public double Health { get ; set ; }
        public double SpeedRate { get ; set ; }

        public string Crawl()
        {
            return Name + " is a " + typeof(Snake).Name + " and is crawling";
        }

        public string EatFood()
        {
            return Name + " is a " + typeof(Snake).Name + " and is eating";
        }

        public string Move(Environment e)
        {
            if (e == Environment.Land)
                return this.Crawl();
            else
                return Name + " is a " + typeof(Snake).Name + " and can't move in " + e + " environment";
            ;
        }

        public string Reproduction(IAnimal animal)
        {
            return Name + " is a " + typeof(Snake).Name + " and reproductive with " + animal.Name;
        }
    }
}