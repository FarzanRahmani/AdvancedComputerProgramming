using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L3
{
    public class AppAnalysis
    {
        public List<AppData> Apps = new List<AppData>();
        public AppAnalysis()
        { }

        public static AppAnalysis AppAnalysisFactory(string csvAddress)
        {
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                int i = 0;
                while (!parser.EndOfData)
                {
                    i++;
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            }
            return appAnalysis;
        }

        public void AppendApp(string[] fields)
        {
            AppData ap = new AppData(fields);
            this.Apps.Add(ap);
        }


        public int AllAppsCount()
        {
            return Apps.Count;

        }


        public object AppsAboveXRatingCount(double minRate)
        {
            // int sum = 0;
            // Apps.ForEach( (i) => {
            //     if (i.Rating >= minRate)
            //         sum++;}
            //     );
            // return sum;
            return Apps.Where( app => app.Rating >= minRate).Count();
        }


        public string RecentlyUpdatedCount(DateTime dateTime)
        {
            return Apps.Where( app => app.LastUpdate >= dateTime).Count().ToString();
        }


        public string RecentlyUpdatedFreqCat(DateTime dateTime)
        {
            return Apps.Where( app => app.LastUpdate >= dateTime)
                .GroupBy( app => app.Category)
                .Aggregate( (g1,g2) => g1.Count() > g2.Count() ? g1 : g2)
                .Key
                .ToString();
            // return Apps.Where( app => app.LastUpdate >= dateTime)
            //     .GroupBy( app => app.Category)
            //     .OrderByDescending(g => g.Count())
            //     .Select(g => g.Key)
            //     .First();
        }


        public List<string> MostRatedCategories(double v1, int v2)
        {
            return Apps.Where( app => app.Rating > v1)
                .GroupBy( app => app.Category)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(v2).ToList();
        }


        public Tuple<string, string> ExtremeMeanUpdateElapse()
        {
            var res = Apps.GroupBy( app => app.Category)
                .OrderBy(g => g.Sum(a => a.LastUpdate.Ticks - DateTime.Now.Ticks)/g.Count())
                .Select(g => g.Key);
            Tuple<string, string> result = new Tuple<string, string>(res.First(),res.Last());
            return result;
        }




        public List<string> XMostProfitables(int x)
        {
            return Apps
                .OrderByDescending(app => app.Installs*app.Price)
                .Select(a => a.Name)
                .Take(x)
                .ToList();
        }


        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
        {
            return Apps
                .OrderBy(app => criteria(app))
                .Select(a => a.Name)
                .Take(x)
                .ToList();

        }

    }
}
