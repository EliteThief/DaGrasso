using DaGrasso.Interfaces;
using DaGrasso.Models;
using System.Collections.Generic;
using System.Linq;


namespace DaGrasso.Data.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly DagrassoContext _appDbContext;
        public ToppingRepository(DagrassoContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Topping> Toppings => _appDbContext.Toppings;

        public Topping GetToppingById(int toppingId) => _appDbContext.Toppings.FirstOrDefault(t => t.ToppingId == toppingId);

    }
}
