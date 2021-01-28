using DaGrasso.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaGrasso.Data.ViewModel
{
    public class PizzaViewModel
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public virtual ICollection<Topping> Toppings { get; set; }
    }
}
