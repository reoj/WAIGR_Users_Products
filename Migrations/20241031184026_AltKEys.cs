using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAIGR_Users_Products.Migrations
{
    /// <inheritdoc />
    public partial class AltKEys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Nombre",
                table: "Users",
                column: "Nombre");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Productos_SKU",
                table: "Productos",
                column: "SKU");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Nombre",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Productos_SKU",
                table: "Productos");
        }
    }
}
