using ApplicationUI.State.Authenticators;
using ApplicationUI.State.Navigators;
using ApplicationUI.ViewModels;
using Domain.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ApplicationUI.Commands;

public class RegisterCommand : AsyncCommandBase
{
    private readonly RegisterViewModel _registerViewModel;
    private readonly IAuthenticator _authenticator;
    private readonly IRenavigator _registerRenavigator;

    public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
    {
        _registerViewModel = registerViewModel;
        _authenticator = authenticator;
        _registerRenavigator = registerRenavigator;

        _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
    }

    public override bool CanExecute(object parameter)
    {
        return _registerViewModel.CanRegister && base.CanExecute(parameter);
    }

    public override async Task ExecuteAsync(object parameter)
    {
        _registerViewModel.ErrorMessage = string.Empty;

        try
        {
            RegistrationResult registrationResult = await _authenticator.Register(
                   _registerViewModel.Email,
                   _registerViewModel.Firstname,
                   _registerViewModel.Lastname,
                   _registerViewModel.Phone,
                   _registerViewModel.Password,
                   _registerViewModel.ConfirmPassword);

            switch (registrationResult)
            {
                case RegistrationResult.Success:
                    _registerRenavigator.Renavigate();
                    break;
                case RegistrationResult.PasswordsDoNotMatch:
                    _registerViewModel.ErrorMessage = "Password does not match confirm password.";
                    break;
                case RegistrationResult.EmailAlreadyExists:
                    _registerViewModel.ErrorMessage = "An account for this email already exists.";
                    break;
                case RegistrationResult.UsernameAlreadyExists:
                    _registerViewModel.ErrorMessage = "An account for this username already exists.";
                    break;
                default:
                    _registerViewModel.ErrorMessage = "Registration failed.";
                    break;
            }
        }
        catch (Exception)
        {
            _registerViewModel.ErrorMessage = "Registration failed.";
        }
    }

    private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
        {
            OnCanExecuteChanged();
        }
    }
}