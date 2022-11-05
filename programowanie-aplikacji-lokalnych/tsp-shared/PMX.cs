using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsp_shared
{
    public class PMX
    {
        public static Cycle FirstStep(Cycle cycleA, Cycle cycleB)
        {
            var random = new Random();
            var resultList = new List<Vertex>(new Vertex[cycleA.Length]);
            var resultCycle = new Cycle(resultList);

            var randomLength = random.Next(1, cycleA.Length-1);
            var randomPosition = random.Next(0, cycleA.Length - randomLength);

            for (int i = 0; i < randomLength; i++)
            {
                resultList[randomPosition + i] = cycleA.GetVertexAt(randomPosition + i);
            }

            return resultCycle;
        }

        public static Cycle SecondStep(Cycle cycleA, Cycle cycleB, Cycle midCycle)
        {
            for (int i = 0; i < cycleB.Length; i++)
            {
                var vertex = cycleB.GetVertexAt(i);

                if(midCycle.ContainsVertex(vertex))
                {
                    continue;
                }
                midCycle.SetNextEmptyVertex(vertex);
            }

            return midCycle;
        }

        public static Cycle Mutate(Cycle cycleA, Cycle cycleB)
        {
            var step1 = FirstStep(cycleA, cycleB);
            var step2 = SecondStep(cycleA, cycleB, step1);

            return step2;
        }
    }
}
