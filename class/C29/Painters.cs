using System.Collections.Generic;
using System.Linq;

namespace C29
{
    class Painters
    {
        private IEnumerable<IPainter> ContainedPainters;
        public Painters(IEnumerable<IPainter> painters)
        {
            ContainedPainters = painters.ToList(); // ToList is because of destroy the reference connection (making new)
        }

        public Painters GetAvailable() => new Painters(this.ContainedPainters.Where(p => p.IsAvailable));

        public IPainter GetCheapest(double sqMeters) =>
            this.ContainedPainters.WithMinimum(p => p.EstimateCompensation(sqMeters));

        public IPainter GetFastest(double sqMeter) => 
            this.ContainedPainters.WithMinimum(p => p.EstimateTimeToPaint(sqMeter));


    }
}