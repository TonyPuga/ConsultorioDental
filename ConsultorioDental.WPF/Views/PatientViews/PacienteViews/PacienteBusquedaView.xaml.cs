using ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.Views.PatientViews.PacienteViews;

public partial class PacienteBusquedaView : UserControl
{
    public PacienteBusquedaView()
    {
        InitializeComponent();
        //DataContext = new PacienteBusquedaViewModel();
        Loaded += PacienteBusquedaView_Loaded;
    }

    private void PacienteBusquedaView_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        txtApellidoPaterno.Focus();
    }
}
