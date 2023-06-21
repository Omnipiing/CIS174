using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPageWebAppElliott.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "ContactName", "Notes", "PhoneNumber" },
                values: new object[] { 2, "Tony Robinson", "D&D DM", "5552783000" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "ContactName", "Notes", "PhoneNumber" },
                values: new object[] { 3, "Derek Ebel", "Team Leader", "5558675309" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "ContactName", "Notes", "PhoneNumber" },
                values: new object[] { 4, "Timothy Cross", "Brother-in-arms", "5551234567" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
