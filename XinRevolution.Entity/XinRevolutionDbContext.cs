using Microsoft.EntityFrameworkCore;
using XinRevolution.Entity.Entities;

namespace XinRevolution.Entity
{
    public class XinRevolutionDbContext : DbContext
    {
        #region DbSet

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<IssueEntity> Issues { get; set; }

        public DbSet<IssueItemEntity> IssueItems { get; set; }

        public DbSet<IssueRelativeLinkEntity> IssueRelativeLinks { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<BlogEntity> Blogs { get; set; }

        public DbSet<BlogPostEntity> BlogPosts { get; set; }

        public DbSet<BlogTagEntity> BlogTags { get; set; }

        #endregion

        #region Constructor

        public XinRevolutionDbContext(DbContextOptions<XinRevolutionDbContext> options) : base(options) { }

        #endregion

        #region Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define Alternate Key & Composite Key
            CreateAlternateKey(modelBuilder);

            // Define Relation
            CreateRelation(modelBuilder);

            // Define Seed Data
            CreateSeedData(modelBuilder);
        }

        #endregion

        #region General Method

        private void CreateAlternateKey(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<UserEntity>().HasAlternateKey(x => new { x.Account });

            // Issue
            modelBuilder.Entity<IssueEntity>().HasAlternateKey(x => new { x.Name });

            // IssueItem
            modelBuilder.Entity<IssueItemEntity>().HasAlternateKey(x => new { x.Title, x.ReleaseDate });

            // Tag
            modelBuilder.Entity<TagEntity>().HasAlternateKey(x => new { x.Name });

            // Blog
            modelBuilder.Entity<BlogEntity>().HasAlternateKey(x => new { x.Name });

            // BlogTag
            modelBuilder.Entity<BlogTagEntity>().HasAlternateKey(x => new { x.BlogId, x.TagId });
        }

        private void CreateRelation(ModelBuilder modelBuilder)
        {
            // IssueItem
            modelBuilder.Entity<IssueItemEntity>().HasOne(x => x.Issue).WithMany(x => x.IssueItems).HasForeignKey(x => x.IssueId);

            // IssueRelativeLink
            modelBuilder.Entity<IssueRelativeLinkEntity>().HasOne(x => x.Issue).WithMany(x => x.IssueRelativeLinks).HasForeignKey(x => x.IssueId);

            // BlogPost
            modelBuilder.Entity<BlogPostEntity>().HasOne(x => x.Blog).WithMany(x => x.BlogPosts).HasForeignKey(x => x.BlogId);

            // BlogTag
            modelBuilder.Entity<BlogTagEntity>().HasOne(x => x.Tag).WithMany(x => x.BlogTags).HasForeignKey(x => x.TagId);
        }

        private void CreateSeedData(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity[] {
                new UserEntity
                {
                    Id = 1,
                    Account = "mike.chen",
                    Password = "A12345678a",
                    Name = "Mike.Chen",
                    Phone = "0916956546",
                    Address = "新北市汐止區",
                    Mail = "tmal0909@gmail.com"
                },
                new UserEntity
                {
                    Id = 2,
                    Account = "mike.huang",
                    Password = "12345678",
                    Name = "Mike.Huang",
                    Phone = "temp phone",
                    Address = "temp address",
                    Mail = "temp mail"
                }
            });

            // Tags
            modelBuilder.Entity<TagEntity>().HasData(new TagEntity[] {
                new TagEntity{
                    Id = 1,
                    Name = "Tag1",
                    Enable = true
                },
                new TagEntity{
                    Id = 2,
                    Name = "Tag2",
                    Enable = false
                }
            });
        }

        #endregion
    }
}
