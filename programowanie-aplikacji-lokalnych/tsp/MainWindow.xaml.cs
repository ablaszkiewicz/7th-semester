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
using tsp_shared;

namespace tsp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PipeServer<MyMessage> _pipe;
        private double minX;
        private double minY;
        private double maxX;
        private double maxY;
        private Cycle cycle;
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(async () => await Server());

            var vertexes = Reader.GetVertexesFromFile("C:\\Users\\Aleksander\\Downloads\\wi29.tsp");
            cycle = new Cycle(vertexes);
            minX = cycle.GetMinX();
            minY = cycle.GetMinY();
            maxX = cycle.GetMaxX();
            maxY = cycle.GetMaxY();
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
            Process.Start("C:\\Users\\Aleksander\\Desktop\\7th-semester\\programowanie-aplikacji-lokalnych\\tsp-task\\bin\\Debug\\net6.0-windows\\tsp-task.exe");
            _pipe.ClientConnected += (a, b) =>
            {
                _pipe.WriteAsync(new MyMessage { Cycle = cycle });
            };
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MessageReceivedFromClient(object sender, ConnectionMessageEventArgs<MyMessage> args)
        {
            ;
            Application.Current.Dispatcher.Invoke(() => DrawCycle(args.Message.Cycle));
        }

        public Cycle CreateRandomCycle()
        {
            var random = new Random();
            var vertexes = new List<Vertex>();

            for (int i = 0; i < 10; i++)
            {
                var x = random.Next(0, 400);
                var y = random.Next(0, 400);
                vertexes.Add(new Vertex(0, new Vector2(x, y)));
            }

            return new Cycle(vertexes);
        }

        public void DrawCycle(Cycle cycle)
        {
            MyCanvas.Children.Clear();

            for (int i = 0; i < cycle.Length; i++)
            {
                var currentVertex = cycle.Vertexes[i];
                var nextVertex = cycle.Vertexes[(i + 1) % cycle.Length];

                DrawLine(currentVertex.Point, nextVertex.Point);
            }

            foreach(var vertex in cycle.Vertexes)
            {
                DrawPoint(vertex.Point);
            }
        }

        private void DrawLine(Vector2 pointA, Vector2 pointB)
        {
            var line = new Line();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 2;

            line.X1 = ClampXToScreen(pointA.X);
            line.Y1 = ClampYToScreen(pointA.Y);

            line.X2 = ClampXToScreen(pointB.X);
            line.Y2 = ClampYToScreen(pointB.Y);

            MyCanvas.Children.Add(line);
        }

        private void DrawPoint(Vector2 point)
        {
            var ellipse = new Ellipse();
            var radius = 8;
            ellipse.Fill = Brushes.Red;
            ellipse.Width = radius;
            ellipse.Height = radius;
            var x = ClampXToScreen(point.X) - (radius / 2);
            var y = ClampYToScreen(point.Y) - (radius / 2);

            ellipse.Margin = new Thickness(x, y, 0, 0);
            MyCanvas.Children.Add(ellipse);
        }

        private double ClampXToScreen(double x)
        {
            var val = Utilities.StrangeClamp(x, minX, maxX, (double)0, MyCanvas.ActualWidth);
            ;
            return val;
        }
        
        private double ClampYToScreen(double y)
        {
            return Utilities.StrangeClamp(y, minY, maxY, (double)0, MyCanvas.ActualHeight);
        }
    }
}
