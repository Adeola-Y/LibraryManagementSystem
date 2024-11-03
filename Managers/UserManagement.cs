using System;
using System.Collections.Generic;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Managers
{
    // handles the list of items under users account like loans and reservations
    public class UserManagement : User
    {
        // stores the loaned items to each user
        public List<Loans> LoanedItems;

        // stores the reservations for each user
        private List<IReservation> Reservations;

        //  lists for loaned items and reservations
        public UserManagement()
        {
            LoanedItems = new List<Loans>();
            Reservations = new List<IReservation>();
        }

        // adds an item to the loaned list if borrowed
        public void BorrowItem(Loans loan)
        {
            LoanedItems.Add(loan);
        }

        // removes an item from the loaned list if returned
        public void ReturnItem(Loans loan)
        {
            if (LoanedItems.Contains(loan))
            {
                LoanedItems.Remove(loan);
            }
        }

        // adds a new reservation for the user
        public void MakeReservation(IReservation reservation)
        {
            Reservations.Add(reservation);
            Console.WriteLine($"reservation made for {reservation.ReservedItem} by {Name}");
        }

        // cancels a reservation for the user.
        public void CancelReservation(IReservation reservation)
        {
            if (Reservations.Contains(reservation))
            {
                reservation.CancelReservation();
                Console.WriteLine($"reservation for {reservation.ReservedItem} canceled by {Name}");
            }
        }

        // completes a reservation for the user
        public void CompleteReservation(IReservation reservation)
        {
            if (Reservations.Contains(reservation))
            {
                reservation.CompleteReservation();
                Console.WriteLine($"reservation for {reservation.ReservedItem} completed by {Name}");
            }
        }

        // displays each loaned item for the user.
        public void DisplayLoanedItems()
        {
            Console.WriteLine($"list of loaned items from {Name}:");
            foreach (Loans item in LoanedItems)
            {
                Console.WriteLine($"{item}");
            }
        }

        //  all reservations for the user.
        public void DisplayReservations()
        {
            Console.WriteLine($"list of reservations for {Name}:");
            foreach (IReservation reservation in Reservations)
            {
                Console.WriteLine($"{reservation.ReservedItem} , Status: {reservation.Status}");
            }
        }
    }
}
