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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    { new Guid("d209ab46-a03b-47d7-a4b6-348c62f7e18a"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yuga.jpg", "First Man", null, null, "yuga@mtr.moon", "Yuri", "Gagarin", "ucJa3b1m3QCZvHM67PqYNTjKrqm6xJ01C/cXXSlvcRM=:eNJJotJygM5lfRT7VsnM5w==", null, "yuga" },
                    { new Guid("fad20788-1ebd-4ce6-a133-42eb34237d15"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Alsh.jpg", "Shepard", null, null, "alsh@mtr.moon", "Alan", "Shepard", "ITzi4V0MySnXMJA5WJu+p/zrjJ7v8F6JR//bUq7kzTM=:54+4rtMAB8384oiNiNCTDg==", null, "alsh" },
                    { new Guid("f4b917ea-9102-41cc-9a11-eed91af2119b"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Vate.jpg", "Valentine", null, null, "vate@mtr.moon", "Valentina", "Tereshkova", "F0RxBSmnVern/V/fHx4SNRMeZ+G6y/weNcBI37ONaSg=:/7FYNPQaAzjB+Qv7oTaXVw==", null, "vate" },
                    { new Guid("de7ae37e-a55c-42f4-8a54-d6df16488710"), "C:\\Users\\balde\\source\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Gubl.jpg", "bluey", null, null, "gubi@mtr.moon", "Guion", "Bluford", "VHblRfxl4dZ2pPNtHWih3gAWtQKtRwa4rtvctzafJPo=:/mo5k7OFhrEkp6m+z0PNsA==", null, "gubl" },
                    { new Guid("527b65e7-35f6-4f1f-adab-0a6233091a19"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Anmo.jpg", "Great Dane", null, null, "anmo@mtr.moon", "Andreas", "Mogensen", "K2HIUcKqjvNUUoHSWczlnnSnR4s6gWZ1F4sqGexWQGI=:mlopqmOCKizStvRG3z14PQ==", null, "anmo" },
                    { new Guid("b1c9bcfb-ac17-42db-924d-062c755aa474"), "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yiso.jpeg", "Neon", null, null, "yiso@mtr.moon", "Yi", "So-Yeon", "zygdXJKeXaglxCmRv3uF7c7Jhn/KMEIhSdEZqwJRRow=:sdRQ1lQmTJ+3F8N0jnSUCQ==", null, "yiso" }
                });

            migrationBuilder.InsertData(
                table: "LandingFacilities",
                columns: new[] { "Id", "DeletedAt", "DistanceToISS", "Latitude", "Longitude", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, 0.0, 55.684740222145393, 12.509714835254639, "Europe", null },
                    { 2, null, 0.0, 41.149626026644633, 119.33727554032843, "China", null },
                    { 3, null, 0.0, 40.014407426017335, -103.68329704730307, "America", null },
                    { 4, null, 0.0, -21.029736672213531, 23.770767883255459, "Africa", null },
                    { 5, null, 0.0, -33.007020987324388, 117.83314818861444, "Australia", null },
                    { 6, null, 0.0, 19.330540162912126, 79.14236662251713, "India", null },
                    { 7, null, 0.0, -34.050351176517886, -65.926829655687428, "Argentina", null }
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
