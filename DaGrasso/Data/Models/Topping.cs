using System.Collections.Generic;

namespace DaGrasso.Models
{
    public class Topping
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }

        public virtual List<PizzaToppings> Pizzas { get; set; } = new List<PizzaToppings>();
    }
}
