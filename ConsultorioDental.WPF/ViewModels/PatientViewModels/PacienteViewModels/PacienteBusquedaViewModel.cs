using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.Models;
using ConsultorioDental.WPF.Repositories.Administracion.Tipo;
using ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;
using ConsultorioDental.WPF.ViewModels.MainViewModels;
using ConsultorioDental.WPF.Views.PatientViews.PacienteViews;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;

public partial class PacienteBusquedaViewModel : ObservableObject
{
    private readonly PatientViewModel _patientViewModel;
    private readonly IDepartamentoRepository _departamentoRepository;
    private readonly IProvinciaRepository _provinciaRepository;
    private readonly IDistritoRepository _distritoRepository;
    private readonly ITipoRepository _tipoRepository;
    private readonly IServiceProvider _serviceProvider;

    // Propiedades para los filtros de búsqueda
    [ObservableProperty]
    private string? apellidoPaterno;

    [ObservableProperty]
    private string? apellidoMaterno;

    [ObservableProperty]
    private string? nombres;

    // Colección de pacientes mostrada en el DataGrid
    [ObservableProperty]
    private ObservableCollection<PacienteModel>? pacientes = new ObservableCollection<PacienteModel>();

    // Propiedades para la paginación
    [ObservableProperty]
    private int paginaActual = 1;

    [ObservableProperty]
    private int totalRegistros;

    [ObservableProperty]
    private int totalPaginacion;

    [ObservableProperty]
    private int totalPaginas;

    [ObservableProperty]
    private bool estaCargando = false;

    // Constructor con inyección de dependencias
    public PacienteBusquedaViewModel(IServiceProvider serviceProvider, 
        IDepartamentoRepository departamentoRepository,
        IProvinciaRepository provinciaRepository,
        IDistritoRepository distritoRepository,
        ITipoRepository tipoRepository,
        PatientViewModel patientViewModel)
    {
        _patientViewModel = patientViewModel;
        _departamentoRepository = departamentoRepository;
        _provinciaRepository = provinciaRepository;
        _distritoRepository = distritoRepository;
        _tipoRepository = tipoRepository;
        _serviceProvider = serviceProvider;

        PaginaActual = 1;
        TotalPaginacion = 20;
        EstaCargando = false;
    }

    //Comando para crear un nuevo paciente
    [RelayCommand]
    private void Nuevo()
    {
        // Verificar si el comando se ejecuta
        Console.WriteLine("Ejecutando comando Nuevo...");

        // Resolver PacienteViewModel y PacienteView desde el contenedor
        var viewModel = _serviceProvider.GetRequiredService<PacienteViewModel>();
        var view = _serviceProvider.GetRequiredService<PacienteView>();

        // Establecer el DataContext de la vista
        view.DataContext = viewModel;

        Console.WriteLine("PacienteViewModel y PacienteView resueltos correctamente.");

        // Actualizar el contenido actual en el módulo
        _patientViewModel.ContenidoActual = view;

        Console.WriteLine("Vista actual actualizada a PacienteView.");
    }

    //Comando para limpiar los filtros de búsqueda
    [RelayCommand]
    private void Limpiar()
    {
        ApellidoPaterno = null;
        ApellidoMaterno = null;
        Nombres = null;

        Pacientes.Clear();
    }

    [RelayCommand(CanExecute = nameof(CanEditar))]
    private void Editar(PacienteModel selectedPaciente)
    {

    }

    private bool CanEditar(PacienteModel selectedPaciente)
    {
        return selectedPaciente is not null;
    }

    [RelayCommand]
    private void Buscar()
    {
        BuscarPaciente();
    }

    [RelayCommand]
    private void PaginaAnterior()
    {
        if(PaginaActual > 1)
        {
            PaginaActual--;
            BuscarPaciente();
        }
    }

    [RelayCommand]
    private void PaginaSiguiente()
    {
        if(PaginaActual < TotalPaginas)
        {
            PaginaActual++;

            BuscarPaciente();
        }
    }

    [RelayCommand]
    private void PaginaUltima()
    {
        PaginaActual = TotalPaginas;
        BuscarPaciente();        
    }

    [RelayCommand]
    private void PaginaPrimera()
    {
        PaginaActual = 1;
        BuscarPaciente();
    }

    private void BuscarPaciente()
    {
        EstaCargando = true;
    }
}