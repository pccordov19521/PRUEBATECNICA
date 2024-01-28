using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIREST.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    personaid = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteid);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    cuentaid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numerocuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipocuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saldoinicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    clienteid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.cuentaid);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    movimientosid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipomovimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuentaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.movimientosid);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cuenta_cuentaid",
                        column: x => x.cuentaid,
                        principalTable: "Cuenta",
                        principalColumn: "cuentaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_clienteid",
                table: "Cuenta",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_cuentaid",
                table: "Movimientos",
                column: "cuentaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
