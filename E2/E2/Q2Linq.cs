
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Q2ChildMortailityStats
{
    string[] datas;
    public Q2ChildMortailityStats(string filePath)
    {  
        datas = File.ReadAllLines(filePath);
        for (int i = 0; i < datas.Count(); i++)
        {
            string[] temp = datas[i].Split(",");
            for (int j = 0; j < temp.Length; j++)
            {
                temp[j] = temp[j].Trim(new char[]{'"','\\'});
            }
            datas[i] = temp[0] + "," + temp[1] + "," + temp[2] + "," + temp[3] + "," + temp[4] + "," + temp[5] ;
        }
    }

    public int Q21_HighestNeoNatalMortalityYear 
    {
        get
        {
            string s =
                datas.Skip(2)
            .Where( l => l.Split(",")[2] != "")
            .GroupBy(l => l.Split(",")[1])
            .Select(g => ( g.Sum(l => double.Parse( l.Split(",")[2]) )  , g.Key) )
            .OrderByDescending(l => l.Item1)
            .FirstOrDefault()
            .Key;
            return int.Parse(s);
        }
    }



    public (string country, int year) Q22_HighestDifferenceBetweenMaleAndFemale 
    {
        get
        {
            var r =
            datas
                .Skip(2)
                .Select( l => (country : l.Split(",")[0] ,
                Year : int.Parse(   l.Split(",")[1])   ,
                diff : Math.Abs(double.Parse(   l.Split(",")[4]    ) - 
                double.Parse(  l.Split(",")[5]   )   )   )   )
                .OrderByDescending(t => t.diff)
                .FirstOrDefault();
            return (r.country , r.Year);
        }
    }
    public string Q23_CountryWithHighestNeoNatalImprovement 
    {
        get
        {

            return datas.Skip(2)
            .Where( l => l.Split(",")[2] != "")
            .Select( l => (country : l.Split(",")[0] , Year : int.Parse((l.Split(",")[1])) , mor : double.Parse((l.Split(",")[2]) ) ) )
            .GroupBy(t => t.country)
            // .Select(g => (diff : Math.Abs(g.Last().mor - g.First().mor) ,country : g.Key ) )
            .Select(g => (diff : Math.Abs(g.Where(l => l.Year == g.Min(t => t.Year) ).First().mor / 
            g.Where(l => l.Year == g.Max(t => t.Year) ).First().mor) ,country : g.Key ) )
            .OrderByDescending(t => t.diff )
            .First()
            .country;
        }
    }
}