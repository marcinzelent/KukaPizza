using System;
using KukaPizza.Controllers;
using KukaPizza.Models;

namespace KukaPizza.Views
{
    public class OrderPizzaStep1View : View
    {
        private static OrderPizzaController _controller;
        private Pizza[] pizzas;

        public OrderPizzaStep1View(OrderPizzaController controller)
        {
            _controller = controller;
            pizzas = controller.Pizzas;
            Init(_controller);
        }

        protected override void Draw()
        {
            Console.Clear();
            Console.Write(
@"================================================================================
    Step 1. Choose base pizza
================================================================================

");

            for (int i = 0; i < pizzas.Length; i++)
            {
                Console.WriteLine($"    {i + 1}. {pizzas[i].Name} ({pizzas[i].ToppingsToString()}) - {pizzas[i].Price}");
            }

            Console.WriteLine("\n    0. Go back");
            Console.Write($"\nChoose number [0-{pizzas.Length}]: ");
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
                if (choiceInt > 0 && choiceInt < pizzas.Length + 1)
                {
                    _controller.ChooseBasePizza(choiceInt - 1);
                    NavigateTo(typeof(OrderPizzaStep2View));
                }

                Draw();
            } while (choice != "0");
        }
    }
}