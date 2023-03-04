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
        public string _id { get; set; }
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
            _id = ObjectId.GenerateNewId().ToString();
        }

        public EventSchema (CreateEventForm cf)
        {
            _id = ObjectId.GenerateNewId().ToString();
            eventName = cf.EventName;
            description = cf.description;
            type = cf.type;
            eventStart = cf.eventStart;
            location = cf.location;
            ticketPrice = cf.ticketPrice;
            availableTickets = cf.availableTickets;
            image = cf.image;
            organizer = cf.organizer;
        }
        

    }
}
