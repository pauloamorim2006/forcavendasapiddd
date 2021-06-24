using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesForce.Data.Migrations
{
    public partial class UpdateCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Cidades_CidadeId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "Clientes",
                newName: "Endereco_CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_CidadeId",
                table: "Clientes",
                newName: "IX_Clientes_Endereco_CidadeId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Clientes",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Clientes",
                type: "varchar(20)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Endereco_CidadeId",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cep",
                table: "Clientes",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Clientes",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Cidades_Endereco_CidadeId",
                table: "Clientes",
                column: "Endereco_CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Cidades_Endereco_CidadeId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco_Cep",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Endereco_CidadeId",
                table: "Clientes",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_Endereco_CidadeId",
                table: "Clientes",
                newName: "IX_Clientes_CidadeId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Clientes",
                type: "varchar(100)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Clientes",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CidadeId",
                table: "Clientes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Clientes",
                type: "varchar(100)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                type: "varchar(100)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Cidades_CidadeId",
                table: "Clientes",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
