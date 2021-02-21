using System;
using KukaPizza.Models;

namespace KukaPizza.Adapters
{
    public class VisaPayment : IPayment
    {
        public void Pay(double price)
        {
            Console.WriteLine($"\nPaid {price} with Visa card.");
        }
    }
}