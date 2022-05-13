using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMentoria.Data.Migrations
{
    public partial class TabelaUrlImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Clientes");
        }
    }
}
