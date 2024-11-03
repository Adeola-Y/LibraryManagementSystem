using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Media
{
    public class Books : IMedia
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int SerialNumber { get; set; }

        public int PageCount { get; set; }

        public string ItemType { get; set; }

        public DateOnly DueDate { get; set; }

        public bool InUse { get; set; } = false;

        public decimal Cost { get; set; }

        private INotifier notifier;


        public Books(string authorName, string title, string genre, int serialNumber, int pageCount, DateOnly dueDate, string itemType, decimal cost, INotifier notifier)
        {
            AuthorName = authorName;
            Title = title;
            Genre = genre;
            SerialNumber = serialNumber;
            PageCount = pageCount;
            DueDate = dueDate;
            ItemType = itemType;
            Cost = cost;
            this.notifier = notifier;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Item Type: {ItemType}, Author: {AuthorName}, Book Title: {Title}, Book Genre: {Genre}, Book Identification Number: {SerialNumber}, Page Count of Book: {PageCount}, Cost: {Cost}");
        }

        public bool IsAvailable()
        {
            if (!InUse)
            {
                Console.WriteLine($"{Title} is available for loan.");
                return true;
            }

            else
            {
                Console.WriteLine($"{Title} is not available for loan.");
                return false;
            }
        }

        public bool IsOverdue()
        {
            return DateOnly.FromDateTime(DateTime.Now) > DueDate;
        }

        public void Loan()
        {
            if (IsAvailable())
            {
                InUse = true;
                DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(30);
                Console.WriteLine($"You loaned {Title}. It should be returned by {DueDate}");
            }

            else
            {
                Console.WriteLine($"Cannot loan {Title}, it is in use");
            }
        }



        public void GetDueDate()
        {
            if (!IsAvailable())
            {
                Console.WriteLine($"The book, {Title} is not available for loan. It should be returned in 30 days on {DueDate}");
                notifier.Notify($"!Reminder!: The book, {Title} is overdue and should have been returned by {DueDate}");
            }

            else
            {
                Console.WriteLine($"The book, {Title} is available for loan.");
            }
        }

    }
}
