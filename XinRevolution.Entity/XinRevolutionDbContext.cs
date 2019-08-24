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
            modelBuilder.Entity<UserEntity>().HasAlternateKey(x => new { x.Account });
        }
    }
}
