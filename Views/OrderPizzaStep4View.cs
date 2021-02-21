using System;
using System.Collections.Generic;
using KukaPizza.Controllers;
using KukaPizza.Models;

namespace KukaPizza.Views
{
    public class OrderPizzaStep4View : View
    {
        private OrderPizzaController _controller;
        private PizzaOrder order;

        public OrderPizzaStep4View(OrderPizzaController controller)
        {
            _controller = controller;
            order = _controller.Order;
            Init(_controller);
        }
        protected override void Draw()
        {
            Console.Clear();
            Console.Write(
@"================================================================================
    Step 4. Confirm order
================================================================================

");
            Console.WriteLine($"    Base pizza: {order.BasePizza.Name}");
            Console.WriteLine($"    Extra toppings: {order.ExtraToppingsToString()}");
            Console.WriteLine($"    Size: {order.Size}");
            Console.WriteLine($"    Price: {order.GetPrice()}");

            Console.Write(
@"    
    Do you want to place this order?
    1. Yes, pay with Visa card
    2. Yes, pay with Mastercard card
    3. No, go back
");
            Console.Write($"\nChoose number [1-3]: ");
        }

        protected override void Interact()
        {
            string choice = "";

            do
            {
                Console.CursorVisible = true;
                choice = Console.ReadLine();
                Console.CursorVisible = false;

                if (choice == "1")
                {
                    _controller.MakePaymentWithVisa();
                }
                else if (choice == "2")
                {
                    _controller.MakePaymentWithMastercard();
                }
                else if (choice == "3")
                {
                    _controller.CancelOrder();
                    Console.WriteLine("\nOrder canceled.");
                }

                if (choice == "1" || choice == "2")
                {
                    _controller.ConfirmOrder();
                    Console.WriteLine("\nOrder successfully placed.");
                }

                Console.WriteLine("Press any key to return to the main screen...");
                Console.ReadKey();
                _controller.GoBackToMainView();


                Draw();
            } while (choice != "3");
        }
    }
}