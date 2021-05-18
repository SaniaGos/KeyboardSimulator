using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardSimulator
{
    enum Language
    {
        English, Ukrainian
    }
    class KeyBoard
    {
        public List<Button> Buttons { get; set; }
        public Language Language { get; set; }

        public KeyBoard()
        {
            Buttons = new List<Button>();
            Language = Language.English;
        }
        static string[] smallKeyNameEn = new string[]
        {
            "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "BackSpace",
            "Tab", "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "\\",
             "CapsLock", "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "'", "Enter",
              "Shift", "z", "x", "c", "v", "b", "n", "m", ",", ".", "/", "Shift",
               "Ctrl", "Win", "Alt", "Space", "Alt", "Win", "Ctrl"
        };
        static string[] bigKeyNameEn = new string[]
        {
            "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "BackSpace",
            "Tab", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "{", "}", "|",
             "CapsLock", "A", "S", "D", "F", "G", "H", "J", "K", "L", ":", "\"", "Enter",
              "Shift", "Z", "X", "C", "V", "B", "N", "M", "<", ">", "?", "Shift",
               "Ctrl", "Win", "Alt", "Space", "Alt", "Win", "Ctrl"
        };
        static string[] smallKeyNameUa = new string[]
        {
            "ё", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "BackSpace",
            "Tab", "й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з", "х", "ї", "\\",
             "CapsLock", "ф", "і", "в", "а", "п", "р", "о", "л", "д", "ж", "є", "Enter",
              "Shift", "я", "ч", "с", "м", "и", "т", "ь", "б", "ю", ".", "Shift",
               "Ctrl", "Win", "Alt", "Space", "Alt", "Win", "Ctrl"
        };

        public void ButtonDefaultContent()
        {
            if(Buttons.Count == smallKeyNameEn.Length)
            {
                for (int i = 0; i < smallKeyNameEn.Length; i++)
                {
                    if(Language == Language.English)
                        Buttons[i].Content = smallKeyNameEn[i];
                    else Buttons[i].Content = smallKeyNameUa[i];
                }
            }
        }
        public void ButtonShiftContent()
        {
            if (Buttons.Count == smallKeyNameEn.Length)
            {
                for (int i = 0; i < smallKeyNameEn.Length; i++)
                {
                    if (Language == Language.English)
                        Buttons[i].Content = bigKeyNameEn[i];
                    else Buttons[i].Content = smallKeyNameUa[i];
                }
            }
        }

    }
}
