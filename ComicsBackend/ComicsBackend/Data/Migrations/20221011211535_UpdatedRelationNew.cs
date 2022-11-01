using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicsBackend.Data.Migrations
{
    public partial class UpdatedRelationNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comics_Artists_ArtistId",
                table: "Comics");

            migrationBuilder.AddColumn<int>(
                name: "CoverArtistId",
                table: "Comics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comics_CoverArtistId",
                table: "Comics",
                column: "CoverArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comics_Artists_ArtistId",
                table: "Comics",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comics_Artists_CoverArtistId",
                table: "Comics",
                column: "CoverArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comics_Artists_ArtistId",
                table: "Comics");

            migrationBuilder.DropForeignKey(
                name: "FK_Comics_Artists_CoverArtistId",
                table: "Comics");

            migrationBuilder.DropIndex(
                name: "IX_Comics_CoverArtistId",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "CoverArtistId",
                table: "Comics");

            migrationBuilder.AddForeignKey(
                name: "FK_Comics_Artists_ArtistId",
                table: "Comics",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
