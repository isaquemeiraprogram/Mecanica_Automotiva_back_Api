using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class altereiprodutopraservicomuitospramuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Servicos_ServicoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ServicoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "ProdutoServico",
                columns: table => new
                {
                    ProdutosId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServicoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoServico", x => new { x.ProdutosId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_ProdutoServico_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoServico_ServicoId",
                table: "ProdutoServico",
                column: "ServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoServico");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicoId",
                table: "Produtos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ServicoId",
                table: "Produtos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Servicos_ServicoId",
                table: "Produtos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
