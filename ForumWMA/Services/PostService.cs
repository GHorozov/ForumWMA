﻿namespace ForumWMA.Services
{
    using ForumWMA.Common.Mapper;
    using ForumWMA.Data;
    using ForumWMA.Data.Models;
    using ForumWMA.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostService : IPostService
    {
        private readonly ForumWMADbContext context;

        public PostService(ForumWMADbContext context)
        {
            this.context = context;
        }
        public T ById<T>(string id)
        {
            var result = this.context
                .Posts
                .Where(x => !x.IsDeleted && x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return result;
        }

        public async Task<string> Create(string title, string content, string categoryId, string userId)
        {
            var post = new Post()
            {
                Title = title,
                Content = content,
                UserId = userId,
                CategoryId = categoryId,
                CreatedOn = DateTime.UtcNow,
            };

            await this.context.Posts.AddAsync(post);
            await this.context.SaveChangesAsync();

            return post.Id;
        }

        public bool IsExist(string postId)
        {
            var post = this.context
                .Posts
                .FirstOrDefault(x => x.Id == postId);

            var result = post != null ? true : false;

            return result;
        }

        public IEnumerable<T> GetByCategoryId<T>(string categoryId, int? take = null, int skip = 0)
        {
            var query = this.context
                .Posts
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => !x.IsDeleted && x.CategoryId == categoryId)
                .Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var result = query.To<T>().ToList();

            return result;
        }

        public int GetCountByCategoryId(string categoryId)
        {
            var result = this.context
                .Posts
                .Where(x => !x.IsDeleted && x.CategoryId == categoryId)
                .Count();

            return result;
        }
    }
}
