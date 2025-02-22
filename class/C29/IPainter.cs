namespace C29
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        double EstimateCompensation(double sqMeters);
        double EstimateTimeToPaint(double sqMeters);
    }
}