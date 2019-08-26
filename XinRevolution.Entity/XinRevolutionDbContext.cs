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
            modelBuilder.Entity<IssueItemEntity>().HasAlternateKey(x => new { x.Title });
        }

        private void CreateRelation(ModelBuilder modelBuilder)
        {
            // IssueItem
            modelBuilder.Entity<IssueItemEntity>().HasOne(x => x.Issue).WithMany(x => x.IssueItems).HasForeignKey(x => x.IssueId);

            // IssueRelativeLink
            modelBuilder.Entity<IssueRelativeLinkEntity>().HasOne(x => x.Issue).WithMany(x => x.IssueRelativeLinks).HasForeignKey(x => x.IssueId);
        }

        private void CreateSeedData(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = 1,
                Account = "mike.chen",
                Password = "A12345678a",
                Name = "Mike",
                Phone = "0916956546",
                Address = "新北市汐止區",
                Mail = "tmal0909@gmail.com"
            });
        }

        #endregion
    }
}
