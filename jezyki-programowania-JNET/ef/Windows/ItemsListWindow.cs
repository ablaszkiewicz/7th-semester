using System;
using System.Linq;

namespace proj.Windows
{
    public class ItemsListWindow : IWindow
    {
        private WindowsManager _windowsManager;

        public ItemsListWindow(WindowsManager windowsManager)
        {
            this._windowsManager = windowsManager;
        }

        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("--- Items list window ---");
            using var db = new MyContext();
            var items = db.Items.OrderBy(item => item.Count).ToList();

           
            foreach(var item in items)
            {
                Console.WriteLine($"{item.Id}:\t{item.Name}\t{item.Description}\t{item.Count}");

            }

            Options();
        }

        private void Options()
        {
            Console.WriteLine();
            Console.WriteLine("Set item count       [S]");
            Console.WriteLine("Add item window      [A]");
            Console.WriteLine("Main menu            [M]");
            var result = Console.ReadKey();

            if (result.Key == ConsoleKey.A)
            {
                _windowsManager.SwitchWindow(new AddItemWindow(_windowsManager));
            }
            if (result.Key == ConsoleKey.M)
            {
                _windowsManager.SwitchWindow(new MainWindow(_windowsManager));
            }
            if (result.Key == ConsoleKey.S)
            {
                SetItemCount();
            }
        }

        private void SetItemCount()
        {
            using var db = new MyContext();
            Console.Write("ID of item to set count: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Count: ");
            var count = int.Parse(Console.ReadLine());

            var item = db.Items.Where(item => item.Id == id).First();
            item.Count = count;
            db.SaveChanges();
            _windowsManager.SwitchWindow(new ItemsListWindow(_windowsManager));
        }
    }
}

