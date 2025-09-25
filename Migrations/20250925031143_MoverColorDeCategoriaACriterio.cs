using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPoint.Migrations
{
    /// <inheritdoc />
    public partial class MoverColorDeCategoriaACriterio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categorias");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CriteriosDeGravedad",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CriteriosDeGravedad");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categorias",
                type: "text",
                nullable: true);
        }
    }
}
