using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicsBackend.Data.Migrations
{
    public partial class UpdateComicPopularity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Comics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Comics");
        }
    }
}
