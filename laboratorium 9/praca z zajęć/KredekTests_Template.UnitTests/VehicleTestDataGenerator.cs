using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KredekTests_Template.UnitTests
{
    public class VehicleTestDataGenerator
    {
        public static IEnumerable<object[]> GetVehiclesFromDataGenerator()
        {
            yield return new object[]
            {
                new List<Vehicle>()
                {

                    new Vehicle
                    {
                        Manufacturer = "VW",
                        Model = "Golf",
                        Worth = 2000,
                        YearOfProduction = 2000,
                        Power = 75
                    },
                    new Vehicle
                    {
                        Manufacturer = "Renault",
                        Model = "Megane",
                        Worth = 3000,
                        YearOfProduction = 2003,
                        Power = 100
                    },
                    new Vehicle
                    {
                        Manufacturer = "Honda",
                        Model = "Civic",
                        Worth = 6000,
                        YearOfProduction = 1999,
                        Power = 130
                    }
                },
                new ExpectedStatistics(3666.67m)
            };
            yield return new object[]
            {
                new List<Vehicle>()
                {

                    new Vehicle
                    {
                        Manufacturer = "VW",
                        Model = "Golf",
                        Worth = 2555.25m,
                        YearOfProduction = 2002,
                        Power = 75
                    }
                },
                new ExpectedStatistics(2555.25m)
            };
            yield return new object[]
            {
                new List<Vehicle>()
                {
                    new Vehicle
                    {
                        Manufacturer = "Renault",
                        Model = "Megane",
                        Worth = 4000,
                        YearOfProduction = 2007,
                        Power = 105
                    },
                    new Vehicle
                    {
                        Manufacturer = "Honda",
                        Model = "Civic",
                        Worth = 6000,
                        YearOfProduction = 2004,
                        Power = 110
                    }
                },
                new ExpectedStatistics(5000.00m)
            };
            yield return new object[]
            {
               new List<Vehicle>
               {
                   new Vehicle()
               },
                new ExpectedStatistics(0)
            };

        }
    }
}
