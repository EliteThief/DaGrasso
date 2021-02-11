using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaGrasso.Data.Models;

namespace DaGrasso.Data.Repositories
{
    public class ChefOrderRepository
    {
        private readonly DagrassoContext _appDbContext;

        public ChefOrderRepository(DagrassoContext appDbContext,OrderRepository orderRepository)
        {
            _appDbContext = appDbContext;
        }


    }
}
