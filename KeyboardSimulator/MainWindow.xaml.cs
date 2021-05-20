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
        TextWriter writer;
        public MainWindow()
        {
            InitializeComponent();
            board = new KeyBoard();
            writer = new TextWriter(Text, WriteText.Children);
            FillButtonList();
            board.ButtonDefaultContent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.None)
                board.KeyDown(e.Key.ToString());
            else if (e.SystemKey == Key.LeftAlt || e.SystemKey == Key.RightAlt)
                board.KeyDown(e.SystemKey.ToString());
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.None)
                board.KeyUp(e.Key.ToString());
            else if (e.SystemKey == Key.LeftAlt || e.SystemKey == Key.RightAlt)
                board.KeyUp(e.SystemKey.ToString());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button)
            {
                string key = (e.Source as Button).Content.ToString();
                if (key == "Space") key = " ";
                if (key.Length == 1)
                    writer.writeSumbol(Convert.ToChar(key));
                else if (key == "BackSpace") writer.DeleteLastSumbol();
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
        private void Shift_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            board.ButtonDefaultContent();
        }
        private void Shift_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            board.ButtonShiftContent();
        }

        private void Capital_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Button)
                board.CapsLock(sender as Button);
        }
    }
}
