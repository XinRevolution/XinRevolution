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
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
