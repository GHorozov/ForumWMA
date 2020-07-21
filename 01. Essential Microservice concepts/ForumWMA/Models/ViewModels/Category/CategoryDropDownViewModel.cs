namespace ForumWMA.Models.ViewModels.Category
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;
 
    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
