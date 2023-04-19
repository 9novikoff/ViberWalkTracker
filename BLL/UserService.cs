using ViberWalkTracker.DAL;
using ViberWalkTracker.DAL.DALModels;

namespace ViberWalkTracker.BLL
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsUserHasIMEI(string id)
        {
            var result = await _userRepository.getAllUsers();
            var isUserExists = result.Find(u => u.Id == id) != null;
            if (!isUserExists)
            {
                await AddUser(id, "");
                return false;
            }
            if (string.IsNullOrEmpty(result.Find(u => u.Id == id)?.IMEI))
                return false;
            return true;
        }

        public async Task ChangeUserIMEI(string id, string IMEI)
        {
            (await _userRepository.getAllUsers()).First(u => u.Id == id).IMEI = IMEI;
            await _userRepository.UpdateUser();
        }

        public async Task AddUser(string id, string IMEI)
        {
            await _userRepository.AddUser(new UserDAL() { Id = id, IMEI = IMEI });
        }

        public async Task<string> GetUserIMEI(string id)
        {
            return (await _userRepository.getAllUsers()).First(u => u.Id == id).IMEI;
        }
    }
}
