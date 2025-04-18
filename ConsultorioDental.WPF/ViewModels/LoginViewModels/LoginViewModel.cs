﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.Views.MainViews;
using System.Security;
using System.Windows;
using ConsultorioDental.WPF.Repositories.Usuario;

namespace ConsultorioDental.WPF.ViewModels.LoginViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string? userName;
    partial void OnUserNameChanged(string? value) =>
            LoginCommand.NotifyCanExecuteChanged();
    
    [ObservableProperty]
    private SecureString? password;
    partial void OnPasswordChanged(SecureString? value) =>
        LoginCommand.NotifyCanExecuteChanged();

    private IUsuarioRepository _usuarioRepository;
    // Constructor con inyección de dependencias
    public LoginViewModel(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private void Login()
    {
        var isValidUser = _usuarioRepository.IniciarSesion(UserName, Password);
        MainView? mainView = new MainView();
        mainView.Show();
        Application.Current.Windows[0]?.Close();
    }

    private bool CanLogin()
    {
        return !string.IsNullOrWhiteSpace(UserName) && Password?.Length > 0;
    }
}