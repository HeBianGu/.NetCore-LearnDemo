using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HebianGu.Demo.EFCore.MoveDBForMySql.Migrations
{
    public partial class changecity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CDate",
                table: "Citys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CDate",
                table: "Citys");
        }
    }
}
