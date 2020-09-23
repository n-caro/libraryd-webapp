using Microsoft.EntityFrameworkCore.Migrations;

namespace PSoft.Libraryd.AcessData.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[] { 1, "Reservado" });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[] { 2, "Alquilado" });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[] { 3, "Cancelado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstadoDeAlquileres",
                keyColumn: "EstadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstadoDeAlquileres",
                keyColumn: "EstadoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstadoDeAlquileres",
                keyColumn: "EstadoId",
                keyValue: 3);
        }
    }
}
