using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Notifications
{
    public class EmailNotification : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }
}
