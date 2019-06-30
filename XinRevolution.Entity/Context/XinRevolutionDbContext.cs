using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XinRevolution.Entity.Model;

namespace XinRevolution.Entity.Context
{
    public class XinRevolutionDbContext : DbContext
    {
        public XinRevolutionDbContext(DbContextOptions<XinRevolutionDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(x => new { x.Account });

            // 尚須整合
            modelBuilder.Entity<BlogModel>().HasKey(x => new { x.Title, x.Date });
        }

        public DbSet<UserModel> Users { get; set; }


        // 尚須整合
        public DbSet<TagModel> Tags { get; set; }

        public DbSet<BlogModel> Blogs { get; set; }

        public DbSet<BlogContentModel> BlogContents { get; set; }

        public DbSet<BlogTagModel> BlogTags { get; set; }
    }
}
