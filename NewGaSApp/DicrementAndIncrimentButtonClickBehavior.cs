using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

                        int count;

                        if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                            count = 10;
                        else if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                            count = 5;
                        else count = 1;

                        count = (command == "down") ? count * -1 : count;

                        value += count;
                        value = (value < 0) ? 0 : value;
                        tb.Text = value.ToString();
                    }
        }
    }
}