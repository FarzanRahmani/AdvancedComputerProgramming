using C29;

class HandPainter : IPainter
{
    public bool IsAvailable => true;

    public double EstimateCompensation(double sqMeters) => 
        sqMeters * 12;

    public double EstimateTimeToPaint(double sqMeters) => 
        sqMeters * 20;
}
