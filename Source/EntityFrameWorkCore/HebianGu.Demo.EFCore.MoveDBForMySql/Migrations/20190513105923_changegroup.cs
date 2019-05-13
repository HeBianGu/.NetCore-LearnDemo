using Microsoft.EntityFrameworkCore.Migrations;

namespace HebianGu.Demo.EFCore.MoveDBForMySql.Migrations
{
    public partial class changegroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Citys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Citys");
        }
    }
}
