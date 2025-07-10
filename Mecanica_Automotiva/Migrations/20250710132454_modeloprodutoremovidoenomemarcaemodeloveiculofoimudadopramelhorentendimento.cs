using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class modeloprodutoremovidoenomemarcaemodeloveiculofoimudadopramelhorentendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_MarcaId",
                table: "Modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_MarcaProduto_MarcaProdutoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Marcas_MarcaVeiculoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ModeloProduto_ModeloProdutoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Modelos_ModeloVeiculoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Marcas_MarcaId",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Modelos_ModeloId",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "ModeloProduto");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ModeloProdutoId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modelos",
                table: "Modelos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarcaProduto",
                table: "MarcaProduto");

            migrationBuilder.DropColumn(
                name: "ModeloProdutoId",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Modelos",
                newName: "ModeloVeiculos");

            migrationBuilder.RenameTable(
                name: "Marcas",
                newName: "MarcaVeiculos");

            migrationBuilder.RenameTable(
                name: "MarcaProduto",
                newName: "MarcaProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_MarcaId",
                table: "ModeloVeiculos",
                newName: "IX_ModeloVeiculos_MarcaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloVeiculos",
                table: "ModeloVeiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarcaVeiculos",
                table: "MarcaVeiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarcaProdutos",
                table: "MarcaProdutos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloVeiculos_MarcaVeiculos_MarcaId",
                table: "ModeloVeiculos",
                column: "MarcaId",
                principalTable: "MarcaVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_MarcaProdutos_MarcaProdutoId",
                table: "Produtos",
                column: "MarcaProdutoId",
                principalTable: "MarcaProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_MarcaVeiculos_MarcaVeiculoId",
                table: "Produtos",
                column: "MarcaVeiculoId",
                principalTable: "MarcaVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ModeloVeiculos_ModeloVeiculoId",
                table: "Produtos",
                column: "ModeloVeiculoId",
                principalTable: "ModeloVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_MarcaVeiculos_MarcaId",
                table: "Veiculos",
                column: "MarcaId",
                principalTable: "MarcaVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_ModeloVeiculos_ModeloId",
                table: "Veiculos",
                column: "ModeloId",
                principalTable: "ModeloVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeloVeiculos_MarcaVeiculos_MarcaId",
                table: "ModeloVeiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_MarcaProdutos_MarcaProdutoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_MarcaVeiculos_MarcaVeiculoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ModeloVeiculos_ModeloVeiculoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_MarcaVeiculos_MarcaId",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_ModeloVeiculos_ModeloId",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloVeiculos",
                table: "ModeloVeiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarcaVeiculos",
                table: "MarcaVeiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarcaProdutos",
                table: "MarcaProdutos");

            migrationBuilder.RenameTable(
                name: "ModeloVeiculos",
                newName: "Modelos");

            migrationBuilder.RenameTable(
                name: "MarcaVeiculos",
                newName: "Marcas");

            migrationBuilder.RenameTable(
                name: "MarcaProdutos",
                newName: "MarcaProduto");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloVeiculos_MarcaId",
                table: "Modelos",
                newName: "IX_Modelos_MarcaId");

            migrationBuilder.AddColumn<Guid>(
                name: "ModeloProdutoId",
                table: "Produtos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modelos",
                table: "Modelos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarcaProduto",
                table: "MarcaProduto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ModeloProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarcaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloProduto_MarcaProduto_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "MarcaProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ModeloProdutoId",
                table: "Produtos",
                column: "ModeloProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloProduto_MarcaId",
                table: "ModeloProduto",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_MarcaId",
                table: "Modelos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_MarcaProduto_MarcaProdutoId",
                table: "Produtos",
                column: "MarcaProdutoId",
                principalTable: "MarcaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Marcas_MarcaVeiculoId",
                table: "Produtos",
                column: "MarcaVeiculoId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ModeloProduto_ModeloProdutoId",
                table: "Produtos",
                column: "ModeloProdutoId",
                principalTable: "ModeloProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Modelos_ModeloVeiculoId",
                table: "Produtos",
                column: "ModeloVeiculoId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Marcas_MarcaId",
                table: "Veiculos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Modelos_ModeloId",
                table: "Veiculos",
                column: "ModeloId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
