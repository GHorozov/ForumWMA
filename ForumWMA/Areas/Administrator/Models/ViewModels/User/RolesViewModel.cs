namespace ForumWMA.Areas.Administrator.Models.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RolesViewModel
    {
        public string Id { get; set; }

        public List<string> Roles { get; set; }
    }
}
