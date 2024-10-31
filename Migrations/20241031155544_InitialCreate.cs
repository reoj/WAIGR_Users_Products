using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAIGR_Users_Products.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IDproducto = table.Column<Guid>(type: "TEXT", nullable: false),
                    SKU = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false),
                    PrecioVenta = table.Column<float>(type: "REAL", nullable: false),
                    ClaveSAT = table.Column<string>(type: "TEXT", nullable: false),
                    ClaveKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IDproducto);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "TEXT", nullable: false),
                    Usuario = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IDVenta = table.Column<Guid>(type: "TEXT", nullable: false),
                    IDUsuario = table.Column<Guid>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subtotal = table.Column<float>(type: "REAL", nullable: false),
                    IVA = table.Column<float>(type: "REAL", nullable: false),
                    Total = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IDVenta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
