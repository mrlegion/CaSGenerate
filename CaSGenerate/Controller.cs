using System;
using System.Windows;
using System.Windows.Controls;

namespace CaSGenerate
{
    class Controller
    {
        private MainWindow _window;
        private CaSGenerator _generator;

        public Controller(MainWindow window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _generator = new CaSGenerator();
            Initialize();
        }

        private void Initialize()
        {
            _window.UpDownColumnButtonEvent += WindowColumnChangeValueHandler;
            _window.UpDownRowButtonEvent += WindowRowChangeValueHandler;
            _window.CheckedIsCheckEvent += WindowCheckedChangeHandler;
            _window.CopyToClipboardEvent += WindowCopyToClipboardHandler;
        }

        private void WindowCopyToClipboardHandler(object sender, EventArgs e)
        {
            if (_window.Result.Text != string.Empty)
            {
                Clipboard.SetText(_window.Result.Text);
                MessageBox.Show("Результат скопирован в буфер обмена!", "Копирование в буфер:", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Окно результата пустое!", "Копирование в буфер:", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ChangeNumberInWindow(TextBox tb, Button b)
        {
            int temp = int.Parse(tb.Text);
            switch (b.Tag)
            {
                case "Up": temp++; break;
                case "Down": temp--; if (temp < 0) temp = 0; break;
            }
            tb.Text = SetZeroInNumber(temp);
        }

        private void WindowRowChangeValueHandler(object sender, EventArgs e)
        {
            ChangeNumberInWindow(_window.Row, ((Button)sender));
            GetResult();
        }

        private void WindowColumnChangeValueHandler(object sender, EventArgs e)
        {
            ChangeNumberInWindow(_window.Column, ((Button)sender));
            GetResult();
        }

        private void WindowCheckedChangeHandler(object sender, EventArgs e) => GetResult();

        private static string SetZeroInNumber(int number) => (number < 10) ? $"0{number}" : number.ToString();

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
