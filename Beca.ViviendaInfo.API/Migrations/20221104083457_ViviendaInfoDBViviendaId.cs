using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.ViviendaInfo.API.Migrations
{
    public partial class ViviendaInfoDBViviendaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Viviendas_ViviendaId",
                table: "Reservas");

            migrationBuilder.AlterColumn<int>(
                name: "ViviendaId",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Viviendas",
                columns: new[] { "Id", "Description", "Direccion", "Name", "Propietario" },
                values: new object[] { 1, "Casa en las afueras muy grande", "Málaga, Marbella, Calle Lopez, n20", "Casa de Campo", "Luis Gómez" });

            migrationBuilder.InsertData(
                table: "Viviendas",
                columns: new[] { "Id", "Description", "Direccion", "Name", "Propietario" },
                values: new object[] { 2, "Piso en el centro de malaga para turistas", "Málaga, Málaga, Calle Granada, n30", "Piso en Ciudad", "José Pérez" });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "FechaFin", "FechaInicio", "NameUsuario", "ViviendaId" },
                values: new object[] { 1, "15-10-2022", "10-10-2022", "Juan Gonzalez", 1 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "FechaFin", "FechaInicio", "NameUsuario", "ViviendaId" },
                values: new object[] { 2, "15-10-2022", "10-10-2022", "Javi Ruiz", 2 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "FechaFin", "FechaInicio", "NameUsuario", "ViviendaId" },
                values: new object[] { 3, "27-11-2022", "20-11-2022", "Juan Gonzalez", 2 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "FechaFin", "FechaInicio", "NameUsuario", "ViviendaId" },
                values: new object[] { 4, "14-11-2022", "11-11-2022", "Alberto Muñoz", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Viviendas_ViviendaId",
                table: "Reservas",
                column: "ViviendaId",
                principalTable: "Viviendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Viviendas_ViviendaId",
                table: "Reservas");

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Viviendas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Viviendas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ViviendaId",
                table: "Reservas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Viviendas_ViviendaId",
                table: "Reservas",
                column: "ViviendaId",
                principalTable: "Viviendas",
                principalColumn: "Id");
        }
    }
}
