using RefactorShapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RefactorShapesTest
{
    public class FacadeGroupOfShapes_Tests
    {
        private FacadeGroupOfShapes facadeGroupOfShapes;
        public FacadeGroupOfShapes_Tests()
        {
            // Arrange
            facadeGroupOfShapes = new FacadeGroupOfShapes(new GroupOfShapes(new List<IShape>()));
            facadeGroupOfShapes.AddShape(new Triangle(10));
            facadeGroupOfShapes.AddShape(new Circle(20));
            facadeGroupOfShapes.AddShape(new Square(20));
            facadeGroupOfShapes.AddShape(new Circle(10));
            facadeGroupOfShapes.AddShape(new Square(5));
            facadeGroupOfShapes.AddShape(new Triangle(25));
            facadeGroupOfShapes.AddShape(new Square(10));
            facadeGroupOfShapes.AddShape(new Circle(30));
            facadeGroupOfShapes.AddShape(new Square(30));
            facadeGroupOfShapes.AddShape(new Triangle(30));
            facadeGroupOfShapes.AddShape(new Circle(40));
            facadeGroupOfShapes.AddShape(new Square(40));
            facadeGroupOfShapes.AddShape(new Circle(5));
            facadeGroupOfShapes.AddShape(new Triangle(5));
            facadeGroupOfShapes.AddShape(new Circle(2));
            facadeGroupOfShapes.AddShape(new Triangle(10));
            facadeGroupOfShapes.AddShape(new Circle(8));
            facadeGroupOfShapes.AddShape(new Triangle(20));
        }
        [Theory]
        [InlineData("Circle: 7, Area: 2429,24, Perimeter: 361,28.\n" +
                    "Triangle: 6, Area: 930,98, Perimeter: 300.\n"+
                    "Square: 5, Area: 3025, Perimeter: 420.\n")]
        public void FacadeGroupOfShapes_GetTextToPrintOrderShapesDescending_Tests(string expectedResult)
        {
            // Act
            string result = facadeGroupOfShapes.GetTextToPrintOrderShapesDescending();
            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
