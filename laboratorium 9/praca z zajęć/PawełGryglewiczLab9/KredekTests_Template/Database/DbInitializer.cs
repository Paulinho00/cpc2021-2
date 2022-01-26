using System.Linq;

namespace KredekTests_Template
{
    internal class DbInitializer
    {
        public static void Initialize(VehicleDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Vehicles.Any())
            {
                return;
            }


            var vehicles = new[]
            {
                new Vehicle()
                {
                    Manufacturer = "VW",
                    Model = "Golf",
                    Worth = 5000,
                    YearOfProduction = 2000
                },
                new Vehicle()
                {
                    Manufacturer = "Renault",
                    Model = "Megane",
                    Worth = 7000,
                    YearOfProduction = 2003
                },
                new Vehicle()
                {
                    Manufacturer = "Honda",
                    Model = "Civic",
                    Worth = 4000,
                    YearOfProduction = 1999
                }

            };

            foreach (var vehicle in vehicles)
            {
                context.Vehicles.Add(vehicle);
            }

            context.SaveChanges();
        }
    }
}