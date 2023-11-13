using ApplicationUI.ViewModels;
using System;

namespace ApplicationUI.State.Navigators;

public enum ViewType
{
    Login,
    Home,
    Reservation
}

public interface INavigator
{
    ViewModelBase CurrentViewModel { get; set; }
    event Action StateChanged;
}