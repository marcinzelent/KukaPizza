using System.Collections.Generic;
using KukaPizza.Models;
using KukaPizza.Views;

namespace KukaPizza.Controllers
{
    public class CheckOrdersController : Controller
    {
        private static Database db = Database.Instance;

        public List<PizzaOrder> Orders { get { return db.Orders; } }
        public CheckOrdersController()
        {
            new CheckOrdersView(this);
        }
    }
}