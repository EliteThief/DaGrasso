using Microsoft.AspNetCore.Mvc;
using DaGrasso.Data.Models;
using DaGrasso.Data.ViewModel;
using DaGrasso.Interfaces;
using System.Linq;
using System;

namespace DaGrasso.Controllers
{
    public class ShoppingCartController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPizzaRepository pizzaRepository, ShoppingCart shoppingCart)
        {
            _pizzaRepository = pizzaRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,   
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
                
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pizzaId)
        {
            Pizza selectedPizza = _pizzaRepository.Pizzas.SingleOrDefault(p => p.PizzaId == pizzaId);
            if (selectedPizza != null)
            {
                System.Diagnostics.Debug.WriteLine(selectedPizza.Name + "SCC" );
                _shoppingCart.AddToCart(selectedPizza);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pizzaId)
        {
            var selectedPizza = _pizzaRepository.Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
            if (selectedPizza != null)
            {
                _shoppingCart.RemoveFromCart(selectedPizza);
            }
            return RedirectToAction("Index");
        }
    }
}
