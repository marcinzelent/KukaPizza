using System;
using KukaPizza.Views;

namespace KukaPizza.Controllers
{
    public class MainController : Controller
    {
        public MainController()
        {
            new MainView(this);
        }

        public void OpenOrderPizza()
        {
            new OrderPizzaController();
        }

        public void OpenCheckOrders()
        {
            new CheckOrdersController();
        }

        public void Close()
        {
            System.Environment.Exit(0);
        }
    }
}