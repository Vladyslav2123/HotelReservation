using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Reservation : IEntity // Бронювання
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid AccountId { get; } //посилання на клієнта
    public Guid HotelRoomId { get; } //посилання на номер

    public DateTime CheckInDate { get; } //Дата початку бронювання
    public DateTime CheckOutDate { get; } //Дата завершення бронювання

    [ForeignKey("AccountID")]
    public virtual required Account Account { get; set; }

    [ForeignKey("HotelRoomID")]
    public virtual required HotelRoom HotelRoom { get; set; }
}