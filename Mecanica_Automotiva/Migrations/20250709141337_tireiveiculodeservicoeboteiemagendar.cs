using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecanica_Automotiva.Migrations
{
    /// <inheritdoc />
    public partial class tireiveiculodeservicoeboteiemagendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Veiculos_VeiculoId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_VeiculoId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Servicos");

            migrationBuilder.AddColumn<Guid>(
                name: "VeiculoId",
                table: "Agendamentos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_VeiculoId",
                table: "Agendamentos",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Veiculos_VeiculoId",
                table: "Agendamentos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Veiculos_VeiculoId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_VeiculoId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Agendamentos");

            migrationBuilder.AddColumn<Guid>(
                name: "VeiculoId",
                table: "Servicos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_VeiculoId",
                table: "Servicos",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Veiculos_VeiculoId",
                table: "Servicos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
