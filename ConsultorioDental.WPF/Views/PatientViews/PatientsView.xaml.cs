using ConsultorioDental.WPF.ViewModels.PatientViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.Views.PatientViews;

/// <summary>
/// Lógica de interacción para PatientsView.xaml
/// </summary>
public partial class PatientsView : UserControl
{
    public PatientsView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<PatientViewModel>();
    }
}