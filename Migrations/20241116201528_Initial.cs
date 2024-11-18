using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenLight.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lampadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Apelido = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    NomeDispositivo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Modo = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lampadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lampadas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    LampadaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConsumoWh = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    DataConsumo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DiferencaMes = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Lampadas_LampadaId",
                        column: x => x.LampadaId,
                        principalTable: "Lampadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lampadas_UsuarioId",
                table: "Lampadas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_LampadaId",
                table: "Registros",
                column: "LampadaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Lampadas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
