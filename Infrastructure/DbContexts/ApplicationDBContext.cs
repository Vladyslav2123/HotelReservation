using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelRoom> HotelRooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }
}