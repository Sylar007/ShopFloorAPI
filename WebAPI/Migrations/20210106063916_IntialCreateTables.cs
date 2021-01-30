using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class IntialCreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mould_Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mould_Id = table.Column<int>(nullable: false),
                    Part_Id = table.Column<int>(nullable: false),
                    PartMould_Type_Id = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mould_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moulds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PartSet_Id = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moulds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operation_Id = table.Column<int>(nullable: false),
                    Assigned_User = table.Column<int>(nullable: false),
                    Flow = table.Column<int>(nullable: false),
                    Operation_Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartSet_Id = table.Column<int>(nullable: false),
                    WorkStation_Status = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operator_Entries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mould_Id = table.Column<int>(nullable: false),
                    Entry_Date = table.Column<DateTime>(nullable: true),
                    Entry_Status = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator_Entries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operator_Entry_Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operator_Entry_Id = table.Column<int>(nullable: false),
                    Part_Id = table.Column<int>(nullable: false),
                    Entry_Result = table.Column<int>(nullable: false),
                    Created_Date = table.Column<DateTime>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator_Entry_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartMould_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mould_Type = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartMould_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hil_Code = table.Column<string>(nullable: true),
                    Part_Name = table.Column<string>(nullable: true),
                    Part_No = table.Column<string>(nullable: true),
                    Customer_Id = table.Column<int>(nullable: false),
                    Material_Code = table.Column<string>(nullable: true),
                    Material_Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Back_Code = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartSet_Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartSet_Id = table.Column<int>(nullable: false),
                    Part_Id = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSet_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartSet_Code = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Production_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule_Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule_Type = table.Column<string>(nullable: true),
                    Machine_Id = table.Column<int>(nullable: false),
                    Shift_Type = table.Column<int>(nullable: false),
                    Part_Id = table.Column<int>(nullable: false),
                    Required_Quantity = table.Column<int>(nullable: false),
                    Schedule_Start_Date = table.Column<string>(nullable: true),
                    Schedule_End_Date = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Created_By = table.Column<int>(nullable: true),
                    Modified_By = table.Column<int>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Production_Type_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Machine_Id = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Mould_Details");

            migrationBuilder.DropTable(
                name: "Moulds");

            migrationBuilder.DropTable(
                name: "OperationDetails");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Operator_Entries");

            migrationBuilder.DropTable(
                name: "Operator_Entry_Details");

            migrationBuilder.DropTable(
                name: "PartMould_Types");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "PartSet_Details");

            migrationBuilder.DropTable(
                name: "PartSets");

            migrationBuilder.DropTable(
                name: "Production_Types");

            migrationBuilder.DropTable(
                name: "Schedule_Jobs");

            migrationBuilder.DropTable(
                name: "Shift_Types");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkStations");
        }
    }
}
