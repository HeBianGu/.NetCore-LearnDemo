using Microsoft.EntityFrameworkCore.Migrations;

namespace HebianGu.Demo.EFCore.MoveDBForMySql.Migrations
{
    public partial class changecount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Citys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Citys");
        }
    }
}
