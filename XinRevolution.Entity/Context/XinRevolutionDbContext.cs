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
            // 定義 Primary Key
            modelBuilder.Entity<UserModel>().HasKey(x => new { x.Account });
            modelBuilder.Entity<TagModel>().HasKey(x => new { x.TagName });
            modelBuilder.Entity<IssueModel>().HasKey(x => new { x.IssueName });
            modelBuilder.Entity<IssueRelativeLinkModel>().HasKey(x => new { x.Id });


            // 定義 Seed Data
            modelBuilder.Entity<UserModel>().HasData(new UserModel[] {
                new UserModel{
                    Account = "mike.chen",
                    Password = "12345678",
                    UserName = "陳彥翔",
                    Phone = "0916956546",
                    EMail = "tmal0909@gmail.com",
                    Address = "尚未編輯"
                },
                new UserModel{
                    Account = "mike.huang",
                    Password = "0933846966",
                    UserName = "黃瀚緯",
                    Phone = "0933846966",
                    EMail = "ss5141318@gmail.com",
                    Address = "尚未編輯"
                }
            });

            modelBuilder.Entity<TagModel>().HasData(new TagModel[] {
                new TagModel
                {
                    TagName = "tag1",
                    TagStatus = true
                },
                new TagModel
                {
                    TagName = "tag2",
                    TagStatus = true
                },
                new TagModel
                {
                    TagName = "tag3",
                    TagStatus = false
                },
            });

            modelBuilder.Entity<IssueModel>().HasData(new IssueModel
            {
                IssueName = "issue1",
                IssueIntro = "this is the first issue for demo purpose!"
            });
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<TagModel> Tags { get; set; }

        public DbSet<IssueModel> Issues { get; set; }

        public DbSet<IssueRelativeLinkModel> IssueRelativeLinks { get; set; }
    }
}
