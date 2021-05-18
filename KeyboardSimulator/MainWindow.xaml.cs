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
        KeyBoard board;
        public MainWindow()
        {
            InitializeComponent();
            board = new KeyBoard();
            FillButtonList();
            ButtonsContent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Button button in board.Buttons)
                if (e.Key.ToString().Equals(button.Name) || e.SystemKey.ToString().Equals(button.Name))
                {
                    button.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                }
        }
        
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }
        
        private async Task UpdateButtonVisualState(Button button)
        {
            typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { true });
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { false });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = UpdateButtonVisualState(sender as Button);

            if (e.Source is Button)
            {
                string key = (e.Source as Button).Content.ToString();
                if (key == "Space") key = " ";
                if (key == "Shift") ButtonsShiftContent();
                if (key.Length == 1)
                    WriteText.Children.Add(new ListBoxItem() { Padding = new Thickness(0), FontSize = 25, Background = Brushes.LightGreen, Content = key });

            }
        }
        private void FillButtonList()
        {
            foreach (var items in OwnerPenal.Children)
            {
                if (items is StackPanel)
                {
                    foreach (var item in (items as StackPanel).Children)
                    {
                        if (item is Button)
                        {
                            board.Buttons.Add(item as Button);
                        }
                    }
                }
            }
        }
        private void ButtonsContent()
        {
            board.ButtonDefaultContent();
        }
        private void ButtonsShiftContent()
        {
            board.ButtonShiftContent();
        }

        
    }
}
