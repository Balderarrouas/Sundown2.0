using Microsoft.EntityFrameworkCore.Migrations;

namespace Sundown2._0.Migrations
{
    public partial class LandingFacilityConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "LandingFacilities");

            migrationBuilder.InsertData(
                table: "LandingFacilities",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 55.684740222145393, 12.509714835254639, "Europe" },
                    { 2, 41.149626026644633, 119.33727554032843, "China" },
                    { 3, 40.014407426017335, -103.68329704730307, "America" },
                    { 4, -21.029736672213531, 23.770767883255459, "Africa" },
                    { 5, -33.007020987324388, 117.83314818861444, "Australia" },
                    { 6, 19.330540162912126, 79.14236662251713, "India" },
                    { 7, -34.050351176517886, -65.926829655687428, "Argentina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LandingFacilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LandingFacilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LandingFacilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LandingFacilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LandingFacilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LandingFacilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LandingFacilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<double>(
                name: "Altitude",
                table: "LandingFacilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
