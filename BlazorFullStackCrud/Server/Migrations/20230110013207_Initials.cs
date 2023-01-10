using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judul_Buku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penerbit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penulis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buku_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Horor" },
                    { 2, "Romance" },
                    { 3, "Komedi" },
                    { 4, "Fantasi" },
                    { 5, "Edukasi" }
                });

            migrationBuilder.InsertData(
                table: "Buku",
                columns: new[] { "Id", "GenreId", "Judul_Buku", "Penerbit", "Penulis" },
                values: new object[,]
                {
                    { 11, 1, "Dear Nathan", "Tere", "Tere Liye" },
                    { 12, 2, "Dilan 1991", "Pidi Baiq", "Pidi" },
                    { 16, 3, "Dibalik 98", "Ismail", "Ismail Marzuki" },
                    { 19, 4, "Kisah Tanah Jawa", "Ismail", "Ismail Marzuki" },
                    { 56, 5, "Dilannnn", "Ismail", "Ismail Marzuki" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buku_GenreId",
                table: "Buku",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buku");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
