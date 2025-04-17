using ConsultorioDental.WPF.ViewModels.MainViewModels;
using Microsoft.Extensions.DependencyInjection;
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

            // Resolver el ViewModel desde el contenedor de dependencias
            DataContext = App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        }
    }
}
