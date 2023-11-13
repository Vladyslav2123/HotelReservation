using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Hotel : IEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }

    public List<HotelRoom> Rooms { get; set; }
}