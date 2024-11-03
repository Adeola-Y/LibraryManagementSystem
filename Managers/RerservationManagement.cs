// ReservationManager.cs
using System.Collections.Generic;

public class ReservationManager
{
    private readonly List<IReservation> reservations = new List<IReservation>();

    public void AddReservation(IReservation reservation)
    {
        reservations.Add(reservation);
    }

    public void CancelReservation(IReservation reservation)
    {
        reservation.CancelReservation();
    }

    public void CompleteReservation(IReservation reservation)
    {
        reservation.CompleteReservation();
    }

    // returns a list of active reservations

    public List<IReservation> GetActiveReservations()
    {
        List<IReservation> activeReservations = new List<IReservation>();
        foreach (var reservation in reservations)
        {
            if (reservation.Status == "Active")
            {
                activeReservations.Add(reservation);
            }
        }
        return activeReservations;
    }
    //  returns a list of reservations by a user
    public List<IReservation> GetUserReservations(User user)
    {
        List<IReservation> userReservations = new List<IReservation>();
        foreach (var reservation in reservations)
        {
            if (reservation.ReservedBy.UserId == user.UserId) //check if the reservation was made by that user
            {
                userReservations.Add(reservation);
            }
        }
        return userReservations;
    }
}

















