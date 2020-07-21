namespace ForumWMA.Areas.Administrator.Models.ViewModels.User
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;

    public class DeleteUserViewModel : IMapFrom<ForumWMAUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}
