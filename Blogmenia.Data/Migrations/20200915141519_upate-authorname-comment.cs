using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogmenia.Data.Migrations
{
    public partial class upateauthornamecomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Comments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
