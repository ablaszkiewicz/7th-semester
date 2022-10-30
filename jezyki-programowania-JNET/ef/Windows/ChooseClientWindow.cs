using System;
using System.Linq;

namespace proj.Windows
{
    public class ChooseClientWindow : IWindow
    {
        private WindowsManager _windowsManager;
        private int page = 0;

        public ChooseClientWindow(WindowsManager windowsManager)
        {
            this._windowsManager = windowsManager;
        }

        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("--- Choose active client ---");
            DisplayClients();
            _windowsManager.SwitchWindow(new MainWindow(_windowsManager));
        }

        private void DisplayClients()
        {
            using var db = new MyContext();
            var clients = db.Clients.Skip(page * 2).Take(2).ToList();
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id}\t{client.Name}\t{client.Address}");
            }

            Console.Write("ID of chosen client: ");
            var id = int.Parse(Console.ReadLine());
            var chosenClient = clients.Find(client => client.Id == id);
            if (chosenClient != null)
            {
                _windowsManager.ActiveClient = chosenClient;
                _windowsManager.SwitchWindow(new MainWindow(_windowsManager));
            }
            else
            {
                _windowsManager.SwitchWindow(new ChooseClientWindow(_windowsManager));
            }
        }


    }
}

