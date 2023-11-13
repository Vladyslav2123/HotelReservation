using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApplicationUI.HostBuilders;

public static class AddServicesHostBuilderExtensions
{
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
        });

        return host;
    }
}
