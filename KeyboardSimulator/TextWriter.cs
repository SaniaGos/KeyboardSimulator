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
        public TextWriter(TextBlock text, UIElementCollection colection )
        {
            readText = text;
            writeText = colection;
        }
        public void writeSumbol(char sum)
        {
            if (writeText.Count < readText.Text.Length)
            {
                if (sum == readText.Text[writeText.Count])
                    writeText.Add(new ListBoxItem() { Padding = new Thickness(0), FontSize = 25, Background = Brushes.LightGreen, Content = sum });
                else
                    writeText.Add(new ListBoxItem() { Padding = new Thickness(0), FontSize = 25, Background = Brushes.Red, Content = sum });
            }
        }
        public void DeleteLastSumbol()
        {
            if (writeText.Count > 0)
            {
                writeText.RemoveAt(writeText.Count - 1); 
            }
        }
    }
}
