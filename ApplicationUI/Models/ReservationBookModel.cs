using ApplicationUI.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationUI.Models;

public class ReservationBookModel
{
    private readonly List<ReservationModel> reservationModels;

    public ReservationBookModel()
    {
        reservationModels = new List<ReservationModel>();
    }

    public IEnumerable<ReservationModel> GetReservationForUser(string userName)
    {
        return reservationModels.Where(r => r.ClientModel.FirstName == userName);
    }

    public void AddReservation(ReservationModel model)
    {
        foreach (var reservation in reservationModels)
        {
            if (reservation.Conflicts(model))
            {
                throw new ReservationConflictException(reservation, model);
            }
        }
        reservationModels.Add(model);
    }
}