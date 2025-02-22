namespace C29
{
    class ProportionalPainter : IPainter
    {
        public bool IsAvailable => true;

        public double TimePerSqMeter { get; set; }
        public double DollarPerHour { get; set; }

        public double EstimateCompensation(double sqMeters) => this.EstimateTimeToPaint(sqMeters) * DollarPerHour;

        public double EstimateTimeToPaint(double sqMeters) => TimePerSqMeter * sqMeters;
    }
}