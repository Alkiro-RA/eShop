using System.ComponentModel.DataAnnotations;

namespace ControllerAPI.Models.Validations
{
    public class Pants_CorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var pants = validationContext.ObjectInstance as Pants;

            // general

            if (pants == null || string.IsNullOrWhiteSpace(pants.Gender))
            {
                return new ValidationResult("Object or gender is empty.");
            }
            if (pants.SizeWaist < 0 || pants.Size < 0)
            {
                return new ValidationResult("Size must be higher than 0.");
            }

            // size 

            if (pants.Size < 100 || pants.Size >= 230)
            {
                return new ValidationResult("Size value must be between 100 and 230[cm].");
            }
            if (pants.Gender.Equals("male", StringComparison.OrdinalIgnoreCase) && pants.Size < 160)
            {
                return new ValidationResult("Men's shirt need to be size greater than 160.");
            }
            if (pants.Gender.Equals("female", StringComparison.OrdinalIgnoreCase) && pants.Size < 150)
            {
                return new ValidationResult("Women's shirt need to be size greater than 150.");
            }
            if (pants.Gender.Equals("kid", StringComparison.OrdinalIgnoreCase) && pants.Size > 160)
            {
                return new ValidationResult("Kid's shirt need to be size smaller than 160.");
            }

            // waist size

            if (pants.SizeWaist < 50 || pants.SizeWaist >= 300)
            {
                return new ValidationResult("Regardless of gender, waist size value must be between 50 and 300[cm].");
            }

            return ValidationResult.Success;
        }
    }
}
