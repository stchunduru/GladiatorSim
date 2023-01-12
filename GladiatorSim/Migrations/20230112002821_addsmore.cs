using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GladiatorSim.Migrations
{
    public partial class addsmore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defeats",
                table: "Gladiators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fights",
                table: "Gladiators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Victories",
                table: "Gladiators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defeats",
                table: "Gladiators");

            migrationBuilder.DropColumn(
                name: "Fights",
                table: "Gladiators");

            migrationBuilder.DropColumn(
                name: "Victories",
                table: "Gladiators");
        }
    }
}
