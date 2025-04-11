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

    public PacienteViewModel(PatientViewModel modulo, IDepartamentoRepository departamentoRepository)
    {
        _modulo = modulo;
        _departamentoRepository = departamentoRepository;

        Departamentos = new ObservableCollection<DepartamentoModel>();
        
        CargarDepartamentos();
    }

    [ObservableProperty]
    private ObservableCollection<DepartamentoModel> departamentos;

    [ObservableProperty]
    private DepartamentoModel? departamentoSeleccionado;

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
