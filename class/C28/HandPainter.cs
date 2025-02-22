using C28;

class HandPainter : IPainter
{
    public bool IsAvailable => true;

    public double EstimateCompensation(double sqMeters) => 
        sqMeters * 12;

    public double EstimateTimeToPaint(double sqMeters) => 
        sqMeters * 20;
}

class MachinePainter : IPainter
{
    public bool IsAvailable => true;

    public double EstimateCompensation(double sqMeters) => 
        sqMeters * 60;

    public double EstimateTimeToPaint(double sqMeters) => 
        sqMeters * 10;
}