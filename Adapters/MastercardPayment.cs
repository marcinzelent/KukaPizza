using System;
using KukaPizza.Models;

namespace KukaPizza.Adapters
{
    public class MasterCardPayment 
    {
        public void PayWithMastercard(double price)
        {
            Console.WriteLine($"\nPaid {price} with Mastercard card.");
        }
    }
}