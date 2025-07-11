using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class altereiprodutopraeleserviremvariasmarcasemodelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeloVeiculos_MarcaVeiculos_MarcaId",
                table: "ModeloVeiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_MarcaVeiculos_MarcaVeiculoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ModeloVeiculos_ModeloVeiculoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_MarcaVeiculoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ModeloVeiculoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "MarcaVeiculoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ModeloVeiculoId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "MarcaId",
                table: "ModeloVeiculos",
                newName: "MarcaVeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloVeiculos_MarcaId",
                table: "ModeloVeiculos",
                newName: "IX_ModeloVeiculos_MarcaVeiculoId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "ModeloVeiculos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "MarcaVeiculos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloVeiculos_ProdutoId",
                table: "ModeloVeiculos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaVeiculos_ProdutoId",
                table: "MarcaVeiculos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarcaVeiculos_Produtos_ProdutoId",
                table: "MarcaVeiculos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloVeiculos_MarcaVeiculos_MarcaVeiculoId",
                table: "ModeloVeiculos",
                column: "MarcaVeiculoId",
                principalTable: "MarcaVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloVeiculos_Produtos_ProdutoId",
                table: "ModeloVeiculos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarcaVeiculos_Produtos_ProdutoId",
                table: "MarcaVeiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloVeiculos_MarcaVeiculos_MarcaVeiculoId",
                table: "ModeloVeiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloVeiculos_Produtos_ProdutoId",
                table: "ModeloVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_ModeloVeiculos_ProdutoId",
                table: "ModeloVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_MarcaVeiculos_ProdutoId",
                table: "MarcaVeiculos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ModeloVeiculos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "MarcaVeiculos");

            migrationBuilder.RenameColumn(
                name: "MarcaVeiculoId",
                table: "ModeloVeiculos",
                newName: "MarcaId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloVeiculos_MarcaVeiculoId",
                table: "ModeloVeiculos",
                newName: "IX_ModeloVeiculos_MarcaId");

            migrationBuilder.AddColumn<Guid>(
                name: "MarcaVeiculoId",
                table: "Produtos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ModeloVeiculoId",
                table: "Produtos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaVeiculoId",
                table: "Produtos",
                column: "MarcaVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ModeloVeiculoId",
                table: "Produtos",
                column: "ModeloVeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloVeiculos_MarcaVeiculos_MarcaId",
                table: "ModeloVeiculos",
                column: "MarcaId",
                principalTable: "MarcaVeiculos",
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
        }
    }
}
