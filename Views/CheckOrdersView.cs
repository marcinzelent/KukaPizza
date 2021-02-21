using System;
using System.Collections.Generic;
using KukaPizza.Controllers;
using KukaPizza.Models;

namespace KukaPizza.Views
{
    public class CheckOrdersView : View
    {
        private CheckOrdersController _controller;
        private List<PizzaOrder> orders;
        public CheckOrdersView(CheckOrdersController controller)
        {
            _controller = controller;
            orders = controller.Orders;
            Init(_controller);
        }

        protected override void Draw()
        {
            Console.Clear();
            Console.Write(
@"================================================================================
    Your orders
================================================================================
");
            foreach (var o in orders)
            {
                Console.WriteLine($"    Base pizza: {o.BasePizza.Name}");
                Console.WriteLine($"    Extra toppings: {o.ExtraToppingsToString()}");
                Console.WriteLine($"    Size: {o.Size}");
                Console.Write("--------------------------------------------------------------------------------");
            }

            Console.WriteLine("\n    0. Go back");
        }

        protected override void Interact()
        {
            int choice = 0;

            do
            {
                choice = Console.ReadKey(true).KeyChar;

                Draw();
            } while (choice != '0');
        }
    }
}