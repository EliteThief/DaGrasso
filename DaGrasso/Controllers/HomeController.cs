using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DaGrasso.Data.ViewModel;
using DaGrasso.Interfaces;
using DaGrasso.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DaGrasso.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IToppingRepository _toppingRepository;
        private readonly IPizzaToppingRepository _pizzaToppingRepository;


        public HomeController(ILogger<HomeController> logger,
            IPizzaRepository pizzaRepository,
            IPizzaToppingRepository pizzaToppingRepository,
            IToppingRepository toppingRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
            _toppingRepository = toppingRepository;
            _pizzaToppingRepository = pizzaToppingRepository;
        }

        public ViewResult Index()
        {
            List<PizzaViewModel> pizzasView = new List<PizzaViewModel>();
            List<Pizza> pizzas = _pizzaRepository.Pizzas.ToList();
            List<Topping> toppings = _toppingRepository.Toppings.ToList();
            List<PizzaToppings> pizzaToppings = _pizzaToppingRepository.PizzasToppings.ToList();


            var result = pizzas.Select(pizza => new PizzaViewModel
            {
                PizzaId = pizza.PizzaId,
                Name = pizza.Name,
                ImageURL = pizza.ImageURL,
                Price = pizza.Price,
                Toppings = pizza.Toppings.Where(pt => pt.PizzaId == pizza.PizzaId)
                             .Select(pt => pt.Topping).ToList()
            }); ;

            return View(result);
        }
        [HttpPost]
        public ActionResult AddPizza(Pizza pizza)
        {
            if (ModelState.IsValid) 
            {
                bool result = _pizzaRepository.AddPizza(pizza);
                if (result) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("AddPizza","Home");
                }
                
            }
            return View();
        }
    }
}
