using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Timers;

namespace KeyboardSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KeyBoard board;
        TextWriter writer;
        Timer timer;
        int time;
        public MainWindow()
        {
            InitializeComponent();
            timer = new Timer() { Interval = 1000, Enabled = false };
            timer.Elapsed += timer_Tick;
            time = 0;
            board = new KeyBoard();
            writer = new TextWriter(Text, WriteText.Children, (int)SliderDifficulty.Value, MyLanguage.Ukrainian);
            FillButtonList();
            board.ButtonDefaultContent();
        }
        void timer_Tick(object sender, ElapsedEventArgs e)
        {
            if (!writer.IsCanWrite)
                Dispatcher.Invoke(new Action(() => { StopButton(); }));
            Dispatcher.Invoke(new Action(() => { time += 1; }));
            Dispatcher.Invoke(new Action(() => { Fails.Content = writer.Fails.ToString(); }));
            Dispatcher.Invoke(new Action(() => { Speed.Content = Convert.ToString(Math.Round((double)writer.GetSumbol() / time * 60, 1)); }));
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
            if (sender is Button)
                board.CapsLock(sender as Button);
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem obj = sender as MenuItem;
            if (obj.HeaderStringFormat == "EN")
            {
                board.ChangeLanguage(MyLanguage.English);
                writer.Language = MyLanguage.English;
                writer.NewText();
            }
            else if (obj.HeaderStringFormat == "UA")
            {
                board.ChangeLanguage(MyLanguage.Ukrainian);
                writer.Language = MyLanguage.Ukrainian;
                writer.NewText();
            }

            LabelLanguage.Content = obj.HeaderStringFormat;
        }
        private void Start_Stop_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button button = (sender as Button);
                if (button != null && button.Content.ToString() == "Start")
                {
                    StartButton();
                }
                else if (button != null && button.Content.ToString() == "Stop")
                {
                    StopButton();
                }
            }
        }
        private void StopButton()
        {
            Start.IsEnabled = true;
            New.IsEnabled = true;
            Stop.IsEnabled = false;
            writer.IsCanWrite = false;
            timer.Stop();
        }
        private void StartButton()
        {
            Start.IsEnabled = false;
            New.IsEnabled = false;
            Stop.IsEnabled = true;
            writer.IsCanWrite = true;
            timer.Start();
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            time = 0;
            writer.Clear();
            writer.NewText();
            Fails.Content = writer.Fails.ToString();
            Speed.Content = 0;
        }
        private void SliderDifficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(writer != null)
                writer.Difficulty = (int)(sender as Slider).Value;
            Difficulty.Content = (sender as Slider).Value;
        }
    }
}
