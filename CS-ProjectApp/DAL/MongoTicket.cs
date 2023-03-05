using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public class MongoTicket : ITicket
    { 

        private readonly IMongoCollection<TicketSchema> _tickets;


        public Task CreateTicket(TicketSchema ticket)
        {
            return _tickets.InsertOneAsync(ticket);

        }

        public Task CreateTickets(List<TicketSchema> tickets)
        {
            return _tickets.InsertManyAsync(tickets);
        }

        public async Task<bool> DeleteTicketAsync(string id)
        {
            var deletefilter = Builders<TicketSchema>.Filter.Where(e => e.ticketId == id);
            var deletionResult = await _tickets.DeleteOneAsync(deletefilter);

            return await Task.FromResult(deletionResult.DeletedCount == 1);
        }

        public async Task<TicketSchema> GetTicketById(string id)
        {
            var filter = Builders<TicketSchema>.Filter.Eq(t => t.ticketId, id);
            var result = _tickets.Find(filter).FirstOrDefault();
            return result;

        }

        public Task UpdateTicket(TicketSchema ticket)
        {
            var filter = Builders<TicketSchema>.Filter.Eq("ticketId", ticket.ticketId);

            return _tickets.ReplaceOneAsync(filter, ticket, new ReplaceOptions { IsUpsert = true });
        }

        public MongoTicket(IDbConnection db)
        {
            _tickets = db.TicketCollection;
        }
    }
}
