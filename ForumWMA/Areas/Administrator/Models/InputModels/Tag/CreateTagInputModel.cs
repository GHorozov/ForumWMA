namespace ForumWMA.Areas.Administrator.Models.InputModels.Tag
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTagInputModel
    {
        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Tag name")]
        public string Name { get; set; }
    }
}
