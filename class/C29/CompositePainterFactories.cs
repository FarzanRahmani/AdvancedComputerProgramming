using System.Collections.Generic;
using System.Linq;

namespace C29
{
    static class CompositePainterFactories
    {
        // public static IPainter CreateCompositePainterGroup(IEnumerable<IPainter> painters) =>
        //     new CompositePainter<IPainter>(
        //         painters,
        //         (sqMeters, sequence) =>
        //         {
        //             var time = 1 / sequence.Where(p => p.IsAvailable)
        //                                     .Sum(p => 1 / p.EstimateTimeToPaint(sqMeters));

        //             var cost = sequence.Where(p => p.IsAvailable)
        //                                 .Sum(p1 => (p1.EstimateCompensation(sqMeters) /
        //                                           p1.EstimateTimeToPaint(sqMeters)) * time);

        //             return new ProportionalPainter()
        //             {
        //                 TimePerSqMeter = time / sqMeters,
        //                 DollarPerHour = cost / time
        //             };
        //         });        
    }
}