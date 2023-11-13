using ApplicationUI.Commands;
using ApplicationUI.State.Authenticators;
using ApplicationUI.State.Navigators;
using System.Windows.Input;

namespace ApplicationUI.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string lastname;
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                OnPropertyChanged(nameof(Lastname));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                OnPropertyChanged(nameof(Firstname));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
                OnPropertyChanged(nameof(CanRegister));
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
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(Firstname) &&
            !string.IsNullOrEmpty(Lastname) &&
            !string.IsNullOrEmpty(Phone) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(ConfirmPassword);

        public ICommand RegisterCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public RegisterViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator, IRenavigator loginRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);
            ViewLoginCommand = new RenavigateCommand(loginRenavigator);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
