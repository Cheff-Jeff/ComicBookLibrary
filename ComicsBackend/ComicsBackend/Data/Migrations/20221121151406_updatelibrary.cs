using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicsBackend.Data.Migrations
{
    public partial class updatelibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libraries_Comics_comicId",
                table: "libraries");

            migrationBuilder.RenameColumn(
                name: "comicId",
                table: "libraries",
                newName: "ComicId");

            migrationBuilder.RenameIndex(
                name: "IX_libraries_comicId",
                table: "libraries",
                newName: "IX_libraries_ComicId");

            migrationBuilder.AddForeignKey(
                name: "FK_libraries_Comics_ComicId",
                table: "libraries",
                column: "ComicId",
                principalTable: "Comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libraries_Comics_ComicId",
                table: "libraries");

            migrationBuilder.RenameColumn(
                name: "ComicId",
                table: "libraries",
                newName: "comicId");

            migrationBuilder.RenameIndex(
                name: "IX_libraries_ComicId",
                table: "libraries",
                newName: "IX_libraries_comicId");

            migrationBuilder.AddForeignKey(
                name: "FK_libraries_Comics_comicId",
                table: "libraries",
                column: "comicId",
                principalTable: "Comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
