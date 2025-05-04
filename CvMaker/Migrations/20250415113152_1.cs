using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvMaker.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Personalinfo_personalinfoId",
                table: "Skill");

            migrationBuilder.RenameColumn(
                name: "personalinfoId",
                table: "Skill",
                newName: "PersonalinfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_personalinfoId",
                table: "Skill",
                newName: "IX_Skill_PersonalinfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Personalinfo_PersonalinfoId",
                table: "Skill",
                column: "PersonalinfoId",
                principalTable: "Personalinfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Personalinfo_PersonalinfoId",
                table: "Skill");

            migrationBuilder.RenameColumn(
                name: "PersonalinfoId",
                table: "Skill",
                newName: "personalinfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_PersonalinfoId",
                table: "Skill",
                newName: "IX_Skill_personalinfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Personalinfo_personalinfoId",
                table: "Skill",
                column: "personalinfoId",
                principalTable: "Personalinfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
