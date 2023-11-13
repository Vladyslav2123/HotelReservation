﻿using ApplicationUI.HostBuilders;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace ApplicationUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = CreateHostBuilder().Build();
    }

    public static IHostBuilder CreateHostBuilder(string[] args = null!)
    {
        return Host.CreateDefaultBuilder(args)
            .AddConfiguration()
            .AddDbContext()
            .AddServices()
            .AddStores()
            .AddViewModels()
            .AddViews();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        ApplicationDbContextFactory contextFactory = _host.Services.GetRequiredService<ApplicationDbContextFactory>();
        using (ApplicationDBContext dbContext = contextFactory.CreateDbContext())
        {
            dbContext.Database.Migrate();
        }

        Window window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}