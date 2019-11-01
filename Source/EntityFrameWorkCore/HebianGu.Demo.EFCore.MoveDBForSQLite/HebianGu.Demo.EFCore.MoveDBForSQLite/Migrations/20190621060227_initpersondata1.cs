using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HebianGu.Demo.EFCore.MoveDBForSQLite.Migrations
{
    public partial class initpersondata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bhb_log_biochemical",
                columns: table => new
                {
                    biochemical_id = table.Column<string>(nullable: false),
                    hb = table.Column<string>(nullable: true),
                    wbc = table.Column<string>(nullable: true),
                    plt = table.Column<string>(nullable: true),
                    fpg = table.Column<string>(nullable: true),
                    glu = table.Column<string>(nullable: true),
                    uma = table.Column<string>(nullable: true),
                    ghb = table.Column<string>(nullable: true),
                    alt = table.Column<string>(nullable: true),
                    ast = table.Column<string>(nullable: true),
                    alb = table.Column<string>(nullable: true),
                    tbil = table.Column<string>(nullable: true),
                    sdb = table.Column<string>(nullable: true),
                    scr = table.Column<string>(nullable: true),
                    bun = table.Column<string>(nullable: true),
                    k = table.Column<string>(nullable: true),
                    na = table.Column<string>(nullable: true),
                    tc = table.Column<string>(nullable: true),
                    tg = table.Column<string>(nullable: true),
                    ldlc = table.Column<string>(nullable: true),
                    hdlc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bhb_log_biochemical", x => x.biochemical_id);
                });

            migrationBuilder.CreateTable(
                name: "bhb_log_operate",
                columns: table => new
                {
                    operate_id = table.Column<string>(nullable: false),
                    operate_date = table.Column<DateTime>(nullable: false),
                    operate_account = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    biochemical_count = table.Column<int>(nullable: false),
                    operate_result = table.Column<bool>(nullable: false),
                    failure_cause = table.Column<string>(nullable: true),
                    person_id = table.Column<string>(nullable: true),
                    biochemical_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bhb_log_operate", x => x.operate_id);
                });

            migrationBuilder.CreateTable(
                name: "bhb_log_person",
                columns: table => new
                {
                    person_id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    sex = table.Column<byte>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    tel = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    region_code = table.Column<string>(nullable: true),
                    card_id = table.Column<string>(nullable: true),
                    health_form_date = table.Column<DateTime>(nullable: false),
                    health_form_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bhb_log_person", x => x.person_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bhb_log_biochemical");

            migrationBuilder.DropTable(
                name: "bhb_log_operate");

            migrationBuilder.DropTable(
                name: "bhb_log_person");
        }
    }
}
