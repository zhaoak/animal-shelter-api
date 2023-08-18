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
        public async Task<ActionResult<IEnumerable<RescueAnimal>>> Get(string speciesFilter, string breedFilter, int minimumAgeFilter, int maximumAgeFilter, bool adoptableFilter)
        {
            IQueryable<RescueAnimal> query = _db.RescueAnimals.AsQueryable();

            // not using a case statement; only multiple `if`s allow multiple params in one query
            if (speciesFilter != null)
            {
                query = query.Where(row => row.Species == speciesFilter);
            }

            if (breedFilter != null)
            {
                query = query.Where(row => row.Breed == breedFilter);
            }

            if (minimumAgeFilter > 0)
            {
                query = query.Where(row => row.Age >= minimumAgeFilter);
            }

            if (maximumAgeFilter != 0)
            {
                query = query.Where(row => row.Age <= maximumAgeFilter);
            }

            if (adoptableFilter != null)
            {
                query = query.Where(row => row.Adoptable == adoptableFilter);
            }

            return await query.ToListAsync();
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

        // use PUT request to update a specific animal
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RescueAnimal updatedAnimal)
        {
            // make sure specified id and updated animal's id match
            if (id != updatedAnimal.RescueAnimalId)
            {
                return BadRequest();
            }
            
            // if they do, try to update selected animal
            _db.RescueAnimals.Update(updatedAnimal);

            try
            {
                await _db.SaveChangesAsync();
            }
            // if updating fails
            catch(DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    // return not found error if animal to update doesn't exist
                    return NotFound();
                }
                else
                {
                    // if other error, throw exception
                    throw;
                }
            }
            
            // return nothing if successful
            return NoContent();
        }

        // use DELETE request to delete a specific animal
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            // find animal to delete
            RescueAnimal animalToDelete = await _db.RescueAnimals.FindAsync(id);
            if (animalToDelete == null)
            {
                // if animal to delete doesn't exist, return error
                return NotFound();
            }
            // otherwise, delete
            _db.RescueAnimals.Remove(animalToDelete);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // helper function, checks if animal with specific id exists
        private bool AnimalExists(int id)
        {
            return _db.RescueAnimals.Any(e => e.RescueAnimalId == id);
        }
    }
}
