using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class _107 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "materialNumber_id",
                table: "Requests",
                newName: "MaterialNumber");

            migrationBuilder.RenameColumn(
                name: "materialDescription_id",
                table: "Requests",
                newName: "MaterialDescription");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                column: "MaterialNumber",
                value: "59568");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaterialNumber",
                table: "Requests",
                newName: "materialNumber_id");

            migrationBuilder.RenameColumn(
                name: "MaterialDescription",
                table: "Requests",
                newName: "materialDescription_id");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                column: "materialNumber_id",
                value: "");
        }
    }
}
