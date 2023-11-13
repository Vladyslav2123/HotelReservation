using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories;

public class HotelRepository : Repository<Hotel>, IHotelRepository
{
    public HotelRepository(ApplicationDbContextFactory factory) : base(factory)
    {
    }
}