using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine("******** Original ********");
            Console.WriteLine(Print(shapes));
            Console.WriteLine("******** Refactorizado ********");
            ShapeFacade shapeFacade = new ShapeFacade(shapes);
            Console.WriteLine(shapeFacade.Calcular());
            Console.ReadKey();
        }
        public static string Calcular(List<IShape> Lshapes)
        {
            string sRet = "";
            List<string> LshapesName = new List<string>();

            if (Lshapes.Count > 0)
            {
                for (int i = 0; i < Lshapes.Count; i++)
                {
                    if (i == 0)
                    {
                        LshapesName.Add(Lshapes[i].GetName());
                    }
                    else
                    {
                        bool bExists = true;
                        foreach (string shapename in LshapesName)
                        {
                            if (shapename == Lshapes[i].GetName())
                                bExists = false;
                        }
                        if (bExists)
                            LshapesName.Add(Lshapes[i].GetName());
                    }
                }
            }
            else
            {
                sRet = "Empty list of shapes!";
            }


            return sRet;
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
