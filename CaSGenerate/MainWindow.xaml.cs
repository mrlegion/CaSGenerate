using System;
using System.Windows;
using System.Windows.Input;

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
        /// Событие двойного клика для сброса значений текстового поля колонок и сток
        /// </summary>
        public event EventHandler ResetNumberOnTextBox = null;

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

        /// <summary>
        /// Оброботчик события двойного нажания на поле Колонки или Строк, для их сброса на значение по-умолчанию
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Событие</param>
        private void ResetNumberInTextBox(object sender, MouseButtonEventArgs e)
        {
            ResetNumberOnTextBox.Invoke(sender, e);
        }
    }
}
