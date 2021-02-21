using KukaPizza.Models;

namespace KukaPizza.Adapters
{
public interface IPayment
    {
        void Pay(double price);
    }
}