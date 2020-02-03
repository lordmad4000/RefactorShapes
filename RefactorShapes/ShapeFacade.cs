using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactorShapes
{
    public class ShapeFacade
    {
        private List<IShape> Lshapes;
        private List<string> LshapesName = new List<string>();
        private List<int> LshapesNumber = new List<int>();
        private List<double> LshapesArea = new List<double>();
        private List<double> LshapesPerimeter = new List<double>();
        private List<int> LshapesOrder = new List<int>();
        public ShapeFacade(List<IShape> Lshapes)
        {
            this.Lshapes = Lshapes;
        }
        public string Calcular()
        {
            string sRet = "";
            sRet = GetNameOfShapes();
            if (sRet == "")
            {
                CalculateTotalOfShapes();
                CalculateTotalAreaOfShapes();
                CalculateTotalPerimeterOfShapes();
                OrderShapes();
                for (int iShapeOrder = 0; iShapeOrder < LshapesOrder.Count; iShapeOrder++)
                {
                    sRet += LshapesName[LshapesOrder[iShapeOrder]] + ": " + LshapesNumber[LshapesOrder[iShapeOrder]];
                    sRet += ", Area: " + LshapesArea[LshapesOrder[iShapeOrder]].ToString("#.##");
                    sRet += ", Perimeter: " + LshapesPerimeter[LshapesOrder[iShapeOrder]].ToString("#.##") + ".\n";
                }
            }
            return sRet;
        }
        private string GetNameOfShapes()
        {
            string sRet = "";

            if (Lshapes.Count > 0)
            {
                for (int i = 0; i < Lshapes.Count; i++)
                {
                    if (i == 0)
                    {
                        LshapesName.Add(Lshapes[i].GetName());
                        LshapesNumber.Add(0);
                        LshapesArea.Add(0);
                        LshapesPerimeter.Add(0);
                        LshapesOrder.Add(-1);
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
                        {
                            LshapesName.Add(Lshapes[i].GetName());
                            LshapesNumber.Add(0);
                            LshapesArea.Add(0);
                            LshapesPerimeter.Add(0);
                            LshapesOrder.Add(-1);
                        }
                    }
                }
            }
            else
            {
                sRet = "Empty list of shapes!";
            }
            return sRet;
        }
        private void CalculateTotalOfShapes()
        {
            if (Lshapes.Count > 0)
            {
                for (int iShapeName = 0; iShapeName < LshapesName.Count; iShapeName++)
                {
                    for (int iShapes = 0; iShapes < Lshapes.Count; iShapes++)
                    {
                        if (LshapesName[iShapeName] == Lshapes[iShapes].GetName())
                        {
                            LshapesNumber[iShapeName]++;
                        }
                    }
                }
            }
        }
        private void CalculateTotalAreaOfShapes()
        {
            if (Lshapes.Count > 0)
            {
                for (int iShapeName = 0; iShapeName < LshapesName.Count; iShapeName++)
                {
                    for (int iShapes = 0; iShapes < Lshapes.Count; iShapes++)
                    {
                        if (LshapesName[iShapeName] == Lshapes[iShapes].GetName())
                        {
                            LshapesArea[iShapeName] += Lshapes[iShapes].GetArea();
                        }
                    }
                }
            }
        }
        private void CalculateTotalPerimeterOfShapes()
        {
            if (Lshapes.Count > 0)
            {
                for (int iShapeName = 0; iShapeName < LshapesName.Count; iShapeName++)
                {
                    for (int iShapes = 0; iShapes < Lshapes.Count; iShapes++)
                    {
                        if (LshapesName[iShapeName] == Lshapes[iShapes].GetName())
                        {
                            LshapesPerimeter[iShapeName] += Lshapes[iShapes].GetPerimeter();
                        }
                    }
                }
            }
        }
        private void OrderShapes()
        {
            int[] sortedList = LshapesNumber.ToArray().OrderByDescending(i => i).ToArray();

            for (int iShapeOrder = 0; iShapeOrder < LshapesOrder.Count; iShapeOrder++)
            {
                for (int iShapeNumber = 0; iShapeNumber < LshapesNumber.Count; iShapeNumber++)
                {
                    if (LshapesNumber[iShapeNumber] == sortedList[iShapeOrder])
                    {
                        bool bExists = false;
                        for (int iShapeOrder1 = 0; iShapeOrder1 < LshapesOrder.Count; iShapeOrder1++)
                        {
                            if (LshapesOrder[iShapeOrder1] == iShapeNumber)
                            {
                                bExists = true;
                            }
                        }
                        if (!bExists)
                        {
                            LshapesOrder[iShapeOrder] = iShapeNumber;
                        }
                    }
                }
            }
        }

    }
}
