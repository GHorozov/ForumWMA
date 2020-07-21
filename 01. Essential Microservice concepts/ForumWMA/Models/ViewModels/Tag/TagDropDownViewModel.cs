namespace ForumWMA.Models.ViewModels.Tag
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;

    public class TagDropDownViewModel : IMapFrom<Tag>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
