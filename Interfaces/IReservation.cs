using LibraryManagementSystem.Interfaces;

public interface IReservation
{
    User ReservedBy { get; }
    IMedia ReservedItem { get; }
    DateTime ReservationDate { get; }
    string Status { get; }
    void CancelReservation();
    void CompleteReservation();
}