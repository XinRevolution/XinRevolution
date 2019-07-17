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

            // 定義 Seed Data
            modelBuilder.Entity<UserModel>().HasData(new UserModel[] {
                new UserModel{
                    Account = "mike.chen",
                    Password = "12345678",
                    Name = "陳彥翔",
                    Phone = "0916956546",
                    EMail = "tmal0909@gmail.com",
                    Address = "尚未編輯"
                },
                new UserModel{
                    Account = "mike.huang",
                    Password = "0933846966",
                    Name = "黃瀚緯",
                    Phone = "0933846966",
                    EMail = "ss5141318@gmail.com",
                    Address = "尚未編輯"
                }
            });
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<TagModel> Tags { get; set; }
    }
}
