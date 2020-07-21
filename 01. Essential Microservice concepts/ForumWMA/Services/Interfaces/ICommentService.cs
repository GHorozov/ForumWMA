namespace ForumWMA.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task Create(string userId, string postId, string content, string parentId = null);

        bool IsInPostId(string commentId, string postId);
    }
}
