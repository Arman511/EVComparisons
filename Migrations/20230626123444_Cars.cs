﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVComparisons.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<int>(type: "int", nullable: false),
                    FullPrice = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Made = table.Column<int>(type: "int", nullable: false),
                    CargoVolume = table.Column<int>(type: "int", nullable: false),
                    RoofRails = table.Column<bool>(type: "bit", nullable: false),
                    TowHitch = table.Column<bool>(type: "bit", nullable: false),
                    TowWeight = table.Column<int>(type: "int", nullable: false),
                    MaxPayload = table.Column<int>(type: "int", nullable: false),
                    Safety = table.Column<int>(type: "int", nullable: false),
                    BatteryCapacity = table.Column<double>(type: "float", nullable: false),
                    NormalChargePower = table.Column<double>(type: "float", nullable: false),
                    NormalChargeTime = table.Column<int>(type: "int", nullable: false),
                    NormalChargePort = table.Column<int>(type: "int", nullable: false),
                    NormalPortLocation = table.Column<int>(type: "int", nullable: false),
                    FastChargePower = table.Column<double>(type: "float", nullable: false),
                    FastChargeTime = table.Column<int>(type: "int", nullable: false),
                    FastChargePort = table.Column<int>(type: "int", nullable: false),
                    FastPortLocation = table.Column<int>(type: "int", nullable: false),
                    TopSpeed = table.Column<int>(type: "int", nullable: false),
                    NaughtTo60 = table.Column<double>(type: "float", nullable: false),
                    Efficiency = table.Column<int>(type: "int", nullable: false),
                    TotalPower = table.Column<int>(type: "int", nullable: false),
                    TotalTorque = table.Column<int>(type: "int", nullable: false),
                    Drive = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
