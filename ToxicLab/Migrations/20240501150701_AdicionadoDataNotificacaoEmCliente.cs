using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToxicLab.Migrations
{
    public partial class AdicionadoDataNotificacaoEmCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cliente_Id",
                table: "exames",
                newName: "cliente_id");

            migrationBuilder.AddColumn<DateOnly>(
                name: "data_notificacao",
                table: "clientes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_notificacao",
                table: "clientes");

            migrationBuilder.RenameColumn(
                name: "cliente_id",
                table: "exames",
                newName: "Cliente_Id");
        }
    }
}
