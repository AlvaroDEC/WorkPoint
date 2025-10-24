using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPoint.Migrations
{
    /// <inheritdoc />
    public partial class QuitarNivelYColorDeCriterio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CriteriosDeGravedad");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "CriteriosDeGravedad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CriteriosDeGravedad",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "CriteriosDeGravedad",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
