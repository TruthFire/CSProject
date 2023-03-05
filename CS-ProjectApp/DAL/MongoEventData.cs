

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
            var deletefilter = Builders<EventSchema>.Filter.Where(e => e._id == id);
            var deletionResult = await _events.DeleteOneAsync(deletefilter);

            return await Task.FromResult(deletionResult.DeletedCount == 1);
        }

        public async Task<List<EventSchema>> GetNEvents(int lim)
        {
            return _events.Find(x => true).Limit(lim).ToList();

        }

        public async Task<EventSchema> GetEventById(string id)
        {

            var filter = Builders<EventSchema>.Filter.Eq("_id", id);


            return (EventSchema)_events.Find(filter).Limit(1).ToList().ElementAt(0);
        }

        public Task UpdateEvent(EventSchema eventData)
        {
            var filter = Builders<EventSchema>.Filter.Eq("eventId", eventData._id);

            return _events.ReplaceOneAsync(filter, eventData, new ReplaceOptions { IsUpsert = true });
        }

        public async Task DecreaseTickets(string eventId, int amount)
        {
            var filter = Builders<EventSchema>.Filter.Eq("_id", eventId);
            var update = Builders<EventSchema>.Update.Inc("availableTickets", amount *-1);

            var tmp = _events.FindOneAndUpdateAsync(filter, update).Result;

            Console.WriteLine(tmp);
;
         
        }
    }
}
