using ConsultorioDental.WPF.Repositories.Administracion.Tipo;
using ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;
using ConsultorioDental.WPF.ViewModels.LoginViewModels;
using ConsultorioDental.WPF.Views.MainViews;
using ConsultorioDental.WPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using ConsultorioDental.WPF.ViewModels.MainViewModels;

namespace ConsultorioDental.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IConfiguration Configuration { get; private set; }
    public static IServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();

        // Configurar el contenedor de servicios
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Registrar repositorios, servicios y ViewModels
        services.AddSingleton<DepartamentoRepository>();
        services.AddSingleton<ProvinciaRepository>();
        services.AddSingleton<DistritoRepository>();
        services.AddSingleton<TipoRepository>();

        // Registrar ViewModels
        services.AddTransient<LoginViewModel>();
        services.AddTransient<MainWindowViewModel>();

        // Registrar vistas
        services.AddTransient<LoginView>();
        services.AddTransient<MainView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Resolver la vista inicial desde el contenedor de servicios
        var loginView = ServiceProvider.GetRequiredService<LoginView>();
        loginView.DataContext = ServiceProvider.GetRequiredService<LoginViewModel>();
        loginView.Show();
    }
}