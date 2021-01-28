using System.Collections.Generic;
using DaGrasso.Data.Models;
using DaGrasso.Models;

namespace DaGrasso
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public ICollection<PizzaTopping> Toppings { get; set; }


    }
}
