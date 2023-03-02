using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.Models
{
    public class BaseUserSchema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public BaseUserSchema()
        {

        }

        public BaseUserSchema(UserSchema user)
        {
            Id = user.Id;
            DisplayName = user.DisplayName;
        }
    }
}
