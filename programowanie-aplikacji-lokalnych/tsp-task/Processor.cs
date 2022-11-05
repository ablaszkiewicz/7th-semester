using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsp_task
{
    public class Processor
    {
        public Processor()
        {

        }

        public async Task Process()
        {
            for (int i = 0; i < 100000000; i++)
            {
                var sum = 123 + i;
            }

            Console.WriteLine("Got result");
        }
    }
}
