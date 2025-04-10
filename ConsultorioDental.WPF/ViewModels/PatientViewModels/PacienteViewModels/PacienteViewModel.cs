using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.Views.PatientViews.PacienteViews;

namespace ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;

public partial class PacienteViewModel
{
    private readonly PatientViewModel _modulo;

    public PacienteViewModel(PatientViewModel modulo)
    {
        _modulo = modulo;
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
}
