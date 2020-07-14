namespace ForumWMA.Areas.Administrator.Models.ViewModels.Tag
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;

    public class TagViewModel : IMapFrom<Tag>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
