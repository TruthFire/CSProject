using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.Models
{
    public class TicketInvoiceSchema
    {
        public string ticketId { get; set; }
        public EventSchema eventInfo { get; set; }
        public DateTime orderTime { get; set; }
    }

}
