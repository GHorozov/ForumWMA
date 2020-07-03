using ForumWMA.Common.Mapper.Interfaces;
using ForumWMA.Data.Models;

namespace ForumWMA.Areas.Administrator.Models.ViewModels.User
{
    public class UserViewModel : IMapFrom<ForumWMAUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
