using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.Models
{
    public class EventSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string eventId { get; set; }
        public string eventName { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public DateTime eventStart { get; set; }
        public string location { get; set; }
        public double ticketPrice { get; set; }
        public int availableTickets { get; set; }
        public string image { get; set; }
        public string organizer { get; set; }

        public EventSchema()
        {
            eventId = ObjectId.GenerateNewId().ToString();
        }
        

    }
}
