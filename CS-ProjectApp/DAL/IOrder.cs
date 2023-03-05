using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public interface IOrder
    {
        Task createOrder(OrderSchema order);
        Task<OrderSchema> GetOrderById(string id);
        Task<bool> DeleteOrderAsync(string id);
        Task UpdateOrder(OrderSchema order);
        Task<List<OrderSchema>> GetUserOrders(string email);
    }
}
