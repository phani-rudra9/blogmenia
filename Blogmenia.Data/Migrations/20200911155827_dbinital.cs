using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogmenia.Data.Migrations
{
    public partial class dbinital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });



            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    FeaturedImg = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    PrimaryCategoryId = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    SendMail = table.Column<string>(nullable: true),
                    SortName = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<string>(nullable: true),
                    MultipleCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                  name: "FK_Post002_PrimaryCategoryId",
                  column: x => x.PrimaryCategoryId,
                  principalTable: "Categories",
                  principalColumn: "CategoryId",
                  onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    AuthorEmail = table.Column<string>(nullable: false),
                    AuthorWebsite = table.Column<string>(nullable: true),
                    AuthorIp = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentDateGmt = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Karma = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CommentAgent = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ParentCommentId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    IsAdmin = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);

                    table.ForeignKey(
                   name: "FK_Comments001_PostId",
                   column: x => x.PostId,
                   principalTable: "Post",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demos",
                columns: table => new
                {
                    DemoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Slug = table.Column<string>(nullable: true),
                    ContentBody = table.Column<string>(nullable: true),
                    PostLink = table.Column<string>(nullable: true),
                    PostUrl = table.Column<string>(nullable: true),
                    DemoTitle = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demos", x => x.DemoId);
                });


            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    EmailId = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    OperatingSystemType = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ActionType = table.Column<string>(nullable: true),
                    IsVerified = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.SubscriberId);
                });

            migrationBuilder.CreateTable(
                name: "Postcategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postcategory_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);


                    table.ForeignKey(
                       name: "FK_Postcategory_CategoryId_PostId",
                       column: x => x.CategoryId,
                       principalTable: "Categories",
                       principalColumn: "CategoryId",
                       onDelete: ReferentialAction.Cascade);


                });

            migrationBuilder.CreateIndex(
                name: "IX_Postcategory_PostId",
                table: "Postcategory",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Demos");

            migrationBuilder.DropTable(
                name: "Postcategory");

            migrationBuilder.DropTable(
                name: "Subscriber");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
