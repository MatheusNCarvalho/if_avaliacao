using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFAVALIACAO.API.Migrations
{
    public partial class create_table_Vaca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaca",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    NomePai = table.Column<string>(nullable: true),
                    NumeroPai = table.Column<int>(nullable: true),
                    VacaMaeId = table.Column<Guid>(nullable: true),
                    Raca = table.Column<string>(nullable: true),
                    GrauSanguinio = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    OrdemParto = table.Column<int>(nullable: true),
                    Ipp = table.Column<int>(nullable: true),
                    FazendaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaca_Fazenda_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "Fazenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaca_Vaca_VacaMaeId",
                        column: x => x.VacaMaeId,
                        principalTable: "Vaca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaca_FazendaId",
                table: "Vaca",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaca_VacaMaeId",
                table: "Vaca",
                column: "VacaMaeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaca");
        }
    }
}
