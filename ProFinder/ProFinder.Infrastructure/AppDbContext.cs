using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProFinder.Infrastructure.Entities;

namespace ProFinder.Infrastructure
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(p => p.Id).HasDefaultValueSql("NEWID()");
                entity.Property(p => p.Title).IsRequired();
                entity.Property(p => p.ImageUrl).IsRequired();
                entity.Property(p => p.Rating).IsRequired();

                entity.HasMany(p => p.Categories).WithMany(c => c.Posts);
                entity.HasMany(p => p.Reviews).WithOne(r => r.Post).HasForeignKey(r => r.PostId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Id).HasDefaultValueSql("NEWID()");
                entity.Property(c => c.Name).IsRequired();

                entity.HasOne(c => c.ParentCategory).WithMany(c => c.SubCategories).HasForeignKey(c => c.ParentCategoryId);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(r => r.Id).HasDefaultValueSql("NEWID()");
                entity.Property(r => r.Title).IsRequired();
                entity.Property(r => r.PublishedDate).IsRequired();
                entity.Property(r => r.Content).IsRequired();
                entity.Property(r => r.UserId).IsRequired();

                entity.HasMany(r => r.Comments).WithOne(c => c.Review).HasForeignKey(c => c.ReviewId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(c => c.Id).HasDefaultValueSql("NEWID()");
                entity.Property(c => c.Body).IsRequired();
                entity.Property(c => c.UserId).IsRequired();

                entity.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserId);
            });

            #region Seed Data
            var adminId = Guid.Parse("237C1048-52E6-400C-9FBA-498750F9FF8B");
            var adminUserName = "admin@test.com";
            var adminPassword = "admin123";
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminId,
                    UserName = adminUserName,
                    NormalizedUserName = adminUserName.ToUpper(),
                    Email = adminUserName,
                    NormalizedEmail = adminUserName.ToUpper(),
                    PasswordHash = passwordHasher.HashPassword(null!, adminPassword),
                    SecurityStamp = Guid.Parse("67F8048E-F8FF-4B19-8BA1-7BF7BCF62184").ToString()
                }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}