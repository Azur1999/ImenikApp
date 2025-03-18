using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImenikApp.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Osobe",
                newName: "OsobaId");

            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Grad",
                newName: "NazivGrad");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grad",
                newName: "GradId");

            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Drzava",
                newName: "NazivDrzava");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Drzava",
                newName: "DrzavaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OsobaId",
                table: "Osobe",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NazivGrad",
                table: "Grad",
                newName: "Naziv");

            migrationBuilder.RenameColumn(
                name: "GradId",
                table: "Grad",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NazivDrzava",
                table: "Drzava",
                newName: "Naziv");

            migrationBuilder.RenameColumn(
                name: "DrzavaId",
                table: "Drzava",
                newName: "Id");
        }
    }
}
