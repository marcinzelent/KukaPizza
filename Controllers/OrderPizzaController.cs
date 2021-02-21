using System.Collections.Generic;
using KukaPizza.Adapters;
using KukaPizza.Builders;
using KukaPizza.Models;
using KukaPizza.Views;

namespace KukaPizza.Controllers
{
    public class OrderPizzaController : Controller
    {
        private static Database db = Database.Instance;

        public Pizza[] Pizzas { get { return db.Pizzas; } }

        public Topping[] Toppings { get { return db.Toppings; } }
        private static List<int> _selectedToppings = new List<int>();
        public List<int> SelectedToppings { get { return _selectedToppings; } }

        private PizzaOrder _order;
        public PizzaOrder Order { get { return _order; } }

        private PizzaBuilder pb = new PizzaBuilder();

        public OrderPizzaController()
        {
            new OrderPizzaStep1View(this);
        }

        public void ChooseBasePizza(int number)
        {
            try
            {
                pb.ChooseBase(db.Pizzas[number]);
            }
            catch { }
        }

        public void SelectTopping(int number)
        {
            _selectedToppings.Add(number);
        }

        public void AddExtraToppings()
        {
            List<Topping> extraToppings = new List<Topping>();
            foreach (var s in _selectedToppings)
            {
                extraToppings.Add(db.Toppings[s]);
            }

            pb.AddExtraToppings(extraToppings);
        }

        public void ChooseSize(int number)
        {
            PizzaSize size;

            switch (number)
            {
                case 1:
                    size = PizzaSize.Small;
                    break;
                case 2:
                    size = PizzaSize.Medium;
                    break;
                case 3:
                    size = PizzaSize.Large;
                    break;
                default:
                    size = PizzaSize.Medium;
                    break;
            }
            pb.ChooseSize(size);

            _order = pb.GetResult();
        }

        public void MakePaymentWithVisa()
        {
            IPayment payment = new VisaPayment();
            payment.Pay(Order.GetPrice());
        }

        public void MakePaymentWithMastercard()
        {
            IPayment payment = new MasterCardPaymentAdapter();
            payment.Pay(Order.GetPrice());
        }

        public void ConfirmOrder()
        {
            _selectedToppings = new List<int>();
            db.Orders.Add(_order);
        }

        public void CancelOrder()
        {
        }

        public void GoBackToMainView()
        {
            new MainController();
        }
    }
}