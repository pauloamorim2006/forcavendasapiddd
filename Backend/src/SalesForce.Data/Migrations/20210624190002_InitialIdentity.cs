using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesForce.Data.Migrations
{
    public partial class InitialIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Cidades_CidadeId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "Empresas",
                newName: "Endereco_CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Empresas_CidadeId",
                table: "Empresas",
                newName: "IX_Empresas_Endereco_CidadeId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Empresas",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Empresas",
                type: "varchar(20)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Empresas",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<Guid>(
                name: "Endereco_CidadeId",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Empresas",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Cidades_Endereco_CidadeId",
                table: "Empresas",
                column: "Endereco_CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Cidades_Endereco_CidadeId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "Endereco_CidadeId",
                table: "Empresas",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Empresas_Endereco_CidadeId",
                table: "Empresas",
                newName: "IX_Empresas_CidadeId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Empresas",
                type: "varchar(100)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Empresas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Empresas",
                type: "varchar(100)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CidadeId",
                table: "Empresas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Empresas",
                type: "varchar(100)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Cidades_CidadeId",
                table: "Empresas",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
