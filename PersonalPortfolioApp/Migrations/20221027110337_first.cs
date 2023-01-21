using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalPortfolioApp.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countryModels",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryModels", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "skillModels",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skillModels", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "cityModels",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityModels", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_cityModels_countryModels_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countryModels",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "persoalModels",
                columns: table => new
                {
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persoalModels", x => x.PersonalId);
                    table.ForeignKey(
                        name: "FK_persoalModels_cityModels_CityId",
                        column: x => x.CityId,
                        principalTable: "cityModels",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_persoalModels_countryModels_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countryModels",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal_Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_Skills_persoalModels_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "persoalModels",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_Skills_skillModels_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skillModels",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cityModels_CountryId",
                table: "cityModels",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_persoalModels_CityId",
                table: "persoalModels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_persoalModels_CountryId",
                table: "persoalModels",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_Skills_PersonalId",
                table: "personal_Skills",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_Skills_SkillId",
                table: "personal_Skills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personal_Skills");

            migrationBuilder.DropTable(
                name: "persoalModels");

            migrationBuilder.DropTable(
                name: "skillModels");

            migrationBuilder.DropTable(
                name: "cityModels");

            migrationBuilder.DropTable(
                name: "countryModels");
        }
    }
}
