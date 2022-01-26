using System;
using Xunit;

namespace KredekTests_Template.UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Subtract5And2ShouldReturn3()
        {
            //Arrange
            //Act
            double result = Calculator.Subtract(5, 2);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Multiply5By10ShouldReturn50()
        {
            double result = Calculator.Multiply(5, 10);

            Assert.Equal(50, result);
        }


        [Theory]
        [InlineData(4, 3, 7)]
        [InlineData(6, 6, 12)]
        [InlineData(7, 8, 15)]
        public void AddSimpleValuesCalculate(double x, double y, double expected)
        {
            //Arrange

            //Act
            double result = Calculator.Add(x, y);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3,0,0)]
        public void DivideSimpleValuesCalculate(double x, double y, double expected)
        {
            //Arrange

            //Act
            double result = Calculator.Divide(x, y);

            //Assert
            Assert.Equal(expected, result);
        }
    }


}
