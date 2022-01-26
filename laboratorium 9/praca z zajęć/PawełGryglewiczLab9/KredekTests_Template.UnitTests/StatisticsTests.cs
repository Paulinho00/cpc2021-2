using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KredekTests_Template.UnitTests
{
    public class StatisticsTests
    {

        [Theory]
        [MemberData(nameof(VehicleTestDataGenerator.GetVehiclesFromDataGenerator), MemberType = typeof(VehicleTestDataGenerator))]
        public void CalculateMeanVehicleWorth(List<Vehicle> vehicles, ExpectedStatistics expectedMeanWorth)
        {
            //Arrange
            var calculator = new StatisticsCalculator();

            //Act
            decimal result = calculator.CalculateMeanWorth(vehicles);


            //Assert
            Assert.Equal(expectedMeanWorth.ExpectedMeanWorth, result);
        }

        [Fact]
        public void CalculateVehicleMeanWorthNull()
        {
            //Arrange
            var calculator = new StatisticsCalculator();

            //Act
            Action act = () => calculator.CalculateMeanWorth(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
