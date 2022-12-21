using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicsBackend.Data.Migrations
{
    public partial class editmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HeroId",
                table: "Teams",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Heroes_HeroId",
                table: "Teams",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Heroes_HeroId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_HeroId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Teams");
        }
    }
}
