using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinariaWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class agregarurlimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagen",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagen",
                table: "Mascotas");
        }
    }
}
