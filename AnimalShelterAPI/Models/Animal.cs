using System.ComponentModel.DataAnnotations;

namespace AnimalShelterAPI.Models
{
  public class RescueAnimal
  {
    public int RescueAnimalId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [StringLength(5000)]
    public string Description { get; set; }
    [Required]
    [StringLength(100)]
    public string Species { get; set; }
    public string Notes { get; set; }
    [Required]
    [Range(0, 400, ErrorMessage = "Age must be between 0 and 400. And really only above 25 for like, the oldest turtles or whatever.")]
    public int Age { get; set; }
    public string ImageURL { get; set; }
    [Required]
    public bool Adoptable { get; set; } = true;
  }
}
