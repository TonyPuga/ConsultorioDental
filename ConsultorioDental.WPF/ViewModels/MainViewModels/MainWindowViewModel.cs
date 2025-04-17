using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.Views.AppointmentViews;
using ConsultorioDental.WPF.Views.BillingViews;
using ConsultorioDental.WPF.Views.DashboardViews;
using ConsultorioDental.WPF.Views.PatientViews;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.ViewModels.MainViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isSidebarVisible = true;

    [ObservableProperty]
    private UserControl currentView;

    private readonly UserControl _dashboardView;
    private readonly UserControl _patientsView;
    private readonly UserControl _appointmentView;
    private readonly UserControl _billingView;

    // Constructor con inyección de dependencias
    public MainWindowViewModel(DashboardView dashboardView, PatientsView patientsView,
                        AppointmentView appointmentView, BillingView billingView)
    {
        _dashboardView = dashboardView;
        _patientsView = patientsView;
        _appointmentView = appointmentView;
        _billingView = billingView;

        // Cargar vista por defecto
        Navigate(Module.Dashboard);
    }

    [RelayCommand]
    private void ToggleSidebar()
    {
        IsSidebarVisible = !IsSidebarVisible;
    }

    [RelayCommand]
    private void Navigate(Module module)
    {
        switch (module)
        {
            case Module.Dashboard:
                CurrentView = _dashboardView;
                break;
            case Module.Patients:
                CurrentView = _patientsView;
                break;
            case Module.Appointments:
                CurrentView = _appointmentView;
                break;
            case Module.Billing:
                CurrentView = _billingView;
                break;
            default:
                CurrentView = null; 
                break;
        }
    }
}

public enum Module
{
    Dashboard,
    Patients,
    Appointments,
    Billing
}