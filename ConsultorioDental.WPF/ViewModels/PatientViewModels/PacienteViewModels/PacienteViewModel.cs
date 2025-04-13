using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;
using ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;
using ConsultorioDental.WPF.Views.PatientViews.PacienteViews;
using System.Collections.ObjectModel;

namespace ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;

public partial class PacienteViewModel : ObservableObject
{
    private readonly PatientViewModel _modulo;
    private readonly IDepartamentoRepository _departamentoRepository;
    private readonly IProvinciaRepository _provinciaRepository;
    private readonly IDistritoRepository _distritoRepository;

    public PacienteViewModel(PatientViewModel modulo,
                        IDepartamentoRepository departamentoRepository,
                        IProvinciaRepository provinciaRepository,
                        IDistritoRepository distritoRepository)
    {
        _modulo = modulo;
        _departamentoRepository = departamentoRepository;
        _provinciaRepository = provinciaRepository;
        _distritoRepository = distritoRepository;

        DepartamentosPaciente = new ObservableCollection<DepartamentoModel>();
        DepartamentosApoderado = new ObservableCollection<DepartamentoModel>();

        CargarDepartamentos();
    }

    [ObservableProperty]
    private ObservableCollection<DepartamentoModel> departamentosPaciente;
    [ObservableProperty]
    private ObservableCollection<DepartamentoModel> departamentosApoderado;

    [ObservableProperty]
    private DepartamentoModel? departamentoSeleccionadoPaciente;

    partial void OnDepartamentoSeleccionadoPacienteChanged(DepartamentoModel? value)
    {
        if (value != null)
        {
            CargarProvinciasPaciente(value.IdDepartamento);
        }

        ProvinciaSeleccionadaPaciente = null;
    }

    [ObservableProperty]
    private DepartamentoModel? departamentoSeleccionadoApoderado;

    partial void OnDepartamentoSeleccionadoApoderadoChanged(DepartamentoModel? value)
    {
        if (value != null)
        {
            CargarProvinciasApoderado(value.IdDepartamento);
        }
    }

    [ObservableProperty]
    private ObservableCollection<ProvinciaModel> provinciasPaciente;

    [ObservableProperty]
    private ProvinciaModel? provinciaSeleccionadaPaciente;
    partial void OnProvinciaSeleccionadaPacienteChanged(ProvinciaModel? value)
    {
        if (value != null)
        {
            CargarDistritosPaciente(value.IdProvincia);
        }
    }

    [ObservableProperty]
    private ObservableCollection<ProvinciaModel> provinciasApoderado;

    [ObservableProperty]
    private ProvinciaModel? provinciaSeleccionadaApoderado;
    partial void OnProvinciaSeleccionadaApoderadoChanged(ProvinciaModel? value)
    {
        if (value != null)
        {
            CargarDistritosApoderado(value.IdProvincia);
        }
    }

    [ObservableProperty]
    private ObservableCollection<DistritoModel> distritosPaciente;

    [ObservableProperty]
    private ObservableCollection<DistritoModel> distritosApoderado;

    [ObservableProperty]
    private DistritoModel? distritoSeleccionadoPaciente;

    [ObservableProperty]
    private DistritoModel? distritoSeleccionadoApoderado;

    private void CargarProvinciasPaciente(int idDepartamento)
    {
        if (ProvinciasPaciente != null)
        {
            ProvinciasPaciente.Clear();
        }

        ProvinciasPaciente = new ObservableCollection<ProvinciaModel>(_provinciaRepository.ListarProvinciaTodo(idDepartamento));
    }

    private void CargarProvinciasApoderado(int idDepartamento)
    {
        ProvinciasApoderado.Clear();
        ProvinciasApoderado = new ObservableCollection<ProvinciaModel>(_provinciaRepository.ListarProvinciaTodo(idDepartamento));
    }

    private void CargarDistritosPaciente(int idProvincia)
    {
        if (DistritosPaciente != null)
        {
            DistritosPaciente.Clear(); 
        }

        DistritosPaciente = new ObservableCollection<DistritoModel>(_distritoRepository.ListarDistritoTodo(idProvincia));
    }

    private void CargarDistritosApoderado(int idProvincia)
    {
        DistritosApoderado.Clear();
        DistritosApoderado = new ObservableCollection<DistritoModel>(_distritoRepository.ListarDistritoTodo(idProvincia));
    }

    [RelayCommand]
    private void Regresar()
    {
        var viewModel = new PacienteBusquedaViewModel(_modulo);
        var view = new PacienteBusquedaView
        {
            DataContext = viewModel
        };

        _modulo.ContenidoActual = view;
    }

    private void CargarDepartamentos()
    {
        DepartamentosPaciente.Clear();
        DepartamentosApoderado.Clear();

        DepartamentosPaciente = new ObservableCollection<DepartamentoModel>(_departamentoRepository.ListarDepartamentoTodo());
        DepartamentosApoderado = new ObservableCollection<DepartamentoModel>(_departamentoRepository.ListarDepartamentoTodo());
    }
}