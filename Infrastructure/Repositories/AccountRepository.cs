using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    private readonly ApplicationDbContextFactory contextFactory;

    public AccountRepository(ApplicationDbContextFactory factory) : base(factory)
    {
        contextFactory = factory;
    }

    public async Task<Account> GetByEmail(string email)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            return await context.Accounts
                .Include(a => a.AccountHolder)
                .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
        }
    }

    public async Task<Account> GetByUsername(string username)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            return await context.Accounts
                .Include(a => a.AccountHolder)
                .FirstOrDefaultAsync(a => a.AccountHolder.FirstName == username);
        }
    }
}