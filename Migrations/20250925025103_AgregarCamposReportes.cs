using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPoint.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposReportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "CriteriosDeGravedad",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Categorias",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categorias",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "CriteriosDeGravedad");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categorias");
        }
    }
}
