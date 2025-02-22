using System;
using System.Collections.Generic;
using System.Linq;

namespace C28
{
    public static class PainterExtensions
    {
        public static IPainter WithMinimumCost(this IEnumerable<IPainter> painters, double sqmt) =>
            painters.Aggregate((IPainter) null, // seed
                    (aggr, curr) => 
                    aggr == null || curr.EstimateCompensation(sqmt) < aggr.EstimateCompensation(sqmt) ? curr : aggr);
        // this : extension method
        public static IPainter WithMinimumTime(this IEnumerable<IPainter> painters, double sqmt) =>
            painters.Aggregate((IPainter) null,
                    (aggr, curr) => 
                    aggr == null || curr.EstimateTimeToPaint(sqmt) < aggr.EstimateTimeToPaint(sqmt) ? curr : aggr);


        public static IPainter WithMinimum<TKey>(
            this IEnumerable<IPainter> painters, Func<IPainter, TKey> criteria)  // criteria : شاخص
                where TKey: IComparable<TKey> // khorooji double ast pas ba khodesh ghabel moghayese ast
            =>  painters.Aggregate((IPainter) null, // seed
                    (aggr, curr) => 
                    aggr == null || criteria(curr).CompareTo(criteria(aggr)) < 0 ? curr : aggr);
                    // az kochic be bozorg sort mishe
                    // proceed : ghabl
                    // follow : bad

    }
}