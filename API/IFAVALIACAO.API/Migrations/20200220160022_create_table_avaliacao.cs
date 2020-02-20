using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFAVALIACAO.API.Migrations
{
    public partial class create_table_avaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    DataHoraInicio = table.Column<DateTime>(nullable: false),
                    DataHoraFim = table.Column<DateTime>(nullable: false),
                    NameCow = table.Column<int>(nullable: false),
                    BodyWight = table.Column<decimal>(nullable: false),
                    Angulosiodade = table.Column<int>(nullable: false),
                    ProfundidadeCorporal = table.Column<int>(nullable: false),
                    ForcaLeiteira = table.Column<int>(nullable: false),
                    AlturaGarupaHipometro = table.Column<int>(nullable: false),
                    ComprimentoCorpo = table.Column<int>(nullable: false),
                    AnguloCarupa = table.Column<int>(nullable: false),
                    LarguraIleo = table.Column<int>(nullable: false),
                    LarguraIsquio = table.Column<int>(nullable: false),
                    AnguloCasco = table.Column<int>(nullable: false),
                    JarreteLateral = table.Column<int>(nullable: false),
                    JarreteTras = table.Column<int>(nullable: false),
                    UbereFirmeza = table.Column<int>(nullable: false),
                    UberePosterior = table.Column<int>(nullable: false),
                    AlturaUbere = table.Column<int>(nullable: false),
                    LigamentoCentral = table.Column<int>(nullable: false),
                    PosicaoTetos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");
        }
    }
}
