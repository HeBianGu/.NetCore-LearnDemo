using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HebianGu.Demo.EFCore.MoveDBForMySql.Migrations
{
    public partial class changehasdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "CDate", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "成都" });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "CDate", "Name" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "北京" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
