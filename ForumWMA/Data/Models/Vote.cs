namespace ForumWMA.Data.Models
{
    using ForumWMA.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
  
    public class Vote : BaseModel<string>
    {
        public Vote()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ForumWMAUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
