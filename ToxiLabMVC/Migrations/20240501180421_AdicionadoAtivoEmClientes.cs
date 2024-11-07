using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToxicLabMVC.Migrations
{
    public partial class AdicionadoAtivoEmClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "clientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "clientes");
        }
    }
}
