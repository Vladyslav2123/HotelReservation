using ApplicationUI.State.Accounts;
using Domain.Entities;
using Domain.Services;
using System;
using System.Threading.Tasks;

namespace ApplicationUI.State.Authenticators;

public class Authenticator : IAuthenticator
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAccountStore _accountStore;

    public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
    {
        _authenticationService = authenticationService;
        _accountStore = accountStore;
    }

    public Account CurrentAccount
    {
        get
        {
            return _accountStore.CurrentAccount;
        }
        private set
        {
            _accountStore.CurrentAccount = value;
            StateChanged?.Invoke();
        }
    }

    public bool IsLoggedIn => CurrentAccount != null;

    public event Action StateChanged;

    public async Task Login(string email, string password)
    {
        CurrentAccount = await _authenticationService.Login(email, password);
    }

    public void Logout()
    {
        CurrentAccount = null!;
    }

    public async Task<RegistrationResult> Register(string email, string firstname, string lastname, string phone, string password, string confirmPassword)
    {
        return await _authenticationService.Register(email, firstname, lastname, phone, password, confirmPassword);
    }
}