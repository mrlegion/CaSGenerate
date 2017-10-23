using System;
using System.Windows;
using System.Windows.Controls;

namespace CaSGenerate
{
    class Controller
    {
        /// <summary>
        /// Основное окно программы
        /// </summary>
        private readonly MainWindow _window;
        /// <summary>
        /// Класс для просчета значений
        /// </summary>
        private readonly CaSGenerator _generator;

        /// <summary>
        /// Конструктор класса Controller
        /// </summary>
        /// <param name="window">Ссылка на основное окно программы</param>
        public Controller(MainWindow window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _generator = new CaSGenerator();
            Initialize();
        }

        /// <summary>
        /// Инициализация всех событий в программе
        /// </summary>
        private void Initialize()
        {
            _window.UpDownColumnButtonEvent += WindowColumnChangeValueHandler;
            _window.UpDownRowButtonEvent += WindowRowChangeValueHandler;
            _window.CheckedIsCheckEvent += WindowCheckedChangeHandler;
            _window.CopyToClipboardEvent += WindowCopyToClipboardHandler;
            _window.ResetNumberOnTextBox += WindowResetNumberOnTextBoxHandler;
        }

        /// <summary>
        /// Оброботчик события двойного нажания на поле Колонки или Строк, для их сброса на значение по-умолчанию
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Событие</param>
        private void WindowResetNumberOnTextBoxHandler(object sender, EventArgs e)
        {
            if (sender is TextBox s) s.Text = SetZeroInNumber(1);
            GetResult();
        }

        /// <summary>
        /// Обработчик событий для события CopyToClipboardEvent (Копирования в буфер обмена)
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void WindowCopyToClipboardHandler(object sender, EventArgs e)
        {
            if (_window.Result.Text != string.Empty)
            {
                Clipboard.SetText(_window.Result.Text);
                MessageBox.Show("Результат скопирован в буфер обмена!", "Копирование в буфер:", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Окно результата пустое!", "Копирование в буфер:", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Универсальный метод для смены значений строк и колонок в текстовых полях программы 
        /// </summary>
        /// <param name="tb">TextBox строки или колонки</param>
        /// <param name="b">Button, которая была нажата</param>
        private static void ChangeNumberInWindow(TextBox tb, Button b)
        {
            int temp = int.Parse(tb.Text);
            switch (b.Tag)
            {
                case "Up": temp++; break;
                case "Down": temp--; if (temp < 0) temp = 0; break;
            }
            tb.Text = SetZeroInNumber(temp);
        }

        /// <summary>
        /// Обработчик событий для события UpDownRowButtonEvent (Повышение или уменьшение значения строк)
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void WindowRowChangeValueHandler(object sender, EventArgs e)
        {
            ChangeNumberInWindow(_window.Row, ((Button)sender));
            GetResult();
        }

        /// <summary>
        /// Обработчик событий для события UpDownColumnButtonEvent (Повышение или уменьшение значения колонок)
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void WindowColumnChangeValueHandler(object sender, EventArgs e)
        {
            ChangeNumberInWindow(_window.Column, ((Button)sender));
            GetResult();
        }

        /// <summary>
        /// Обработчик событий для события CheckedIsCheckEvent (Включение или отключение просчета для односторонней печати)
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void WindowCheckedChangeHandler(object sender, EventArgs e) => GetResult();

        /// <summary>
        /// Установка у цифр первого нуля до 10
        /// </summary>
        /// <param name="number">Значение числа</param>
        /// <returns>Новое строковое значение числа</returns>
        private static string SetZeroInNumber(int number) => (number < 10) ? $"0{number}" : number.ToString();

        /// <summary>
        /// Запуск основного просчета групп и значений Cut And Stack
        /// </summary>
        private void GetResult()
        {
            _generator.Column = int.Parse(_window.Column.Text);
            _generator.Row = int.Parse(_window.Row.Text);
            _generator.OneSideCheck = (_window.OneSideCheck.IsChecked == true);
            _window.Result.Text = _generator.GetGenerateNumber();
            _window.GroupLabel.Content = $"Group is Number: {((_generator.OneSideCheck) ? _generator.Group : _generator.Group * 2)}";
        }
    }
}
