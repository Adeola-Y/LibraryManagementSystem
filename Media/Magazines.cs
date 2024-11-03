using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Media
{
    public class Magazines : IMedia
    {
        public string Title { get; set; }
        public string Distributor { get; set; }

        public string Author { get; set; }

        public int SerialNumber { get; set; }

        public string ItemType { get; set; }

        public DateOnly DueDate { get; set; }

        public bool InUse { get; set; } = false;

        public decimal Cost { get; set; }

        private INotifier notifier;

        public Magazines(string title, string author, string distributor, int serialNumber, string itemType, DateOnly dueDate, decimal cost, INotifier notifier)
        {
            Title = title;
            Author = author;
            Distributor = distributor;
            SerialNumber = serialNumber;
            ItemType = itemType;
            DueDate = dueDate;
            Cost = cost;
            this.notifier = notifier;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Item Type: {ItemType}, Magazine Author: {Author}, Title: {Title}, Magazine Distributor: {Distributor}, Magazine Number: {SerialNumber}, Cost: {Cost}");
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
                Console.WriteLine($"The magazine, {Title} is not available for loan. It should be returned in 30 days on {DueDate}");
                notifier.Notify($"!Reminder!: The Magazine, {Title} is overdue and should have been returned by {DueDate} ");
            }

            else
            {
                Console.WriteLine($"The magazine, {Title} is available for loan.");
            }
        }
    }
}
