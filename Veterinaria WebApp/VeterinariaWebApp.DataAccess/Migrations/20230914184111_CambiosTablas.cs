using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinariaWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CambiosTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especie",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Mascotas");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Especie",
                table: "Servicios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Mascotas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
