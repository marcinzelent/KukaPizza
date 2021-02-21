using System.Collections.Generic;

namespace KukaPizza.Models
{
    public enum PizzaSize
    {
        Small,
        Medium,
        Large
    }
    public class PizzaOrder
    {
        public Pizza BasePizza { get; set; }
        public List<Topping> ExtraToppings { get; set; }
        public PizzaSize Size { get; set; }

        public string ExtraToppingsToString()
        {
            string toppings = "";

            for (int i = 0; i < ExtraToppings.Count - 1; i++)
            {
                toppings += ExtraToppings[i].Name + ", ";
            }

            toppings += ExtraToppings[ExtraToppings.Count - 1].Name;

            return toppings;
        }

        public double GetPrice()
        {
            double totalPrice = BasePizza.Price;

            foreach (var t in ExtraToppings)
            {
                totalPrice += t.Price;
            }

            return totalPrice;
        }
    }
}