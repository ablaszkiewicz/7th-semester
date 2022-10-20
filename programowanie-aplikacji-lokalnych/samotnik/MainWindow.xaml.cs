using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace samotnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<MyButton> buttons = new List<MyButton>();
        private MyButton lastClikedButton;
        private List<GameCommand> commands = new List<GameCommand>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            for (int x = 2; x < 5; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    var button = CreateButton(x, y);
                    if (x == 3 && y == 3)
                    {
                        button.SetIsPawn(false);
                    }
                }
            }

            for (int y = 2; y < 5; y++)
            {
                for (int x = 0; x < 2; x++)
                {
                    CreateButton(x, y);
                    
                }
                for (int x = 5; x < 7; x++)
                {
                    CreateButton(x, y);
                }
            }
        }

        private void OnButtonClicked(int x, int y, MyButton sender)
        {
            if(lastClikedButton != null)
            {
                OnSecondButtonClicked(x, y, sender);
            } else
            {
                OnFirstButtonClicked(x, y, sender);
            }
        }

        private void OnFirstButtonClicked(int x, int y, MyButton sender)
        {
            sender.SetClicked(true);
            lastClikedButton = sender;
        }

        private void OnSecondButtonClicked(int x, int y, MyButton sender)
        {
            if(sender == lastClikedButton)
            {
                sender.SetClicked(false);
                lastClikedButton = null;
                return;
            }

            if(!ButtonsFollowRule(lastClikedButton, sender) || sender.IsPawn)
            {
                return;
            }

            var middleButton = GetButtonBetweenButtons(lastClikedButton, sender);

            var senderState = sender.GetState();
            var middleButtonState = middleButton.GetState();
            var lastClickedButtonState = lastClikedButton.GetState();

            var states = new List<ButtonState>();
            states.Add(middleButtonState);
            states.Add(lastClickedButtonState);
            states.Add(senderState);

            var command = new GameCommand(states);
            commands.Add(command);

            middleButton.SetIsPawn(false);

            lastClikedButton.SetClicked(false);
            lastClikedButton.SetIsPawn(false);

            sender.SetIsPawn(true);
            lastClikedButton = null;

            BackButton.IsEnabled = true;
            CheckWinCondition();
        }

        private MyButton CreateButton(int x, int y)
        {
            var button = new MyButton(this, x, y, OnButtonClicked);
            buttons.Add(button);

            return button;
        }

        private bool ButtonsFollowRule(MyButton last, MyButton next)
        {
            return (last.X == next.X && Math.Abs(last.Y - next.Y) == 2
                || last.Y == next.Y && Math.Abs(last.X - next.X) == 2);

        }

        private MyButton GetButtonBetweenButtons(MyButton last, MyButton next)
        {
            var averageX = (last.X + next.X) / 2;
            var averageY = (last.Y + next.Y) / 2;
            return buttons.Where(button => button.X == averageX && button.Y == averageY).First();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var command = commands.Last();
            commands.RemoveAt(commands.Count - 1);

            command.Reverse();
            if(commands.Count == 0)
            {
                this.BackButton.IsEnabled = false;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Restart();
        }

        public void Restart()
        {
            commands.Clear();
            InitializeButtons();
            BackButton.IsEnabled = false;
        }

        private void CheckWinCondition()
        {
            var buttonsWithPawns = buttons.Where(button => button.IsPawn).ToList();

            if(buttonsWithPawns.Count() == 1 && buttonsWithPawns[0].X == 3 && buttonsWithPawns[0].Y == 3)
            {
                var winWindow = new WinWindow(this);
                winWindow.Show();
            }
        }
    }
}
