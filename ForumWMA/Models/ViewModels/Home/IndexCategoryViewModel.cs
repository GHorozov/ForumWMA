namespace ForumWMA.Models.ViewModels.Home
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
