using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CS_ProjectApp.Models
{
    public class OrderSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string orderId { get; set; }
        public EventSchema eventInfo { get; set; }
        public List<TicketSchema> tickets { get; set; }
        public string orderedBy { get; set; }

        public OrderSchema()
        {
            orderId = ObjectId.GenerateNewId().ToString();
        }

        public void setEventInfo(EventSchema ev)
        {
            this.eventInfo = ev;
        }
    }
}
