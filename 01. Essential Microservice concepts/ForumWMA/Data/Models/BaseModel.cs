namespace ForumWMA.Data.Models
{
    using ForumWMA.Data.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaseModel<T> :  IAuditInfo
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
