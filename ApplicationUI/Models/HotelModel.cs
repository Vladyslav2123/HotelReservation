using System.Collections.Generic;

namespace ApplicationUI.Models;

public class HotelModel
{
    private readonly ReservationBookModel reservationBook;

    public string Name { get; set; }

    public HotelModel(string name)
    {
        this.reservationBook = new ReservationBookModel();
        Name = name;
    }

    public IEnumerable<ReservationModel> GetReservationForUser(string userName)
    {
        return reservationBook.GetReservationForUser(userName);
    }


    public void MakeReservation(ReservationModel reservation)
    {
        reservationBook.AddReservation(reservation);
    }
}