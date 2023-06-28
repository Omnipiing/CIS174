using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class ver121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sloc_ep_id",
                table: "Requests",
                newName: "RawMaterial");

            migrationBuilder.RenameColumn(
                name: "salesOrgExtend_id",
                table: "Requests",
                newName: "ProdSupervisor");

            migrationBuilder.RenameColumn(
                name: "raw_mat_id",
                table: "Requests",
                newName: "OldPartNumber");

            migrationBuilder.RenameColumn(
                name: "productionSlocExtend_id",
                table: "Requests",
                newName: "NextHigherAssembly");

            migrationBuilder.RenameColumn(
                name: "prod_sup_id",
                table: "Requests",
                newName: "MRPController");

            migrationBuilder.RenameColumn(
                name: "old_pn_id",
                table: "Requests",
                newName: "EPSloc");

            migrationBuilder.RenameColumn(
                name: "next_higher_assm_id",
                table: "Requests",
                newName: "Component");

            migrationBuilder.RenameColumn(
                name: "mrp_cntrl_id",
                table: "Requests",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "materialPlantExtend_id",
                table: "Requests",
                newName: "Authority");

            migrationBuilder.RenameColumn(
                name: "component_id",
                table: "Requests",
                newName: "AdditionalSloc");

            migrationBuilder.RenameColumn(
                name: "commentBox_id",
                table: "Requests",
                newName: "AdditionalSalesOrg");

            migrationBuilder.RenameColumn(
                name: "authority_id",
                table: "Requests",
                newName: "AdditionalPlant");

            migrationBuilder.RenameColumn(
                name: "additional_id",
                table: "Requests",
                newName: "AdditionalCheckBox");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                columns: new[] { "AdditionalPlant", "AdditionalSalesOrg", "AdditionalSloc", "Authority", "Comment", "Component", "EPSloc", "MRPController", "NextHigherAssembly", "OldPartNumber", "ProdSupervisor", "RawMaterial" },
                values: new object[] { "", "", "", "AUTH", "Required by Monday", "COM", "REC1", "EAJ", "NEX", "59567", "007", "RAW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RawMaterial",
                table: "Requests",
                newName: "sloc_ep_id");

            migrationBuilder.RenameColumn(
                name: "ProdSupervisor",
                table: "Requests",
                newName: "salesOrgExtend_id");

            migrationBuilder.RenameColumn(
                name: "OldPartNumber",
                table: "Requests",
                newName: "raw_mat_id");

            migrationBuilder.RenameColumn(
                name: "NextHigherAssembly",
                table: "Requests",
                newName: "productionSlocExtend_id");

            migrationBuilder.RenameColumn(
                name: "MRPController",
                table: "Requests",
                newName: "prod_sup_id");

            migrationBuilder.RenameColumn(
                name: "EPSloc",
                table: "Requests",
                newName: "old_pn_id");

            migrationBuilder.RenameColumn(
                name: "Component",
                table: "Requests",
                newName: "next_higher_assm_id");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Requests",
                newName: "mrp_cntrl_id");

            migrationBuilder.RenameColumn(
                name: "Authority",
                table: "Requests",
                newName: "materialPlantExtend_id");

            migrationBuilder.RenameColumn(
                name: "AdditionalSloc",
                table: "Requests",
                newName: "component_id");

            migrationBuilder.RenameColumn(
                name: "AdditionalSalesOrg",
                table: "Requests",
                newName: "commentBox_id");

            migrationBuilder.RenameColumn(
                name: "AdditionalPlant",
                table: "Requests",
                newName: "authority_id");

            migrationBuilder.RenameColumn(
                name: "AdditionalCheckBox",
                table: "Requests",
                newName: "additional_id");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "requestId",
                keyValue: 1,
                columns: new[] { "authority_id", "commentBox_id", "component_id", "materialPlantExtend_id", "mrp_cntrl_id", "next_higher_assm_id", "old_pn_id", "prod_sup_id", "productionSlocExtend_id", "raw_mat_id", "salesOrgExtend_id", "sloc_ep_id" },
                values: new object[] { "AUTH", "Required by Monday", "COM", "", "EAJ", "NEX", "59567", "007", "", "RAW", "", "REC1" });
        }
    }
}
