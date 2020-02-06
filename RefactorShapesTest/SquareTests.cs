using RefactorShapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RefactorShapesTest
{
    public class SquareTests
    {
        private IShape square;

        public SquareTests()
        {
            // Arrange
            square = new Square(20);
        }
        [Theory]
        [InlineData(400)]
        public void Square_GetArea_Test(double expectedResult)
        {
            // Act
            double result = square.GetArea();
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(80)]
        public void Square_GetPerimeter_Test(double expectedResult)
        {
            // Act
            double result = square.GetPerimeter();
            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
