using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XinRevolution.Entity.Models;

namespace XinRevolution.Entity.Context
{
    public class XinRevolutionDbContext : DbContext
    {
        public XinRevolutionDbContext(DbContextOptions<XinRevolutionDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<TagModel> Tags { get; set; }
    }
}