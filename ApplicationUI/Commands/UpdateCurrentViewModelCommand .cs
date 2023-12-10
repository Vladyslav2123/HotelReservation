using ApplicationUI.State.Navigators;
using ApplicationUI.ViewModels;
using System;
using System.Windows.Input;

namespace ApplicationUI.Commands;

public class UpdateCurrentViewModelCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly INavigator _navigator;
    private readonly ISimpleViewModelFactory _viewModelFactory;

    public UpdateCurrentViewModelCommand(INavigator navigator, ISimpleViewModelFactory viewModelFactory)
    {
        _navigator = navigator;
        _viewModelFactory = viewModelFactory;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not ViewType)
        {
            return;
        }
        ViewType viewType = (ViewType)parameter;

        _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
    }
}