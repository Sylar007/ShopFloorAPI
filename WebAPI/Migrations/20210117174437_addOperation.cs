using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class addOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Schedule_Id",
                table: "Operations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "OperationDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "OperationDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schedule_Id",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "OperationDetails");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "OperationDetails");
        }
    }
}
