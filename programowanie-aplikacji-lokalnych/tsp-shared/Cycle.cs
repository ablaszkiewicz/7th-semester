using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsp_shared
{
    public class Cycle
    {
        public List<Vertex> Vertexes { get; set; }

        public int Length { get => Vertexes.Count; }

        public Cycle(List<Vertex> vertexes)
        {
            Vertexes = vertexes;
        }

        public override string ToString()
        {
            var concated = "";

            foreach (var vertex in Vertexes)
            {
                if(vertex == null)
                {
                    concated += $"  ";
                }
                else
                {
                    concated += $"{vertex.Number} ";
                }
                
            }

            return concated;
        }

        public Vertex GetVertexAt(int position)
        {
            return Vertexes[position];
        }

        private bool ContainsVertexWithNumber(int number)
        {
            return Vertexes.Any(vertex => vertex != null && vertex.Number == number);
        }

        public bool ContainsVertex(Vertex vertex)
        {
            return ContainsVertexWithNumber(vertex.Number);
        }

        public void SetNextEmptyVertex(Vertex vertex)
        {
            for (int i = 0; i < Vertexes.Count; i++)
            {
                if (Vertexes[i] == null)
                {
                    Vertexes[i] = vertex;
                    return;
                }
            }
        }
    }
}
