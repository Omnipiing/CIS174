using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class _106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Military_three_radio_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "buy_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "civil_four_radio_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "civil_one_radio_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "create_id",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "make_id",
                table: "Requests",
                newName: "Make_Buy_radio");

            migrationBuilder.RenameColumn(
                name: "extend_id",
                table: "Requests",
                newName: "Create_Extend_radio");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                columns: new[] { "Create_Extend_radio", "Make_Buy_radio", "PrimarySBU" },
                values: new object[] { "Create", "Make", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Make_Buy_radio",
                table: "Requests",
                newName: "make_id");

            migrationBuilder.RenameColumn(
                name: "Create_Extend_radio",
                table: "Requests",
                newName: "extend_id");

            migrationBuilder.AddColumn<string>(
                name: "Military_three_radio_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "buy_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "civil_four_radio_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "civil_one_radio_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "create_id",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                columns: new[] { "Military_three_radio_id", "PrimarySBU", "buy_id", "civil_four_radio_id", "civil_one_radio_id", "create_id", "extend_id", "make_id" },
                values: new object[] { "FALSE", false, "FALSE", "FALSE", "TRUE", "TRUE", "FALSE", "TRUE" });
        }
    }
}
