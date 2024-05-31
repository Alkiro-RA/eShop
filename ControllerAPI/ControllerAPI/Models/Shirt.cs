using ControllerAPI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace ControllerAPI.Models
{
    public class Shirt
    {
        [Required]
        public int ShirtId { get; set; }
        
        public string? Brand { get; set; }
        
        [Required]
        public string? Color { get; set; }

        [Shirt_CorrectSizing]
        public int? Size { get; set; }
        
        [Required]
        [Shirt_Gender]
        public string? Gender { get; set; }
        
        [Required]
        public double? Price { get; set; }
    }
}
