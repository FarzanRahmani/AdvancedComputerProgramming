using System;
using System.Collections.Generic;
using System.Linq;

namespace C29
{

    // TODO: Make Reduce virtual in the base class and override here 
    // instead of taking Reduce as a delegate parameter in the constructor
    // class ProportionalCompositePainter: CompositePainter<ProportionalPainter>
    // {}

    class ProportionalCompositePainter: CompositePainter<ProportionalPainter>
    {
        public ProportionalCompositePainter(IEnumerable<ProportionalPainter> painters) : base(painters)
        {
        }

        public override IPainter Reduce(double sqMeters, IEnumerable<ProportionalPainter> sequence)
        {
            var time = 1 / sequence.Where(p => p.IsAvailable)
                                            .Sum(p => 1 / p.EstimateTimeToPaint(sqMeters));

            var cost = sequence.Where(p => p.IsAvailable)
                                .Sum(p1 => (p1.EstimateCompensation(sqMeters) /
                                            p1.EstimateTimeToPaint(sqMeters)) * time);

            return new ProportionalPainter()
            {
                TimePerSqMeter = time / sqMeters,
                DollarPerHour = cost / time
            };
        }
    }

    public class CompositePainter<TPainter>: IPainter // group of painters
    where TPainter: IPainter
    {
        private IEnumerable<TPainter> painters {get; }

        public bool IsAvailable => this.painters.Any(p => p.IsAvailable); // had aghal yeki

        public CompositePainter(
            IEnumerable<TPainter> painters) // double sqMeters , IEnumerable<TPainter> sequence
        {
            this.painters = painters.ToList(); // not reference pass
        }

        public virtual IPainter Reduce(double sqMeters,IEnumerable<TPainter> sequence)
        {
            var time = sequence.Where(p => p.IsAvailable)
                                            .Sum(p => p.EstimateTimeToPaint(sqMeters));

            var cost = sequence.Where(p => p.IsAvailable)
                                .Sum(p1 => (p1.EstimateCompensation(sqMeters))  );

            return new ProportionalPainter()
            {
                TimePerSqMeter = time / sqMeters,
                DollarPerHour = cost / time
            };
        }

        public double EstimateCompensation(double sqMeters) => 
            this.Reduce(sqMeters, this.painters).EstimateCompensation(sqMeters);

        public double EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters, this.painters).EstimateTimeToPaint(sqMeters);
    }




    // public class CompositePainter<TPainter>: IPainter // group of painters
    //     where TPainter: IPainter
    // {
    //     private IEnumerable<TPainter> painters {get; }

    //     public bool IsAvailable => this.painters.Any(p => p.IsAvailable); // had aghal yeki

    //     public CompositePainter(
    //         IEnumerable<TPainter> painters, 
    //         Func<double, IEnumerable<TPainter>, IPainter> reduce) // double sqMeters , IEnumerable<TPainter> sequence
    //     {
    //         this.painters = painters.ToList(); // not reference pass
    //         this.Reduce = reduce;
    //     }

    //     private Func<double, IEnumerable<TPainter>, IPainter> Reduce; // composite mikone --> IPianter mide ke dar vaghe tarkib hameye naghashas masalan age prportional ya ... kar konan fargh dare
    //     // ye Painters ro be ye IPainter kahesh mide

    //     public double EstimateCompensation(double sqMeters) => 
    //         this.Reduce(sqMeters, this.painters).EstimateCompensation(sqMeters);

    //     public double EstimateTimeToPaint(double sqMeters) =>
    //         this.Reduce(sqMeters, this.painters).EstimateTimeToPaint(sqMeters);
    // }
}