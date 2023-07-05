using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCoreApp_Elliott.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "in", "Indoor" },
                    { "out", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name" },
                values: new object[,]
                {
                    { "para", "Paralympic" },
                    { "summer", "Summer Olympics" },
                    { "winter", "Winter Olympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryId", "FlagImage", "GameId", "Name" },
                values: new object[,]
                {
                    { "aut", "out", "AUT.PNG", "para", "Austria" },
                    { "bra", "out", "BRA.PNG", "summer", "Brazil" },
                    { "can", "in", "CAN.PNG", "winter", "Canada" },
                    { "chn", "in", "CHN.PNG", "summer", "China" },
                    { "cyp", "in", "CYP.PNG", "youth", "Cyprus" },
                    { "deu", "in", "DEU.PNG", "summer", "Germany" },
                    { "fin", "out", "FIN.PNG", "youth", "Finland" },
                    { "fra", "in", "FRA.PNG", "youth", "France" },
                    { "gbr", "in", "GBR.PNG", "winter", "Great Britain" },
                    { "ita", "out", "ITA.PNG", "winter", "Italy" },
                    { "jam", "out", "JAM.PNG", "winter", "Jamaica" },
                    { "jpn", "out", "JAP.PNG", "winter", "Japan" },
                    { "mex", "in", "MEX.PNG", "summer", "Mexico" },
                    { "nld", "out", "NLD.PNG", "summer", "Netherlands" },
                    { "pak", "out", "PAK.PNG", "para", "Pakistan" },
                    { "prt", "out", "PRT.PNG", "youth", "Portugal" },
                    { "rus", "in", "RUS.PNG", "youth", "Russia" },
                    { "svk", "out", "SVK.PNG", "youth", "Slovakia" },
                    { "swe", "in", "SWE.PNG", "winter", "Sweden" },
                    { "tha", "in", "THA.PNG", "para", "Thailand" },
                    { "ukr", "in", "UKR.PNG", "para", "Ukraine" },
                    { "ury", "in", "URY.PNG", "para", "Uruguay" },
                    { "usa", "out", "USA.PNG", "summer", "United States" },
                    { "zwe", "out", "ZWE.PNG", "para", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryId",
                table: "Countries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameId",
                table: "Countries",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
