using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace proj.Windows
{
    public class ListOrdersWindow : IWindow
    {
        private WindowsManager _windowsManager;

        public ListOrdersWindow(WindowsManager windowsManager)
        {
            this._windowsManager = windowsManager;
        }

        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("--- Orders list ---");

            using var db = new MyContext();
            var orders = db.Orders
                .Include(o => o.ItemsOrders)
                .ThenInclude(io => io.Item)
                .ToList();

            foreach(var order in orders)
            {
                Console.WriteLine($"Order with ID={order.Id}");

                foreach(var itemOrder in order.ItemsOrders)
                {
                    Console.WriteLine($"- {itemOrder.Item.Name} x {itemOrder.Quantity}");
                }

                Console.WriteLine();
            }

            Options();
        }

        private void Options()
        {
            Console.WriteLine();
            Console.WriteLine("Main menu  [M]");
            var result = Console.ReadKey();

            if (result.Key == ConsoleKey.M)
            {
                _windowsManager.SwitchWindow(new MainWindow(_windowsManager));
            }
        }
    }
}

