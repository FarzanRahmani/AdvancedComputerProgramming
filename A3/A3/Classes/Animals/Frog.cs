using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Frog : IAnimal, IWalkable, ISwimable
    {
        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            this.age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Name { get  ; set  ; }
        public int age { get  ; set  ; }
        public double Health { get  ; set  ; }
        public double SpeedRate { get  ; set  ; }

        public string EatFood()
        {
            return Name + " is a " + typeof(Frog).Name + " and is eating";
        }

        public string Move(Environment e)
        {
            if ( e == Environment.Land)
                return this.Walk();
            else if (e == Environment.Watery)
                return this.Swim();
            else 
                return Name + " is a " + typeof(Frog).Name + " and can't move in " + e + " environment";
        }

        public string Reproduction(IAnimal animal)
        {
            return Name + " is a " + typeof(Frog).Name + " and reproductive with " + animal.Name;
        }

        public string Swim()
        {
            return Name + " is a " + typeof(Frog).Name + " and is swimming";
        }

        public string Walk()
        {
            return Name + " is a " + typeof(Frog).Name + " and is walking";
        }
    }
}