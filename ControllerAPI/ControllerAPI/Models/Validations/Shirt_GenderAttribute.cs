using ControllerAPI.Migrations;
using System.ComponentModel.DataAnnotations;

namespace ControllerAPI.Models.Validations
{
    public class Shirt_GenderAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;

            if (shirt == null || string.IsNullOrWhiteSpace(shirt.Gender))
            {
                return new ValidationResult("Object or gender is empty.");
            }
            if (shirt.Gender.Equals("kid", StringComparison.OrdinalIgnoreCase) ||
                shirt.Gender.Equals("male", StringComparison.OrdinalIgnoreCase) ||
                shirt.Gender.Equals("female", StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Gender needs to have any of the following values: 'male', 'female', or 'kid'.");
        }
    }
}
