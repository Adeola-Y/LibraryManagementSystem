
// uses delegates to notify when the reservation changes.
public delegate void ReservationStatusChangedHandler(IReservation reservation); // delegate for reservation status changes

public class ReservationNotifier
{
    public event ReservationStatusChangedHandler ReservationStatusChanged; // vent  when a reservations status changes

    public void OnReservationStatusChanged(IReservation reservation)
    {
        ReservationStatusChanged?.Invoke(reservation); // invoke event if there are any subscribers
    }
}
