using H.Pipes;
using H.Pipes.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsp_shared
{
    public class Client
    {
        public Action<MyMessage> OnMessageReceived;
        public Client(string pipeName)
        {
            Task.Run(async () => await StartClient(pipeName));
        }

        public async Task StartClient(string pipeName)
        {
            await using var client = new PipeClient<MyMessage>(pipeName);
            client.MessageReceived += MessageReceivedFromServer;

            await client.ConnectAsync();
            Console.WriteLine("Connected");
            await Task.Delay(Timeout.InfiniteTimeSpan);
        }

        private void MessageReceivedFromServer(object sender, ConnectionMessageEventArgs<MyMessage> args)
        {
            OnMessageReceived.Invoke(args.Message);
        }
    }
}
