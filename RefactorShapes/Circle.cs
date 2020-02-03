using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorShapes
{
    public class Circle : IShape
    {
        public readonly double width;
        public Circle(double width)
        {
            this.width = width;
        }
        public string GetName()
        {
            return "Circle";
        }
        public double GetArea()
        {
            return Math.PI * (width / 2) * (width / 2);
        }
        public double GetPerimeter()
        {
            return Math.PI * width;
        }
    }
}
