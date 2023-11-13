using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories;

public class HotelRoomRepository : Repository<HotelRoom>, IHotelRoomRepository
{
    public HotelRoomRepository(ApplicationDbContextFactory factory) : base(factory)
    {
    }
}