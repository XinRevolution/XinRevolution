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

        public DbSet<UserModel> Users { get; set; }

        public DbSet<IssueModel> Issues { get; set; }

        public DbSet<IssueRelativeLinkModel> IssueRelativeLinks { get; set; }

        public DbSet<IssueItemModel> IssueItems { get; set; }

        public DbSet<TagModel> Tags { get; set; }

        public DbSet<BlogModel> Blogs { get; set; }

        public DbSet<BlogTagModel> BlogTags { get; set; }

        public DbSet<BlogContent> BlogContents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 定義 Primary Key
            modelBuilder.Entity<UserModel>().HasKey(x => new { x.Account });
            modelBuilder.Entity<IssueModel>().HasKey(x => new { x.Id });
            modelBuilder.Entity<IssueRelativeLinkModel>().HasKey(x => new { x.Id });
            modelBuilder.Entity<IssueItemModel>().HasKey(x => new { x.Title, x.Date });
            modelBuilder.Entity<TagModel>().HasKey(x => x.Id);
            modelBuilder.Entity<TagModel>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<BlogModel>().HasKey(x => x.Id);
            modelBuilder.Entity<BlogModel>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<BlogContent>().HasKey(x => x.Id);
            modelBuilder.Entity<BlogTagModel>().HasKey(x => new { x.BlogId, x.TagId });


            // 定義 Identity
            modelBuilder.Entity<UserModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IssueModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IssueRelativeLinkModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IssueItemModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TagModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BlogModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BlogContent>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BlogTagModel>().Property(x => x.Id).ValueGeneratedOnAdd();


            // 定義 Relation & Foreign Key
            modelBuilder.Entity<IssueRelativeLinkModel>().HasOne(x => x.Issue).WithMany(x => x.IssueRelativeLinks).HasForeignKey(x => x.IssueId);
            modelBuilder.Entity<IssueItemModel>().HasOne(x => x.Issue).WithMany(x => x.IssueItems).HasForeignKey(x => x.IssueId);
            modelBuilder.Entity<BlogContent>().HasOne(x => x.Blog).WithMany(x => x.BlogContents).HasForeignKey(x => x.BlogId);
            modelBuilder.Entity<BlogTagModel>().HasOne(x => x.Blog).WithMany(x => x.BlogTags).HasForeignKey(x => x.BlogId);
            modelBuilder.Entity<BlogTagModel>().HasOne(x => x.Tag).WithMany(x => x.BlogTags).HasForeignKey(x => x.TagId);

            // 定義 Seed Data
            modelBuilder.Entity<UserModel>().HasData(new UserModel[] {
                new UserModel{
                    Id = 1,
                    Account = "mike.chen",
                    Password = "12345678",
                    Name = "陳彥翔",
                    Phone = "0916956546",
                    EMail = "tmal0909@gmail.com",
                    Address = "尚未編輯"
                },
                new UserModel{
                    Id = 2,
                    Account = "mike.huang",
                    Password = "0933846966",
                    Name = "黃瀚緯",
                    Phone = "0933846966",
                    EMail = "ss5141318@gmail.com",
                    Address = "尚未編輯"
                }
            });
            modelBuilder.Entity<TagModel>().HasData(new TagModel[] {
                new TagModel{
                    Id = 1,
                    Name = "tag1",
                    Enable = true
                },
                new TagModel{
                    Id = 2,
                    Name = "tag2",
                    Enable = true
                },
                new TagModel{
                    Id = 3,
                    Name = "tag3",
                    Enable = false
                },
            });
        }
    }
}
