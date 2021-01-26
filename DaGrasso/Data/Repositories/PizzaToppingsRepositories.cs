using DaGrasso.Interfaces;
using System.Collections.Generic;

namespace DaGrasso.Data.Repositories
{
    public class PizzaToppingsRepositories : IPizzaToppingRepository
    {
        private readonly AppDbContext _appDbContext;

        public PizzaToppingsRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<PizzaToppings> PizzasToppings => _appDbContext.PizzaToppings;
    }
}
