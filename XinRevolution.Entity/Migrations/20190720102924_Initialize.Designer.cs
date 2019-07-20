﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XinRevolution.Entity.Context;

namespace XinRevolution.Entity.Migrations
{
    [DbContext(typeof(XinRevolutionDbContext))]
    [Migration("20190720102924_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XinRevolution.Entity.Model.IssueModel", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Name");

                    b.ToTable("Issues");

                    b.HasData(
                        new { Name = "issue1", Id = 0L, Intro = "this is the first issue for demo purpose!" }
                    );
                });

            modelBuilder.Entity("XinRevolution.Entity.Model.IssueRelativeLinkModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ResourceVirtualPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("IssueRelativeLinks");
                });

            modelBuilder.Entity("XinRevolution.Entity.Model.TagModel", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Name");

                    b.ToTable("Tags");

                    b.HasData(
                        new { Name = "tag1", Id = 0L, Status = true },
                        new { Name = "tag2", Id = 0L, Status = true },
                        new { Name = "tag3", Id = 0L, Status = false }
                    );
                });

            modelBuilder.Entity("XinRevolution.Entity.Model.UserModel", b =>
                {
                    b.Property<string>("Account")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Account");

                    b.ToTable("Users");

                    b.HasData(
                        new { Account = "mike.chen", Address = "尚未編輯", EMail = "tmal0909@gmail.com", Id = 0L, Name = "陳彥翔", Password = "12345678", Phone = "0916956546" },
                        new { Account = "mike.huang", Address = "尚未編輯", EMail = "ss5141318@gmail.com", Id = 0L, Name = "黃瀚緯", Password = "0933846966", Phone = "0933846966" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}