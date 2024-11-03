using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces
{
    public interface IMedia
    {
        string ItemType { get; set; }

        int SerialNumber { get; set; }

        string Title { get; set; }

        DateOnly DueDate { get; set; }

        bool InUse { get; set; }

        decimal Cost { get; set; }

        void GetInfo();

        bool IsAvailable();

        bool IsOverdue();

        void Loan();

        void GetDueDate();
    }
}
