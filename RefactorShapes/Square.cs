using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    public class Square : IShape
    {
        private readonly double width;
        public Square(double width)
        {
            this.width = width;
        }
        public string GetName()
        {
            return "Square";
        }
        public double GetArea()
        {
            return width * width;
        }
        public double GetPerimeter()
        {
            return 4 * width;
        }
    }
}
