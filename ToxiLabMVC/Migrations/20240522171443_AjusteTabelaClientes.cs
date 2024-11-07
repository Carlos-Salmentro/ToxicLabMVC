using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToxicLabMVC.Migrations
{
    public partial class AjusteTabelaClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rg",
                table: "clientes",
                newName: "numero_custodia");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_vencimento",
                table: "exames",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_realizado",
                table: "exames",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numero_custodia",
                table: "clientes",
                newName: "rg");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "data_vencimento",
                table: "exames",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "data_realizado",
                table: "exames",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
