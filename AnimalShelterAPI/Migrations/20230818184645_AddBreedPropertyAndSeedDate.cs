using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalShelterAPI.Migrations
{
    public partial class AddBreedPropertyAndSeedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Animals",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "RescueAnimalId", "Adoptable", "Age", "Breed", "Description", "ImageURL", "Name", "Notes", "Species" },
                values: new object[,]
                {
                    { 1, true, 4, "American Longhair", "A linty fluffball.", null, "Linty", null, "Feline" },
                    { 2, true, 2, "Labrador", "A smelly doggo.", null, "Smelly", null, "Canine" },
                    { 3, true, 1, "Sphynx", "A smooth bingus.", null, "Bingus", null, "Feline" },
                    { 4, false, 36, null, "He's gonna be so mad when he sees this, it'll be great", null, "Greg", null, "Human" },
                    { 5, true, 4, "Beagle", "Professional Dog Detective. Do not remove hat.", null, "Sheila", null, "Canine" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "RescueAnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "RescueAnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "RescueAnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "RescueAnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "RescueAnimalId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Animals");
        }
    }
}
