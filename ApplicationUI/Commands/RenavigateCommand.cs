﻿using ApplicationUI.State.Navigators;
using System;
using System.Windows.Input;

namespace ApplicationUI.Commands;

public class RenavigateCommand : ICommand
{
    private readonly IRenavigator _renavigator;

    public RenavigateCommand(IRenavigator renavigator) => _renavigator = renavigator;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _renavigator.Renavigate();
}
