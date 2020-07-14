namespace ForumWMA.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tag : BaseDeletableModel<string>
    {
        public Tag()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Posts = new HashSet<PostTag>();
        }

        public string Name { get; set; }

        public virtual ICollection<PostTag> Posts { get; set; }
    }
}
