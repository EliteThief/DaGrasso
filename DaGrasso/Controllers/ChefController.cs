using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaGrasso.Data.Interfaces;
using DaGrasso.Data.Models;
using DaGrasso.Data.Repositories;
using DaGrasso.Data.ViewModel;
using DaGrasso.Interfaces;
using DaGrasso.Models;
using Microsoft.AspNetCore.Authorization;

namespace DaGrasso.Controllers
{
    [Authorize(Roles="Chef")]
    public class Chef : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly PizzaRepository _pizzaRepository;
        
        public Chef(OrderRepository orderRepository,PizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }
        [HttpGet]
        public IActionResult CreatePizza()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePizza(PizzaViewModel model,List<Topping> toppings)
        {
            if (ModelState.IsValid)
            {
                Pizza pizza = new Pizza()
                {
                    Name = model.Name,
                    Price = model.Price,
                    ImageURL = model.ImageURL,
                    Toppings = model.Toppings
                };

                var result =  _pizzaRepository.AddPizza(pizza);
                if (result)
                {
                    return RedirectToAction("Index", "Chef");
                }
                else
                {
                    
                }
            }

            return View();
        }

    }
}
