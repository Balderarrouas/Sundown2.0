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
                    AstronautId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosestLandingFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandingFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    DistanceToISS = table.Column<double>(type: "float", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MissionReports",
                columns: table => new
                {
                    MissionReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    MissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalisationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AstronautId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionReports", x => x.MissionReportId);
                    table.ForeignKey(
                        name: "FK_MissionReports_Astronauts_AstronautId",
                        column: x => x.AstronautId,
                        principalTable: "Astronauts",
                        principalColumn: "AstronautId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionImages",
                columns: table => new
                {
                    MissionImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CameraName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoverStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MissionReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionImages", x => x.MissionImageId);
                    table.ForeignKey(
                        name: "FK_MissionImages_MissionReports_MissionReportId",
                        column: x => x.MissionReportId,
                        principalTable: "MissionReports",
                        principalColumn: "MissionReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Astronauts",
                columns: new[] { "AstronautId", "Avatar", "CodeName", "CreatedAt", "DeletedAt", "Email", "FirstName", "LastName", "Password", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("8c0e2924-e290-4cd3-a7eb-d360a6a51fbc"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yuga.jpg", "First Man", null, null, "yuga@mtr.moon", "Yuri", "Gagarin", "ucJa3b1m3QCZvHM67PqYNTjKrqm6xJ01C/cXXSlvcRM=:eNJJotJygM5lfRT7VsnM5w==", null, "yuga" },
                    { new Guid("3be03faa-9c78-4d3b-bc08-8c3c89bac208"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Alsh.jpg", "Shepard", null, null, "alsh@mtr.moon", "Alan", "Shepard", "ITzi4V0MySnXMJA5WJu+p/zrjJ7v8F6JR//bUq7kzTM=:54+4rtMAB8384oiNiNCTDg==", null, "alsh" },
                    { new Guid("9e70fddc-0693-4c38-be13-3f6a9681f2ec"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Vate.jpg", "Valentine", null, null, "vate@mtr.moon", "Valentina", "Tereshkova", "F0RxBSmnVern/V/fHx4SNRMeZ+G6y/weNcBI37ONaSg=:/7FYNPQaAzjB+Qv7oTaXVw==", null, "vate" },
                    { new Guid("c37140b0-fd12-4867-9868-03f82ccba040"), "C:\\Users\\balde\\source\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Gubl.jpg", "bluey", null, null, "gubi@mtr.moon", "Guion", "Bluford", "VHblRfxl4dZ2pPNtHWih3gAWtQKtRwa4rtvctzafJPo=:/mo5k7OFhrEkp6m+z0PNsA==", null, "gubl" },
                    { new Guid("f8928099-a389-467d-93ee-32be7c14f62b"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Anmo.jpg", "Great Dane", null, null, "anmo@mtr.moon", "Andreas", "Mogensen", "K2HIUcKqjvNUUoHSWczlnnSnR4s6gWZ1F4sqGexWQGI=:mlopqmOCKizStvRG3z14PQ==", null, "anmo" },
                    { new Guid("95cef011-8395-4876-a8dc-b3d542137d6d"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yiso.jpeg", "Neon", null, null, "yiso@mtr.moon", "Yi", "So-Yeon", "zygdXJKeXaglxCmRv3uF7c7Jhn/KMEIhSdEZqwJRRow=:sdRQ1lQmTJ+3F8N0jnSUCQ==", null, "yiso" }
                });

            migrationBuilder.InsertData(
                table: "LandingFacilities",
                columns: new[] { "Id", "DeletedAt", "DistanceToISS", "Latitude", "Longitude", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("e378f454-0793-46e6-824c-2e8aae7190bb"), null, 0.0, 55.684740222145393, 12.509714835254639, "Europe", null },
                    { new Guid("f090f415-9d6d-45c6-8b83-9ccb77d6e114"), null, 0.0, 41.149626026644633, 119.33727554032843, "China", null },
                    { new Guid("25e4a43b-7e7e-423c-982b-f01017547f5d"), null, 0.0, 40.014407426017335, -103.68329704730307, "America", null },
                    { new Guid("970a3da5-99a8-48ee-b7ac-06844a5616d0"), null, 0.0, -21.029736672213531, 23.770767883255459, "Africa", null },
                    { new Guid("c3085e3f-8797-4256-8aaa-7d541726fcd0"), null, 0.0, -33.007020987324388, 117.83314818861444, "Australia", null },
                    { new Guid("fe78d56f-3413-4196-a532-46910fb297ef"), null, 0.0, 19.330540162912126, 79.14236662251713, "India", null },
                    { new Guid("69fd5693-2ff6-4f5c-92bc-5c728f1920fe"), null, 0.0, -34.050351176517886, -65.926829655687428, "Argentina", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_Email",
                table: "Astronauts",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MissionImages_MissionReportId",
                table: "MissionImages",
                column: "MissionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionReports_AstronautId",
                table: "MissionReports",
                column: "AstronautId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosestLandingFacility");

            migrationBuilder.DropTable(
                name: "LandingFacilities");

            migrationBuilder.DropTable(
                name: "MissionImages");

            migrationBuilder.DropTable(
                name: "MissionReports");

            migrationBuilder.DropTable(
                name: "Astronauts");
        }
    }
}
