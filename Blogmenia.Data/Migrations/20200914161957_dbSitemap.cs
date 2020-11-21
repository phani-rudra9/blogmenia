using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogmenia.Data.Migrations
{
    public partial class dbSitemap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tooltip",
                table: "Post");

            migrationBuilder.CreateTable(
                name: "Sitemaping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    URl = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitemaping", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sitemaping");

            migrationBuilder.AddColumn<string>(
                name: "tooltip",
                table: "Post",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
