using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media.Effects;

namespace NewGaSApp
{
    public class MainWindowBehaviors : Behavior<Window>
    {
        private Border _border;

        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.Loaded += OnLoadedHandler;
            this.AssociatedObject.Activated += OnActivatedHandler;
            this.AssociatedObject.Deactivated += OnDeactivatedHandler;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.Loaded -= OnLoadedHandler;
            this.AssociatedObject.Activated -= OnActivatedHandler;
            this.AssociatedObject.Deactivated -= OnDeactivatedHandler;
        }

        private void OnLoadedHandler(object sender, RoutedEventArgs e)
        {
            DropShadowEffect shadow = new DropShadowEffect()
            {
                BlurRadius = 35,
                Opacity = .4,
                Direction = 15,
                ShadowDepth = 0,
            };

            _border = (Border) (LogicalTreeHelper.FindLogicalNode(this.AssociatedObject, "Root"));

            if (_border != null)
                _border.Effect = shadow;
        }

        private void OnDeactivatedHandler(object sender, EventArgs e)
        {
            if (_border != null)
                if (_border.Effect is DropShadowEffect shadow)
                {
                    shadow.BlurRadius = 20;
                    shadow.Opacity = .2;
                    _border.Effect = shadow;
                }
        }

        private void OnActivatedHandler(object sender, EventArgs e)
        {
            if (_border != null)
                if (_border.Effect is DropShadowEffect shadow)
                {
                    shadow.BlurRadius = 35;
                    shadow.Opacity = .4;
                    _border.Effect = shadow;
                }
        }

        
    }
}