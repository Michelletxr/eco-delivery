using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoDeliveryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contribuintes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuintes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensageiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensageiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contribuicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<double>(type: "float", nullable: false),
                    TipoPagamentoId = table.Column<int>(type: "int", nullable: false),
                    ContribuinteId = table.Column<int>(type: "int", nullable: false),
                    Data_Prevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Recebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contribuicao_Contribuintes_ContribuinteId",
                        column: x => x.ContribuinteId,
                        principalTable: "Contribuintes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contribuicao_TipoPagamentos_TipoPagamentoId",
                        column: x => x.TipoPagamentoId,
                        principalTable: "TipoPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentosDiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Movimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MensageiroId = table.Column<int>(type: "int", nullable: false),
                    ContribuicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentosDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentosDiarios_Contribuicao_ContribuicaoId",
                        column: x => x.ContribuicaoId,
                        principalTable: "Contribuicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentosDiarios_Mensageiros_MensageiroId",
                        column: x => x.MensageiroId,
                        principalTable: "Mensageiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_ContribuinteId",
                table: "Contribuicao",
                column: "ContribuinteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_TipoPagamentoId",
                table: "Contribuicao",
                column: "TipoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentosDiarios_ContribuicaoId",
                table: "MovimentosDiarios",
                column: "ContribuicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentosDiarios_MensageiroId",
                table: "MovimentosDiarios",
                column: "MensageiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentosDiarios");

            migrationBuilder.DropTable(
                name: "Contribuicao");

            migrationBuilder.DropTable(
                name: "Mensageiros");

            migrationBuilder.DropTable(
                name: "Contribuintes");

            migrationBuilder.DropTable(
                name: "TipoPagamentos");
        }
    }
}
