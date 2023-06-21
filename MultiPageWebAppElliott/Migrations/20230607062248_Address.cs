using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPageWebAppElliott.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 2,
                column: "Address",
                value: "123 Keats Ave, Tempe, AZ 85209");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 3,
                column: "Address",
                value: "9876 Boss Dr, Huxley, IA 50023");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 4,
                column: "Address",
                value: "666 13th St, Boston, MA 10015");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contacts");
        }
    }
}
