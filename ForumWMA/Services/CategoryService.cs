namespace ForumWMA.Services
{
    using ForumWMA.Common.Mapper;
    using ForumWMA.Data;
    using ForumWMA.Services.Interfaces;

    public class CategoryService : ICategoryService
    {
        private readonly ForumWMADbContext context;

        public CategoryService(ForumWMADbContext context)
        {
            this.context = context;
        }

        //public IEnumerable<T> All<T>(int? count = null)
        //{
        //    IQueryable<Category> query = this.context
        //        .Categories
        //        .Where(x => !x.IsDeleted)
        //        .OrderBy(x => x.Name);
        //    if (count.HasValue)
        //    {
        //        query = query.Take(count.Value);
        //    }

        //    var result = query.To<T>().ToList();

        //    return result;
        //}
    }
}
