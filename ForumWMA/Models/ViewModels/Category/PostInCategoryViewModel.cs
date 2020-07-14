namespace ForumWMA.Models.ViewModels.Category
{
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.RegularExpressions;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 200 ? content?.Substring(0, 200) + "..." : content;
            }
        }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<PostTagViewModel> Tags { get; set; }
    }
}
