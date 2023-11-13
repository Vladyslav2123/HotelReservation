using Domain.Entities;

namespace Domain.Services
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthenticationService
    {
        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="firstname">The user's first name.</param>
        /// <param name="lastname">The user's last name.</param>
        /// <param name="phone">The user's phone.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="confirmPassword">The user's confirmed password.</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> Register(string email, string firstname, string lastname, string phone, string password, string confirmPassword);

        /// <summary>
        /// Get an account for a user's credentials.
        /// </summary>
        /// <param name="email">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The account for the user.</returns>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task<Account> Login(string email, string password);
    }
}
