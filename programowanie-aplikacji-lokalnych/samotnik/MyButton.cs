using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace samotnik
{
    public class MyButton
    {
        public delegate void ButtonClickedDelegate(int x, int y, MyButton sender);
        private ButtonClickedDelegate OnButtonClicked;
        private MainWindow mainWindow;
        private int x;
        private int y;
        private Button button;
        private bool isPawn;

        public int X { get => x; }
        public int Y { get => y; }
        public bool IsPawn { get => isPawn; }
        public MyButton(MainWindow mainWindow, int x, int y, ButtonClickedDelegate del)
        {
            this.mainWindow = mainWindow;
            this.x = x;
            this.y = y;
            OnButtonClicked = del;

            CreateButton();
        }

        private void CreateButton()
        {
            var betweenButtonsMargin = 5;

            this.button = new Button();
            button.Width = 40;
            button.Height = 40;
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.VerticalAlignment = VerticalAlignment.Top;
            var margin = new Thickness();
            margin.Top = betweenButtonsMargin + y * (40 + betweenButtonsMargin);
            margin.Left = betweenButtonsMargin + x * (40 + betweenButtonsMargin);

            button.Margin = margin;
            button.Click += (sender, evt) => OnButtonClicked(x, y, this);
            SetIsPawn(true);

            mainWindow.MainGrid.Children.Add(button);
        }

        public void SetIsPawn(bool isPawn)
        {
            button.Content = isPawn ? "\u25A0" : "";
            this.isPawn = isPawn;
        }

        public void SetClicked(bool isClicked)
        {
            var thickness = new Thickness();
            if (isClicked)
            {
                thickness.Top = 3;
                thickness.Bottom = 3;
                thickness.Left = 3;
                thickness.Right = 3;
            }
            else
            {
                thickness.Top = 1;
                thickness.Bottom = 1;
                thickness.Left = 1;
                thickness.Right = 1;
            }
            button.BorderThickness = thickness;
        }

        public ButtonState GetState()
        {
            var state = new ButtonState();
            state.button = this;
            state.isPawnAtStateCapture = isPawn;

            return state;
        }
    }
}
