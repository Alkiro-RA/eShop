using ControllerAPI.Data;
using ControllerAPI.Filters.ActionFilters;
using ControllerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PantsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public PantsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetPants()
        {
            return Ok(db.Pants.ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Pants_ValidatePantsIdFilterAttribute))]
        public IActionResult GetPantsById([FromRoute] int id)
        {
            // got that object form the action filter

            var pants = HttpContext.Items["pants"];

            return Ok(pants);
        }

        [HttpPost]
        public IActionResult CreatePants()
        {
            return Ok();
        }

        /*[HttpPost]
        [Route("form")]
        public IActionResult CreatePantsForm([FromForm] Pants pants)
        {
            return Ok("Creating a pants from form");
        }*/

        [HttpPut("{id}")]
        public IActionResult UpdatePants()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePants()
        {
            return Ok();
        }
    }
}
