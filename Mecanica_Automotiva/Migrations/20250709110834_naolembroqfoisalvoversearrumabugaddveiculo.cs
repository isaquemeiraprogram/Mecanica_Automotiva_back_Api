using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class naolembroqfoisalvoversearrumabugaddveiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Veiculos_VeiculoId",
                table: "Pecas");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeiculoId",
                table: "Pecas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaVeiculo",
                table: "Pecas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MarcaPecaId",
                table: "Pecas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "MarcaVeiculoId",
                table: "Pecas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ModeloPecaId",
                table: "Pecas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ModeloVeiculoId",
                table: "Pecas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "QtdEstoque",
                table: "Pecas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "ModeloPeca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarcaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
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
                name: "IX_ModeloPeca_MarcaId",
                table: "ModeloPeca",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_MarcaPeca_MarcaPecaId",
                table: "Pecas",
                column: "MarcaPecaId",
                principalTable: "MarcaPeca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Marcas_MarcaVeiculoId",
                table: "Pecas",
                column: "MarcaVeiculoId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_ModeloPeca_ModeloPecaId",
                table: "Pecas",
                column: "ModeloPecaId",
                principalTable: "ModeloPeca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Modelos_ModeloVeiculoId",
                table: "Pecas",
                column: "ModeloVeiculoId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Veiculos_VeiculoId",
                table: "Pecas",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_MarcaPeca_MarcaPecaId",
                table: "Pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Marcas_MarcaVeiculoId",
                table: "Pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_ModeloPeca_ModeloPecaId",
                table: "Pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Modelos_ModeloVeiculoId",
                table: "Pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Veiculos_VeiculoId",
                table: "Pecas");

            migrationBuilder.DropTable(
                name: "ModeloPeca");

            migrationBuilder.DropTable(
                name: "MarcaPeca");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_MarcaPecaId",
                table: "Pecas");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_MarcaVeiculoId",
                table: "Pecas");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_ModeloPecaId",
                table: "Pecas");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_ModeloVeiculoId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "CategoriaVeiculo",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "MarcaPecaId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "MarcaVeiculoId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "ModeloPecaId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "ModeloVeiculoId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "QtdEstoque",
                table: "Pecas");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeiculoId",
                table: "Pecas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Veiculos_VeiculoId",
                table: "Pecas",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
