using Microsoft.EntityFrameworkCore;

namespace AnimalShelterAPI.Models
{
  public class AnimalShelterAPIContext : DbContext
  {
    public DbSet<RescueAnimal> Animals { get; set; }

    public AnimalShelterAPIContext(DbContextOptions<AnimalShelterAPIContext> options) : base(options)
    {
    }

    // seeding database with dummy data
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<RescueAnimal>()
        .HasData(
              new RescueAnimal { RescueAnimalId = 1, Name = "Linty", Species = "Feline", Breed = "American Longhair", Description = "A linty fluffball.", Age = 4, Adoptable = true },
              new RescueAnimal { RescueAnimalId = 2, Name = "Smelly", Species = "Canine", Breed = "Labrador", Description = "A smelly doggo.", Age = 2, Adoptable = true },
              new RescueAnimal { RescueAnimalId = 3, Name = "Bingus", Species = "Feline", Breed = "Sphynx", Description = "A smooth bingus.", Age = 1, Adoptable = true },
              new RescueAnimal { RescueAnimalId = 4, Name = "Greg", Species = "Human", Description = "He's gonna be so mad when he sees this, it'll be great", Age = 36, Adoptable = false },
              new RescueAnimal { RescueAnimalId = 5, Name = "Sheila", Species = "Canine", Breed = "Beagle", Description = "Professional Dog Detective. Do not remove hat.", Age = 4, Adoptable = true }
            );
    }
  }
}
