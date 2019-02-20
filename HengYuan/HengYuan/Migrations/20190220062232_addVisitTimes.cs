using Microsoft.EntityFrameworkCore.Migrations;

namespace HengYuan.Migrations
{
    public partial class addVisitTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitTimes",
                table: "Visitors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitTimes",
                table: "Visitors");
        }
    }
}
