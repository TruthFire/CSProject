using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.Models
{
    public class TicketSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ticketId { get; set; }
        public MongoDBRef eventInfo { get; set; }
        public DateTime orderTime { get; set; }

        public TicketSchema()
        {
            ticketId = ObjectId.GenerateNewId().ToString();
        }


    }
}
