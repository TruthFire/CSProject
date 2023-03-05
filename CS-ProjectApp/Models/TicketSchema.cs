using MongoDB.Bson;

namespace CS_ProjectApp.Models
{
    public class TicketSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ticketId { get; set; }
        public EventSchema eventInfo { get; set; }
        public DateTime orderTime { get; set; }

        public TicketSchema()
        {
            ticketId = ObjectId.GenerateNewId().ToString();
            orderTime = DateTime.Now;
        }

        public void setEventInfo(EventSchema ev)
        {
            eventInfo = ev;
        }


    }
}
