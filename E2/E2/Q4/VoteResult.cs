using System;

namespace E2.Q4
{
    public record VoteResult(string Issue, int YesCount, int NoCount, int WhiteCount)
    {
        public override string ToString()
        {
            return $"{Issue}, Yes:{YesCount}\tNo:{NoCount}\tWhite:{WhiteCount}";
        }

        public int Total => YesCount+NoCount+WhiteCount;
    }
}