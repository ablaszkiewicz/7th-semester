using System;
using Terminal.Gui;

namespace proj.Windows
{
    public class WindowsManager
    {
        private IWindow currentWindow;
        public Client ActiveClient { get; set; }

        public WindowsManager()
        {
            SwitchWindow(new MainWindow(this));
        }

        public void SwitchWindow(IWindow window)
        {
            window.Initialize();
        }
    }
}

