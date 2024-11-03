using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Notifications
{
    public class SMSNotification : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }
    }
}
