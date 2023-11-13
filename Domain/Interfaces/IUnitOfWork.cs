namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository User { get; }
    IHotelRepository Hotel { get; }
    IHotelRoomRepository HotelRoom { get; }
    IReservationRepository Reservation { get; }
    IAccountRepository Account { get; }

    void Save();
}