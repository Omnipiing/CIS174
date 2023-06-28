using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class _104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aog_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "leadTime_checkbox_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "primary_sbu_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "sto_id",
                table: "Requests");

            migrationBuilder.AddColumn<bool>(
                name: "AOG",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LeadTime",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrimarySBU",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "STO",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AOG",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "LeadTime",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PrimarySBU",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "STO",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "aog_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "leadTime_checkbox_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "primary_sbu_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sto_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                columns: new[] { "aog_id", "leadTime_checkbox_id", "primary_sbu_id", "sto_id" },
                values: new object[] { "FALSE", "FALSE", "TRUE", "FALSE" });
        }
    }
}
