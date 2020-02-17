using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorShapes
{
    public class GroupOfShapes : IGroupOfShapes
    {
        private Dictionary<IShape, string> Dshapes;
        public GroupOfShapes(List<IShape> Lshapes)
        {
            this.Dshapes = Lshapes.ToDictionary( x => x, x => x.GetName());
        }
        public void Add(IShape shape)
        {
            Dshapes.Add(shape, shape.GetName());
        }
        public List<string> GetNameOfShapes()
        {
            List<string> LshapesName = new List<string>();
            if (Dshapes.Count > 0)
            {
                LshapesName = Dshapes.Values.Distinct()
                                            .ToList<string>();                
            }
            return LshapesName;
        }
        public List<int> GetNumberOfShapes()
        {
            List<int> LshapesNumber = new List<int>();
            if (Dshapes.Count > 0)
            {
                LshapesNumber = Dshapes.Values.GroupBy(x => x)
                                              .Select(y => new { Key = y.Key, Count = y.Count() })
                                              .ToDictionary(x => x.Key, x => x.Count).Values
                                              .ToList();
            }
            return LshapesNumber;
        }
        public List<double> GetAreaOfShapes()
        {
            List<double> LshapesArea = new List<double>();
            if (Dshapes.Count > 0)
            {

                LshapesArea = Dshapes.GroupBy(x => x.Value)
                                .Select(n => new
                                {
                                    Key = n.Key,
                                    Area = n.Sum(c => c.Key.GetArea()),
                                })
                                .ToDictionary(r => r.Key, r => r.Area).Values
                                .ToList();
            }
            return LshapesArea;
        }
        public List<double> GetPerimeterOfShapes()
        {
            List<double> LshapesPerimeter = new List<double>();
            if (Dshapes.Count > 0)
            {
                LshapesPerimeter = Dshapes.GroupBy(x => x.Value)
                                .Select(n => new
                                {
                                    Key = n.Key,
                                    Perimeter = n.Sum(c => c.Key.GetPerimeter()),
                                })
                                .ToDictionary(r => r.Key, r => r.Perimeter).Values
                                .ToList();
            }
            return LshapesPerimeter;
        }
        public List<int> GetOrderShapesDescending()
        {
            List<int> LshapesOrder = new List<int>();
            if (Dshapes.Count > 0)
            {

                LshapesOrder = Dshapes.Values.GroupBy(x => x)
                                             .Select((y, i) => new { Key = i, Count = y.Count() })
                                             .OrderByDescending(c => c.Count).ToDictionary(r => r.Key, r => r.Count).Keys
                                             .ToList();
            }
            return LshapesOrder;
        }
    }
}
