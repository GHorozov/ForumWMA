﻿namespace ForumWMA.Data.Models
{
    using System;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Content { get; set; }

        public string ParentCommentId { get; set; }

        public virtual Comment ParentComment { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public string UserId { get; set; }

        public virtual ForumWMAUser User { get; set; }
    }
}
