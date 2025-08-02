using CarManufacturersAPI.Models;

namespace CarManufacturersAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Manufacturers.Any())
            {
                return;
            }

            var manufacturers = new Manufacturer[]
            {
                new Manufacturer
                {
                    Name = "Toyota",
                    Country = "Japan",
                },
                new Manufacturer
                {
                    Name = "BMW",
                    Country = "Germany",
                },
                new Manufacturer
                {
                    Name = "Ford",
                    Country = "USA",
                },
                new Manufacturer
                {
                    Name = "Volkswagen",
                    Country = "Germany",
                },
                new Manufacturer
                {
                    Name = "Honda",
                    Country = "Japan",
                }
            };

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            var cars = new Car[]
            {
                new Car
                {
                    Model = "Camry",
                    Year = 2023,
                    Color = "White",
                    Price = 25000.00m,
                    ManufacturerId = manufacturers[0].Id
                },
                new Car
                {
                    Model = "Corolla",
                    Year = 2022,
                    Color = "Silver",
                    Price = 22000.00m,
                    ManufacturerId = manufacturers[0].Id
                },
                new Car
                {
                    Model = "X5",
                    Year = 2023,
                    Color = "Black",
                    Price = 65000.00m,
                    ManufacturerId = manufacturers[1].Id
                },
                new Car
                {
                    Model = "3 Series",
                    Year = 2022,
                    Color = "Blue",
                    Price = 45000.00m,
                    ManufacturerId = manufacturers[1].Id
                },
                new Car
                {
                    Model = "Mustang",
                    Year = 2023,
                    Color = "Red",
                    Price = 35000.00m,
                    ManufacturerId = manufacturers[2].Id
                },
                new Car
                {
                    Model = "F-150",
                    Year = 2022,
                    Color = "Gray",
                    Price = 40000.00m,
                    ManufacturerId = manufacturers[2].Id
                },
                new Car
                {
                    Model = "Golf",
                    Year = 2023,
                    Color = "White",
                    Price = 28000.00m,
                    ManufacturerId = manufacturers[3].Id
                },
                new Car
                {
                    Model = "Passat",
                    Year = 2022,
                    Color = "Silver",
                    Price = 32000.00m,
                    ManufacturerId = manufacturers[3].Id
                },
                new Car
                {
                    Model = "Civic",
                    Year = 2023,
                    Color = "Red",
                    Price = 24000.00m,
                    ManufacturerId = manufacturers[4].Id
                },
                new Car
                {
                    Model = "CR-V",
                    Year = 2022,
                    Color = "Blue",
                    Price = 30000.00m,
                    ManufacturerId = manufacturers[4].Id
                }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
} 