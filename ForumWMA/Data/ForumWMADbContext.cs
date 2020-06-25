namespace ForumWMA.Data
{
    using ForumWMA.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ForumWMADbContext : IdentityDbContext<ForumWMAUser, ForumWMARole, string>
    {
        public ForumWMADbContext(DbContextOptions<ForumWMADbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<ForumWMAUser>()
                .HasMany(x => x.Roles)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ForumWMAUser>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .Entity<ForumWMAUser>()
              .HasMany(x => x.Logins)
              .WithOne()
              .HasForeignKey(x => x.UserId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
