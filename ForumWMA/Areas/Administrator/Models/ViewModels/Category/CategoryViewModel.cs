namespace ForumWMA.Areas.Administrator.Models.ViewModels.Category
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
