using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Managers;
using LibraryManagementSystem.Services;
using System;

public class Returns : Loans
{
    public DateOnly ReturnDate { get; set; }

    public Returns(IMedia returnedItem, DateOnly returnDate, UserManagement userLoan) : base(returnedItem, DateOnly.FromDateTime(DateTime.Now), userLoan) 
    {
        ReturnDate = returnDate;
    }

    public void ReturnItem()
    {
        //checks if item is in users account first
        if(Item.InUse)
        {
            // changes it to false to indicate to returned
            Item.InUse = false; 
            // calls user mangement function to remove item from loan list
            UserLoan.ReturnItem(this);
            Console.WriteLine($"{Item.Title} has been returned. Under: {UserLoan.Name} at {ReturnDate}");
        }
        else
        {
            Console.WriteLine($"{UserLoan.Name} does not have {Item.Title} to return or it is already returned.");
        }
        
    }

}
