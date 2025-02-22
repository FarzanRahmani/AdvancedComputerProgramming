using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Partridge : IAnimal, IWalkable, IFlyable
    {
        public Partridge(string name, int age, double speedRate, double health)
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

        public string EatFood()
        {
            return Name + " is a " + typeof(Partridge).Name + " and is eating";
        }

        public string Fly()
        {
            return Name + " is a " + typeof(Partridge).Name + " and is flying";
        }

        public string Move(Environment e)
        {
            if ( e == Environment.Land)
                return this.Walk();
            else if (e == Environment.Air)
                return this.Fly();
            else 
                return Name + " is a " + typeof(Partridge).Name + " and can't move in " + e + " environment";
        }

        public string Reproduction(IAnimal animal)
        {
            return Name + " is a " + typeof(Partridge).Name + " and reproductive with " + animal.Name;
        }

        public string Walk()
        {
            return Name + " is a " + typeof(Partridge).Name + " and is walking";
        }
    }
}