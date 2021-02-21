using System;
using System.Collections.Generic;
using KukaPizza.Controllers;
using KukaPizza.Models;

namespace KukaPizza.Views
{
    public class OrderPizzaStep2View : View
    {
        private static OrderPizzaController _controller;
        private Topping[] toppings;
        private List<int> selectedToppings;
        public OrderPizzaStep2View(OrderPizzaController controller)
        {
            _controller = controller;
            toppings = _controller.Toppings;
            selectedToppings = _controller.SelectedToppings;
            Init(_controller);
        }


        protected override void Draw()
        {
            Console.Clear();
            Console.Write(
@"================================================================================
    Step 2. Add extra toppings
================================================================================

");

            for (int i = 0; i < toppings.Length; i++)
            {
                Console.WriteLine($"    [{(selectedToppings.Contains(i + 1) ? 'x' : ' ')}] {i + 1}. {toppings[i].Name} - {toppings[i].Price}");
            }

            Console.WriteLine($"\n    {toppings.Length + 1}. Done\n    0. Go back");
            Console.Write($"\nChoose number [0-{toppings.Length + 1}]: ");
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

                if (choiceInt != 0 && choiceInt != toppings.Length + 1)
                    _controller.SelectTopping(choiceInt);
                else if (choiceInt == toppings.Length + 1)
                {
                    _controller.AddExtraToppings();
                    NavigateTo(typeof(OrderPizzaStep3View));
                }

                Draw();
            } while (choice != "0");
        }
    }
}