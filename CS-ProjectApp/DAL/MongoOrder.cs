using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public class MongoOrder : IOrder
    {
        private readonly IMongoCollection<OrderSchema> _orders;
        public MongoOrder(IDbConnection db)
        {
            _orders = db.OrderCollection;
        }

        public Task createOrder(OrderSchema order)
        {
            return _orders.InsertOneAsync(order);
        }

        public Task<bool> DeleteOrderAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderSchema> GetOrderById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(OrderSchema order)
        {
            throw new NotImplementedException();
        }
    }
}
