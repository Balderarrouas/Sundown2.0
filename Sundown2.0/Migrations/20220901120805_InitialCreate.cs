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
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Astronauts", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Astronauts",
                columns: new[] { "Id", "Avatar", "CodeName", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "", "First Man", "yuga@mtr.moon", "Yuri", "Gagarin", "poleposition1", "yuga" },
                    { 2, "", "Shepard", "alsh@mtr.moon", "Alan", "Shepard", "secret", "alsh" },
                    { 3, "", "Valentine", "vate@mtr.moon", "Valentina", "Tereshkova", "DQ!cnRVYzQ64@Fwha!XB_kYn", "vate" },
                    { 4, "", "bluey", "gubi@mtr.moon", "Guion", "Bluford", "STS-8!Challenger1983", "gubi" },
                    { 5, "", "Great Dane", "anmo@mtr.moon", "Andreas", "Mogensen", "rødgrødmedfløde", "anmo" },
                    { 6, "", "Neon", "yiso@mtr.moon", "Yi", "So-Yeon", "K2t@dACRkGCd3-UQQmCZJbTj", "yiso" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Astronauts");

            migrationBuilder.DropTable(
                name: "ClosestLandingFacility");

            migrationBuilder.DropTable(
                name: "LandingFacilities");

            migrationBuilder.DropTable(
                name: "SpaceStations");
        }
    }
}
