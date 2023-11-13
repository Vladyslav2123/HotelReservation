using ApplicationUI.Models;
using System;

namespace ApplicationUI.Exceptions;

public class ReservationConflictException : Exception
{
    public ReservationModel ExistingReservation { get; set; }
    public ReservationModel IncomingReservation { get; set; }



    public ReservationConflictException(string? message, Exception? innerException, ReservationModel existingReservation, ReservationModel incomingReservation) : base(message, innerException)
    {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(ReservationModel existingReservation, ReservationModel incomingReservation)
    {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(string? message, ReservationModel existingReservation, ReservationModel incomingReservation) : base(message)
    {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }
}
