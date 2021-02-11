using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DaGrasso.Data.ViewModel;
using DaGrasso.Interfaces;
using DaGrasso.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DaGrasso.Controllers
{
    public class HomeController : Controller
    {
        private readonly DagrassoContext _context;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IToppingRepository _toppingRepository;


        public HomeController(ILogger<HomeController> logger,
            IPizzaRepository pizzaRepository,
            IToppingRepository toppingRepository,
            DagrassoContext context)
        {
            _pizzaRepository = pizzaRepository;
            _toppingRepository = toppingRepository;
            _context = context;
        }
        [Route("/")]
        public ViewResult Index()
        {
            List<PizzaViewModel> pizzasView = new List<PizzaViewModel>();
            List<Pizza> pizzas = _pizzaRepository.Pizzas.ToList();
            List<Topping> toppings = _toppingRepository.Toppings.ToList();


            var result = _context.Pizzas.Include(t=>t.Toppings).ToList();
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
