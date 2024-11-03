using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Payments;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Managers
{
    public class FinePaymentManager
    {
        private readonly List<IFine> finePayments = new List<IFine>();

        public void AddPayment(IFine payment)
        {
            finePayments.Add(payment);
        }

        // polymorphism 
        public void ProccessPayments()
        {
            foreach (IFine payment in finePayments)
            {
                if (payment.ValidateFinePayment())
                {
                    Console.WriteLine($"Processing {payment.PaymentType} in {payment.PaymentCurrency}");
                    payment.ProcessPayment();
                    payment.LogFinePayment();
                }

                else
                {
                    Console.WriteLine("Payment validation failed. The payment was not processed.");
                }
            }
        }

    }
}
