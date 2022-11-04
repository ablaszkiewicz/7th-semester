using System;
using tsp;
using H.Pipes;
using System.Threading.Tasks;
using System.Threading;
using H.Pipes.Args;
using System.Diagnostics;

namespace tsp_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Client();
            while (true) { }
        }
    }
}
