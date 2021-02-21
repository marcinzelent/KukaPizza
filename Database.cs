using System.Collections.Generic;
using System.Linq;

using KukaPizza.Models;

namespace KukaPizza
{
    public sealed class Database
    {
        private static readonly Database instance = new Database();

        static Database() { }
        private Database()
        {
            _toppings = new Topping[] {
                new Topping("ham", ToppingCategory.Meat, 1.23),
                new Topping("beef", ToppingCategory.Meat, 2.12),
                new Topping("chicken", ToppingCategory.Meat, 2.11),
                new Topping("pepperoni", ToppingCategory.Meat, 1.43),
                new Topping("mushrooms", ToppingCategory.Vegetable, 1.35),
                new Topping("corn", ToppingCategory.Vegetable, 1.76),
                new Topping("tomatoes", ToppingCategory.Vegetable, 1.99),
                new Topping("peppers", ToppingCategory.Vegetable, 1.11),
                new Topping("black olives", ToppingCategory.Vegetable, 1.22),
                new Topping("onion", ToppingCategory.Vegetable, 1.30),
                new Topping("mozzarella", ToppingCategory.Cheese, 2.42),
                new Topping("Grana Padano", ToppingCategory.Cheese, 4.23),
                new Topping("tomato sauce", ToppingCategory.Sauce, 1.25),
                new Topping("spicy tomato sauce", ToppingCategory.Sauce, 1.40),
                new Topping("BBQ sauce", ToppingCategory.Sauce, 1.50)
            };

            _pizzas = new Pizza[] {
                new Pizza("Margherita", (
                    from t in _toppings
                    where t.Name == "mozzarella"
                    || t.Name == "herbal tomato sauce"
                    select t
                ).ToList(), 20.99),
                new Pizza("Classica", (
                    from t in _toppings
                    where t.Name == "ham"
                    || t.Name == "mushrooms"
                    || t.Name == "mozzarella"
                    || t.Name == "tomato sauce"
                    select t
                ).ToList(), 32.99),
                new Pizza("Pepperoni", (
                    from t in _toppings
                    where t.Name == "pepperoni"
                    || t.Name == "mozarella"
                    || t.Name == "tomato sauce"
                    select t
                ).ToList(), 32.99),
                new Pizza("Texas", (
                    from t in _toppings
                    where t.Name == "chicken"
                    || t.Name == "corn"
                    || t.Name == "onion"
                    || t.Name == "mozzarella"
                    || t.Name == "BBQ sauce"
                    select t
                ).ToList(), 34.99),
                new Pizza("Prosciutto", (
                    from t in _toppings
                    where t.Name == "ham"
                    || t.Name == "Grana Padano"
                    || t.Name == "tomatoes"
                    || t.Name == "mozzarella"
                    || t.Name == "tomato sauce"
                    select t
                ).ToList(), 37.99),
                new Pizza("European", (
                    from t in _toppings
                    where t.Name == "beef"
                    || t.Name == "ham"
                    || t.Name == "mushrooms"
                    || t.Name == "mozzarella"
                    || t.Name == "tomato sauce"
                    select t
                ).ToList(), 34.99),
                new Pizza("Farmer", (
                    from t in _toppings
                    where t.Name == "chicken"
                    || t.Name == "onion"
                    || t.Name == "peppers"
                    || t.Name == "mushrooms"
                    || t.Name == "mozzarella"
                    || t.Name == "tomato sauce"
                    select t
                ).ToList(), 34.99),
                new Pizza("Capricciosa", (
                    from t in _toppings
                    where t.Name == "ham"
                    || t.Name == "mushrooms"
                    || t.Name == "tomatoes"
                    || t.Name == "black olives"
                    || t.Name == "mozzarella"
                    || t.Name == "tomato sauce"
                    select t
                ).ToList(), 34.99),
            };

            _orders = new List<PizzaOrder>();
        }

        public static Database Instance { get { return instance; } }

        private Topping[] _toppings;
        private Pizza[] _pizzas;
        private List<PizzaOrder> _orders;

        public Topping[] Toppings { get { return _toppings; } }
        public Pizza[] Pizzas { get { return _pizzas; } }
        public List<PizzaOrder> Orders { get { return _orders; } }
    }
}