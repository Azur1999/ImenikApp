using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImenikApp.Migrations
{
    /// <inheritdoc />
    public partial class entityUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Drzava_DrzavaId",
                table: "Osobe");

            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Grad_GradId",
                table: "Osobe");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "Osobe",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Osobe",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Drzava_DrzavaId",
                table: "Osobe",
                column: "DrzavaId",
                principalTable: "Drzava",
                principalColumn: "DrzavaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Grad_GradId",
                table: "Osobe",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "GradId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Drzava_DrzavaId",
                table: "Osobe");

            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Grad_GradId",
                table: "Osobe");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "Osobe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Osobe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Drzava_DrzavaId",
                table: "Osobe",
                column: "DrzavaId",
                principalTable: "Drzava",
                principalColumn: "DrzavaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Grad_GradId",
                table: "Osobe",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "GradId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
