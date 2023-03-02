

using MongoDB.Driver;

namespace CS_ProjectApp.DAL
{
    public class MongoEventData : IEventData
    {

        private readonly IMongoCollection<EventSchema> _events;

        public MongoEventData(IDbConnection db)
        {
            _events = db.EventCollection;
        }

        public Task CreateEvent(EventSchema eventData)
        {
            return _events.InsertOneAsync(eventData);
        }

        public async Task<bool> DeleteEventAsync(string id)
        {
            var deletefilter = Builders<EventSchema>.Filter.Where(e => e.eventId == id);
            var deletionResult = await _events.DeleteOneAsync(deletefilter);

            return await Task.FromResult(deletionResult.DeletedCount == 1);
        }

        public async Task<List<EventSchema>> GetNEvents(int lim)
        {
            return _events.Find(x => true).Limit(lim).ToList();

        }

        public async Task<EventSchema> GetEventById(string id)
        { 
            return (EventSchema)_events.Find(x => x.eventId == id).Limit(1);
        }

        public Task UpdateEvent(EventSchema eventData)
        {
            var filter = Builders<EventSchema>.Filter.Eq("eventId", eventData.eventId);

            return _events.ReplaceOneAsync(filter, eventData);
            throw new NotImplementedException();
        }
    }
}
