using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class tireicategoriaveiculodeagendaservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaVeiculo",
                table: "Veiculos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaVeiculo",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
