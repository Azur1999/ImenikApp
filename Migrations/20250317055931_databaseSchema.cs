using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ImenikApp.Migrations
{
    /// <inheritdoc />
    public partial class databaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DrzavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pol = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradId = table.Column<int>(type: "int", nullable: false),
                    DrzavaId = table.Column<int>(type: "int", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osobe_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Osobe_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Hrvatska" },
                    { 3, "Srbija" },
                    { 4, "Spanija" },
                    { 5, "Njemacka" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "Id", "DrzavaId", "Naziv" },
                values: new object[,]
                {
                    { 1, 1, "Sarajevo" },
                    { 2, 1, "Tuzla" },
                    { 3, 1, "Banja Luka" },
                    { 4, 1, "Mostar" },
                    { 5, 1, "Sarajevo" },
                    { 6, 2, "Zagreb" },
                    { 7, 2, "Split" },
                    { 8, 2, "Rijeka" },
                    { 9, 3, "Beograd" },
                    { 10, 3, "Nis" },
                    { 11, 3, "Novi Sad" },
                    { 12, 4, "Madrid" },
                    { 13, 4, "Barcelona" },
                    { 14, 5, "Minhen" },
                    { 15, 5, "Berlin" },
                    { 16, 5, "Frankfurt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaId",
                table: "Grad",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_DrzavaId",
                table: "Osobe",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_GradId",
                table: "Osobe",
                column: "GradId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
