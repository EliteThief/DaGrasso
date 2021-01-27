using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaGrasso.Data.Models;
using DaGrasso.Data.Repositories;

namespace DaGrasso.Controllers
{
    public class Chef : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly PizzaRepository _pizzaRepository;

        public Chef()
        {
                
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
