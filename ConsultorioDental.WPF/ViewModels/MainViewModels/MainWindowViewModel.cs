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
    
    public MainWindowViewModel()
    {
        // Cargar vista por defecto
        Navigate("Dashboard");
    }

    [RelayCommand]
    private void ToggleSidebar()
    {
        IsSidebarVisible = !IsSidebarVisible;
    }

    [RelayCommand]
    private void Navigate(string module)
    {
        switch (module)
        {
            case "Dashboard":
                CurrentView = new DashboardView(); 
                break;
            case "Patients":
                CurrentView = new PatientsView(); 
                break;
            case "Appointments":
                CurrentView = new AppointmentView(); 
                break;
            case "Billing":
                CurrentView = new BillingView(); 
                break;
            default:
                CurrentView = null; 
                break;
        }
    }
}