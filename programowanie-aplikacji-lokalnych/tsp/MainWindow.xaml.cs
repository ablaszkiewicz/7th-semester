using H.Pipes;
using H.Pipes.Args;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tsp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PipeServer<MyMessage> _pipe;
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(async () => await Server());
        }

        public async Task Server()
        {
            _pipe = new PipeServer<MyMessage>("tsp-task");
            _pipe.MessageReceived += MessageReceivedFromClient;
            await _pipe.StartAsync();
            await Task.Delay(Timeout.InfiniteTimeSpan);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("C:\\Users\\Aleksander\\Desktop\\7th-semester\\programowanie-aplikacji-lokalnych\\tsp-task\\bin\\Debug\\net6.0-windows\\tsp-task.exe", "Wysylam message");
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            _pipe.WriteAsync(new MyMessage
            {
                Text = "Welcome!"
            });
        }

        private void MessageReceivedFromClient(object sender, ConnectionMessageEventArgs<MyMessage> args)
        {
            Trace.WriteLine($"Client: {args.Message}");
        }
    }

    [Serializable]
    public class MyMessage
    {
        public string Text;
    }
}
