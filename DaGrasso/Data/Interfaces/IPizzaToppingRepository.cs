using System.Collections.Generic;

namespace DaGrasso.Interfaces
{
    public interface IPizzaToppingRepository
    {
        public IEnumerable<PizzaToppings> PizzasToppings { get; }
    }
}
