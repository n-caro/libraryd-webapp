using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSoft.Libraryd.AcessData.Migrations
{
    public partial class libraryddbv3 : Migration
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
                    table.UniqueConstraint("AK_Clientes_DNI_Email", x => new { x.DNI, x.Email });
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
                    table.ForeignKey(
                        name: "FK_Alquileres_Libros_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Libros",
                        principalColumn: "ISBN",
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
                    { "9783642191756", "Ian Gorton", "Second Edition", "Springer", "https://i.imgur.com/wVXlZzF.jpg", 5, "Essential Software Architecture" },
                    { "9786073206037", "Ian Sommerville", "Novena Edicion", "Addison-Wesley", "https://i.imgur.com/XwTsnyv.jpg", 4, "Ingenieria de Software" },
                    { "9780136073734", "William Stallings", "Septima Edicion", "Pearsons", "https://i.imgur.com/eFiruFW.jpg", 8, "Organización y Arquitectura de Computadores" },
                    { "9788497644907", "Homero", "2005", "Edimat Libros", "https://i.imgur.com/PsK9lpi.jpg", 10, "La iliada" },
                    { "9780132350884", "Robert C. Martin", "1 ed.", "Prentice Hall", "https://i.imgur.com/XyEK93p.jpg", 1, "Clean Code" },
                    { "9788445000663", "J. R. R. Tolkien", "1", "Booket", "https://i.imgur.com/FMxBdpD.jpg", 0, "El Señor de los Anillos I" },
                    { "9786070712739", "J. R. R. Tolkien", "2012", "Booket", "https://i.imgur.com/0813LgS.jpg", 2, "El Señor de los Anillos II" },
                    { "9786070712746", "J. R. R. Tolkien", "Reprint edición", "Planeta", "https://i.imgur.com/Bxs4Ia5.jpg", 3, "El Señor de los Anillos III" },
                    { "9788497598637", "Eduard Estivill", "2003", "DEBOLSILLO", "https://i.imgur.com/7EWiKz2.jpg", 15, "NECESITO DORMIR!" },
                    { "9780525566267", "Stephen King", "Edición Media tie-in", "Vintage Espanol", "https://i.imgur.com/Sq51uG6.jpg", 6, "It (Eso)" },
                    { "9780764508141", "Davis, Stephen R", "2001", "Hungry Minds Inc", "https://i.imgur.com/6BKObap.jpg", 2, "C# for Dummies" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Cliente",
                table: "Alquileres",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Estado",
                table: "Alquileres",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ISBN",
                table: "Alquileres",
                column: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
