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
        }

        private void WindowColumnChangeValueHandler(object sender, EventArgs e)
        {
            ChangeNumberInWindow(_window.Column, ((Button)sender));
        }

        private static string SetZeroInNumber(int number) => (number < 10) ? $"0{number}" : number.ToString();
    }
}
