using A3.Interfaces;

namespace A3.Classes.Vehicles
{
    public class Submarine : ISwimable
    {
        public string Model{get;set;}
        public double MaxDepthSupported {get;set;}
        public double SpeedRate {get; set;}
        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            this.Model = model;
            this.MaxDepthSupported = maxDepthSupported;
        }
        public string Swim()
        {
            return Model + " is a " + typeof(Submarine).Name + " and is swimming in " + MaxDepthSupported.ToString() + " meter depth";
        }
    }
}