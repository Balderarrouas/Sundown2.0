using Microsoft.EntityFrameworkCore.Migrations;

namespace Sundown2._0.Migrations
{
    public partial class AddSpaceStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpaceStations");
        }
    }
}
