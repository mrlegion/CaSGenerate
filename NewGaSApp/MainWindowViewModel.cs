using System.Net.Mime;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace NewGaSApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "GaS Generation";

        public const string TitlePropertyName = "Title";

        public string Title
        {
            get { return _title; }
            set { Set(TitlePropertyName, ref _title, value); }
        }

        private RelayCommand _exitCommand;

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
    }
}