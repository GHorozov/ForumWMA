namespace ForumWMA.Services
{
    using ForumWMA.Data;
    using ForumWMA.Data.Models;
    using ForumWMA.Data.Models.Enums;
    using ForumWMA.Services.Interfaces;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class VoteService : IVoteService
    {
        private readonly ForumWMADbContext context;

        public VoteService(ForumWMADbContext context)
        {
            this.context = context;
        }

        public int GetVotesCount(string postId)
        {
            var result = this.context
                .Votes
                .Where(x => x.PostId == postId)
                .Sum(x => (int)x.Type);

            return result;
        }

        public async Task VoteAsync(string postId, string userId, bool isUpVote)
        {
            var vote = this.context
                .Votes
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.Up : VoteType.Down;
                vote.ModifiedOn = DateTime.UtcNow;
            }
            else
            {
                vote = new Vote()
                {
                    PostId = postId,
                    UserId = userId,
                    CreatedOn = DateTime.UtcNow,
                    Type = isUpVote ? VoteType.Up : VoteType.Down,
                };

                await this.context.Votes.AddAsync(vote);
            }

            await this.context.SaveChangesAsync();
        }
    }
}
