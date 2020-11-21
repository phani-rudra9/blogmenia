using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogmenia.Data.Migrations
{
    public partial class columntootlip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tooltip",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tooltip",
                table: "Post");
        }
    }
}
