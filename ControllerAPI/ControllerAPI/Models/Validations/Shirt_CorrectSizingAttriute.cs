﻿using System.ComponentModel.DataAnnotations;

namespace ControllerAPI.Models.Validations
{
    public class Shirt_CorrectSizingAttriute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;

            if (shirt == null || string.IsNullOrWhiteSpace(shirt.Gender))
            {
                return new ValidationResult("Object or gender is empty.");
            }
            if (shirt.Gender.Equals("male", StringComparison.OrdinalIgnoreCase) && shirt.Size < 160)
            {
                return new ValidationResult("Men's shirt need to be size greater than 160.");
            }
            if (shirt.Gender.Equals("female", StringComparison.OrdinalIgnoreCase) && shirt.Size < 150)
            {
                return new ValidationResult("Women's shirt need to be size greater than 150.");
            }

            return ValidationResult.Success;
        }
    }
}
