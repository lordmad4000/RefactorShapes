using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    public class GroupOfShapes : IGroupOfShapes
    {
        private List<IShape> Lshapes;
        public GroupOfShapes(List<IShape> Lshapes)
        {
            this.Lshapes = Lshapes;
        }
        public void Add(IShape shape)
        {
            Lshapes.Add(shape);
        }
        public List<string> GetNameOfShapes()
        {
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
                        {
                            LshapesName.Add(Lshapes[i].GetName());
                        }
                    }
                }
            }
            return LshapesName;
        }
        public List<int> GetNumberOfShapes()
        {
            List<int> LshapesNumber = new List<int>();
            List<string> LshapesName = GetNameOfShapes();
            if (Lshapes.Count > 0)
            {
                for (int iShapeName = 0; iShapeName < LshapesName.Count; iShapeName++)
                {
                    LshapesNumber.Add(0);
                    for (int iShapes = 0; iShapes < Lshapes.Count; iShapes++)
                    {
                        if (LshapesName[iShapeName] == Lshapes[iShapes].GetName())
                        {
                            LshapesNumber[iShapeName]++;
                        }
                    }
                }
            }
            return LshapesNumber;
        }
        public List<double> GetAreaOfShapes()
        {
            List<double> LshapesArea = new List<double>();
            List<string> LshapesName = GetNameOfShapes();
            if (Lshapes.Count > 0)
            {
                for (int iShapeName = 0; iShapeName < LshapesName.Count; iShapeName++)
                {
                    LshapesArea.Add(0);
                    for (int iShapes = 0; iShapes < Lshapes.Count; iShapes++)
                    {
                        if (LshapesName[iShapeName] == Lshapes[iShapes].GetName())
                        {
                            LshapesArea[iShapeName] += Lshapes[iShapes].GetArea();
                        }
                    }
                }
            }
            return LshapesArea;
        }
        public List<double> GetPerimeterOfShapes()
        {
            List<double> LshapesPerimeter = new List<double>();
            List<string> LshapesName = GetNameOfShapes();
            if (Lshapes.Count > 0)
            {
                for (int iShapeName = 0; iShapeName < LshapesName.Count; iShapeName++)
                {
                    LshapesPerimeter.Add(0);
                    for (int iShapes = 0; iShapes < Lshapes.Count; iShapes++)
                    {
                        if (LshapesName[iShapeName] == Lshapes[iShapes].GetName())
                        {
                            LshapesPerimeter[iShapeName] += Lshapes[iShapes].GetPerimeter();
                        }
                    }
                }
            }
            return LshapesPerimeter;
        }
        public List<int> GetOrderShapesDescending()
        {
            List<int> LshapesOrder = new List<int>();
            List<int> LshapesNumber = GetNumberOfShapes();
            int[] sortedList = LshapesNumber.ToArray().OrderByDescending(i => i).ToArray();

            for (int iShapeOrder = 0; iShapeOrder < LshapesNumber.Count; iShapeOrder++)
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
                            LshapesOrder.Add(iShapeNumber);

                            //LshapesOrder[iShapeOrder] = iShapeNumber;
                        }
                    }
                }
            }
            return LshapesOrder;
        }
    }
}
