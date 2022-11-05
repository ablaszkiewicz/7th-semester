using System;
using tsp;
using H.Pipes;
using System.Threading.Tasks;
using System.Threading;
using H.Pipes.Args;
using System.Diagnostics;
using tsp_shared;
using System.Windows.Documents;
using System.Collections.Generic;

namespace tsp_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var client = new Client("tsp-task");
            //client.OnMessageReceived += (message) => Console.WriteLine(message.Text);
            //while (true) { }

            var pointsList1 = new List<int>() { 3, 5, 1, 8, 2, 6, 7, 4, 9 };
            var pointsList2 = new List<int>() { 1, 6, 2, 7, 4, 8, 5, 9, 3 };

            var vertexList1 = new List<Vertex>();
            var vertexList2 = new List<Vertex>();

            foreach(var number in pointsList1)
            {
                vertexList1.Add(new Vertex(number));
            }

            foreach(var number in pointsList2)
            {
                vertexList2.Add(new Vertex(number));
            }

            var cycleA = new Cycle(vertexList1);
            var cycleB = new Cycle(vertexList2);

            

            var mutatedA = PMX.Mutate(cycleA, cycleB);
            var mutatedB = PMX.Mutate(cycleB, cycleA);

            Console.WriteLine(cycleA);
            Console.WriteLine(mutatedA);
            Console.WriteLine();
            Console.WriteLine(cycleB);
            Console.WriteLine(mutatedB);
        }
    }
}
