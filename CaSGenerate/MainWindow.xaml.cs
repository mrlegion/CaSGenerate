using System;
using System.Windows;

namespace CaSGenerate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Событие для кнопок управления Колонок
        /// </summary>
        public event EventHandler UpDownColumnButtonEvent = null;
        /// <summary>
        /// Событие для кнопок управления Строк
        /// </summary>
        public event EventHandler UpDownRowButtonEvent = null;
        /// <summary>
        /// Событие для управления просчета для односторонней печати
        /// </summary>
        public event EventHandler CheckedIsCheckEvent = null;
        /// <summary>
        /// Событие для кнопки копирования в буфер обмен
        /// </summary>
        public event EventHandler CopyToClipboardEvent = null;

        /// <summary>
        /// Конструтор основного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            new Controller(this);
        }

        /// <summary>
        /// Событие, которое отрабатывает по нажатию на кнопки изменения Колонок
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="routedEventArgs">Событие</param>
        private void UpDownColumnButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            UpDownColumnButtonEvent.Invoke(sender, routedEventArgs);
        }

        /// <summary>
        /// Событие, которое отрабатывает по нажатию на кнопки изменения Строк
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="routedEventArgs">Событие</param>
        private void UpDownRowButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            UpDownRowButtonEvent.Invoke(sender, routedEventArgs);
        }

        /// <summary>
        /// Событие, которое обрабатывает включение или отключение CheckedBox Односторонней печати
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="routedEventArgs">Событие</param>
        private void OnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            CheckedIsCheckEvent.Invoke(sender, routedEventArgs);
        }

        /// <summary>
        /// Событие, которое вызывается при нажатии на кнопку Копирования в буфер
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="routedEventArgs">Событие</param>
        private void CopyToClipboard_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            CopyToClipboardEvent.Invoke(sender, routedEventArgs);
        }
    }
}
