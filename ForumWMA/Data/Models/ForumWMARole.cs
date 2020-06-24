namespace ForumWMA.Data.Models
{
    using ForumWMA.Data.Models.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ForumWMARole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ForumWMARole()
            : this(null)
        {
        }

        public ForumWMARole(string name)
            :base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
