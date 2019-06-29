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
            modelBuilder.Entity<BlogModel>().HasKey(c => new { c.Title, c.Date });
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<TagModel> Tags { get; set; }

        public DbSet<BlogModel> Blogs { get; set; }

        public DbSet<BlogContentModel> BlogContents { get; set; }

        public DbSet<BlogTagModel> BlogTags { get; set; }
    }
}
