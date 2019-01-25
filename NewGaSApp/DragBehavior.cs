using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace NewGaSApp
{
    public class DragBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.MouseLeftButtonDown += OnMouseLeftButtonDownHandler;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.MouseLeftButtonDown -= OnMouseLeftButtonDownHandler;
        }

        private void OnMouseLeftButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow?.DragMove();
        }
    }
}