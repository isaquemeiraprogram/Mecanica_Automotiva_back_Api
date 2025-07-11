using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class autereiIDpraidemalgumasclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_SubCategoriasProdutos_SubCategoriaProdutoID",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Agendamentos_AgendarID",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoriasProdutos_CategoriasProdutos_CategoriaProdutoID",
                table: "SubCategoriasProdutos");

            migrationBuilder.RenameColumn(
                name: "CategoriaProdutoID",
                table: "SubCategoriasProdutos",
                newName: "CategoriaProdutoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SubCategoriasProdutos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoriasProdutos_CategoriaProdutoID",
                table: "SubCategoriasProdutos",
                newName: "IX_SubCategoriasProdutos_CategoriaProdutoId");

            migrationBuilder.RenameColumn(
                name: "AgendarID",
                table: "Servicos",
                newName: "AgendarId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_AgendarID",
                table: "Servicos",
                newName: "IX_Servicos_AgendarId");

            migrationBuilder.RenameColumn(
                name: "SubCategoriaProdutoID",
                table: "Produtos",
                newName: "SubCategoriaProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_SubCategoriaProdutoID",
                table: "Produtos",
                newName: "IX_Produtos_SubCategoriaProdutoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CategoriasProdutos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Agendamentos",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_SubCategoriasProdutos_SubCategoriaProdutoId",
                table: "Produtos",
                column: "SubCategoriaProdutoId",
                principalTable: "SubCategoriasProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Agendamentos_AgendarId",
                table: "Servicos",
                column: "AgendarId",
                principalTable: "Agendamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoriasProdutos_CategoriasProdutos_CategoriaProdutoId",
                table: "SubCategoriasProdutos",
                column: "CategoriaProdutoId",
                principalTable: "CategoriasProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_SubCategoriasProdutos_SubCategoriaProdutoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Agendamentos_AgendarId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoriasProdutos_CategoriasProdutos_CategoriaProdutoId",
                table: "SubCategoriasProdutos");

            migrationBuilder.RenameColumn(
                name: "CategoriaProdutoId",
                table: "SubCategoriasProdutos",
                newName: "CategoriaProdutoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubCategoriasProdutos",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoriasProdutos_CategoriaProdutoId",
                table: "SubCategoriasProdutos",
                newName: "IX_SubCategoriasProdutos_CategoriaProdutoID");

            migrationBuilder.RenameColumn(
                name: "AgendarId",
                table: "Servicos",
                newName: "AgendarID");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_AgendarId",
                table: "Servicos",
                newName: "IX_Servicos_AgendarID");

            migrationBuilder.RenameColumn(
                name: "SubCategoriaProdutoId",
                table: "Produtos",
                newName: "SubCategoriaProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_SubCategoriaProdutoId",
                table: "Produtos",
                newName: "IX_Produtos_SubCategoriaProdutoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CategoriasProdutos",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Agendamentos",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_SubCategoriasProdutos_SubCategoriaProdutoID",
                table: "Produtos",
                column: "SubCategoriaProdutoID",
                principalTable: "SubCategoriasProdutos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Agendamentos_AgendarID",
                table: "Servicos",
                column: "AgendarID",
                principalTable: "Agendamentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoriasProdutos_CategoriasProdutos_CategoriaProdutoID",
                table: "SubCategoriasProdutos",
                column: "CategoriaProdutoID",
                principalTable: "CategoriasProdutos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
