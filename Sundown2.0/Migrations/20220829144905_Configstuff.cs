using Microsoft.EntityFrameworkCore.Migrations;

namespace Sundown2._0.Migrations
{
    public partial class Configstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Astronauts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Astronauts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Astronauts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Astronauts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Astronauts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Astronauts",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
