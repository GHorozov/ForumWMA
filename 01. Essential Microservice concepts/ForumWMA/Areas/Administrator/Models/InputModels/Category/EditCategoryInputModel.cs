namespace ForumWMA.Areas.Administrator.Models.InputModels.Category
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;
    using System.ComponentModel.DataAnnotations;
    

    public class EditCategoryInputModel : IMapFrom<Category>
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Category name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 9)]
        [Url()]
        public string ImageUrl { get; set; }
    }
}
