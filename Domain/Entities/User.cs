using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : IEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; } // Ім'я клієнта
    public string Email { get; set; } // Електронна пошта
    public string Phone { get; set; } // Телефон
    public string PasswordHash { get; set; }
    public DateTime DatedJoined { get; set; }
}