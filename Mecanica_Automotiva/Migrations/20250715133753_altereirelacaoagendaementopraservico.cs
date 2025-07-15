using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class altereirelacaoagendaementopraservico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Agendamentos_AgendarId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_AgendarId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "AgendarId",
                table: "Servicos");

            migrationBuilder.CreateTable(
                name: "AgendaServico",
                columns: table => new
                {
                    AgendarId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServicosId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaServico", x => new { x.AgendarId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_AgendaServico_Agendamentos_AgendarId",
                        column: x => x.AgendarId,
                        principalTable: "Agendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaServico_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaServico_ServicosId",
                table: "AgendaServico",
                column: "ServicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaServico");

            migrationBuilder.AddColumn<Guid>(
                name: "AgendarId",
                table: "Servicos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_AgendarId",
                table: "Servicos",
                column: "AgendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Agendamentos_AgendarId",
                table: "Servicos",
                column: "AgendarId",
                principalTable: "Agendamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
