using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GladiatorSim.Migrations
{
    public partial class Skillsupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gladiators_Skills_SkillId",
                table: "Gladiators");

            migrationBuilder.DropIndex(
                name: "IX_Gladiators_SkillId",
                table: "Gladiators");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Gladiators");

            migrationBuilder.CreateTable(
                name: "GladiatorSkill",
                columns: table => new
                {
                    GladiatorsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GladiatorSkill", x => new { x.GladiatorsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_GladiatorSkill_Gladiators_GladiatorsId",
                        column: x => x.GladiatorsId,
                        principalTable: "Gladiators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GladiatorSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 1, 30, "Light Attack" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 2, 60, "Heavy Attack" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 3, 90, "Ultra Attack" });

            migrationBuilder.CreateIndex(
                name: "IX_GladiatorSkill_SkillsId",
                table: "GladiatorSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GladiatorSkill");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Gladiators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gladiators_SkillId",
                table: "Gladiators",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gladiators_Skills_SkillId",
                table: "Gladiators",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
