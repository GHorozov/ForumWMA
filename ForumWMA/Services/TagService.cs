namespace ForumWMA.Services
{
    using AutoMapper;
    using ForumWMA.Common.Mapper;
    using ForumWMA.Data;
    using ForumWMA.Data.Models;
    using ForumWMA.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    public class TagService : ITagService
    {
        private readonly ForumWMADbContext context;
        private readonly IMapper mapper;

        public TagService(ForumWMADbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<T> All<T>(int? count = null)
        {
            IQueryable<Tag> query = this.context
               .Tags
               .Where(x => !x.IsDeleted)
               .OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            var result = query.To<T>().ToList();

            return result;
        }

        public async Task<string> Create(string name)
        {
            var tag = new Tag()
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
            };

            await this.context.Tags.AddAsync(tag);
            await this.context.SaveChangesAsync();

            return tag.Id;
        }

        public async Task<bool> Edit(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name)) return false;

            var tag = await this.context.Tags.SingleOrDefaultAsync(x => x.Id == id);
            if (tag == null) return false;

            tag.Name = name;
            tag.ModifiedOn = DateTime.UtcNow;

            this.context.Tags.Update(tag);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<T> GetTagById<T>(string id)
        {
            var tag = await this.context
               .Tags
               .Where(x => x.Id == id)
               .To<T>(this.mapper)
               .SingleOrDefaultAsync();

            return tag;
        }
    }
}
