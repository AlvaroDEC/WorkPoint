using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPoint.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionToArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaciones_Roles_RolId",
                table: "Asignaciones");

            migrationBuilder.DropIndex(
                name: "IX_Asignaciones_RolId",
                table: "Asignaciones");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Asignaciones");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Inspecciones",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Areas",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Areas",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Areas");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Inspecciones",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Asignaciones",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Areas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_RolId",
                table: "Asignaciones",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaciones_Roles_RolId",
                table: "Asignaciones",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
