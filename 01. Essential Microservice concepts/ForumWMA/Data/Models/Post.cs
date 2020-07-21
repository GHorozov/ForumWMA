namespace ForumWMA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
            this.Tags = new HashSet<PostTag>();
        }
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ForumWMAUser User { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<PostTag> Tags { get; set; }
    }
}
