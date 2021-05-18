using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace KeyboardSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var items in OwnerPenal.Children)
            {
                if (items is StackPanel)
                {
                    foreach (var item in (items as StackPanel).Children)
                    {
                        if (item is Button)
                        {
                            Button button = (item as Button);
                            string key = e.Key.ToString();
                            string buttonName = button.Name;
                            
                            if (key.Equals(buttonName))
                            {
                                button.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                            }

                        }
                    }
                }
            }
        }

        private async Task UpdateButtonVisualState(Button button)
        {
            typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { true });
            await Task.Delay(TimeSpan.FromMilliseconds(200));
            typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { false });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = UpdateButtonVisualState(sender as Button);
        }
    }
}
