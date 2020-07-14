namespace ForumWMA.Models.InputModels.Post
{
    using ForumWMA.Models.ViewModels.Category;
    using ForumWMA.Models.ViewModels.Tag;
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

        [Required]
        [Display(Name = "Tag")]
        public IEnumerable<string> MultipleTagId { get; set; }

        public IEnumerable<TagDropDownViewModel> Tags { get; set; }
    }
}
