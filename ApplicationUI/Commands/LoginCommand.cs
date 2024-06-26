﻿using ApplicationUI.State.Authenticators;
using ApplicationUI.State.Navigators;
using ApplicationUI.ViewModels;
using Domain.Exceptions;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ApplicationUI.Commands;

public class LoginCommand : AsyncCommandBase
{
    private readonly LoginViewModel _loginViewModel;
    private readonly IAuthenticator _authenticator;
    private readonly IRenavigator _renavigator;

    public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
    {
        _loginViewModel = loginViewModel;
        _authenticator = authenticator;
        _renavigator = renavigator;

        _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged!;
    }

    public override bool CanExecute(object? parameter)
    {
        return _loginViewModel.CanLogin && base.CanExecute(parameter);
    }

    public override async Task ExecuteAsync(object parameter)
    {
        _loginViewModel.SetErrorMessage = string.Empty;

        try
        {
            await _authenticator.Login(_loginViewModel.Email, _loginViewModel.Password);

            _renavigator.Renavigate();
        }
        catch (UserNotFoundException)
        {
            _loginViewModel.SetErrorMessage = "Username does not exist.";
        }
        catch (InvalidPasswordException)
        {
            _loginViewModel.SetErrorMessage = "Incorrect password.";
        }
        catch (Exception)
        {
            _loginViewModel.SetErrorMessage = "Login failed.";
        }
    }

    private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(LoginViewModel.CanLogin))
        {
            OnCanExecuteChanged();
        }
    }
}
