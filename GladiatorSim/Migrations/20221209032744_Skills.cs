using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GladiatorSim.Migrations
{
    public partial class Skills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Gladiators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gladiators_Skills_SkillId",
                table: "Gladiators");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Gladiators_SkillId",
                table: "Gladiators");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Gladiators");
        }
    }
}
