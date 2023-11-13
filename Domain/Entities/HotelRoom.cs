using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class HotelRoom : IEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid HotelID { get; set; } // посилання на готель
    public int RoomNumber { get; set; } // Номер кімнати
    public int RoomType { get; set; } // Тип кімнати
    public double PricePerNight { get; set; } // Ціна за ніч

    [ForeignKey("HotelID")]
    public virtual Hotel Hotel { get; set; }

    public virtual List<Reservation> Reservation { get; set; }
}