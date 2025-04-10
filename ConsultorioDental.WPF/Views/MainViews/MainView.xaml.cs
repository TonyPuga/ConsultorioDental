using ConsultorioDental.WPF.ViewModels.MainViewModels;
using System.Windows;

namespace ConsultorioDental.WPF.Views.MainViews
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
