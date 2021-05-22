using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardSimulator
{
    enum MyLanguage
    {
        English, Ukrainian
    }
    class KeyBoard
    {
        private bool isCapsLock;
        public List<Button> Buttons { get; set; }
        public MyLanguage Language { get; set; }

        public KeyBoard()
        {
            Buttons = new List<Button>();
            Language = MyLanguage.Ukrainian;
            isCapsLock = false;
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
        static string[] bigKeyNameUa = new string[]
        {
            "Ё", "!", "\"", "№", ";", "%", ":", "?", "*", "(", ")", "_", "+", "BackSpace",
            "Tab", "Й", "Ц", "У", "К", "Е", "Н", "Г", "Ш", "Щ", "З", "Х", "Ї", "/",
             "CapsLock", "Ф", "І", "В", "А", "П", "Р", "О", "Л", "Д", "Ж", "Є", "Enter",
              "Shift", "Я", "Ч", "С", "М", "И", "Т", "Ь", "Б", "Ю", ",", "Shift",
               "Ctrl", "Win", "Alt", "Space", "Alt", "Win", "Ctrl"
        };

        public void ButtonDefaultContent()
        {
            if(Buttons.Count == smallKeyNameEn.Length)
            {
                for (int i = 0; i < smallKeyNameEn.Length; i++)
                {
                    if(Language == MyLanguage.English)
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
                    if (Language == MyLanguage.English)
                        Buttons[i].Content = bigKeyNameEn[i];
                    else Buttons[i].Content = bigKeyNameUa[i];
                }
            }
        }
        public void KeyDown(string key)
        {
            foreach (Button button in Buttons)
            {
                if (key.Equals(button.Name))
                {
                    if (key.Equals("LeftShift") || key.Equals("RightShift"))
                        ButtonShiftContent();
                    else if (key.Equals("Capital"))
                    {
                        CapsLock(button);
                        return;
                    }
                    else
                        button.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));

                    _ = UpdateButtonVisualState(button);
                }
            }
        }
        public void KeyUp(string key)
        {
            foreach (Button button in Buttons)
            {
                if (key.Equals(button.Name))
                {
                    if (key.Equals("LeftShift") || key.Equals("RightShift"))
                        ButtonDefaultContent();
                    else if (key.Equals("Capital"))
                    {
                        return;
                    }
                    _ = UpdateButtonNormalVisualState(button);
                }
            }
        }
        private async Task UpdateButtonNormalVisualState(Button button)
        {
            typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { false });
            await Task.Delay(TimeSpan.FromMilliseconds(200));
        }
        private async Task UpdateButtonVisualState(Button button)
        {
            typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { true });
            await Task.Delay(TimeSpan.FromMilliseconds(200));
        }
        public void CapsLock(Button button)
        {
            if(!isCapsLock)
            {
                _ = UpdateButtonVisualState(button);
                isCapsLock = true;
                ButtonShiftContent();
            }
            else
            {
                _ = UpdateButtonNormalVisualState(button);
                isCapsLock = false;
                ButtonDefaultContent();
            }
        }
        public void ChangeLanguage(MyLanguage language)
        {
            if (Buttons.Count == smallKeyNameEn.Length)
            {
                if (language == MyLanguage.English)
                {
                    for (int i = 0; i < smallKeyNameEn.Length; i++)
                    {
                        if (isCapsLock)
                            Buttons[i].Content = bigKeyNameEn[i];
                        else Buttons[i].Content = smallKeyNameEn[i];
                    }
                    Language = MyLanguage.English;
                }
                else if (language == MyLanguage.Ukrainian)
                {
                    for (int i = 0; i < smallKeyNameEn.Length; i++)
                    {
                        if (isCapsLock)
                            Buttons[i].Content = bigKeyNameUa[i];
                        else Buttons[i].Content = smallKeyNameUa[i];
                    }
                    Language = MyLanguage.Ukrainian;
                }
            }
        }

    }
}
