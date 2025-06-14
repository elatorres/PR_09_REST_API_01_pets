using Microsoft.AspNetCore.Mvc;
using DogApi.Models;

namespace DogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Dog>> GetAll() => DogRepository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Dog> Get(int id)
        {
            var dog = DogRepository.Get(id);
            return dog == null ? NotFound() : Ok(dog);
        }

        [HttpPost]
        public ActionResult<Dog> Add(Dog dog)
        {
            var created = DogRepository.Add(dog);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Dog dog)
        {
            return DogRepository.Update(id, dog) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return DogRepository.Delete(id) ? NoContent() : NotFound();
        }
    }
}