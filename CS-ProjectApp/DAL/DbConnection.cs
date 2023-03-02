using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public class DbConnection : IDbConnection
    {
        private readonly IMongoDatabase _db;
        public string DbName { get; private set; }
        public string EventsCollectionName { get; private set; } = "events";
        public string TicketCollectionName { get; private set; } = "tickets";

        public MongoClient Client { get; private set; }

        public IMongoCollection<EventSchema> EventCollection { get; private set; }
        public IMongoCollection<TicketSchema> TicketCollection { get; private set; }

        public DbConnection()
        {
            Client = new MongoClient(Environment.GetEnvironmentVariable("MongoConnString"));
            DbName = "TicketShop";
            _db = Client.GetDatabase(DbName);
            

            //Collections initialization
            EventCollection = _db.GetCollection<EventSchema>(EventsCollectionName);
            TicketCollection = _db.GetCollection<TicketSchema>(TicketCollectionName);
        }

    }
}
