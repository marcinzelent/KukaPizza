using System.Collections.Generic;

namespace KukaPizza.Models
{
    public class Pizza
    {
        private string _name;
        private List<Topping> _toppings;
        private double _price;

        public Pizza(string name, List<Topping> toppings, double price)
        {
            _name = name;
            _toppings = toppings;
            _price = price;
        }

        public string Name { get { return _name; } }
        public List<Topping> Toppings { get { return _toppings; } }
        public double Price { get { return _price; } }

        public string ToppingsToString()
        {
            string toppings = "";

            for (int i = 0; i < _toppings.Count - 1; i++)
            {
                toppings += _toppings[i].Name + ", ";
            }

            toppings += _toppings[_toppings.Count - 1].Name;

            return toppings;
        }
    }
}