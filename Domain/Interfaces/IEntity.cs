using System.ComponentModel.DataAnnotations;

namespace Domain.Interfaces;

public class IEntity
{
    [Key]
    public Guid Id { get; }
}