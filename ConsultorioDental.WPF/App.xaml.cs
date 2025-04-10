using Microsoft.Extensions.Configuration;
using System.Windows;

namespace ConsultorioDental.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IConfiguration Configuration { get; private set; }

    public App()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        Configuration = builder.Build();
    }
}