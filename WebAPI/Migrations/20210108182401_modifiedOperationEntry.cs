using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class modifiedOperationEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mould_Id",
                table: "Operator_Entries");

            migrationBuilder.AddColumn<int>(
                name: "Schedule_Job_Id",
                table: "Operator_Entries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schedule_Job_Id",
                table: "Operator_Entries");

            migrationBuilder.AddColumn<int>(
                name: "Mould_Id",
                table: "Operator_Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
