using System;
using System.Collections.Generic;
using System.Linq;

namespace E2.Q4
{
    public class City : IVoter
    {
        public string Name;
        public Person[] People;
        public City(string name, Person[] people)
        {
            Name = name;
            People = people;
        }
        /// <summary>
        /// shows the entire vote result of a city by calculating the sum of all people's vote who live in this city
        /// by calling each person's vote function
        /// </summary>
        public VoteResult Vote(string issue) 
        {
            List<VoteResult> vrs = new List<VoteResult>();
            foreach (var item in People)
            {
                vrs.Add(item.Vote(issue));
            }
            int yesCount = 0;
            int noCount = 0;
            int whiteCount = 0;
            foreach (var item in vrs)
            {
                yesCount += item.YesCount;
                noCount += item.NoCount;
                whiteCount += item.WhiteCount;
            }

            return new VoteResult(issue, yesCount, noCount, whiteCount);
        }
    }
}