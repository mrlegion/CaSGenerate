using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace NewGaSApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private string _title = "GaS Generation";
        private RelayCommand _exitCommand;
        private int _columns;
        private int _rows;
        private int _groups;
        private string _result;
        private bool _isOneSide;
        private RelayCommand _resetCommand;
        private RelayCommand _copyToCommand;

        #endregion

        #region Ctor

        #endregion

        #region Properties

        public const string TitlePropertyName = "Title";
        public const string ColumnsPropertyName = "Columns";
        public const string RowsPropertyName = "Rows";
        public const string ResultPropertyName = "Result";
        public const string GroupsPropertyName = "Groups";
        public const string IsOneSidePropertyName = "IsOneSide";

        public string Title
        {
            get { return _title; }
            set { Set(TitlePropertyName, ref _title, value); }
        }

        public int Columns
        {
            get { return _columns; }
            set
            {
                Set(ColumnsPropertyName, ref _columns, value);
                Calculate();
            }
        }

        public int Rows
        {
            get { return _rows; }
            set
            {
                Set(RowsPropertyName, ref _rows, value);
                Calculate();
            }
        }

        public int Groups
        {
            get { return _groups; }
            set { Set(GroupsPropertyName, ref _groups, value); }
        }

        public string Result
        {
            get { return _result; }
            set { Set(ResultPropertyName, ref _result, value); }
        }

        public bool IsOneSide
        {
            get { return _isOneSide; }
            set
            {
                Set(IsOneSidePropertyName, ref _isOneSide, value);
                Calculate();
            }
        }

        #endregion

        #region Commands

        public RelayCommand ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new RelayCommand(() =>
                {
                    Application.Current.Shutdown();
                }));
            }
        }

        public RelayCommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = new RelayCommand(Clear));
            }
        }

        public RelayCommand CopyToCommand
        {
            get
            {
                return _copyToCommand ?? (_copyToCommand = new RelayCommand(() =>
                {
                    Result = "Copy to clipboard";
                    Clipboard.SetText(Result);
                }));
            }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void Clear()
        {
            Columns = 0;
            Rows = 0;
            Result = "";
            IsOneSide = false;
        }

        private void UpdateGroupNumber()
        {
            int g = Columns * Rows;
            Groups = (IsOneSide) ? g : g * 2;
        }

        private void SingleArray()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= Groups; ++i)
                sb.Append($"{i} ");
            string s = sb.ToString().TrimEnd(' ');
            string result = s;
            if (s.Length > 200)
            {
                result = s.Substring(0, 200);
                result += " ...";
            }
            Result = result;
        }

        private void Calculate()
        {
            UpdateGroupNumber();
            if (Groups == 0) return;
            Thread thread = new Thread(new ThreadStart(SingleArray));
            thread.Start();
        }

        #endregion

        #region Exceptions classes

        #endregion
    }
}