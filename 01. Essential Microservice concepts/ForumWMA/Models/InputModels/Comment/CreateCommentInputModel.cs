namespace ForumWMA.Models.InputModels.Comment
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }

        public string PostId { get; set; }

        public string ParentId { get; set; }
    }
}
