using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sundown2._0.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Astronauts",
                columns: table => new
                {
                    AstronautId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astronauts", x => x.AstronautId);
                });

            migrationBuilder.CreateTable(
                name: "ClosestLandingFacility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentDistanceInMeters = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosestLandingFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandingFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    DistanceToISS = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Altitude = table.Column<double>(type: "float", nullable: false),
                    Velocity = table.Column<double>(type: "float", nullable: false),
                    Visibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Footprint = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<int>(type: "int", nullable: false),
                    Daynum = table.Column<double>(type: "float", nullable: false),
                    SolarLat = table.Column<double>(type: "float", nullable: false),
                    SolarLon = table.Column<double>(type: "float", nullable: false),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MissionReport",
                columns: table => new
                {
                    MissionReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    MissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalisationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AstronautId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionReport", x => x.MissionReportId);
                    table.ForeignKey(
                        name: "FK_MissionReport_Astronauts_AstronautId",
                        column: x => x.AstronautId,
                        principalTable: "Astronauts",
                        principalColumn: "AstronautId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionImage",
                columns: table => new
                {
                    MissionImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    RoverStatus = table.Column<bool>(type: "bit", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MissionReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionImage", x => x.MissionImageId);
                    table.ForeignKey(
                        name: "FK_MissionImage_MissionReport_MissionReportId",
                        column: x => x.MissionReportId,
                        principalTable: "MissionReport",
                        principalColumn: "MissionReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Astronauts",
                columns: new[] { "AstronautId", "Avatar", "CodeName", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "C:\\Usersalde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yuga.jpg", "First Man", "yuga@mtr.moon", "Yuri", "Gagarin", "ucJa3b1m3QCZvHM67PqYNTjKrqm6xJ01C/cXXSlvcRM=:eNJJotJygM5lfRT7VsnM5w==", "yuga" },
                    { 2, "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Alsh.jpg", "Shepard", "alsh@mtr.moon", "Alan", "Shepard", "ITzi4V0MySnXMJA5WJu+p/zrjJ7v8F6JR//bUq7kzTM=:54+4rtMAB8384oiNiNCTDg==", "alsh" },
                    { 3, "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Vate.jpg", "Valentine", "vate@mtr.moon", "Valentina", "Tereshkova", "F0RxBSmnVern/V/fHx4SNRMeZ+G6y/weNcBI37ONaSg=:/7FYNPQaAzjB+Qv7oTaXVw==", "vate" },
                    { 4, "C:\\Users\\balde\\source\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Gubl.jpg", "bluey", "gubi@mtr.moon", "Guion", "Bluford", "VHblRfxl4dZ2pPNtHWih3gAWtQKtRwa4rtvctzafJPo=:/mo5k7OFhrEkp6m+z0PNsA==", "gubl" },
                    { 5, "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Anmo.jpg", "Great Dane", "anmo@mtr.moon", "Andreas", "Mogensen", "K2HIUcKqjvNUUoHSWczlnnSnR4s6gWZ1F4sqGexWQGI=:mlopqmOCKizStvRG3z14PQ==", "anmo" },
                    { 6, "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yiso.jpeg", "Neon", "yiso@mtr.moon", "Yi", "So-Yeon", "zygdXJKeXaglxCmRv3uF7c7Jhn/KMEIhSdEZqwJRRow=:sdRQ1lQmTJ+3F8N0jnSUCQ==", "yiso" }
                });

            migrationBuilder.InsertData(
                table: "LandingFacilities",
                columns: new[] { "Id", "DistanceToISS", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, 55.684740222145393, 12.509714835254639, "Europe" },
                    { 2, 0.0, 41.149626026644633, 119.33727554032843, "China" },
                    { 3, 0.0, 40.014407426017335, -103.68329704730307, "America" },
                    { 4, 0.0, -21.029736672213531, 23.770767883255459, "Africa" },
                    { 5, 0.0, -33.007020987324388, 117.83314818861444, "Australia" },
                    { 6, 0.0, 19.330540162912126, 79.14236662251713, "India" },
                    { 7, 0.0, -34.050351176517886, -65.926829655687428, "Argentina" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionImage_MissionReportId",
                table: "MissionImage",
                column: "MissionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionReport_AstronautId",
                table: "MissionReport",
                column: "AstronautId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosestLandingFacility");

            migrationBuilder.DropTable(
                name: "LandingFacilities");

            migrationBuilder.DropTable(
                name: "MissionImage");

            migrationBuilder.DropTable(
                name: "SpaceStations");

            migrationBuilder.DropTable(
                name: "MissionReport");

            migrationBuilder.DropTable(
                name: "Astronauts");
        }
    }
}
