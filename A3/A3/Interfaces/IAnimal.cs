using A3.Enums;

namespace A3.Interfaces
{
    public interface IAnimal
    {
        string Name{get;set;}
        int age{get;set;}
        double Health {get; set;}
        string EatFood();
        string Reproduction(IAnimal animal);
        string Move(Environment e);
    }
}