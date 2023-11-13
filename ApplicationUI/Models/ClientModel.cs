using Domain.Interfaces;
using System;

namespace ApplicationUI.Models;

public class ClientModel : IEntity
{
    public Guid Id { get; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}