using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterAPI.Models;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalShelterAPIContext _db;

        public AnimalsController(AnimalShelterAPIContext db)
        {
            _db = db;
        }

        // GET full list of animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RescueAnimal>>> Get()
        {
            return await _db.RescueAnimals.ToListAsync();
        }

        // GET specific animal
        [HttpGet("{id}")]
        public async Task<ActionResult<RescueAnimal>> GetAnimal(int id)
        {
            RescueAnimal thisAnimal = await _db.RescueAnimals.FindAsync(id);

            if (thisAnimal == null)
            {
                return NotFound();
            }

            return thisAnimal;
        }

        // POST new animal to API
        [HttpPost]
        public async Task<ActionResult<RescueAnimal>> Post(RescueAnimal newAnimal)
        {
            _db.RescueAnimals.Add(newAnimal);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAnimal), new { id = newAnimal.RescueAnimalId }, newAnimal);
        }
    }
}
