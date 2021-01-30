using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class updateOperation_details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entry_Result",
                table: "Operator_Entry_Details");

            migrationBuilder.AddColumn<int>(
                name: "Comply",
                table: "Operator_Entry_Details",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Not_Comply",
                table: "Operator_Entry_Details",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comply",
                table: "Operator_Entry_Details");

            migrationBuilder.DropColumn(
                name: "Not_Comply",
                table: "Operator_Entry_Details");

            migrationBuilder.AddColumn<int>(
                name: "Entry_Result",
                table: "Operator_Entry_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
