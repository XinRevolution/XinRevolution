//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using XinRevolution.Entity.Model;

//namespace XinRevolution.Entity.Context
//{
//    public class XinRevolutionDbContext : DbContext
//    {
//        public XinRevolutionDbContext(DbContextOptions<XinRevolutionDbContext> options) : base(options) { }

//        public DbSet<UserModel> Users { get; set; }

//        //public DbSet<IssueModel> Issues { get; set; }

//        //public DbSet<IssueRelativeLinkModel> IssueRelativeLinks { get; set; }

//        //public DbSet<IssueItemModel> IssueItems { get; set; }

//        //public DbSet<TagModel> Tags { get; set; }

//        //public DbSet<BlogModel> Blogs { get; set; }

//        //public DbSet<BlogTagModel> BlogTags { get; set; }

//        //public DbSet<BlogContent> BlogContents { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // 定義 Primary Key
//            //modelBuilder.Entity<TagModel>().HasKey(x => x.Id);
//            //modelBuilder.Entity<TagModel>().HasAlternateKey(x => x.Name);
//            //modelBuilder.Entity<BlogModel>().HasKey(x => x.Id);
//            //modelBuilder.Entity<BlogModel>().HasAlternateKey(x => x.Name);
//            //modelBuilder.Entity<BlogContent>().HasKey(x => x.Id);
//            //modelBuilder.Entity<BlogTagModel>().HasKey(x => new { x.BlogId, x.TagId });


//            // 定義 Relation & Foreign Key
//            //modelBuilder.Entity<BlogContent>().HasOne(x => x.Blog).WithMany(x => x.BlogContents).HasForeignKey(x => x.BlogId);
//            //modelBuilder.Entity<BlogTagModel>().HasOne(x => x.Blog).WithMany(x => x.BlogTags).HasForeignKey(x => x.BlogId);
//            //modelBuilder.Entity<BlogTagModel>().HasOne(x => x.Tag).WithMany(x => x.BlogTags).HasForeignKey(x => x.TagId);
//        }
//    }
//}
