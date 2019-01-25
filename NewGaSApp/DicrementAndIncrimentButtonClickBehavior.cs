using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace NewGaSApp
{
    public class DicrementAndIncrimentButtonClickBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Click += OnClickHandler;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Click -= OnClickHandler;
        }

        private void OnClickHandler(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.Parent is StackPanel sp)
                foreach (var child in sp.Children)
                    if (child is TextBox tb)
                    {
                        string command = AssociatedObject.Tag.ToString().ToLower();
                        int value = Int32.Parse(tb.Text);
                        value = (command == "up") ? value + 1 : (command == "down") ? value - 1 : value;
                        value = (value < 0) ? 0 : value;
                        tb.Text = value.ToString();
                    }
        }
    }
}