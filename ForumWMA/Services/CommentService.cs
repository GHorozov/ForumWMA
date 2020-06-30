namespace ForumWMA.Services
{
    using ForumWMA.Data;
    using ForumWMA.Data.Models;
    using ForumWMA.Services.Interfaces;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentService : ICommentService
    {
        private readonly ForumWMADbContext context;

        public CommentService(ForumWMADbContext context)
        {
            this.context = context;
        }

        public async Task Create(string userId, string postId, string content, string parentId = null)
        {
            var comment = new Comment()
            {
                PostId = postId,
                CreatedOn = DateTime.UtcNow,
                Content = content,
                ParentCommentId = parentId,
                UserId = userId,
            };

            await this.context.Comments.AddAsync(comment);
            await this.context.SaveChangesAsync();
        }

        public bool IsInPostId(string commentId, string postId)
        {
            var commentPostId = this.context
                .Comments
                .Where(x => !x.IsDeleted && x.Id == commentId)
                .Select(x => x.PostId)
                .FirstOrDefault();

            var result = commentPostId == postId;

            return result;
        }
    }
}
