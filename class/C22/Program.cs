using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace C22
{
    public record WordCount(string Word, int Count); // shabihe tuple vali classe va in ke moghayese ham mishe

    // public class WordCount
    // {
    //     public int Count{get; init;}
    //     public string Word{ get; init;} // init to constructor meghdar dehi mishe
    //     public WordCount(string word, int count)
    //     {
    //         this.Count = count;
    //         this.Word = word;
    //     }
    // }

    public static class Ext
    {
        // this --> extension method
        public static IEnumerable<WordCount> GetHistogram(this string fileName, string country) =>
                File.ReadAllLines(fileName)
                .Select(l => l.ToLower())
                .Where(l => l.Contains(country))
                .SelectMany(l => l.Split(new char[]{' ', '"'}, StringSplitOptions.RemoveEmptyEntries))
                .Select(w => w.Trim(new char[]{',', '.', ';', ':'}))
                .GroupBy(w => w)
                .Select(g => new WordCount(g.Key, g.Count()))
                .OrderByDescending(d => d.Count);
    }

    class Program
    {
        static string MakeString((string str, int cnt) w) // shabih int a
        {
            return $"{w.str} => {w.cnt}";
        }

        static string MakeString(WordCount w) // bara tuple va record mishe tabe nevesht vali bara anonymous type nemishe
        {
            return $"{w.Word} => {w.Count}";
        }

        
        static void Main(string[] args)
        {
            // Find the year each country's children per women rate dropped the most compared to previous year
            // The result should have (country, rate, previous year, current year, diff)
            // ordered by "diff"

            File.ReadAllLines("children-per-woman-UN.csv")
                    .Select(l => l.ToLower())
                    .Skip(1)
                    // .Select( l => {
                    //     var toks = l.Split(",");
                    //     (country : toks[0] , Year : int.Parse(toks[2]) , fertility : double.Parse(toks[3]) ));
                    // })
                    .Select( l => (country : l.Split(",")[0] , Year : int.Parse(l.Split(",")[2]) , fertility : double.Parse(l.Split(",")[3]) ))
                    .GroupBy( t => t.country)
                    .Select(g => 
                    g.Join(g ,
                    g1 => g1.Year , g2 => g2.Year-1 ,
                    (f , s) => (diff : s.fertility - f.fertility , country : f.country , previousyear : f.Year , currentyear : s.Year)
                    )
                    .Aggregate( (a,b) => a.diff < b.diff ? a : b)
                    )
                    .OrderByDescending(a => a.diff)
                    .ToList()
                    .ForEach(a => Console.WriteLine(a));



            #region talash_shekast_khorde2
            // var res = File.ReadAllLines("children-per-woman-UN.csv")
            //         .Select(l => l.ToLower())
            //         .Skip(1)
            //         .Select( l => (country : l.Split(",")[0] , Year : l.Split(",")[2] , fertility : double.Parse(l.Split(",")[3]) ))
            //         .GroupBy( t => t.country)
            //         // .
            //         ;

            // var first = File.ReadAllLines("children-per-woman-UN.csv")
            //         .Select(l => l.ToLower())
            //         .Skip(1)
            //         .Select( l => (country : l.Split(",")[0] , Year : int.Parse(l.Split(",")[2]) , fertility : double.Parse(l.Split(",")[3]) ))
            //         .GroupBy( t => t.country);
            //         // .SelectMany(g => g);
            //         // .SelectMany(g => g.SkipLast(1));
            // var second = File.ReadAllLines("children-per-woman-UN.csv")
            //         .Select(l => l.ToLower())
            //         .Skip(1)
            //         .Select( l => (country : l.Split(",")[0] , Year : int.Parse(l.Split(",")[2])  , fertility : double.Parse(l.Split(",")[3]) ) )
            //         .GroupBy( t => t.country);
            //         // .SelectMany(g => g);
                    // .SelectMany(g => g.Skip(1));

                        // .Select(;
                // first.Joig => g.Skip(1))n(second ,
                    //         f => f.Key , s => s.Key ,
                    //         (f ,s ) =>  
            // var diffs = first.Join(second ,
            // f => f.Year , s => s.Year-1 ,
            // (f , s) => (diff : s.fertility - f.fertility , country : f.country , previousyear : f.Year , currentyear : s.Year)
            // ).GroupBy( t => t.country);
            // diffs.Select(g => g.Aggregate( (a,b) => a.diff < b.diff ? a : b) )
            // .ToList()
            // .ForEach(a => Console.WriteLine(a));

            // first.Select(g => 
            // g.Join(g ,
            // g1 => g1.Year , g2 => g2.Year-1 ,
            // (f , s) => (diff : s.fertility - f.fertility , country : f.country , previousyear : f.Year , currentyear : s.Year)
            // )
            // .Aggregate( (a,b) => a.diff > b.diff ? a : b)
            // ).ToList()
            // .ForEach(a => Console.WriteLine(a));
            // .Select(g => g.
            // .ToList()
            // .ForEach(a => Console.WriteLine(a));
            // PrintResult("Africa");
            #endregion
        }
        #region talash_shekast_khorde1
        // static void PrintResult(string country)
        // {
        //     var first = File.ReadAllLines("children-per-woman-UN.csv")
        //             .Select(l => l.ToLower())
        //             .Skip(1)
        //             .Select( l => (country : l.Split(",")[0] , Year : l.Split(",")[2] , fertility : double.Parse(l.Split(",")[3]) ))
        //             // .Where(l => l.country == country)
        //             .GroupBy( t => t.country)
        //             .SelectMany(g => g.SkipLast(1));
        //     var second = File.ReadAllLines("children-per-woman-UN.csv")
        //             .Select(l => l.ToLower())
        //             .Skip(1)
        //             .Select( l => (country : l.Split(",")[0] , Year : l.Split(",")[2] , fertility : double.Parse(l.Split(",")[3]) ) )
        //             // .Where(l => l.country == country)
        //             .GroupBy( t => t.country)
        //             .SelectMany(g => g.Skip(1));
        //     var diffs = first.Join(second ,
        //     f => f.country , s => s.country ,
        //     (f , s) => (diff : s.fertility - f.fertility , country : f.country , previousyear : f.Year , currentyear : s.Year)
        //     );
        //     var r = diffs.Aggregate( (a,b) => a.diff > b.diff ? a : b);
        //     Console.WriteLine( r.ToString() );
        // }
        #endregion


        static void Main2(string[] args)
        {
            var israelData = "TweetText.txt".GetHistogram("israel");
            IEnumerable<WordCount> iranData = "TweetText.txt".GetHistogram("iran");

            // Zip hame ro be ham peyvand mide vali Join faghat onaee ke key moshtarak daran ro be ham peyvand mide
            iranData.Join(israelData, 
                            ird => ird.Word, isd => isd.Word, // matching keys  // khorooji in do ta har kodoom yeki bashe ro bar midare
                                    (ird,isd) => (isd.Word, irCnt: ird.Count, isCnt: isd.Count)) // result selector
                    .OrderBy(d => d.irCnt)
                    .Take(50)
                    .Select(d => d.ToString())
                    .ToList()
                    .ForEach(Console.WriteLine);
                    // .ForEach( w => Console.WriteLine(w));
        }


        static void Main3(string[] args)
        {
            IEnumerable<WordCount> israelData = "TweetText.txt".GetHistogram("israel");
            var iranData = "TweetText.txt".GetHistogram("iran");

            Dictionary<string, WordCount> israelDic = israelData.ToDictionary(d => d.Word);
            var iranDic = iranData.ToDictionary(d => d.Word);

            israelData.Take(30).Zip(iranData, (dis, dir) => 
                        (dis.Word, dis.Count, iranDic.ContainsKey(dis.Word)? iranDic[dis.Word].Count: 0))
                .ToList()
                .ForEach(l => System.Console.WriteLine(l));

            System.Console.WriteLine("------------");

            iranData.Take(30).Zip(israelData, (dir, dis) => 
                        (dir.Word, dir.Count, israelDic.ContainsKey(dir.Word)? israelDic[dir.Word].Count: 0))
                .ToList()
                .ForEach(l => System.Console.WriteLine(l));
        }


        static void Main4(string[] args)
        {
            IEnumerable<WordCount> israelData = "TweetText.txt".GetHistogram("israel").Take(20);
            var iranData = "TweetText.txt".GetHistogram("iran").Take(20);

            israelData.Zip(iranData, (dis, dir) => (dis.Word, dis.Count, dir.Word, dir.Count)) // daghighan kar zip ro anjam mide
                .ToList()
                .ForEach(l => System.Console.WriteLine(l));
        }

        static void Main5(string[] args)
        {
            File.ReadAllLines("TweetText.txt")
                .Select(l => l.ToLower())
                .Where(l => l.Contains("israel"))
                .SelectMany(l => l.Split(new char[]{' ', '"'}, StringSplitOptions.RemoveEmptyEntries)) // farghesh ba select ine ke IEnumarable ha ro ta rkib mikone va yedooone mide
                .Select(w => w.Trim(new char[]{',', '.', ';', ':'})) // faghat az aval va akhar barmidare na vasat
                .GroupBy(w => w) // key = w e.g. key = iran
                .Select(g => new WordCount(g.Key, g.Count())) // IEnumarable<Worconut>
                .OrderByDescending(d => d.Count)
                .Select(d => MakeString(d)) // IEnumarable<string>
                .Take(30)
                .ToList()
                // .Distinct() // tekrari haro mihazve
                .ForEach(l => System.Console.WriteLine(l));
        }
        // .Distinct()


    }
}
