using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DaGrasso.Data.Interfaces;
using DaGrasso.Data.Models;
using DaGrasso.Data.ViewModel;
using DaGrasso.Interfaces;
using DaGrasso.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DaGrasso.Controllers
{
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Shopping Cart is empty. Add some pizzas!");
            }
            if (ModelState.IsValid) 
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thenk you for choosing our retaurant!";
            return View();
        }
    }
}
