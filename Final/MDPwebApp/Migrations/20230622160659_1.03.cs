using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class _103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CIVL_ITAR_radio",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                column: "CIVL_ITAR_radio",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CIVL_ITAR_radio",
                table: "Requests");
        }
    }
}
