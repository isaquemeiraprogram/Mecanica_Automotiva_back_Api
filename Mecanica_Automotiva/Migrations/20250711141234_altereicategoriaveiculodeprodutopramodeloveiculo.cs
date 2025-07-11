using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class altereicategoriaveiculodeprodutopramodeloveiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaVeiculo",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaVeiculo",
                table: "ModeloVeiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaVeiculo",
                table: "ModeloVeiculos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaVeiculo",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
