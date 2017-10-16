using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaSGenerate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler UpDownColumnButtonEvent = null;
        public event EventHandler UpDownRowButtonEvent = null;
        public event EventHandler CheckedIsCheckEvent = null;
        public event EventHandler CopyToClipboardEvent = null;

        public MainWindow()
        {
            InitializeComponent();
            new Controller(this);
        }

        private void UpDownColumnButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            UpDownColumnButtonEvent.Invoke(sender, routedEventArgs);
        }

        private void UpDownRowButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            UpDownRowButtonEvent.Invoke(sender, routedEventArgs);
        }

        private void OnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            CheckedIsCheckEvent.Invoke(sender, routedEventArgs);
        }

        private void CopyToClipboard_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            CopyToClipboardEvent.Invoke(sender, routedEventArgs);
        }
    }
}
