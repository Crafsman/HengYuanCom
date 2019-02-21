using Microsoft.EntityFrameworkCore.Migrations;

namespace HengYuan.Migrations
{
    public partial class changeVisiteName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitTime",
                table: "Visitors",
                newName: "RecentVisitTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecentVisitTime",
                table: "Visitors",
                newName: "VisitTime");
        }
    }
}
