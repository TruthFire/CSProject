using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ProjectApp.DAL
{
    public interface IUserData
    {
        Task CreateUser(UserSchema user);
        Task<UserSchema> GetUserByIdAsync(string id);
        Task<UserSchema> GetUserFromAuthentication(string objectId);
        Task<List<UserSchema>> GetUsersAsync();
        Task UpdateUser(UserSchema user);
    }
}
