using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvMaker.Migrations
{
    /// <inheritdoc />
    public partial class lang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitueType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalinfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExpId);
                    table.ForeignKey(
                        name: "FK_Experience_Personalinfo_PersonalinfoId",
                        column: x => x.PersonalinfoId,
                        principalTable: "Personalinfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalinfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LangId);
                    table.ForeignKey(
                        name: "FK_Language_Personalinfo_PersonalinfoId",
                        column: x => x.PersonalinfoId,
                        principalTable: "Personalinfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Institute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObtainedMarks = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    PersonalinfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_Qualification_Personalinfo_PersonalinfoId",
                        column: x => x.PersonalinfoId,
                        principalTable: "Personalinfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkilLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personalinfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillsId);
                    table.ForeignKey(
                        name: "FK_Skill_Personalinfo_personalinfoId",
                        column: x => x.personalinfoId,
                        principalTable: "Personalinfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experience_PersonalinfoId",
                table: "Experience",
                column: "PersonalinfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_PersonalinfoId",
                table: "Language",
                column: "PersonalinfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_PersonalinfoId",
                table: "Qualification",
                column: "PersonalinfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_personalinfoId",
                table: "Skill",
                column: "personalinfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
