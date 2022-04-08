using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMentoria.Data.Migrations
{
    public partial class AddCC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celulares",
                columns: table => new
                {
                    CelularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dercicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemCameraFrontal = table.Column<bool>(type: "bit", nullable: false),
                    SistemaOperaciona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapaciadadeMemoriaRam = table.Column<int>(type: "int", nullable: false),
                    CapaciadadeAramazenamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celulares", x => x.CelularId);
                });

            migrationBuilder.CreateTable(
                name: "Computadores",
                columns: table => new
                {
                    ComputadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLacamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemPlacaDeVideo = table.Column<bool>(type: "bit", nullable: false),
                    VersaoProcessador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadeMemoriaRam = table.Column<int>(type: "int", nullable: false),
                    CapacidadeHDEmGb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computadores", x => x.ComputadorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Celulares");

            migrationBuilder.DropTable(
                name: "Computadores");
        }
    }
}
