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

        Departamentos = new ObservableCollection<DepartamentoModel>();
        
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
            ProvinciaSeleccionadaApoderado = value;
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
            CargarDistritos(value.IdProvincia);
        }
    }

    [ObservableProperty]
    private ObservableCollection<DistritoModel> distritos;

    private void CargarProvinciasPaciente(int idDepartamento)
    {
        ProvinciasPaciente.Clear();

        ProvinciasPaciente = new ObservableCollection<ProvinciaModel>(_provinciaRepository.ListarProvinciaTodo(idDepartamento));
    }

    private void CargarProvinciasApoderado(int idDepartamento)
    {
        ProvinciasApoderado.Clear();
        ProvinciasApoderado = new ObservableCollection<ProvinciaModel>(_provinciaRepository.ListarProvinciaTodo(idDepartamento));
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
        Departamentos.Clear();

        Departamentos = new ObservableCollection<DepartamentoModel>(_departamentoRepository.ListarDepartamentoTodo());
    }
}
