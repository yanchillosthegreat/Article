using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Article.Controls.AttachedProperties
{
    public partial class PasswordBoxAttachedProperties
    {
        public static string GetRegexPattern(DependencyObject obj)
        {
            return (string)obj.GetValue(RegexPatternProperty);
        }

        public static void SetRegexPattern(DependencyObject obj, string value)
        {
            obj.SetValue(RegexPatternProperty, value);
        }

        public static readonly DependencyProperty RegexPatternProperty =
            DependencyProperty.RegisterAttached("RegexPattern", typeof(string), typeof(PasswordBoxAttachedProperties), new PropertyMetadata(string.Empty, OnRegexPatternChanged));

        public static bool GetIsValid(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsValidProperty);
        }

        public static void SetIsValid(DependencyObject obj, bool value)
        {
            obj.SetValue(IsValidProperty, value);
        }

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.RegisterAttached("IsValid", typeof(bool), typeof(PasswordBoxAttachedProperties), new PropertyMetadata(true));

        private static void OnRegexPatternChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as Windows.UI.Xaml.Controls.PasswordBox;
            if (passwordBox == null)
            {
                return;
            }

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            var regexPattern = (string)e.NewValue;

            if (string.IsNullOrEmpty(regexPattern))
            {
                return;
            }

            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            SetIsValid(passwordBox, ValidateText(passwordBox.Password, regexPattern));
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as Windows.UI.Xaml.Controls.PasswordBox;
            if (passwordBox == null)
            {
                return;
            }

            if (ValidateText(passwordBox.Password, GetRegexPattern(passwordBox)))
            {
                SetIsValid(passwordBox, true);
            }
            else
            {
                SetIsValid(passwordBox, false);
            }
        }

        private static bool ValidateText(string text, string regexPattern)
        {
            if (Regex.IsMatch(text, regexPattern))
            {
                return true;
            }
            return false;
        }
    }
}
