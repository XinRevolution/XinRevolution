﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XinRevolution.Entity;

namespace XinRevolution.Entity.Migrations
{
    [DbContext(typeof(XinRevolutionDbContext))]
    [Migration("20190826155344_Table_Issue_Initialize")]
    partial class Table_Issue_Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XinRevolution.Entity.Entities.IssueEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("XinRevolution.Entity.Entities.IssueItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ResourceUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Title");

                    b.HasIndex("IssueId");

                    b.ToTable("IssueItems");
                });

            modelBuilder.Entity("XinRevolution.Entity.Entities.IssueRelativeLinkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ResourceUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("IssueRelativeLinks");
                });

            modelBuilder.Entity("XinRevolution.Entity.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Account");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Account = "mike.chen",
                            Address = "新北市汐止區",
                            Mail = "tmal0909@gmail.com",
                            Name = "Mike",
                            Password = "A12345678a",
                            Phone = "0916956546"
                        });
                });

            modelBuilder.Entity("XinRevolution.Entity.Entities.IssueItemEntity", b =>
                {
                    b.HasOne("XinRevolution.Entity.Entities.IssueEntity", "Issue")
                        .WithMany("IssueItems")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XinRevolution.Entity.Entities.IssueRelativeLinkEntity", b =>
                {
                    b.HasOne("XinRevolution.Entity.Entities.IssueEntity", "Issue")
                        .WithMany("IssueRelativeLinks")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}