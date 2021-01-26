﻿using Microsoft.AspNetCore.Mvc;
using DaGrasso.Data.Models;
using DaGrasso.Data.ViewModel;

namespace Pizzeria.Components
{

    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            System.Diagnostics.Debug.WriteLine(_shoppingCart.GetShoppingCartItems()+" UTKAJ JUZ");

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
    }
}