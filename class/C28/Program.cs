using System.Collections.Generic;
using System.Linq;

namespace C28
{
    class ProportionalPainter: IPainter
    {
        public bool IsAvailable => true;

        public double TimePerSqMeter { get; set; }
        public double DollarPerHour { get; set; }

        public double EstimateCompensation(double sqMeters) => this.EstimateTimeToPaint(sqMeters) * DollarPerHour;

        public double EstimateTimeToPaint(double sqMeters) => TimePerSqMeter * sqMeters;
    }

    class Program
    {
        static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            var time = 1 / painters.Where(p => p.IsAvailable)
                            .Sum(p => 1 / p.EstimateTimeToPaint(sqMeters));

            var cost = painters.Where(p => p.IsAvailable)
                            .Sum(p1 => (p1.EstimateCompensation(sqMeters) /
                                        p1.EstimateTimeToPaint(sqMeters)) * time);

            return new ProportionalPainter() {
                TimePerSqMeter = time / sqMeters,
                DollarPerHour = cost / time
            };
        }
        // copmosite pattern


        static IPainter FindCheapest4(IEnumerable<IPainter> painters, double sqmt) =>
            painters.Where(p => p.IsAvailable)
                    .WithMinimum(painter => painter.EstimateCompensation(sqmt));

        static IPainter FindFastest4(IEnumerable<IPainter> painters, double sqmt) =>
            painters.Where(p => p.IsAvailable)
                    .WithMinimum(p => p.EstimateTimeToPaint(sqmt));
        // strategy pattern

        static IPainter FindCheapest3(IEnumerable<IPainter> painters, double sqmt) =>
            painters.Where(p => p.IsAvailable)
                    .WithMinimumCost(sqmt);

        static IPainter FindFastest3(IEnumerable<IPainter> painters, double sqmt) =>
            painters.Where(p => p.IsAvailable)
                    .WithMinimumTime(sqmt);
        // strategy pattern


        static IPainter FindFastest2(IEnumerable<IPainter> painters, double sqmt) =>
            painters.Where(p => p.IsAvailable)
                    .Aggregate( (IPainter) null,
                        (aggr, curr) => 
                        aggr == null || curr.EstimateTimeToPaint(sqmt) < aggr.EstimateTimeToPaint(sqmt) ? curr : aggr);

        static IPainter FindCheapest2(IEnumerable<IPainter> painters, double sqmt) =>
            painters.Where(p => p.IsAvailable)
                    .Aggregate((IPainter) null,
                        (aggr, curr) => 
                        aggr == null || curr.EstimateCompensation(sqmt) < aggr.EstimateCompensation(sqmt) ? curr : aggr);
        // iterator pattern
        static IPainter FindCheapest(IEnumerable<IPainter> painters, double sqmt)
        {
            double lowest = 0;
            IPainter chosen = null;
            foreach(var p in painters)
            {
                if (p.IsAvailable)
                {
                    double cost = p.EstimateCompensation(sqmt);
                    if (null == chosen || cost < lowest)
                    {
                        lowest = cost;
                        chosen = p;
                    }
                }
            }
            return chosen;
        }
    
        static void Main(string[] args)
        {
            IPainter[] painters = new IPainter[]{ // object haee ke in interface ro daran
                new HandPainter(),            
                new MachinePainter()
            };

            IPainter chosen = FindCheapest(painters, 25);
            System.Console.WriteLine(8.CompareTo(10)); 
            List<int> y = new List<int>(){4,9,1,7};
            y.Sort();
            foreach( var i in y)
                System.Console.WriteLine(i);

        }
    }
}