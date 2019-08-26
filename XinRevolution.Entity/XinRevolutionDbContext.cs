using Microsoft.EntityFrameworkCore;
using XinRevolution.Entity.Entities;

namespace XinRevolution.Entity
{
    public class XinRevolutionDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public XinRevolutionDbContext(DbContextOptions<XinRevolutionDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define Alternate Key & Composite Key
            CreateAlternateKey(modelBuilder);

            // Define Seed Data
            CreateSeedData(modelBuilder);
        }

        private void CreateAlternateKey(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<UserEntity>().HasAlternateKey(x => new { x.Account });
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
    }
}
