namespace ForumWMA.Models.InputModels.Post
{
    using ForumWMA.Models.ViewModels.Category;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostCreateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
