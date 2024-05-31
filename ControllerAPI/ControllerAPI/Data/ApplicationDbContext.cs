using ControllerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControllerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Pants> Pants { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // data seeding

            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Male", Price = 30, Size = 170 },
                new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Female", Price = 35, Size = 150 },
                new Shirt { ShirtId = 3, Brand = "Your Brand", Color = "Red", Gender = "Male", Price = 40, Size = 180 },
                new Shirt { ShirtId = 4, Brand = "Your Brand", Color = "Green", Gender = "Female", Price = 20, Size = 160 }
            );
            modelBuilder.Entity<Pants>().HasData(
                new Pants { PantsId = 1, Brand = "MyBrand", Color = "Blue", Gender = "Male", Price = 70, Size = 170, SizeWaist = 100, Type = "Jeans" },
                new Pants { PantsId = 2, Brand = "YourBrand", Color = "Gray", Gender = "Female", Price = 60, Size = 160, SizeWaist = 80, Type = "Trousers" },
                new Pants { PantsId = 3, Brand = "TheirBrand", Color = "Black", Gender = "Kid", Price = 40, Size = 110, SizeWaist = 55, Type = "Shorts" }
            );
        }
    }
}
