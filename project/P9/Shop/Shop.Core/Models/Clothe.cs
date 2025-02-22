
namespace Shop.Core
{
    public class Clothe /// Model
    {
        public int Price {get ; set ;}
        public string Name{get ;set ;}
        public int Id {get ; set ;}
        public string Color {get ;set ;}
        public override string ToString()
        {
            return $"{this.Name}, {this.Price}, {this.Id}, {this.Color}";
            
        }
        public override int GetHashCode()
        {
            return this.Id ;
        }
        public override bool Equals(object obj)
        {
            var otherCloth = obj as Clothe;
            if (obj is null) return false;
            return this.Id == otherCloth.Id;
        }
    }
}