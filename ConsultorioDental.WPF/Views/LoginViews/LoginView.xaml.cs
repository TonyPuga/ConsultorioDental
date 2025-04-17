using ConsultorioDental.WPF.ViewModels.LoginViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ConsultorioDental.WPF.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            // Asignar el DataContext usando el contenedor de dependencias
            DataContext = App.ServiceProvider.GetRequiredService<LoginViewModel>();

            Loaded += LoginView_Loaded;
        }

        private void LoginView_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the focus to the username textbox when the window is loaded
            txtUsuario.Focus();
        }
    }
}
