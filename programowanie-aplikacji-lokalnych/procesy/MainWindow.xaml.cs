using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace procesy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private Process selectedProcess = null;
        private DispatcherTimer timer = new();
        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += (s, e) => { 
                RefreshProcesses();
                UpdateDetailsWindow(selectedProcess);
            };
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            RefreshProcesses();
        }

        private void RefreshProcesses()
        {
            var processes = Process.GetProcesses();
            lvUsers.ItemsSource = processes;

            var view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Process).ProcessName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }

        private void lvUsersColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvUsers.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvUsers.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void ListViewItem_Click(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item == null) return;

            Trace.WriteLine((item.DataContext as Process).ProcessName);
            UpdateDetailsWindow(item.DataContext as Process);
            selectedProcess = item.DataContext as Process;
        }

        private void UpdateDetailsWindow(Process process)
        {
            if (process == null) return;

            NameText.Text = process.ProcessName;
            PriorityClassText.Text = process.PriorityClass.ToString();
            CpuText.Text = process.TotalProcessorTime.ToString();
            MemoryText.Text = process.WorkingSet64.ToString();
        }

        private void KillButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshProcesses();
            selectedProcess.Kill();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine(PrioritySelect.Text);

            switch (PrioritySelect.Text)
            {
                case "Idle":
                    selectedProcess.PriorityClass = ProcessPriorityClass.Idle;
                    break;
                case "High":
                    selectedProcess.PriorityClass = ProcessPriorityClass.High;
                    break;
            }

            RefreshProcesses();
            UpdateDetailsWindow(selectedProcess);
        }

        private void Interval_TextChanged(object sender, TextChangedEventArgs e)
        {
            timer.Stop();
            timer.Interval = new TimeSpan(0, 0, int.Parse(Interval.Text));
            timer.Start();
        }

        private void AutoRefreshCheckbox_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)AutoRefreshCheckbox.IsChecked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
    }

    public enum SexType { Male, Female };

    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }

        public SexType Sex { get; set; }
    }
}
