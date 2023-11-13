using Domain.Entities;
using System;

namespace ApplicationUI.State.Accounts;

public interface IAccountStore
{
    Account CurrentAccount { get; set; }
    event Action StateChanged;
}