using System;
using System.Collections.Generic;
using System.Linq;

namespace C29
{
    public static class PainterExtensions
    {
        public static IPainter WithMinimumCost(this IEnumerable<IPainter> painters, double sqmt) =>
            painters.Aggregate((IPainter) null,
                    (aggr, curr) => 
                    aggr == null || curr.EstimateCompensation(sqmt) < aggr.EstimateCompensation(sqmt) ? curr : aggr);

        public static IPainter WithMinimumTime(this IEnumerable<IPainter> painters, double sqmt) =>
            painters.Aggregate((IPainter) null,
                    (aggr, curr) => 
                    aggr == null || curr.EstimateTimeToPaint(sqmt) < aggr.EstimateTimeToPaint(sqmt) ? curr : aggr);


        public static IPainter WithMinimum<TKey>(
            this IEnumerable<IPainter> painters, Func<IPainter, TKey> criteria) 
                where TKey: IComparable<TKey> // TKey --> double
            =>  painters.Aggregate((IPainter) null,
                    (aggr, curr) => 
                    aggr == null || criteria(curr).CompareTo(criteria(aggr)) < 0 ? curr : aggr);

    }
}