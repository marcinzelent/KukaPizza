using System;
using System.Collections.Generic;
using KukaPizza.Controllers;
using KukaPizza.Models;

namespace KukaPizza.Views
{
    public class OrderPizzaStep3View : View
    {
        private OrderPizzaController _controller;

        public OrderPizzaStep3View(OrderPizzaController controller)
        {
            _controller = controller;
            Init(_controller);
        }

        protected override void Draw()
        {
            Console.Clear();
            Console.Write(
@"================================================================================
    Step 3. Choose pizza size
================================================================================

    1. Small
    2. Medium
    3. Large

");
            Console.WriteLine($"    0. Go back");
            Console.Write($"\nChoose number [0-3]: ");
        }

        protected override void Interact()
        {
            string choice = "";

            do
            {
                Console.CursorVisible = true;
                choice = Console.ReadLine();
                Console.CursorVisible = false;
                
                if (choice == "") choice = "-1";

                int choiceInt = Int32.Parse(choice);
                if (choiceInt > 0 && choiceInt < 4)
                {
                    _controller.ChooseSize(choiceInt);
                    NavigateTo(typeof(OrderPizzaStep4View));
                }

                Draw();
            } while (choice != "0");
        }
    }
}