using DaGrasso.Data.Models;

namespace DaGrasso.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
