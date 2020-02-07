using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    class Program
    {
        public class Shapes            
        {
            public System.Collections.Generic.IEnumerable<IShape> NextShape
            {
                get
                {
                    yield return new Triangle(10);
                    yield return new Circle(20);
                    yield return new Square(20);
                    yield return new Circle(10);
                    yield return new Square(5);
                    yield return new Triangle(25);
                    yield return new Square(10);
                    yield return new Circle(30);
                    yield return new Square(30);
                    yield return new Triangle(30);
                    yield return new Circle(40);
                    yield return new Square(40);
                    yield return new Circle(5);
                    yield return new Triangle(5);
                    yield return new Circle(2);
                    yield return new Triangle(10);
                    yield return new Circle(8);
                    yield return new Triangle(20);
                }
            }
        }
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();
            FacadeGroupOfShapes facadeGroupOfShapes = new FacadeGroupOfShapes(new GroupOfShapes(new List<IShape>()));
            foreach (IShape ishape in new Shapes().NextShape)
            {
                shapes.Add(ishape);
                facadeGroupOfShapes.AddShape(ishape);
            }
            Console.WriteLine("************ Original ***********");
            Console.WriteLine(Print(shapes) + "\n");
            Console.WriteLine("******** Refactorizado 1 ********");
            FacadeListOfShapes shapeFacade = new FacadeListOfShapes(shapes);            
            Console.WriteLine(shapeFacade.Calcular());
            Console.WriteLine("******** Refactorizado 2 ********");
            Console.WriteLine(facadeGroupOfShapes.GetTextToPrintOrderShapesDescending());
            Console.ReadKey();
        }
        public static String Print(List<IShape> shapes)
        {
            String returnString = "";
            String squareString = "";
            String circlesString = "";
            String trianglesString = "";

            if (shapes.Count == 0)
            {
                returnString = "Empty list of shapes!";
            }
            else
            {
                int numberSquares = 0;
                int numberCircles = 0;
                int numberTriangles = 0;

                double areaSquares = 0;
                double areaCircles = 0;
                double areaTriangles = 0;

                double perimeterSquares = 0;
                double perimeterCircles = 0;
                double perimeterTriangles = 0;

                // Compute calculations
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].GetType() == typeof(Square))
                    {
                        numberSquares++;
                        areaSquares += shapes[i].GetArea();
                        perimeterSquares += shapes[i].GetPerimeter();
                    }
                    if (shapes[i].GetType() == typeof(Circle))
                    {
                        numberCircles++;
                        areaCircles += shapes[i].GetArea();
                        perimeterCircles += shapes[i].GetPerimeter();
                    }
                    if (shapes[i].GetType() == typeof(Triangle))
                    {
                        numberTriangles++;
                        areaTriangles += shapes[i].GetArea();
                        perimeterTriangles += shapes[i].GetPerimeter();
                    }
                }

                // Get texts to print.
                if (numberSquares > 0)
                {
                    squareString = "Squares: " + numberSquares + ", Area: " + areaSquares.ToString("#.##") + ", Perimeter: " + perimeterSquares.ToString("#.##") + ".";
                }

                if (numberCircles > 0)
                {
                    circlesString = "Circles: " + numberCircles + ", Area: " + areaCircles.ToString("#.##") + ", Perimeter: " + perimeterCircles.ToString("#.##") + ".";
                }

                if (numberTriangles > 0)
                {
                    trianglesString = "Triangles: " + numberTriangles + ", Area: " + areaTriangles.ToString("#.##") + ", Perimeter: " + perimeterTriangles.ToString("#.##") + ".";
                }


                //Order the printed results
                if (numberSquares >= numberCircles && numberSquares >= numberTriangles)
                {
                    if (numberCircles >= numberTriangles)
                    {
                        returnString = squareString + "\n" + circlesString + "\n" + trianglesString;
                    }
                    else
                    {
                        returnString = squareString + "\n" + trianglesString + "\n" + circlesString;
                    }
                }
                else if (numberTriangles >= numberCircles && numberTriangles >= numberSquares)
                {
                    if (numberCircles >= numberSquares)
                    {
                        returnString = trianglesString + "\n" + circlesString + "\n" + squareString;
                    }
                    else
                    {
                        returnString = trianglesString + "\n" + squareString + "\n" + circlesString;
                    }
                }
                else
                {
                    if (numberTriangles >= numberSquares)
                    {
                        returnString = circlesString + "\n" + trianglesString + "\n" + squareString;
                    }
                    else
                    {
                        returnString = circlesString + "\n" + squareString + "\n" + trianglesString;
                    }
                }
            }

            return returnString.Trim();
        }
    }
}
