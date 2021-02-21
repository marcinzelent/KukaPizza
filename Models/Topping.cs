namespace KukaPizza.Models
{
    public enum ToppingCategory
    {
        Vegetable,
        Meat,
        Spice,
        Cheese,
        SeaFood,
        Sauce
    }

    public class Topping
    {
        private string _name;
        private ToppingCategory _category;
        private double _price;
        public Topping(string name, ToppingCategory category, double price)
        {
            _name = name;
            _category = category;
            _price = price;
        }

        public string Name { get { return _name; } }
        public ToppingCategory Category { get { return _category; } }
        public double Price { get { return _price; } }
    }
}