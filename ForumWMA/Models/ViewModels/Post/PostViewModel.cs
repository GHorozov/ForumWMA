namespace ForumWMA.Models.ViewModels.Post
{
    using ForumWMA.Common.Mapper.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ForumWMA.Data.Models;
    using AutoMapper;
    using Ganss.XSS;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<PostCommentViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.VotesCount, src =>
                {
                    src.MapFrom(p => p.Votes.Sum(x => (int)x.Type));
                });
        }
    }
}
