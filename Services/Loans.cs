using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Managers;

namespace LibraryManagementSystem.Services
{
    public class Loans
    {

        public IMedia Item { get; set; }

        public DateOnly LoanDate { get; set; }

        public UserManagement UserLoan { get; set; }

        public Loans(IMedia item, DateOnly loanDate, UserManagement userLoan)
        {
            Item = item;
            LoanDate = loanDate;
            Item.InUse = true;
            UserLoan = userLoan;
        }
        public bool ItemOverdue()
        {
            // used FromDateTime to get only the date and not the time to see if the due date for returns have been exceeded
            if (Item.InUse && DateOnly.FromDateTime(DateTime.Now) > Item.DueDate)
            {
                OverdueFine();
            }

            return false;
        }

        public decimal OverdueFine()
        {
            if (ItemOverdue())
            {
                // if overdue, the fine will be the cost of the item
                return Item.Cost;
            }

            else
            {
                return 0;
            }
        }

        public void GetDetails()
        {
            Console.WriteLine($"Details of Loan - Loaner Name: {UserLoan.Name}, Loaner Id: {UserLoan.UserId}, Loan Date: {LoanDate}, Due Date: {Item.DueDate}");
            // adds loaned items to users loan list
            UserLoan.BorrowItem(this);
            Item.GetInfo();
        }
    }
}
