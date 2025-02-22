using A3.Interfaces;

namespace A3.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        public string Model{get;set;}
        public double SpeedRate { get ; set ; }

        public Airplane(double speedRate, string model)
        {
            SpeedRate = speedRate;
            Model = model;
        }

        public string Fly()
        {
            return Model + " with " + SpeedRate.ToString() + " speed rate is flying";
        }
    }
}