using Domain.Entities;

namespace Domain.Interfaces;

public interface IAccountRepository : IRepository<Account>
{
    Task<Account> GetByUsername(string username);
    Task<Account> GetByEmail(string email);
}
