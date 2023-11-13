using ApplicationUI.State.Authenticators;
using ApplicationUI.State.Navigators;
using ApplicationUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ApplicationUI.HostBuilders;

public static class AddViewModelsHostBuilderExtensions
{
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient(CreateHomeViewModel);
            services.AddTransient<HomeViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<ReservationDateViewModel>();

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
            services.AddSingleton<CreateViewModel<ReservationDateViewModel>>(services => () => services.GetRequiredService<ReservationDateViewModel>());
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
            services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));

            services.AddSingleton<ISimpleViewModelFactory, SimpleViewModelFactory>();

            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<ReservationDateViewModel>>();
        });

        return hostBuilder;
    }

    private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
    {
        return new HomeViewModel(
            services.GetRequiredService<LoginViewModel>()
            );
    }

    private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
    {
        return new LoginViewModel(
            services.GetRequiredService<IAuthenticator>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
    }

    private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
    {
        return new RegisterViewModel(
            services.GetRequiredService<IAuthenticator>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
    }
}