using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicsBackend.Data.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steve Ditko" },
                    { 2, "Jack Kirby" },
                    { 3, "Bob Kane" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Marvel Comics" },
                    { 2, "DC Comics" },
                    { 3, "Dark Horse Comics" }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Stan Lee" },
                    { 2, "Neil Gaiman" },
                    { 3, "Dan Slott" }
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "ArtistId", "CoverArtistId", "Description", "Image", "PublisherId", "Title", "WriterId" },
                values: new object[] { 1, 2, 2, "Bla Bla Bla", "Cover.jpg", 1, "Spider-man #1", 1 });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "ArtistId", "CoverArtistId", "Description", "Image", "PublisherId", "Title", "WriterId" },
                values: new object[] { 2, 3, 3, "Bla Bla Bla", "Cover.jpg", 2, "Santman #1", 2 });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "ArtistId", "CoverArtistId", "Description", "Image", "PublisherId", "Title", "WriterId" },
                values: new object[] { 3, 1, 3, "Bla Bla Bla", "Cover.jpg", 3, "Walking Dead #1", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
