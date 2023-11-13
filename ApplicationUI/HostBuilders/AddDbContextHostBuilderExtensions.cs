using Domain.Interfaces;
using Infrastructure;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ApplicationUI.HostBuilders;

public static class AddDbContextHostBuilderExtensions
{
    public static IHostBuilder AddDbContext(this IHostBuilder host)
    {
        host.ConfigureServices((context, services) =>
        {
            string connectionString = context.Configuration.GetConnectionString("Hotel");
            Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

            services.AddDbContext<ApplicationDBContext>(configureDbContext);
            services.AddSingleton(new ApplicationDbContextFactory(configureDbContext));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        });

        return host;
    }
}
