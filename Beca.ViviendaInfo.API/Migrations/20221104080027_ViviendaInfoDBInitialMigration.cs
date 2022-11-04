using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.ViviendaInfo.API.Migrations
{
    public partial class ViviendaInfoDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viviendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Propietario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viviendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameUsuario = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FechaInicio = table.Column<string>(type: "TEXT", nullable: true),
                    FechaFin = table.Column<string>(type: "TEXT", nullable: true),
                    ViviendaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Viviendas_ViviendaId",
                        column: x => x.ViviendaId,
                        principalTable: "Viviendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ViviendaId",
                table: "Reservas",
                column: "ViviendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Viviendas");
        }
    }
}
