using ApplicationUI.State.Navigators;
using System;

namespace ApplicationUI.ViewModels;

public class SimpleViewModelFactory : ISimpleViewModelFactory
{
    private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
    private readonly CreateViewModel<ReservationDateViewModel> _createResrvationViewModel;
    private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;


    public SimpleViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
        CreateViewModel<ReservationDateViewModel> createResrvationViewModel,
        CreateViewModel<LoginViewModel> createLoginViewModel)
    {
        _createHomeViewModel = createHomeViewModel;
        _createResrvationViewModel = createResrvationViewModel;
        _createLoginViewModel = createLoginViewModel;
    }

    public ViewModelBase CreateViewModel(ViewType viewType)
    {
        switch (viewType)
        {
            case ViewType.Login:
                return _createLoginViewModel();
            case ViewType.Home:
                return _createHomeViewModel();
            case ViewType.Reservation:
                return _createResrvationViewModel();
            default:
                throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
        }
    }
}