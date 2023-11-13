using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Account : IEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public User AccountHolder { get; set; }

    // Зв'язок з сутністю "Бронювання" (Reservation)
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}