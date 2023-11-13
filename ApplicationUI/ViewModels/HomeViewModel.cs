namespace ApplicationUI.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public LoginViewModel LoginViewModel { get; }

    public HomeViewModel(LoginViewModel loginViewModel)
    {
        LoginViewModel = loginViewModel;
    }

    public override void Dispose()
    {
        LoginViewModel.Dispose();

        base.Dispose();
    }
}