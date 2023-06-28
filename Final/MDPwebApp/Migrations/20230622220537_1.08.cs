using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class _108 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salesOrg_id",
                table: "Requests",
                newName: "SalesOrg");

            migrationBuilder.RenameColumn(
                name: "productionSloc_id",
                table: "Requests",
                newName: "ProdSloc");

            migrationBuilder.RenameColumn(
                name: "materialPlant_id",
                table: "Requests",
                newName: "MaterialPlant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalesOrg",
                table: "Requests",
                newName: "salesOrg_id");

            migrationBuilder.RenameColumn(
                name: "ProdSloc",
                table: "Requests",
                newName: "productionSloc_id");

            migrationBuilder.RenameColumn(
                name: "MaterialPlant",
                table: "Requests",
                newName: "materialPlant_id");
        }
    }
}
