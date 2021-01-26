using DaGrasso.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaGrasso.Data.Models;

namespace DaGrasso.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.OrderId,
                    PizzaId = shoppingCartItem.Pizza.PizzaId,          
                    Amount = shoppingCartItem.Amount,                       
                    Price = shoppingCartItem.Pizza.Price
                };
                order.OrderDetails.Add(orderDetail);
                _appDbContext.OrderDetails.Add(orderDetail);              
            }
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
    }

}