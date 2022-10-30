using System;
using System.Collections.Generic;
using Terminal.Gui;

namespace proj.Windows
{
    public class MainWindow : IWindow
    {
        private WindowsManager _windowsManager;

        public MainWindow(WindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
        }

        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("--- Main window ---");
            if(_windowsManager.ActiveClient != null)
            {
                Console.WriteLine($"(active client: {_windowsManager.ActiveClient.Name})");
            }
            Options();
        }

        private void Options()
        {
            Console.WriteLine("Add item window  [A]");
            Console.WriteLine("Item list window [V]");
            Console.WriteLine("Choose client    [C]");
            Console.WriteLine("Create order     [O]");
            Console.WriteLine("Orders list      [L]");

            var result = Console.ReadKey();

            if (result.Key == ConsoleKey.A)
            {
                _windowsManager.SwitchWindow(new AddItemWindow(_windowsManager));
            }
            if (result.Key == ConsoleKey.V)
            {
                _windowsManager.SwitchWindow(new ItemsListWindow(_windowsManager));
            }
            if (result.Key == ConsoleKey.C)
            {
                _windowsManager.SwitchWindow(new ChooseClientWindow(_windowsManager));
            }
            if (result.Key == ConsoleKey.O)
            {
                _windowsManager.SwitchWindow(new CreateOrderWindow(_windowsManager));
            }
            if (result.Key == ConsoleKey.L)
            {
                _windowsManager.SwitchWindow(new ListOrdersWindow(_windowsManager));
            }
        }
    }
}

