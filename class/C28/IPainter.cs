namespace C28
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        double EstimateCompensation(double sqMeters); // cost
        double EstimateTimeToPaint(double sqMeters);
    }
}