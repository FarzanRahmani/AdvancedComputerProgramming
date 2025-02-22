using C29;

class MachinePainter : IPainter
{
    public bool IsAvailable => true;

    public double EstimateCompensation(double sqMeters) => 
        sqMeters * 60;

    public double EstimateTimeToPaint(double sqMeters) => 
        sqMeters * 10;
}