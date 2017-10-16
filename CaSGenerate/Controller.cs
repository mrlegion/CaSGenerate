using System;
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
        }

        private void WindowRowChangeValueHandler(object sender, EventArgs e)
        {
            int row;
            switch (((Button)sender).Tag)
            {
                case "Up":
                    row = int.Parse(_window.Row.Text);
                    row++;
                    _window.Row.Text = SetZeroInNumber(row);
                    break;
                case "Down":
                    row = int.Parse(_window.Row.Text);
                    row--;
                    if (row < 0) row = 0;
                    _window.Row.Text = SetZeroInNumber(row);
                    break;
            }
        }

        private void WindowColumnChangeValueHandler(object sender, EventArgs e)
        {
            int col;
            switch (((Button)sender).Tag)
            {
                case "Up":
                    col = int.Parse(_window.Column.Text);
                    col++;
                    _window.Column.Text = SetZeroInNumber(col);
                    break;
                case "Down":
                    col = int.Parse(_window.Column.Text);
                    col--;
                    if (col < 0) col = 0;
                    _window.Column.Text = SetZeroInNumber(col);
                    break;
            }
        }

        private static string SetZeroInNumber(int number) => (number < 10) ? $"0{number}" : number.ToString();
    }
}
