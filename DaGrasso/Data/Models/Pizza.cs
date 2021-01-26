using System.Collections.Generic;

namespace DaGrasso
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public virtual ICollection<PizzaToppings> Toppings { get; set; } = new List<PizzaToppings>();


    }
}
