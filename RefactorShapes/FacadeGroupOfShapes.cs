using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    public class FacadeGroupOfShapes
    {
        private IGroupOfShapes groupOfShapes;

        public FacadeGroupOfShapes(IGroupOfShapes groupOfShapes)
        {
            this.groupOfShapes = groupOfShapes;
        }
        public void AddShape(IShape shape)
        {
            groupOfShapes.Add(shape);
        }
        public string GetTextToPrintOrderShapesDescending()
        { 
            List<string> LsRet = groupOfShapes.GetNameOfShapes();
            List<string> LshapesName = groupOfShapes.GetNameOfShapes();
            List<int> LshapesNumber = groupOfShapes.GetNumberOfShapes();
            List<double> LshapesArea = groupOfShapes.GetAreaOfShapes();
            List<double> LshapesPerimeter = groupOfShapes.GetPerimeterOfShapes();
            List<int> LshapesOrder = groupOfShapes.GetOrderShapesDescending();
            string sRet = "";
            for (int iShapeOrder = 0; iShapeOrder < LshapesOrder.Count; iShapeOrder++)
            {
                sRet += LshapesName[LshapesOrder[iShapeOrder]] + ": " + LshapesNumber[LshapesOrder[iShapeOrder]];
                sRet += ", Area: " + LshapesArea[LshapesOrder[iShapeOrder]].ToString("#.##");
                sRet += ", Perimeter: " + LshapesPerimeter[LshapesOrder[iShapeOrder]].ToString("#.##") + ".\n";
            }
            return sRet;
        }
    }
}
