using DaGrasso.Models;

namespace DaGrasso
{
    public class PizzaToppings
    {
        public int PizzaToppingsId { get; set; }
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }
        public int ToppingId { get; set; }

        public virtual Topping Topping { get; set; }
    }
}
