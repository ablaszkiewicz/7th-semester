using System;
using System.Collections.Generic;
using System.Linq;

namespace proj.Windows
{
    public class CreateOrderWindow : IWindow
    {
        private WindowsManager _windowsManager;
        private List<ItemQuantity> items = new List<ItemQuantity>();

        public CreateOrderWindow(WindowsManager windowsManager)
        {
            this._windowsManager = windowsManager;
        }

        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("--- Add order ---");
            Console.WriteLine("item\tqt");

            foreach(var item in items)
            {
                Console.WriteLine($"{item.ItemId}\t{item.Quantity}");
            }
            Console.WriteLine();

            Options();
        }

        private void Options()
        {
            Console.WriteLine("Add item    [A]");
            Console.WriteLine("Make order  [M]");

            var result = Console.ReadKey();

            if (result.Key == ConsoleKey.A)
            {
                AddItem();
            }
            if (result.Key == ConsoleKey.M)
            {
                MakeOrder();
            }
        }

        private void AddItem()
        {
            Console.WriteLine();
            Console.Write("Item id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Quantity: ");
            var quantity = int.Parse(Console.ReadLine());

            items.Add(new ItemQuantity() { ItemId = id, Quantity = quantity });

            Initialize();
        }

        private void MakeOrder()
        {
            using var db = new MyContext();

            var client = db.Clients.Where(c => c.Id == _windowsManager.ActiveClient.Id).First();

            var order = new Order()
            {
                Client = client,
            };

            db.Orders.Add(order);
            db.SaveChanges();


            foreach(var itemQuantity in items)
            {
                var orderItem = new ItemsOrders() { ItemId = itemQuantity.ItemId, OrderId = order.Id, Quantity = itemQuantity.Quantity };
                db.ItemsOrders.Add(orderItem);
            }

            db.SaveChanges();
        }
    }

    class ItemQuantity
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}

