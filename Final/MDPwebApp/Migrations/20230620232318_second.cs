using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "oemroNum",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                column: "oemroNum",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oemroNum",
                table: "Requests");
        }
    }
}
