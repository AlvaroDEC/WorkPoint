using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPoint.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoToArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Areas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Areas");
        }
    }
}
