using System;
using Terminal.Gui;

namespace proj.Windows
{
    public class AddItemWindow : IWindow
    {
        private WindowsManager _windowsManager;

        public AddItemWindow(WindowsManager windowsManager)
        {
            this._windowsManager = windowsManager;
        }

        public void Initialize()
        {
            using var db = new MyContext();

            Console.Clear();
            Console.WriteLine(db.DbPath);

            Console.WriteLine("--- Add item window ---");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();


            db.Items.Add(new Item() { Name = name, Description = description, Count = 0 });
            db.SaveChanges();

            _windowsManager.SwitchWindow(new MainWindow(_windowsManager));
        }
    }
}

