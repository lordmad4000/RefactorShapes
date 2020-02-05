using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    public interface IGroupOfShapes
    {
        void Add(IShape shape);
        List<string> GetNameOfShapes();
        List<int> GetNumberOfShapes();
        List<double> GetAreaOfShapes();
        List<double> GetPerimeterOfShapes();
        List<int> GetOrderShapesDescending();
    }

}
