using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class trocapecaporproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pecas");

            migrationBuilder.DropTable(
                name: "ModeloPeca");

            migrationBuilder.DropTable(
                name: "SubCategoriasPecas");

            migrationBuilder.DropTable(
                name: "MarcaPeca");

            migrationBuilder.DropTable(
                name: "CategoriasPecas");

            migrationBuilder.CreateTable(
                name: "CategoriasProdutos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MarcaProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaProduto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubCategoriasProdutos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaProdutoID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoriasProdutos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategoriasProdutos_CategoriasProdutos_CategoriaProdutoID",
                        column: x => x.CategoriaProdutoID,
                        principalTable: "CategoriasProdutos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModeloProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarcaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
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

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Img = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubCategoriaProdutoID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarcaProdutoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ModeloProdutoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QtdEstoque = table.Column<int>(type: "int", nullable: false),
                    MarcaVeiculoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ModeloVeiculoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaVeiculo = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VeiculoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_MarcaProduto_MarcaProdutoId",
                        column: x => x.MarcaProdutoId,
                        principalTable: "MarcaProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Marcas_MarcaVeiculoId",
                        column: x => x.MarcaVeiculoId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_ModeloProduto_ModeloProdutoId",
                        column: x => x.ModeloProdutoId,
                        principalTable: "ModeloProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Modelos_ModeloVeiculoId",
                        column: x => x.ModeloVeiculoId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_SubCategoriasProdutos_SubCategoriaProdutoID",
                        column: x => x.SubCategoriaProdutoID,
                        principalTable: "SubCategoriasProdutos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloProduto_MarcaId",
                table: "ModeloProduto",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaProdutoId",
                table: "Produtos",
                column: "MarcaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaVeiculoId",
                table: "Produtos",
                column: "MarcaVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ModeloProdutoId",
                table: "Produtos",
                column: "ModeloProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ModeloVeiculoId",
                table: "Produtos",
                column: "ModeloVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ServicoId",
                table: "Produtos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_SubCategoriaProdutoID",
                table: "Produtos",
                column: "SubCategoriaProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_VeiculoId",
                table: "Produtos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoriasProdutos_CategoriaProdutoID",
                table: "SubCategoriasProdutos",
                column: "CategoriaProdutoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ModeloProduto");

            migrationBuilder.DropTable(
                name: "SubCategoriasProdutos");

            migrationBuilder.DropTable(
                name: "MarcaProduto");

            migrationBuilder.DropTable(
                name: "CategoriasProdutos");

            migrationBuilder.CreateTable(
                name: "CategoriasPecas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasPecas", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MarcaPeca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaPeca", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubCategoriasPecas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaPecaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoriasPecas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategoriasPecas_CategoriasPecas_CategoriaPecaID",
                        column: x => x.CategoriaPecaID,
                        principalTable: "CategoriasPecas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModeloPeca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarcaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloPeca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloPeca_MarcaPeca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "MarcaPeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarcaPecaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarcaVeiculoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ModeloPecaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ModeloVeiculoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServicoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubCategoriaPecaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaVeiculo = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QtdEstoque = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pecas_MarcaPeca_MarcaPecaId",
                        column: x => x.MarcaPecaId,
                        principalTable: "MarcaPeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_Marcas_MarcaVeiculoId",
                        column: x => x.MarcaVeiculoId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_ModeloPeca_ModeloPecaId",
                        column: x => x.ModeloPecaId,
                        principalTable: "ModeloPeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_Modelos_ModeloVeiculoId",
                        column: x => x.ModeloVeiculoId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_SubCategoriasPecas_SubCategoriaPecaID",
                        column: x => x.SubCategoriaPecaID,
                        principalTable: "SubCategoriasPecas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloPeca_MarcaId",
                table: "ModeloPeca",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_MarcaPecaId",
                table: "Pecas",
                column: "MarcaPecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_MarcaVeiculoId",
                table: "Pecas",
                column: "MarcaVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_ModeloPecaId",
                table: "Pecas",
                column: "ModeloPecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_ModeloVeiculoId",
                table: "Pecas",
                column: "ModeloVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_ServicoId",
                table: "Pecas",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_SubCategoriaPecaID",
                table: "Pecas",
                column: "SubCategoriaPecaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_VeiculoId",
                table: "Pecas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoriasPecas_CategoriaPecaID",
                table: "SubCategoriasPecas",
                column: "CategoriaPecaID");
        }
    }
}
