
using LibraryManagementSystem.Interfaces;
using System;

public class BaseReservation : IReservation
{
    public User ReservedBy { get; private set; }
    public IMedia ReservedItem { get; private set; }
    public DateTime ReservationDate { get; private set; }
    public string Status { get; private set; }

    public BaseReservation(User reservedBy, IMedia reservedItem)
    {
        ReservedBy = reservedBy;
        ReservedItem = reservedItem;
        ReservationDate = DateTime.Now;
        Status = "active";
    }

    public virtual void CancelReservation()
    {
        Status = "canceled";
    }

    public virtual void CompleteReservation()
    {
        Status = "completed";
    }
}
