using System;
using System.Collections.Generic;
using System.Linq;

namespace E2.Q4
{
    public class Country : IVoter
    {
        public string Name;
        public State[] States;
        public Country(string name, State[] states)
        {
            Name = name;
            States = states;
        }
        /// <summary>
        /// generating vote result for the entire country by summing all the vote results of the states located in  the country
        /// and caaling each state's vote function which itself calls the located cities' vote function and so on (call hierarchy)
        /// </summary>
        /// <param name="issue"></param>
        public VoteResult Vote(string issue) 
        {
            List<VoteResult> vrs = new List<VoteResult>();
            foreach (var item in States)
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