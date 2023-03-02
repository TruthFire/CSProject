using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public interface IEventData
    {
        Task CreateEvent(EventSchema eventData);
        Task<EventSchema> GetEventById(string id);
        Task<List<EventSchema>> GetNEvents(int n);
        Task<bool> DeleteEventAsync (string id);
        Task UpdateEvent(EventSchema eventData);
    }
}
