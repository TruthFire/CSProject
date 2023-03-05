using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public interface ITicket
    {
        Task CreateTicket(TicketSchema ticket);
        Task CreateTickets(List<TicketSchema> tickets);
        Task<TicketSchema> GetTicketById(string id);
        Task<bool> DeleteTicketAsync(string id);
        Task UpdateTicket(TicketSchema ticket);
    }
}
