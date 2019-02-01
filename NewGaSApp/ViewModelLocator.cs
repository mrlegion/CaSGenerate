using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace NewGaSApp
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            InitViews();
            InitViewModels();

            SimpleIoc.Default.Register<ICreator, Creator>();
        }

        public MainWindowViewModel Main => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        private static void InitViewModels()
        {
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        private static void InitViews()
        {
            SimpleIoc.Default.Register<MainWindow>();
        }
    }
}