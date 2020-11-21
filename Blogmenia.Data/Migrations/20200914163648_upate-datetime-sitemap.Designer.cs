﻿// <auto-generated />
using System;
using Blogmenia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blogmenia.Data.Migrations
{
    [DbContext(typeof(BlogmeniaDbContext))]
    [Migration("20200914163648_upate-datetime-sitemap")]
    partial class upatedatetimesitemap
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Blogmenia.Core.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IsActive")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Blogmenia.Core.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AuthorId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AuthorIp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AuthorWebsite")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CommentAgent")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CommentDateGmt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("IsAdmin")
                        .HasColumnType("int");

                    b.Property<string>("Karma")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Blogmenia.Core.Demos", b =>
                {
                    b.Property<int>("DemoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContentBody")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DemoTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("PostLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PostUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DemoId");

                    b.ToTable("Demos");
                });

            modelBuilder.Entity("Blogmenia.Core.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("CommentCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FeaturedImg")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IsFeatured")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MetaKeyword")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MultipleCategory")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PrimaryCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Rating")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SendMail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SortName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Blogmenia.Core.Postcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Postcategory");
                });

            modelBuilder.Entity("Blogmenia.Core.Sitemaping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Priority")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("URl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Sitemaping");
                });

            modelBuilder.Entity("Blogmenia.Core.Subscriber", b =>
                {
                    b.Property<int>("SubscriberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActionType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IpAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IsVerified")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OperatingSystemType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SubscriberId");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("Blogmenia.Core.Postcategory", b =>
                {
                    b.HasOne("Blogmenia.Core.Post", "Post")
                        .WithMany("Postcategory")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
