using System.Collections.Generic;

namespace DaGrasso.Interfaces
{
    public interface IPizzaRepository
    {
        public IEnumerable<Pizza> Pizzas { get; }

        bool AddPizza(Pizza pizza);
    }
}
