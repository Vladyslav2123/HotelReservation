using ApplicationUI.Views;
using System.Collections.ObjectModel;

namespace ApplicationUI.ViewModels;

public class ReservationDateViewModel : ViewModelBase
{
    RoomView roomView;

    public ObservableCollection<RoomView> Rooms { get; set; }

    public RoomView Room
    {
        get
        {
            return roomView;
        }
        set
        {
            roomView = value;
            OnPropertyChanged(nameof(Room));
        }
    }

    public ReservationDateViewModel()
    {
        roomView = new RoomView();
        Rooms = new ObservableCollection<RoomView>
        {
            roomView,
        };
    }
}
