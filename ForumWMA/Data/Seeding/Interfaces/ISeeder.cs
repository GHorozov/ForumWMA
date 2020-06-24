namespace ForumWMA.Data.Seeding.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(ForumWMADbContext dbContext, IServiceProvider serviceProvider);
    }
}
