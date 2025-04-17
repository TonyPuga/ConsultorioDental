using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;
using ConsultorioDental.WPF.Views.PatientViews.PacienteViews;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.ViewModels.PatientViewModels;

public partial class PatientViewModel : ObservableObject
{
    [ObservableProperty]
    private Object? contenidoActual;

    partial void OnContenidoActualChanged(Object? value)
    {
        // Aquí puedes agregar lógica adicional si es necesario
        Console.WriteLine("Vista actual actualizada a PacienteView.");
    }

    private readonly IServiceProvider _serviceProvider;

    // Constructor con inyección de dependencias
    public PatientViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    // Comando para crear un nuevo paciente
    [RelayCommand]
    public void RegistroPaciente()
    {
        // Resolver PacienteBusquedaViewModel y PacienteBusquedaView desde el contenedor
        var viewModel = _serviceProvider.GetRequiredService<PacienteBusquedaViewModel>();
        var view = _serviceProvider.GetRequiredService<PacienteBusquedaView>();

        // Establecer el DataContext de la vista
        view.DataContext = viewModel;

        // Actualizar el contenido actual
        ContenidoActual = view;
    }
}