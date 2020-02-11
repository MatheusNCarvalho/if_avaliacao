using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFAVALIACAO.API.Migrations
{
    public partial class alter_table_User_modify_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "User",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "User",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
