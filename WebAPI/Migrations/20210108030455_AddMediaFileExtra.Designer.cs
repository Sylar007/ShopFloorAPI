﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Helpers;

namespace WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210108030455_AddMediaFileExtra")]
    partial class AddMediaFileExtra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebAPI.Entities.File_Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File_Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("File_Media");
                });

            modelBuilder.Entity("WebAPI.Entities.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("WebAPI.Entities.Mould", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartSet_Id")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Moulds");
                });

            modelBuilder.Entity("WebAPI.Entities.Mould_Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mould_Id")
                        .HasColumnType("int");

                    b.Property<int>("PartMould_Type_Id")
                        .HasColumnType("int");

                    b.Property<int>("Part_Id")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mould_Details");
                });

            modelBuilder.Entity("WebAPI.Entities.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartSet_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("WorkStation_Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("WebAPI.Entities.OperationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assigned_User")
                        .HasColumnType("int");

                    b.Property<int>("Flow")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Operation_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Operation_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OperationDetails");
                });

            modelBuilder.Entity("WebAPI.Entities.Operator_Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Entry_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Entry_Status")
                        .HasColumnType("int");

                    b.Property<int>("Mould_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Operator_Entries");
                });

            modelBuilder.Entity("WebAPI.Entities.Operator_Entry_Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Entry_Result")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Operator_Entry_Id")
                        .HasColumnType("int");

                    b.Property<int>("Part_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Operator_Entry_Details");
                });

            modelBuilder.Entity("WebAPI.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Back_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Hil_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Media_Id")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Part_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Part_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("WebAPI.Entities.PartMould_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mould_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PartMould_Types");
                });

            modelBuilder.Entity("WebAPI.Entities.PartSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PartSet_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PartSets");
                });

            modelBuilder.Entity("WebAPI.Entities.PartSet_Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartSet_Id")
                        .HasColumnType("int");

                    b.Property<int>("Part_Id")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PartSet_Details");
                });

            modelBuilder.Entity("WebAPI.Entities.Production_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Production_Types");
                });

            modelBuilder.Entity("WebAPI.Entities.Schedule_Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Created_By")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_By")
                        .HasColumnType("int");

                    b.Property<int>("PartSet_Id")
                        .HasColumnType("int");

                    b.Property<int>("Required_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Schedule_End_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule_Start_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Schedule_Type")
                        .HasColumnType("int");

                    b.Property<int>("Shift_Type")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Workstation_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Schedule_Jobs");
                });

            modelBuilder.Entity("WebAPI.Entities.Shift_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Production_Type_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Shift_Types");
                });

            modelBuilder.Entity("WebAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAPI.Entities.WorkStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Machine_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkStations");
                });
#pragma warning restore 612, 618
        }
    }
}
