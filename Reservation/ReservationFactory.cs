
// to create reservations based on input
using LibraryManagementSystem.Interfaces;

public class ReservationFactory
{
    // creates reservation for given user and item
    public IReservation CreateReservation(User user, IMedia item)
    {
        return new BaseReservation(user, item); // creates a base object
    }
}
