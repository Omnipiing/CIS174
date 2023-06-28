using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class ver12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "scenarioType_id",
                table: "Requests",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "materialType_id",
                table: "Requests",
                newName: "ProgramType");

            migrationBuilder.RenameColumn(
                name: "ProgramType_id",
                table: "Requests",
                newName: "MaterialType");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                columns: new[] { "MaterialType", "ProgramType" },
                values: new object[] { "Z001", "AE250" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Scenario",
                table: "Requests",
                newName: "scenarioType_id");

            migrationBuilder.RenameColumn(
                name: "ProgramType",
                table: "Requests",
                newName: "materialType_id");

            migrationBuilder.RenameColumn(
                name: "MaterialType",
                table: "Requests",
                newName: "ProgramType_id");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                columns: new[] { "ProgramType_id", "materialType_id" },
                values: new object[] { "AE250", "Z001" });
        }
    }
}
