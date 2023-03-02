﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> DeleteTicketAsync(string id)
        {
            var deletefilter = Builders<TicketSchema>.Filter.Where(e => e.ticketId == id);
            var deletionResult = await _tickets.DeleteOneAsync(deletefilter);

            return await Task.FromResult(deletionResult.DeletedCount == 1);
        }

        public Task<TicketSchema> GetTicketById(string id)
        {
            return (Task<TicketSchema>)_tickets.Find(x => x.ticketId== id).Limit(1);
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