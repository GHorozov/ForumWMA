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

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTag { get; set; }

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

            builder
               .Entity<PostTag>()
               .HasKey(x => new { x.PostId, x.TagId });

            builder
                .Entity<Post>()
                .HasMany(x => x.Tags)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Tag>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.Tag)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
