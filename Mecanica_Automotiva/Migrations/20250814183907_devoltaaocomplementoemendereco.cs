using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class devoltaaocomplementoemendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apto",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Bloco",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "CodigoAmigavel",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "OutroComplemento",
                table: "Enderecos",
                newName: "Complemento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Enderecos",
                newName: "OutroComplemento");

            migrationBuilder.AddColumn<string>(
                name: "Apto",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Bloco",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CodigoAmigavel",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
