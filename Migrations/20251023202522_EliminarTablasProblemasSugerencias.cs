using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkPoint.Migrations
{
    /// <inheritdoc />
    public partial class EliminarTablasProblemasSugerencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observaciones_Problemas_ProblemaId",
                table: "Observaciones");

            migrationBuilder.DropTable(
                name: "Sugerencias");

            migrationBuilder.DropTable(
                name: "Problemas");

            migrationBuilder.DropIndex(
                name: "IX_Observaciones_ProblemaId",
                table: "Observaciones");

            migrationBuilder.DropColumn(
                name: "ProblemaId",
                table: "Observaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProblemaId",
                table: "Observaciones",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Problemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sugerencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProblemaId = table.Column<int>(type: "integer", nullable: false),
                    Codigo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugerencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sugerencias_Problemas_ProblemaId",
                        column: x => x.ProblemaId,
                        principalTable: "Problemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_ProblemaId",
                table: "Observaciones",
                column: "ProblemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sugerencias_ProblemaId",
                table: "Sugerencias",
                column: "ProblemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observaciones_Problemas_ProblemaId",
                table: "Observaciones",
                column: "ProblemaId",
                principalTable: "Problemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
