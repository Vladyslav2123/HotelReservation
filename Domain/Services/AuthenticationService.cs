using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNet.Identity;

namespace Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountRepository _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountRepository accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string email, string password)
        {
            Account storedAccount = await _accountService.GetByEmail(email);
            if (storedAccount == null)
            {
                throw new UserNotFoundException(email);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(email, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string email, string firstname, string lastname, string phone, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            Account emailAccount = await _accountService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    FirstName = firstname,
                    LastName = lastname,
                    Phone = phone,
                    PasswordHash = hashedPassword,
                    DatedJoined = DateTime.Now
                };

                Account account = new Account()
                {
                    AccountHolder = user
                };

                await _accountService.Add(account);
            }

            return result;
        }
    }
}