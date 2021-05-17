using System;
using System.Collections.Generic;
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
                            string key = e.Key.ToString();
                            string button = ((item as Button).Content as string);
                            bool rez = key.Contains(button);
                            if (rez)
                            {
                                (item as Button).IsEnabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
