using Domain.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext dbContext;

    public UnitOfWork(ApplicationDbContextFactory applicationDbContextFactory)
    {
        this.dbContext = applicationDbContextFactory.CreateDbContext();

        User = new UserRepository(applicationDbContextFactory);

        Hotel = new HotelRepository(applicationDbContextFactory);

        HotelRoom = new HotelRoomRepository(applicationDbContextFactory);

        Reservation = new ReservationRepository(applicationDbContextFactory);

        Account = new AccountRepository(applicationDbContextFactory);
    }

    public IUserRepository User { get; private set; }

    public IHotelRepository Hotel { get; private set; }

    public IHotelRoomRepository HotelRoom { get; private set; }

    public IReservationRepository Reservation { get; private set; }

    public IAccountRepository Account { get; private set; }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public void Save()
    {
        dbContext.SaveChanges();
    }
}