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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 定義 Primary Key
            modelBuilder.Entity<UserModel>().HasKey(x => x.Id);

            // 定義 Unique Key
            modelBuilder.Entity<UserModel>().HasAlternateKey(x => new { x.Account });

            
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
        }
    }
}
