using RefactorShapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RefactorShapesTest
{
    public class CircleTests
    {
        private IShape circle;

        public CircleTests()
        {
            // Arrange
            circle = new Circle(20);
        }
        [Theory]
        [InlineData(314.1592653589793)]
        public void Circle_GetArea_Test(double expectedResult)
        {
            // Act
            double result = circle.GetArea();
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(62.83185307179586)]
        public void Circle_GetPerimeter_Test(double expectedResult)
        {
            // Act
            double result = circle.GetPerimeter();
            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
