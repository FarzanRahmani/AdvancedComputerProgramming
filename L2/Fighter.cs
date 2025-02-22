using System;
namespace L2
{
    public class Fighter
    {
        public Fighter(string n,int h)
        {
            Name = n;
            Health = h;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} -- {Health}");
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public delegate void del(Fighter f1,Fighter f2);
        // public event Action<Fighter,Fighter> GameOver;
        public event del GameOver;
        public void Start(Fighter f1,Fighter f2) => GameOver(f1,f2);
        public void Attack(Fighter other)
        {
            Random n = new Random();
            int Defence = n.Next(0,2);
            if (Defence == 0)     
                this.Health -= n.Next(1,11);
            // if (Defence == 0)
            // {     
            //     this.Health -= n.Next(1,11);
            //     if(Health <= 0)
            //         GameOver(this,other);
            // }
        }
    }
}