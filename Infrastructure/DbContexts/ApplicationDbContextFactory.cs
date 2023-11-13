using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class ApplicationDbContextFactory
{
    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    public ApplicationDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
    {
        _configureDbContext = configureDbContext;
    }

    public ApplicationDBContext CreateDbContext()
    {
        DbContextOptionsBuilder<ApplicationDBContext> options = new DbContextOptionsBuilder<ApplicationDBContext>();

        _configureDbContext(options);

        return new ApplicationDBContext(options.Options);
    }
}
