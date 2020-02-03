using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    public interface IShape
    {
        string GetName();
        double GetArea();
        double GetPerimeter();
    }
}
