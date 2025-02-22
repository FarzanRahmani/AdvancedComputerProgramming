
using System;
using System.Collections.Generic;
using System.Linq;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        public List<IAnimal> Animals { get; set; }

        public string[] MoveAnimals()
        {
            string[] result = new string[ this.Animals.Count() * 3];
            int i = 0 ;
            foreach(IAnimal A in this.Animals)
                {
                    result[i] = (A.Move(Environment.Air));i++;
                    result[i] = (A.Move(Environment.Land));i++;
                    result[i] = (A.Move(Environment.Watery));i++;
                }
            return result;
        }
        
    }
}
