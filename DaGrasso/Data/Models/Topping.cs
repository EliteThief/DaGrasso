using System.Collections.Generic;
using DaGrasso.Data.Models;

namespace DaGrasso.Models
{
    public class Topping
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }

        public List<PizzaTopping> Pizzas { get; set; }
    }
}
