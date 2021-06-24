using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesForce.Data.Migrations
{
    public partial class UpdateCliente2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Cep",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Clientes",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cep",
                table: "Clientes",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
