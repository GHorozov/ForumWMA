namespace ForumWMA.Services
{
    using ForumWMA.Common.Mapper;
    using ForumWMA.Data;
    using ForumWMA.Data.Models;
    using ForumWMA.Services.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly ForumWMADbContext context;

        public CategoryService(ForumWMADbContext context)
        {
            this.context = context;
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
                .To<T>()
                .FirstOrDefault();

            return result;
        }
    }
}
