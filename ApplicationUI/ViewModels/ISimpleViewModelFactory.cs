using ApplicationUI.State.Navigators;

namespace ApplicationUI.ViewModels;

public interface ISimpleViewModelFactory
{
    ViewModelBase CreateViewModel(ViewType viewType);
}
