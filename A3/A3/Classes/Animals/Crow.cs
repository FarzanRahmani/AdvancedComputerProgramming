using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Crow : IAnimal, IFlyable
    {
        public Crow(string name, int age, double health, double speedRate)
        {

            Name = name;
            this.age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Name { get ; set ;}
        public int age { get ; set ; }
        public double Health { get ; set ; }
        public double SpeedRate { get ; set ; }

        public string EatFood()
        {
            return Name + " is a " + typeof(Crow).Name + " and is eating";
        }

        public string Fly()
        {
            return Name + " is a " + typeof(Crow).Name + " and is flying";
        }

        public string Move(Environment e)
        {
            if (e == Environment.Air)
                return this.Fly();
            else
                return Name + " is a " + typeof(Crow).Name + " and can't move in " + e + " environment";
            ;
        }

        public string Reproduction(IAnimal animal)
        {
            return Name + " is a " + typeof(Crow).Name + " and reproductive with " + animal.Name;
        }
    }
}