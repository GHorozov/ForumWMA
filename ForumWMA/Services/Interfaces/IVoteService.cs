namespace ForumWMA.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IVoteService
    {
        Task VoteAsync(string postId, string userId, bool isUpVote);

        int GetVotesCount(string postId);
    }
}
