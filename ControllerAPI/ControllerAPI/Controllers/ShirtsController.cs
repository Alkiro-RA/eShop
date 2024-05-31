using ControllerAPI.Data;
using ControllerAPI.Filters.ActionFilters;
using ControllerAPI.Filters.ExceptionFilters;
using ControllerAPI.Models;
using ControllerAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ShirtsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(db.Shirts.ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult GetShirtById([FromRoute] int id)
        {
            // 2nd db contact - bad for big projects (1st is in the action filter)

            // var shirt = db.Shirts.Find(id);

            // big projects favorite

            var shirt = HttpContext.Items["shirt"];

            return Ok(shirt);
        }

        [HttpPost]
        [TypeFilter(typeof(Shirt_ValidateCreateShirtFilterAttribute))]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            db.Shirts.Add(shirt);
            db.SaveChanges();

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

        [HttpPut("{id}")]
        [Shirt_ValidateUpdateShirtFilter]   // action filter without dependecy injection
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]   // action filter with dependecy injection
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))] // exception filter with dependecy injection
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            // using HttpContext bcs the action filter has already put it there

            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult DeleteShirt(int id)
        {
            // not worring about nulls, bcs of the action filter

            var shirtToDelete = HttpContext.Items["shirt"] as Shirt;

            db.Shirts.Remove(shirtToDelete);
            db.SaveChanges();

            return Ok(shirtToDelete);
        }
    }
}
