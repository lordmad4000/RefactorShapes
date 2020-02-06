using RefactorShapes;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace RefactorShapesTest
{
    public class GroupOfShapesTests
    {
        private readonly ITestOutputHelper output;
        private GroupOfShapes groupOfShapes;

        public GroupOfShapesTests(ITestOutputHelper output)
        {
            this.output = output;
            // Arrange
            List<IShape> shapes = new List<IShape>();
            shapes.Add(new Triangle(10));
            shapes.Add(new Circle(20));
            shapes.Add(new Square(20));
            shapes.Add(new Circle(10));
            shapes.Add(new Square(5));
            shapes.Add(new Triangle(25));
            shapes.Add(new Square(10));
            shapes.Add(new Circle(30));
            shapes.Add(new Square(30));
            shapes.Add(new Triangle(30));
            shapes.Add(new Circle(40));
            shapes.Add(new Square(40));
            shapes.Add(new Circle(5));
            shapes.Add(new Triangle(5));
            shapes.Add(new Circle(2));
            shapes.Add(new Triangle(10));
            shapes.Add(new Circle(8));
            shapes.Add(new Triangle(20));
            groupOfShapes = new GroupOfShapes(shapes);
            output.WriteLine("Fin del constructor");
        }
        [Theory]
        [InlineData("Triangle,Circle,Square")]
        public void GroupOfShapes_GetNameOfShapes_Test(string expectedResult)
        {
            // Act
            var ArrayResult = groupOfShapes.GetNameOfShapes().ToArray();
            string result = string.Join(",", string.Join(",", ArrayResult));
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData("6,7,5")]
        public void GroupOfShapes_GetNumberOfShapes_Test(string expectedResult)
        {
            // Act
            var ArrayResult = groupOfShapes.GetNumberOfShapes().ToArray();
            string result = string.Join(",", string.Join(",", ArrayResult));
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData("930,9773090682714,2429,2365193883074,3025")]
        public void GroupOfShapes_GetAreaOfShapes_Test(string expectedResult)
        {
            // Act
            var ArrayResult = groupOfShapes.GetAreaOfShapes().ToArray();
            string result = string.Join(",", string.Join(",", ArrayResult));
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData("300,361,2831551628261,420")]
        public void GroupOfShapes_GetPerimeterOfShapes_Test(string expectedResult)
        {
            // Act
            var ArrayResult = groupOfShapes.GetPerimeterOfShapes().ToArray();
            string result = string.Join(",", string.Join(",", ArrayResult));
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData("1,0,2")]
        public void GroupOfShapes_GetOrderOfShapes_Test(string expectedResult)
        {
            // Arrange
            // Act
            var ArrayResult = groupOfShapes.GetOrderShapesDescending().ToArray();
            string result = string.Join(",", string.Join(",", ArrayResult));
            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
