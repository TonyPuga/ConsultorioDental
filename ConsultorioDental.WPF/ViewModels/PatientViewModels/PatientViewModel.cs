using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;
using ConsultorioDental.WPF.Views.PatientViews.PacienteViews;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.ViewModels.PatientViewModels;

public partial class PatientViewModel : ObservableObject
{
    [ObservableProperty]
    private UserControl contenidoActual;

    [RelayCommand]
    public void RegistroPaciente()
    {
        var viewModel = new PacienteBusquedaViewModel(this);
        var view = new PacienteBusquedaView
        {
            DataContext = viewModel
        };
        
        ContenidoActual = view;        
    }
}