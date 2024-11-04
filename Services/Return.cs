using System;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Managers;

namespace LibraryManagementSystem.Services
{
    public class Return
    {
        public Loans Loan { get; set; }
        public DateOnly ReturnDate { get; set; }

        public Return(Loans loan, DateOnly returnDate)
        {
            Loan = loan;
            ReturnDate = returnDate;
            ProcessReturn();
        }

        private void ProcessReturn()
        {
            // Mark the item as returned
            Loan.MarkAsReturned();

            // Remove loan from user's LoanedItems
            Loan.UserLoan.ReturnItem(Loan);

            Console.WriteLine($"Item '{Loan.Item.Title}' has been returned by {Loan.UserLoan.Name} on {ReturnDate}.");
        }
    }
}
