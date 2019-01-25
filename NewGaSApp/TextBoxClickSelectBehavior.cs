using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace NewGaSApp
{
    public class TextBoxClickSelectBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.GotKeyboardFocus += OnGotKeyboardFocusHandler;
            this.AssociatedObject.MouseDoubleClick += OnMouseDoubleClickHandler;
            this.AssociatedObject.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDownHandler;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.GotKeyboardFocus += OnGotKeyboardFocusHandler;
            this.AssociatedObject.MouseDoubleClick += OnMouseDoubleClickHandler;
            this.AssociatedObject.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDownHandler;
        }

        private void OnPreviewMouseLeftButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            DependencyObject parent = e.OriginalSource as UIElement;
            while (parent != null && !(parent is TextBox))
                parent = VisualTreeHelper.GetParent(parent);

            if (parent != null)
            {
                var textBox = (TextBox)parent;
                if (!textBox.IsKeyboardFocusWithin)
                {
                    textBox.Focus();
                    e.Handled = true;
                }
            }

        }

        private void OnMouseDoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            this.AssociatedObject.SelectAll();
        }

        private void OnGotKeyboardFocusHandler(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.AssociatedObject.SelectAll();
        }
    }
}