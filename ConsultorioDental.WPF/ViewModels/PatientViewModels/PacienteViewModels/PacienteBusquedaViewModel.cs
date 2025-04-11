using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.Models;
using ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;
using ConsultorioDental.WPF.Views.PatientViews.PacienteViews;
using System.Collections.ObjectModel;

namespace ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;

public partial class PacienteBusquedaViewModel : ObservableObject
{
    private readonly PatientViewModel _modulo;

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

    public PacienteBusquedaViewModel(PatientViewModel patientViewModel)
    {
        _modulo = patientViewModel;
        PaginaActual = 1;
        TotalPaginacion = 20;
        EstaCargando = false;
    }

    //Comando para crear un nuevo paciente
    [RelayCommand]
    private void Nuevo()
    {
        var departamentoRepository = new DepartamentoRepository();
        var provinciaRepository = new ProvinciaRepository();
        var distritoRepository = new DistritoRepository();

        var viewModel = new PacienteViewModel(_modulo, departamentoRepository, provinciaRepository, distritoRepository);
        var view = new PacienteView
        {
            DataContext = viewModel
        };
        
        _modulo.ContenidoActual = view;
        
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