using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KeyboardSimulator
{
    class TextWriter
    {
        TextBlock readText;
        UIElementCollection writeText;
        int difficulty;
        public int Fails { get; private set; }
        public bool IsCanWrite { get; set; }
        public MyLanguage Language { get; set; }
        public int Difficulty { get => difficulty; set { difficulty = value; NewText(); } }
        public TextWriter(TextBlock text, UIElementCollection colection, int difficulty, MyLanguage language)
        {
            readText = text;
            writeText = colection;
            IsCanWrite = false;
            Language = language;
            Difficulty = difficulty;
        }
        public void writeSumbol(char sum)
        {
            if (IsCanWrite && writeText.Count < readText.Text.Length)
            {
                if (sum == readText.Text[writeText.Count])
                {
                    writeText.Add(new ListBoxItem()
                    {
                        Padding = new Thickness(0),
                        FontSize = 25,
                        Background = Brushes.LightGreen,
                        Content = sum,
                        BorderBrush = Brushes.LightGreen,
                        FontFamily = new FontFamily("Consolas")
                    });
                }
                else
                {
                    writeText.Add(new ListBoxItem()
                    {
                        Padding = new Thickness(0),
                        FontSize = 25,
                        Background = Brushes.Red,
                        Content = sum,
                        BorderBrush = Brushes.Red,
                        FontFamily = new FontFamily("Consolas")
                    });
                    Fails++;
                }
            }
            if (writeText.Count == readText.Text.Length) IsCanWrite = false; ;
        }
        public int GetSumbol()
        {
            return writeText.Count;
        }
        public void DeleteLastSumbol()
        {
            if (IsCanWrite && writeText.Count > 0)
            {
                writeText.RemoveAt(writeText.Count - 1); 
            }
        }
        public void Clear()
        {
            Fails = 0;
            writeText.Clear();
        }
        public void NewText()
        {
            readText.Text = Text.GetText(Difficulty, Language);
        }
    }
}
