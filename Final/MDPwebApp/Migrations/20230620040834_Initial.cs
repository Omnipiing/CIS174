using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDPwebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    requestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materialNumber_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    materialDescription_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    materialPlant_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    materialType_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramType_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productionSloc_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salesOrg_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scenarioType_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    old_pn_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sloc_ep_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    materialPlantExtend_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productionSlocExtend_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salesOrgExtend_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commentBox_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mrp_cntrl_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    component_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raw_mat_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authority_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    next_higher_assm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prod_sup_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sto_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    additional_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    leadTime_checkbox_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option_EPP_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option_MRO_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option_OE_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    primary_sbu_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aog_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    civil_four_radio_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Military_three_radio_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    civil_one_radio_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buy_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    make_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extend_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.requestId);
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "requestId", "Military_three_radio_id", "ProgramType_id", "additional_id", "aog_id", "authority_id", "buy_id", "civil_four_radio_id", "civil_one_radio_id", "commentBox_id", "component_id", "create_id", "extend_id", "leadTime_checkbox_id", "make_id", "materialDescription_id", "materialNumber_id", "materialPlantExtend_id", "materialPlant_id", "materialType_id", "mrp_cntrl_id", "next_higher_assm_id", "old_pn_id", "option_EPP_id", "option_MRO_id", "option_OE_id", "primary_sbu_id", "prod_sup_id", "productionSlocExtend_id", "productionSloc_id", "raw_mat_id", "salesOrgExtend_id", "salesOrg_id", "scenarioType_id", "sloc_ep_id", "sto_id" },
                values: new object[] { 1, "FALSE", "AE250", "TRUE", "FALSE", "AUTH", "FALSE", "FALSE", "TRUE", "Required by Monday", "COM", "TRUE", "FALSE", "FALSE", "TRUE", "SEAL", "", "", "2020", "Z001", "EAJ", "NEX", "59567", "FALSE", "FALSE", "TRUE", "TRUE", "007", "", "NEW1", "RAW", "", "4000", "END ITEM", "REC1", "FALSE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
