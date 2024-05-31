using System.ComponentModel.DataAnnotations;

namespace ControllerAPI.Models.Validations
{
    public class Pants_GenderAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var pants = validationContext.ObjectInstance as Pants;

            if (pants == null || string.IsNullOrWhiteSpace(pants.Gender))
            {
                return new ValidationResult("Object or gender is empty.");
            }
            if (pants.Gender.Equals("kid", StringComparison.OrdinalIgnoreCase) ||
                pants.Gender.Equals("male", StringComparison.OrdinalIgnoreCase) ||
                pants.Gender.Equals("female", StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Gender needs to have any of the following values: 'male', 'female', or 'kid'.");
        }
    }
}
