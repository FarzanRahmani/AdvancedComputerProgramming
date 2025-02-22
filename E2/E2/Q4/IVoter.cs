namespace E2.Q4
{
    /// <summary>
    /// each class which implements this interface must implement vote method which returns the voteresult of the object called upon
    /// </summary>
    public interface IVoter
    {
        VoteResult Vote(string issue);
    }
}