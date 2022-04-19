using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class WebApplication1ModelsKeyvalueContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KeyItems",
                columns: new[] { "Key", "Value" },
                values: new object[] { "temp_word", "74" });

            migrationBuilder.InsertData(
                table: "KeyItems",
                columns: new[] { "Key", "Value" },
                values: new object[] { "temp_art", "44" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KeyItems",
                keyColumn: "Key",
                keyValue: "temp_art");

            migrationBuilder.DeleteData(
                table: "KeyItems",
                keyColumn: "Key",
                keyValue: "temp_word");
        }
    }
}
