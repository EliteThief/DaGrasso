using DaGrasso.Models;
using System.Collections.Generic;

namespace DaGrasso.Interfaces
{
    public interface IToppingRepository
    {
        public IEnumerable<Topping> Toppings { get; }
        public Topping GetToppingById(int toppingId);
    }
}
