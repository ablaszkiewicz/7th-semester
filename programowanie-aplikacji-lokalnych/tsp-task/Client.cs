using H.Pipes.Args;
using H.Pipes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tsp;

namespace tsp_task
{
    public class Client
    {
        public Client()
        {
            Task.Run(async () => await StartClient());
        }

        public async Task StartClient()
        {
            await using var client = new PipeClient<MyMessage>("tsp-task");
            client.MessageReceived += MessageReceivedFromServer;

            await client.ConnectAsync();
            Console.WriteLine("Connected");
            await Task.Delay(Timeout.InfiniteTimeSpan);
        }

        private void MessageReceivedFromServer(object sender, ConnectionMessageEventArgs<MyMessage> args)
        {
            Console.WriteLine($"Client: {args.Message.Text}");
        }
    }
}
