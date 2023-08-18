using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalShelterAPI.Migrations
{
    public partial class ChangeTableNameToRescueAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "RescueAnimals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RescueAnimals",
                table: "RescueAnimals",
                column: "RescueAnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RescueAnimals",
                table: "RescueAnimals");

            migrationBuilder.RenameTable(
                name: "RescueAnimals",
                newName: "Animals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "RescueAnimalId");
        }
    }
}
