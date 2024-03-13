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
            return Ok("Reading all shirts");
        }

        [HttpGet("{id}")]
        [Shirts_IdValidationFilter]
        public IActionResult GetShirt([FromRoute] int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            return Ok($"Creating a shirt");
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
