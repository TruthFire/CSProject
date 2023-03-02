using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public interface IDbConnection
    {   
        
        IMongoCollection<EventSchema> EventCollection{ get; }
        string EventsCollectionName { get; }
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<TicketSchema> TicketCollection{ get; }
    }
}
