using RefactorShapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RefactorShapesTest
{
    public class TriangleTests
    {
        private IShape triangle;

        public TriangleTests()
        {
            // Arrange
            triangle = new Triangle(20);
        }
        [Theory]
        [InlineData(173.2050807568877)]
        public void Triangle_GetArea_Test(double expectedResult)
        {
            // Act
            double result = triangle.GetArea();
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(60)]
        public void Triangle_GetPerimeter_Test(double expectedResult)
        {
            // Act
            double result = triangle.GetPerimeter();
            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
