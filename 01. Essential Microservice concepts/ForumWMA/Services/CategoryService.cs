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
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly ForumWMADbContext context;
        private readonly IMapper mapper;

        public CategoryService(ForumWMADbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<T> All<T>(int? count = null)
        {
            IQueryable<Category> query = this.context
                .Categories
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            var result = query.To<T>().ToList();

            return result;
        }

        public T GetByName<T>(string name, int? take = null, int skip = 0)
        {
            var result = this.context
                .Categories
                .Where(x => !x.IsDeleted && x.Name == name)
                .Include(x => x.Posts)
                .ThenInclude(x => x.Tags)
                .To<T>()
                .FirstOrDefault();

            return result;
        }

        public async Task<string> Create(string name, string title, string description, string imageUrl)
        {
            var category = new Category()
            {
                Name = name,
                Title = title,
                Description = description,
                ImageUrl = imageUrl,
                CreatedOn = DateTime.UtcNow,
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return category.Id;
        }

        public async Task<T> GetCategoryById<T>(string id)
        {
            var category = await this.context
                .Categories
                .Where(x => x.Id == id)
                .To<T>(this.mapper)
                .SingleOrDefaultAsync();


            return category;
        }

        public async Task<bool> Edit(string id, string name, string title, string description, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name)) return false;

            var category = await this.context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (category == null) return false;

            category.Name = name;
            category.Title = title;
            category.Description = description;
            category.ImageUrl = imageUrl;
            category.ModifiedOn = DateTime.UtcNow;

            this.context.Update(category);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
