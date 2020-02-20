using Microsoft.EntityFrameworkCore.Migrations;

namespace IFAVALIACAO.API.Migrations
{
    public partial class alter_all_table_add_column_deletado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Fazenda",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Fazenda");
        }
    }
}
