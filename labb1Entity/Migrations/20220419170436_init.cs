using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace labb1Entity.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationForLeaves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: false),
                    EployeePhone = table.Column<string>(nullable: false),
                    TypeOFLeave = table.Column<string>(nullable: false),
                    DateStartForLeave = table.Column<DateTime>(nullable: false),
                    DateEndForLeave = table.Column<DateTime>(nullable: false),
                    DateOfApplication = table.Column<string>(nullable: true),
                    TimeOfApplication = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForLeaves", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationForLeaves");
        }
    }
}
