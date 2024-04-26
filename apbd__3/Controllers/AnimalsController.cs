using Microsoft.AspNetCore.Mvc;
using apbd__3.Models;
using apbd__3.Services;

namespace apbd__3.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IDBService DBService;

        public AnimalsController(IDBService DBService)
        {
            this.DBService = DBService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals([FromQuery] string orderBy)
        {
            List<Animal> animals = null;
            animals = DBService.GetAnimals(orderBy);
          
            return Ok(animals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] Animal animal)
        {
            try { DBService.CreateAnimal(animal); }
            catch (Exception) { return BadRequest("Entered data is not valid!"); }
            return Ok("Succsesfully created!");
        }

        [HttpPut("{idAnimal}")]
        public async Task<IActionResult> ChangeAnimal([FromRoute] int idAnimal, [FromBody] Animal animal)
        {
            DBService.ChangeAnimal(idAnimal, animal); 

            return Ok("Succsesfully changed!");
        }

        [HttpDelete("{idAnimal}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int idAnimal)
        {
             DBService.DeleteAnimal(idAnimal); 
        
            return Ok("Succsesfully deleted!");
        }


    }
}