﻿using ApplicationUI.Commands;
using ApplicationUI.State.Authenticators;
using ApplicationUI.State.Navigators;
using System.Windows.Input;

namespace ApplicationUI.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string email = "test@test.com";
    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(CanLogin));
        }
    }

    private string _password;
    public string Password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(CanLogin));
        }
    }

    public bool CanLogin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

    public MessageViewModel ErrorMessageViewModel { get; }

    public string ErrorMessage
    {
        set => ErrorMessageViewModel.Message = value;
    }

    public ICommand LoginCommand { get; }
    public ICommand ViewRegisterCommand { get; }

    public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator)
    {
        ErrorMessageViewModel = new MessageViewModel();

        LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
        ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
    }

    public override void Dispose()
    {
        ErrorMessageViewModel.Dispose();

        base.Dispose();
    }
}