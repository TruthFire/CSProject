using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public class MongoUserData : IUserData
    {
        private readonly IMongoCollection<UserSchema> _users;
        public MongoUserData(IDbConnection db)
        {
            _users = db.UserCollection;
        }

        public async Task<List<UserSchema>> GetUsersAsync()
        {
            // returns records if true
            var results = await _users.FindAsync(_ => true);
            return results.ToList();
        }
        public async Task<UserSchema> GetUserByIdAsync(string id)
        {
            var results = await _users.FindAsync(x => x.Id == id);
            return results.FirstOrDefault();
        }
        public async Task<UserSchema> GetUserFromAuthentication(string objectId)
        {
            var results = await _users.FindAsync(x => x.ObjectIdentifier == objectId);
            return results.FirstOrDefault();
        }

        public Task CreateUser(UserSchema user)
        {
            return _users.InsertOneAsync(user);
        }
        public Task UpdateUser(UserSchema user)
        {
            var filter = Builders<UserSchema>.Filter.Eq("Id", user.Id);
            return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }

    }
}
