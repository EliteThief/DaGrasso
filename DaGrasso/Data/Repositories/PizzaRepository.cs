using DaGrasso.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DaGrasso.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext _appDbContext;
        public PizzaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pizza> Pizzas => _appDbContext.Pizzas;

        public bool AddPizza(Pizza pizza) 
        {
            if(pizza != null) 
            {
                _appDbContext.Pizzas.Add(pizza);
                _appDbContext.SaveChanges();
                return true;
                   
            }

            return false;
        }
    }

}
