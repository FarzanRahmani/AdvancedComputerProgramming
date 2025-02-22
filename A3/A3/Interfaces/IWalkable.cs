namespace A3.Interfaces
{
    public interface IWalkable
    {
        double SpeedRate { get; set; }
        string Walk();
    }
}