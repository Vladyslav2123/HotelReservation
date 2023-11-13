using ApplicationUI.State.Accounts;
using ApplicationUI.State.Authenticators;
using ApplicationUI.State.Navigators;
using ApplicationUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApplicationUI.HostBuilders;

public static class AddStoresHostBuilderExtensions
{
    public static IHostBuilder AddStores(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<IRenavigator, ViewModelDelegateRenavigator<ReservationDateViewModel>>();
            services.AddSingleton<IRenavigator, ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<IRenavigator, ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<IRenavigator, ViewModelDelegateRenavigator<RegisterViewModel>>();
        });

        return host;
    }
}