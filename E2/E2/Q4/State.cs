using System;
using System.Collections.Generic;
using System.Linq;

namespace E2.Q4
{
    public class State : IVoter
    {
        public string Name;
        public City[] Cities;
        public State(string name, City[] city)
        {
            Name = name;
            Cities = city;
        }
        /// <summary>
        /// generating vote result for a state by summing all the vote results of the cities located in  this state
        /// and calling each city's vote function
        /// </summary>
        public VoteResult Vote(string issue) 
        {
            List<VoteResult> vrs = new List<VoteResult>();
            foreach (var item in Cities)
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