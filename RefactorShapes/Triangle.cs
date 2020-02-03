using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorShapes
{
    public class Triangle : IShape
    {
        public readonly double width;
        public Triangle(double width)
        {
            this.width = width;
        }
        public string GetName()
        {
            return "Triangle";
        }
        public double GetArea()
        {
            return (Math.Sqrt(3) / 4) * width * width;
        }

        public double GetPerimeter()
        {
            return 3 * width;
        }
    }
}
