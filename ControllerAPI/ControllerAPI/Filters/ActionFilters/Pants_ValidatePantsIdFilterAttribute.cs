using ControllerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControllerAPI.Filters.ActionFilters
{
    public class Pants_ValidatePantsIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;

        public Pants_ValidatePantsIdFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var pantsId = context.ActionArguments["id"] as int?;

            if (pantsId.HasValue)
            {
                if (pantsId.Value <= 0)
                {
                    context.ModelState.AddModelError("PantsId", "Pants ID is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var pants = db.Pants.Find(pantsId.Value);

                    if (pants == null)
                    {
                        context.ModelState.AddModelError("PantsId", "Pants ID doesn't exist.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["pants"] = pants;
                    }
                }
            }
        }
    }
}
