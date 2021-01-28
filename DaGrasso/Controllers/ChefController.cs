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
using Microsoft.EntityFrameworkCore;

namespace DaGrasso.Controllers
{
    [Authorize(Roles="Chef")]
    public class Chef : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IToppingRepository _toppingRepository;

        public Chef(AppDbContext context,IPizzaRepository pizzaRepository,IToppingRepository toppingRepository)
        {
            _context = context;
            _pizzaRepository = pizzaRepository;
            _toppingRepository = toppingRepository;
        }

        public ViewResult Index()
        {
            var result = _context.OrderDetails.Include(x => x.Pizza).Include(x => x.Order).ToList();  
            

            return View(result);
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
