using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicsBackend.Data.Migrations
{
    public partial class neweditmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "HeroTeam",
                columns: table => new
                {
                    heroesId = table.Column<int>(type: "int", nullable: false),
                    teamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroTeam", x => new { x.heroesId, x.teamsId });
                    table.ForeignKey(
                        name: "FK_HeroTeam_Heroes_heroesId",
                        column: x => x.heroesId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroTeam_Teams_teamsId",
                        column: x => x.teamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroTeam_teamsId",
                table: "HeroTeam",
                column: "teamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroTeam");

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
    }
}
