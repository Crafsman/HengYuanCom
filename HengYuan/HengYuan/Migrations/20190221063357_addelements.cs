using Microsoft.EntityFrameworkCore.Migrations;

namespace HengYuan.Migrations
{
    public partial class addelements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Visitors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Visitors",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Visitors",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longtitude",
                table: "Visitors",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "Visitors");
        }
    }
}
