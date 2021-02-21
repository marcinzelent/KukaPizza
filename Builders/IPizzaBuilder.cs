using System.Collections.Generic;
using KukaPizza.Models;

namespace KukaPizza.Builders
{
    public interface IPizzaBuilder
    {
        void ChooseBase(Pizza pizza);
        void AddExtraToppings(List<Topping> extraToppings);
        void ChooseSize(PizzaSize size);
    }
}