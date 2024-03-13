using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace ControllerAPI.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> Shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Male", Price = 30, Size = 170},
            new Shirt {ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Female", Price = 35, Size = 150},
            new Shirt {ShirtId = 3, Brand = "Your Brand", Color = "Red", Gender = "Male", Price = 40, Size = 180},
            new Shirt {ShirtId = 4, Brand = "Your Brand", Color = "Green", Gender = "Female", Price = 20, Size = 160}
        };

        public static bool ShirtExists(int id)
        {
            return Shirts.Any(x => x.ShirtId == id);
        }

        public static List<Shirt> GetShirts()
        {
            return Shirts;
        }

        public static Shirt? GetShirtById(int id)
        {
            return Shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? color, string? gender, int? size)
        {
            return Shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = Shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;
            Shirts.Add(shirt);
        }
    }
}
