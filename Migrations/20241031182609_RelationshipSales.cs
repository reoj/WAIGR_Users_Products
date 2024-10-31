using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAIGR_Users_Products.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioIdUsuario",
                table: "Ventas",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioIdUsuario",
                table: "Ventas",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Users_UsuarioIdUsuario",
                table: "Ventas",
                column: "UsuarioIdUsuario",
                principalTable: "Users",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Users_UsuarioIdUsuario",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_UsuarioIdUsuario",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Ventas");
        }
    }
}
