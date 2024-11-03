using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Payments
{
    public class CashFinePayments : IFine
    {
        private string paymentType;

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        private string paymentCurrency;

        public string PaymentCurrency
        {
            get { return paymentCurrency; }
            set { paymentCurrency = value; }
        }

        private decimal paymentAmount;

        public decimal PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }

        public CashFinePayments(decimal cost)
        {
            PaymentType = "Cash Payment";
            PaymentCurrency = "CAD";
            PaymentAmount = cost;
        }

        public bool ValidateFinePayment()
        {
            if (paymentCurrency != "CAD")
            {
                Console.WriteLine("Fine payment was not validated. Pay in Canadian Dollars(CAD).");
                return false;
            }

            return true;
        }

        public void ProcessPayment()
        {
            Console.WriteLine($"{PaymentType} of {PaymentAmount} was successfully processed");
        }

        public void LogFinePayment()
        {
            Console.WriteLine($"Payment Type: {paymentType}, Payment Amount: {paymentAmount}, Payment Currency: {paymentCurrency}");
        }
    }
}
