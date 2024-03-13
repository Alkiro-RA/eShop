using ControllerAPI.Filters;
using ControllerAPI.Models;
using ControllerAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById([FromRoute] int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }

        [HttpPost]
        [Route("form")]
        public IActionResult CreateShirtForm([FromForm] Shirt shirt)
        {
            return Ok("Creating a shirt from form");
        }

        [HttpPut]
        public IActionResult UpdateShirt([FromQuery] int id, [FromQuery] string color)
        {
            return Ok($"Updating shirt with ID {id}, color: {color}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting shirt with ID {id}");
        }
    }
}
