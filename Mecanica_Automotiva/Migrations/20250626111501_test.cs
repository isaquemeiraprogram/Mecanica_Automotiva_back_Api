using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_CategoriaPeca_CategoriaPecaID",
                table: "Pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoriaPeca_CategoriaPeca_CategoriaPecaID",
                table: "SubCategoriaPeca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoriaPeca",
                table: "SubCategoriaPeca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaPeca",
                table: "CategoriaPeca");

            migrationBuilder.RenameTable(
                name: "SubCategoriaPeca",
                newName: "SubCategoriasPecas");

            migrationBuilder.RenameTable(
                name: "CategoriaPeca",
                newName: "CategoriasPecas");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoriaPeca_CategoriaPecaID",
                table: "SubCategoriasPecas",
                newName: "IX_SubCategoriasPecas_CategoriaPecaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoriasPecas",
                table: "SubCategoriasPecas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriasPecas",
                table: "CategoriasPecas",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_CategoriasPecas_CategoriaPecaID",
                table: "Pecas",
                column: "CategoriaPecaID",
                principalTable: "CategoriasPecas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoriasPecas_CategoriasPecas_CategoriaPecaID",
                table: "SubCategoriasPecas",
                column: "CategoriaPecaID",
                principalTable: "CategoriasPecas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_CategoriasPecas_CategoriaPecaID",
                table: "Pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoriasPecas_CategoriasPecas_CategoriaPecaID",
                table: "SubCategoriasPecas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoriasPecas",
                table: "SubCategoriasPecas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriasPecas",
                table: "CategoriasPecas");

            migrationBuilder.RenameTable(
                name: "SubCategoriasPecas",
                newName: "SubCategoriaPeca");

            migrationBuilder.RenameTable(
                name: "CategoriasPecas",
                newName: "CategoriaPeca");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoriasPecas_CategoriaPecaID",
                table: "SubCategoriaPeca",
                newName: "IX_SubCategoriaPeca_CategoriaPecaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoriaPeca",
                table: "SubCategoriaPeca",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaPeca",
                table: "CategoriaPeca",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_CategoriaPeca_CategoriaPecaID",
                table: "Pecas",
                column: "CategoriaPecaID",
                principalTable: "CategoriaPeca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoriaPeca_CategoriaPeca_CategoriaPecaID",
                table: "SubCategoriaPeca",
                column: "CategoriaPecaID",
                principalTable: "CategoriaPeca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
