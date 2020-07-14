namespace ForumWMA.Models.ViewModels.Category
{
    using AutoMapper;
    using ForumWMA.Common.Mapper.Interfaces;
    using ForumWMA.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    public class PostTagViewModel : IMapFrom<PostTag> //, IHaveCustomMappings
    {
        public string TagId { get; set; }

        public Tag Tag { get; set; }


        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<PostTag, PostTagViewModel>()
        //        .ForMember(desc => desc.Tag, mapper => mapper.MapFrom(src => src.Tag));
        //}
    }
}
