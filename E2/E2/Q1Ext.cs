using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public record Point(double x, double y);

public static class QExt
{    
    public static double Q01EuclideanDistance(Point p1, Point p2) => Math.Sqrt(Math.Pow(p1.x-p2.x,2)+Math.Pow(p1.y-p2.y,2));

    public static double Q02ManhatanDistance(Point p1, Point p2) => Math.Abs(p1.x-p2.x) + Math.Abs(p1.y-p2.y);

    public static double Q03StringDistance(string s1, string s2) 
    { 
        int result = s1.Count();
        foreach (char c in s1)
        {
            if (s2.Contains(c))
                    result--;
        }
        return result;
    }

    public static (int min, int max) Q11GetRange(this int[] nums)
    {
        int min = nums.Min();
        int max = nums.Max();
        return (min,max);
    }

    public static int Q12GetRange(this int[] nums) 
    {
        int UB = 0;
        int LB = 0;
        (LB , UB) = Q11GetRange(nums);
        return UB - LB;
    }

    public static (T min, T max) Q13GetRange<T>(this T[] vals) where T: IComparable<T> 
    {
        if (vals.Count() == 0)
            throw new InvalidOperationException();
        T min = vals.Min();
        T max = vals.Max();
        return (min,max);
    }

    public static (T min, T max) Q14GetRange<T>(this T[] vals, Func<T, T, double> diff) 
    {   
        List<(T,T,double)> toks = new List<(T,T,double)>();
        for (int i = 0; i < vals.Count(); i++)
        {
            for (int j = 0; j < vals.Count(); j++)
            {
                // toks.Append( (vals[i] , vals[j] , diff(vals[i] , vals[j])) );
                toks.Add( (vals[i] , vals[j] , diff(vals[i] , vals[j])) );
            }
        }
        (T,T,double) reuslt = toks.OrderByDescending(e => e.Item3).FirstOrDefault();
        return (reuslt.Item2 , reuslt.Item1);
    }

    public static double Q15GetRange<T>(this T[] vals, Func<T, T, double> diff) 
    {
        T UB;
        T LB;
        (LB , UB) = Q14GetRange(vals,diff);
        return diff(UB,LB);
    }
}