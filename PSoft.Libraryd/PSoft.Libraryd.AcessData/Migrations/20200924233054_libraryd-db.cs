using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PSoft.Libraryd.AcessData.Migrations
{
    public partial class libraryddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 45, nullable: false),
                    Apellido = table.Column<string>(maxLength: 45, nullable: false),
                    Email = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeAlquileres",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeAlquileres", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(maxLength: 45, nullable: false),
                    Autor = table.Column<string>(maxLength: 45, nullable: false),
                    Editorial = table.Column<string>(maxLength: 45, nullable: false),
                    Edicion = table.Column<string>(maxLength: 45, nullable: false),
                    Stock = table.Column<int>(maxLength: 45, nullable: true),
                    Imagen = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    FechaAlquiler = table.Column<DateTime>(type: "Date", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "Date", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Clientes_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_EstadoDeAlquileres_Estado",
                        column: x => x.Estado,
                        principalTable: "EstadoDeAlquileres",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Alquilado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "9783642191756", "Ian Gorton", "Second Edition", "Springer", "", 5, "Essential Software Architecture" },
                    { "9780136073734", "William Stallings", "Septima Edicion", "Pearsons", "", 8, "Organización y Arquitectura de Computadores" },
                    { "9780764508141", "Davis, Stephen R", "2001", "Hungry Minds Inc", "", 2, "C# for Dummies" },
                    { "9789875809659", "Dross Rotzank", "2019", "BOOKET", "", 1, "Luna de Pluton" },
                    { "9788497598637", "Eduard Estivill", "2003", "DEBOLSILLO", "", 15, "NECESITO DORMIR!" },
                    { "9786073206037", "Ian Sommerville", "Novena Edicion", "Addison-Wesley", "", 3, "Ingenieria de Software" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Cliente",
                table: "Alquileres",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Estado",
                table: "Alquileres",
                column: "Estado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");
        }
    }
}
