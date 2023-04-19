using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ViberWalkTracker.DAL.DALModels;

namespace ViberWalkTracker.DAL
{
    public class UserRepository
    {
        private UserContext _userContext;
        public UserRepository(UserContext userContext) 
        {
            _userContext = userContext;
        }

        public Task<List<UserDAL>> getAllUsers()
        {
            return _userContext.Users.ToListAsync();
        }

        public async Task AddUser(UserDAL user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task UpdateUser()
        {
            await _userContext.SaveChangesAsync();
        }

    }
}
