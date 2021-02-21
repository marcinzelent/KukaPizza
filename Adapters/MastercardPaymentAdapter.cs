using KukaPizza.Models;

namespace KukaPizza.Adapters
{
    public class MasterCardPaymentAdapter : IPayment
    {
        private MasterCardPayment _mastercardPayment = new MasterCardPayment();
        public void Pay(double price)
        {
            _mastercardPayment.PayWithMastercard(price);
        }
    }
}