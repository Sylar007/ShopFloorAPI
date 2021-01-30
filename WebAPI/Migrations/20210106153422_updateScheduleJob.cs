using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class updateScheduleJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Machine_Id",
                table: "Schedule_Jobs");

            migrationBuilder.DropColumn(
                name: "Part_Id",
                table: "Schedule_Jobs");

            migrationBuilder.AddColumn<int>(
                name: "PartSet_Id",
                table: "Schedule_Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Workstation_Id",
                table: "Schedule_Jobs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartSet_Id",
                table: "Schedule_Jobs");

            migrationBuilder.DropColumn(
                name: "Workstation_Id",
                table: "Schedule_Jobs");

            migrationBuilder.AddColumn<int>(
                name: "Machine_Id",
                table: "Schedule_Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Part_Id",
                table: "Schedule_Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
