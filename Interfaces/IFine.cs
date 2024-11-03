using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces
{
    public interface IFine
    {
        string PaymentType { get; }
        string PaymentCurrency { get; }
        decimal PaymentAmount { get; }

        bool ValidateFinePayment();

        void ProcessPayment();

        void LogFinePayment();
    }
}
