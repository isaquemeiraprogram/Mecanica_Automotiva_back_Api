using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassePecas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassePecas", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rua = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoVeiculos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVeiculos", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubClassePecas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassePecaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClassePecas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubClassePecas_ClassePecas_ClassePecaID",
                        column: x => x.ClassePecaID,
                        principalTable: "ClassePecas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<int>(type: "int", nullable: false),
                    MarcaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TipoID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ModeloID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Marcas_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marcas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculos_Modelos_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "Modelos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculos_TipoVeiculos_TipoID",
                        column: x => x.TipoID,
                        principalTable: "TipoVeiculos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPeca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassePecaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubClassePecaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPeca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoPeca_ClassePecas_ClassePecaID",
                        column: x => x.ClassePecaID,
                        principalTable: "ClassePecas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoPeca_SubClassePecas_SubClassePecaID",
                        column: x => x.SubClassePecaID,
                        principalTable: "SubClassePecas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    ValorTotal = table.Column<double>(type: "double", nullable: false),
                    TempoDeServiço = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    Duracao = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    AgendarID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Agendamentos_AgendarID",
                        column: x => x.AgendarID,
                        principalTable: "Agendamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Img = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClassePecaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubClassePecaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServicoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pecas_ClassePecas_ClassePecaID",
                        column: x => x.ClassePecaID,
                        principalTable: "ClassePecas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pecas_SubClassePecas_SubClassePecaID",
                        column: x => x.SubClassePecaID,
                        principalTable: "SubClassePecas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_TipoPeca_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoPeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_ClassePecaID",
                table: "Pecas",
                column: "ClassePecaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_ServicoId",
                table: "Pecas",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_SubClassePecaID",
                table: "Pecas",
                column: "SubClassePecaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_TipoId",
                table: "Pecas",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_AgendarID",
                table: "Servicos",
                column: "AgendarID");

            migrationBuilder.CreateIndex(
                name: "IX_SubClassePecas_ClassePecaID",
                table: "SubClassePecas",
                column: "ClassePecaID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPeca_ClassePecaID",
                table: "TipoPeca",
                column: "ClassePecaID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPeca_SubClassePecaID",
                table: "TipoPeca",
                column: "SubClassePecaID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_MarcaID",
                table: "Veiculos",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ModeloID",
                table: "Veiculos",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TipoID",
                table: "Veiculos",
                column: "TipoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pecas");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "TipoPeca");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "TipoVeiculos");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "SubClassePecas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ClassePecas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
