using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsp_shared
{
    public class Vertex
    {
        public Vector2 Point { get; set; }
        public int Number { get; set; }

        public Vertex(int number)
        {
            Number = number;
        }

        public Vertex(int number, Vector2 point)
        {
            Number = number;
            Point = point;
        }
    }
}
