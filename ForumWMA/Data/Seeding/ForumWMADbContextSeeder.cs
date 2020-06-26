namespace ForumWMA.Data.Seeding
{
    using ForumWMA.Data.Seeding.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ForumWMADbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ForumWMADbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(typeof(ForumWMADbContextSeeder));

            var seeders = new List<ISeeder>
            {
                new RolesSeeder(),
                new CategoriesSeeder(),
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
