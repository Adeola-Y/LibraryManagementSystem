using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Media
{
    public class DVD : IMedia
    {
        public string ProducerName { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public int SerialNumber { get; set; }

        public string ItemType { get; set; }

        public DateOnly DueDate { get; set; }

        public bool InUse { get; set; } = false;

        public decimal Cost { get; set; }

        private INotifier notifier;

        public DVD(string producerName, string title, string genre, int serialNumber, string itemType, DateOnly dueDate, decimal cost, INotifier notifier)
        {
            ProducerName = producerName;
            Title = title;
            Genre = genre;
            SerialNumber = serialNumber;
            ItemType = itemType;
            DueDate = dueDate;
            Cost = cost;
            this.notifier = notifier;
        }


        public void GetInfo()
        {
            Console.WriteLine($"Item Type: {ItemType}, Producer: {ProducerName}, Book Title: {Title}, Book Genre: {Genre}, Book Identification Number: {SerialNumber}, Cost: {Cost}");
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
                notifier.Notify($"!Reminder!: The DVD, {Title} is overdue and should have been returned by {DueDate} ");
            }

            else
            {
                Console.WriteLine($"The book, {Title} is available for loan.");
            }
        }
    }
}
