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
                Console.WriteLine($"Order with ID={order.Id}  | Accepted: {order.Accepted}");

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
            Console.WriteLine("Main menu    [M]");
            Console.WriteLine("Accept order [A]");
            var result = Console.ReadKey();

            if (result.Key == ConsoleKey.M)
            {
                _windowsManager.SwitchWindow(new MainWindow(_windowsManager));
            }
            if (result.Key == ConsoleKey.A)
            {
                AcceptOrder();
            }
        }

        private void AcceptOrder()
        {
            using var db = new MyContext();
            Console.Write("Provide order ID: ");
            var orderId = int.Parse(Console.ReadLine());

            var order = db.Orders
                .Where(o => o.Id == orderId)
                .Include(o => o.ItemsOrders)
                .ThenInclude(io => io.Item)
                .First();



            foreach (var itemOrder in order.ItemsOrders)
            {
                Console.Write($"Removing {itemOrder.Item.Name} x {itemOrder.Quantity}...");
                var item = db.Items.Where(item => item.Id == itemOrder.ItemId).First();
                
                if(item.Count < itemOrder.Quantity)
                {
                    Console.WriteLine("Failed. Not enough items. Press any key to refresh...");
                    Console.ReadKey();
                    Initialize();
                }

                item.Count -= itemOrder.Quantity;
                db.SaveChanges();

            }

            order.Accepted = true;
            db.SaveChanges();

            Console.WriteLine("Success. Press any key to refresh...");
            Console.ReadKey();

            Initialize();
        }
    }
}

