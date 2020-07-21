using ForumWMA.Common.Mapper.Interfaces;
using ForumWMA.Data.Models;
using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForumWMA.Models.ViewModels.Post
{
    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string Content { get; set; }

        //public string CleanContent
        //{
        //    get
        //    {
        //        var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
        //        return content;
        //    }
        //}

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ParentCommentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public string UserProfilePictureUrl { get; set; }
    }
}
