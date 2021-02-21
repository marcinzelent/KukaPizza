using System.Collections.Generic;
using KukaPizza.Models;

namespace KukaPizza.Builders
{
    public class PizzaBuilder : IPizzaBuilder
    {
        PizzaOrder _pizzaOrder = new PizzaOrder();
        public void ChooseBase(Pizza pizza)
        {
            _pizzaOrder.BasePizza = pizza;
        }

        public void AddExtraToppings(List<Topping> extraToppings)
        {
            _pizzaOrder.ExtraToppings = extraToppings;
        }

        public void ChooseSize(PizzaSize size)
        {
            _pizzaOrder.Size = size;
        }

        public PizzaOrder GetResult()
        {
            return _pizzaOrder;
        }
    }
}