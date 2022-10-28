using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEspaco.Data.Migrations
{
    public partial class RemoveSobrenome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Clientes",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");
        }
    }
}
