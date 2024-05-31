using ControllerAPI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace ControllerAPI.Models
{
    public class Pants
    {
        [Required]
        public int PantsId { get; set; }

        public string? Brand { get; set; }

        public string? Color { get; set; }

        [Pants_Gender]
        public string? Gender { get; set; }

        public string? Type { get; set; }

        [Pants_CorrectSizing]
        public int? Size { get; set; }

        [Pants_CorrectSizing]
        public int? SizeWaist { get; set; }

        [Required]
        public int? Price { get; set; }
    }
}
